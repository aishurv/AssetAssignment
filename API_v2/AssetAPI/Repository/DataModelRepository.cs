using DataService.Model;
using DataService.MongoDB;
using MongoDB.Driver;

namespace AssetAPI.Repository
{
    public class DataModelRepository
    {
        private readonly IMongoCollection<DataModel>? _data;
        public DataModelRepository()
        {
            _data = DbContext.Database?.GetCollection<DataModel>("asset");
        }
        public List<DataModel> GetAll()
        {
            return _data.Find(FilterDefinition<DataModel>.Empty).ToList();
        }
        public async Task AddDataList(List<DataModel> data)
        {
            await _data!.InsertManyAsync(data);
        }
    }
}
