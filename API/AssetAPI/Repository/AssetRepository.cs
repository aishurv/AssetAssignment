using DataService.Model;
using DataService.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AssetAPI.Repository
{
    public class AssetRepository
    {
        private readonly IMongoCollection<AssetData>? _assetData;
        private readonly LatestAssetSeriesRepository _latestAssetSeriesRepository;

        public AssetRepository()
        {
            _assetData = DbContext.Database?.GetCollection<AssetData>("asset");
            _latestAssetSeriesRepository = new LatestAssetSeriesRepository();
        }
        public Task<List<AssetData>?> GetAll()
        {
            return _assetData.Find(FilterDefinition<AssetData>.Empty).ToListAsync();
        }
        public List<AssetData> GetAssetByMachineModel(string machineModel)
        {
            var assets = _assetData.Find(FilterDefinition<AssetData>.Empty).ToList();

            return assets.Where(a => a.Machines.Contains(machineModel)).ToList();
        }
        public async Task AddAsset(AssetData asset)
        {
            var filter = Builders<AssetData>.Filter.Eq("_id", asset.Id);
            var data = await _assetData.Find(filter).FirstOrDefaultAsync();
            if (data == null)
            {
                await _assetData!.InsertOneAsync(asset);
                _latestAssetSeriesRepository.Insert(asset.Name!, asset.Series!);
            }
            else
            {
                await UpdateMachinesByIdAsync(asset.Id!, asset);
            }
        }
        public async Task AddAssets(List<AssetData> assets)
        {
            foreach (var asset in assets)
            {
                await AddAsset(asset);
            }
        }
        public Dictionary<string, string> GetLatestAssets()
        {
            return _latestAssetSeriesRepository.GetLatestSeries();
        }

        public AssetData GetAssetByNameAsync(string name)
        {
            AssetData? assetData = _assetData.Find(_ => _.Name == name).FirstOrDefault();
            return assetData == null ?
                throw new Exception($"There is no asset found for name ={name}")
            : assetData;
        }
        public async Task DeleteAll()
        {
            await _assetData!.DeleteManyAsync(FilterDefinition<AssetData>.Empty);
        }
        public async Task<bool> UpdateMachinesByIdAsync(string id, AssetData updatedAsset)
        {
            var filter = Builders<AssetData>.Filter.Eq(a => a.Id, id);
            var update = Builders<AssetData>.Update
                .Set(a => a.Machines, updatedAsset.Machines);

            var result = await _assetData!.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

    }
}
