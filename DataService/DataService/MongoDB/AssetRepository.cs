//using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using DataService.Model;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MongoDB.Driver;

namespace DataService.MongoDB
{
    public class AssetRepository
    {
        private readonly DBService _DbService = new();
        private readonly IMongoCollection<AssetData>? _assetData;
        
        public AssetRepository()
        {
            _assetData = _DbService.Database?.GetCollection<AssetData>("asset");
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
