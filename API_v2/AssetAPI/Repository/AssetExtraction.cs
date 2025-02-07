using DataService.Model;

namespace AssetAPI.Repository
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
            .GroupBy(a => new { a.AssetName, a.AssetSeries }) // Group by both Name & Series
            .Select(g => new AssetData
            {
                Name = g.Key.AssetName,
                Series = g.Key.AssetSeries,
                Machines = g.Select(a => a.MachineModel).Distinct().ToList()
            })
            .OrderBy(a => a.Name) // Optional: Order alphabetically
            .ThenBy(a => int.Parse(a.Series[1..])) // Order numerically by Series
            .ToList();
            return assets ?? [];
        }

    }
}
