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
            throw new NotImplementedException();
        }
        public List<AssetData> GetAssetByMachineModel(string machineModel)
        {
            throw new NotImplementedException();
        }
        public Dictionary<string, string> GetLatestAssets()
        {
            throw new NotImplementedException();
        }

    }
}
