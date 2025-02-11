using AssetAPI.Repository;
using DataService.Model;

namespace AssetAPI.Extraction
{
    internal class AssetService
    {
        private List<MachineAssetSeries> _assetMachineData;
        private AssetMachineRepository _repository;

        public AssetService()
        {
            _repository = new AssetMachineRepository();
            _assetMachineData = _repository.GetAll();
        }
        public List<AssetData> GetAllAssets()
        {
            var assets = _assetMachineData
            .GroupBy(a => new { a.AssetName, a.AssetSeries })
            .Select(g => new AssetData
            {
                Name = g.Key.AssetName,
                Series = g.Key.AssetSeries,
                Machines = g.Select(a => a.MachineModel).Distinct().ToList()
            })
            .ToList();
            return assets;
        }
        public List<AssetSummary> GetLatestAssets()
        {
            return _assetMachineData!.GetLatestAssets();
        }
        public List<AssetSummary> GetAssetByMachineModel(string machineModel)
        {
            var assets = _assetMachineData
                .Where(machine => machine.MachineModel == machineModel)
                .Select (data => new AssetSummary
                {
                    Name = data.AssetName,
                    Series = data.AssetSeries
                }).ToList();
            return assets ;
        }
    }
}
