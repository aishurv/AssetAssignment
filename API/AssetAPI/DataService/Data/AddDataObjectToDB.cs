using DataService.MongoDB;

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

        public async Task AddAssets()
        {
            await _assetRepository.AddAssets(txtToDataObject.Assets);
        }
        public async Task AddMachineData()
        {
            await _machineRepository.AddMachinesData(txtToDataObject.Machines);
        }
    }
}
