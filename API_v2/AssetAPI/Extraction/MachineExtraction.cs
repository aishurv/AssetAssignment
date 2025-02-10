using AssetAPI.Repository;
using DataService.Model;
namespace AssetAPI.Extraction
{
    public class MachineExtraction
    {
        private List<DataModel>? _assetMachineData;
        private DataModelRepository _repository;

        public MachineExtraction()
        {
            _repository = new DataModelRepository();
            _assetMachineData = _repository.GetAll();
        }

        public List<MachineData> GetAllMachines()
        {
            var machineData = _assetMachineData!
            .GroupBy(a => a.MachineModel)
            .Select(g => new MachineData
            {
                ModelName = g.Key,
                assets = g.Select(a => new AssetSummary
                {
                    Name = a.AssetName,
                    Series = a.AssetSeries
                }).ToList()
            })
            .ToList();
            return machineData ?? [];
        }
        public MachineData GetMachineById(string id)
        {
            var machine = _assetMachineData!
            .Where(a => a.MachineModel == id)
            .GroupBy(a => a.MachineModel)
            .Select(g => new MachineData
            {
                ModelName = g.Key,
                assets = g.Select(a => new AssetSummary
                {
                    Name = a.AssetName,
                    Series = a.AssetSeries
                }).ToList()
            });
            MachineData Machine = new MachineData
            {
                ModelName = id,
                assets = machine.First().assets
            };

            return Machine;
        }
        public List<string> GetMachineModelsByAssetName(string assetName)
        {
            var machineModels = _assetMachineData!
            .Where(a => a.AssetName == assetName)
            .Select(a => a.MachineModel)
            .ToList();
            return machineModels ?? [];
        }

        public List<string> GetMachineWithLatestAssets()
        {
            var latestAssetSeries = _assetMachineData?.GetLatestAssets();
            
            var MachineWithLatestAssets = _assetMachineData?
            .GroupBy(a => a.MachineModel)
            .ToDictionary(
                g => g.Key,
                g => g.Select(d => new AssetSummary
                {
                    Name = d.AssetName,
                    Series = d.AssetSeries
                }).ToList())
            .Where(machine => machine.Value.All(asset =>
                latestAssetSeries!.Any(latest => latest.Name == asset.Name && latest.Series == asset.Series)))
            .Select(g => g.Key)
            .ToList();
            return MachineWithLatestAssets ?? ["Not Found !"];
        }

    }
}
