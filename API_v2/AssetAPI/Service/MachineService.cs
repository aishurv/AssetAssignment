using AssetAPI.Repository;
using DataService.Model;
namespace AssetAPI.Extraction
{
    internal class MachineService
    {
        private List<MachineAssetSeries> _assetMachineData;
        private AssetMachineRepository _repository;

        public MachineService()
        {
            _repository = new AssetMachineRepository();
            _assetMachineData = _repository.GetAll();
        }

        public List<MachineData> GetAllMachines()
        {
            var machineData = _assetMachineData
            .GroupBy(a => a.MachineModel)
            .Select(g => new MachineData
            {
                ModelName = g.Key,
                Assets = g.Select(a => new AssetSummary
                {
                    Name = a.AssetName,
                    Series = a.AssetSeries
                }).ToList()
            })
            .ToList();
            return machineData ;
        }
        public MachineData GetMachineById(string id)
        {
            var assets = _assetMachineData
            .Where(a => a.MachineModel == id)
            .Select(a => new AssetSummary
            {
                Name = a.AssetName,
                Series = a.AssetSeries
            }).ToList();
            MachineData Machine = new MachineData
            {
                ModelName = id,
                Assets = assets  
            };

            return Machine;
        }
        public List<string> GetMachineModelsByAssetName(string assetName)
        {
            var machineModels = _assetMachineData
            .Where(a => a.AssetName == assetName)
            .Select(a => a.MachineModel)
            .ToList();
            return machineModels ;
        }

        public List<string> GetMachineWithLatestAssets()
        {
            var latestAssetSeries = _assetMachineData?.GetLatestAssets();
            
            var MachineWithLatestAssets = _assetMachineData
            .GroupBy(a => a.MachineModel)
            .ToDictionary(
                g => g.Key,
                g => g.Select(d => new AssetSummary
                {
                    Name = d.AssetName,
                    Series = d.AssetSeries
                }).ToList())
            .Where(machine => machine.Value.All(asset =>latestAssetSeries!.Contains(asset)))
            .Select(g => g.Key)
            .ToList();
            return MachineWithLatestAssets ;
        }

    }
}
