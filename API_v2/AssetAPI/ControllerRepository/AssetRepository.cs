using AssetAPI.Extraction;
using DataService.Model;
using DataService.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AssetAPI.Repository
{
    public class AssetRepository
    {
        private AssetExtraction _extraction;

        public AssetRepository()
        {
            _extraction = new AssetExtraction();
        }
        public List<AssetData> GetAll()
        {
            return _extraction.GetAllAssets(); 
        }
        public List<AssetSummary> GetAssetByMachineModel(string machineModel)
        {
            return _extraction.GetAssetByMachineModel(machineModel);
        }
        public List<AssetSummary> GetLatestAssets()
        {
            return _extraction.GetLatestAssets();
        }

    }
}
