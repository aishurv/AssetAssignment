using DataService.Model;
namespace AssetAPI.Repository
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
        public Dictionary<string,string> GetLatestAssets()
        {
            var LatestAssets = _assetMachineData!
             .GroupBy(a => a.AssetName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(a => a.AssetSeries).Aggregate(GetLatestSeries)
            );
            return LatestAssets;
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
            var latestAssetSeries = GetLatestAssets();
            var MachineWithLatestAssets = _assetMachineData?
            .GroupBy(a => a.MachineModel)
            .Where(g => latestAssetSeries!.All(latest =>
                g.Any(a => a.AssetName == latest.Key && a.AssetSeries == latest.Value)))
            .Select(g => g.Key)
            .ToList();
            return MachineWithLatestAssets ?? [];
        }
        public static string GetLatestSeries(string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            var n1 = int.Parse(s1[1..]); //var n1 = int.Parse(s1.Substring(1));
            var n2 = int.Parse(s2[1..]); // var n2 = int.Parse(s2.Substring(1));

            return n1 > n2 ? s1 : s2;
        }
    }
}
