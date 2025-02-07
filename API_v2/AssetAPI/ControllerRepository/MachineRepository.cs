using DataService.Model;
using DataService.MongoDB;
using MongoDB.Driver;
namespace AssetAPI.Repository
{

    public class MachineRepository
    {
        private MachineExtraction _extraction;

        public MachineRepository()
        {
            _extraction = new MachineExtraction();
        }
        public  List<MachineData> GetAll()
        {
            return _extraction.GetAllMachines();
        }
        public MachineData GetById(string id)
        {
            return _extraction.GetMachineById(id);
        }
        public List<string> GetMachineModelByAssetName(string assetName)
        {
            return _extraction.GetMachineModelsByAssetName(assetName);
        }
        public List<string> MachineWithLatestAssetSeries()
        {
            return _extraction.GetMachineWithLatestAssets();
        }

    }
}
