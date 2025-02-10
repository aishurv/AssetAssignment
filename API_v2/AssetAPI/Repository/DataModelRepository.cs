using DataService.Model;
using DataService.MongoDB;
using MongoDB.Driver;

namespace AssetAPI.Repository
{
    public class DataModelRepository
    {
        private readonly IMongoCollection<DataModel>? _assetMachineList;
        public DataModelRepository()
        {
            _assetMachineList = DbContext.Database?.GetCollection<DataModel>("asset_machine_map");
        }
        public List<DataModel> GetAll()
        {
            return _assetMachineList.Find(FilterDefinition<DataModel>.Empty).ToList();
        }
        public async Task AddDataList(List<DataModel> data)
        {
            foreach (var entry in data)
            {
                await AddData(entry);
            }
        }
        public async Task AddData(DataModel obj)
        {
            var filter = Builders<DataModel>.Filter.Eq("_id", obj._id);
            var data = await _assetMachineList.Find(filter).FirstOrDefaultAsync();
            if (data==null)
            {
                await _assetMachineList!.InsertOneAsync(obj);
            }
        }
    }
}
