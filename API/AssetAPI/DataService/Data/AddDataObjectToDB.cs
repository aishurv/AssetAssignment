using AssetAPI.Repository;
using DataService.Model;

namespace DataService.Data
{
    public class AddDataObjectToDB
    {
        private readonly AssetRepository _assetRepository;
        private readonly MachineRepository _machineRepository;
        public AddDataObjectToDB()
        {
            _assetRepository = new AssetRepository();
            _machineRepository = new MachineRepository();
        }

        public async Task AddAssets( List<AssetData> Assets)
        {
            await _assetRepository.AddAssets(Assets);
        }
        public async Task AddMachineData(List<MachineData> Machines)
        {
            await _machineRepository.AddMachinesData(Machines);
        }
    }
}
