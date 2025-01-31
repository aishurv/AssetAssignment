using DataService.Model;
using MongoDB.Driver;

namespace DataService.MongoDB
{
    public class AssetRepository
    {
        private readonly IMongoCollection<AssetData>? _assetData;
        
        public AssetRepository()
        {
            _assetData = DbContext.Database?.GetCollection<AssetData>("asset");
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



    }
}
