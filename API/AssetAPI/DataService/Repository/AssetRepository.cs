using DataService.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataService.MongoDB
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
        public Task<List<AssetData>> GetAll()
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
        }
        public async Task AddAssets(List<AssetData> assets)
        {
            foreach (var asset in assets)
            {
                await AddAsset(asset);
            }
        }
        public Dictionary<string,string> GetLatestAssets()
        {
            return _latestAssetSeriesRepository.GetLatestSeries();
        }
        public async Task DeleteAll()
        {
            await _assetData!.DeleteManyAsync(FilterDefinition<AssetData>.Empty);
        }

    }
}
