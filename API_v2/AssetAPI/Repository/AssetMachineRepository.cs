using DataService.Model;
using DataService.MongoDB;
using MongoDB.Driver;

namespace AssetAPI.Repository
{
    internal class AssetMachineRepository
    {
        private readonly IMongoCollection<MachineAssetSeries> _assetMachineList;
        public AssetMachineRepository()
        {
            _assetMachineList = DbContext.Database.GetCollection<MachineAssetSeries>("asset_machine_map");
        }
        public  List<MachineAssetSeries>  GetAll()
        {
            return _assetMachineList.Find(FilterDefinition<MachineAssetSeries>.Empty).ToList();
        }
        public async Task AddDataListAsync(List<MachineAssetSeries> data)
        {
            foreach (var entry in data)
            {
                await AddDataAsync(entry);
            }
        }
        public async Task AddDataAsync(MachineAssetSeries obj)
        {
            var filter = Builders<MachineAssetSeries>.Filter.Eq("_id", obj._id);
            var data = await _assetMachineList.Find(filter).FirstOrDefaultAsync();
            if (data==null)
            {
                await _assetMachineList.InsertOneAsync(obj);
            }
        }
    }
}
