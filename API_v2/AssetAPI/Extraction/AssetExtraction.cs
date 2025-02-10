using AssetAPI.Repository;
using DataService.Model;

namespace AssetAPI.Extraction
{
    public class AssetExtraction
    {
        private List<DataModel>? _assetMachineData;
        private DataModelRepository _repository;

        public AssetExtraction()
        {
            _repository = new DataModelRepository();
            _assetMachineData = _repository.GetAll();
        }
        public List<AssetData> GetAllAssets()
        {
            var assets = _assetMachineData?
            .GroupBy(a => new { a.AssetName, a.AssetSeries })
            .Select(g => new AssetData
            {
                Name = g.Key.AssetName,
                Series = g.Key.AssetSeries,
                Machines = g.Select(a => a.MachineModel).Distinct().ToList()
            })
            .ToList();
            return assets ?? [];
        }
        public List<AssetSummary> GetLatestAssets()
        {
            return _assetMachineData!.GetLatestAssets();
        }
        public List<AssetSummary> GetAssetByMachineModel(string machineModel)
        {
            var assets = _assetMachineData?
                .Where(machine => machine.MachineModel == machineModel)
                .Select (ad => new AssetSummary
                {
                    Name = ad.AssetName,
                    Series = ad.AssetSeries
                }).ToList();
            return assets ?? [];
        }
    }
}
