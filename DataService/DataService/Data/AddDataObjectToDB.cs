using DataService.Model;
using DataService.MongoDB;
using MongoDB.Driver;

namespace DataService.Data
{
    public class AddDataObjectToDB
    {
        private readonly DBService _DbService = new();
        private readonly IMongoCollection<AssetData>? _assetData;
        private readonly IMongoCollection<MachineData>? _machineData;
        private readonly IMongoCollection<Dictionary<string,string>>? _latest;
        public AddDataObjectToDB()
        {
            _assetData = _DbService.Database?.GetCollection<AssetData>("asset");
            _machineData = _DbService.Database?.GetCollection<MachineData>("machine");
            _latest = _DbService.Database?.GetCollection<Dictionary<string, string>>("latestseries");
            //addAssets(txtToDataObject.Assets);
            //addMachines();
            //addLatestAssetSeries();
        }
        public void addAssets(List<AssetData> assets)
        {
            _assetData.InsertMany(assets);
        }
        public void addMachines(List<MachineData> machines)
        {
            //var machines = txtToDataObject.Machines;
            _machineData.InsertMany(machines);
        }
        public void addLatestAssetSeries(Dictionary<string, string> latest)
        {
            //var latest = txtToDataObject.LatestAssetSeries;
            _latest.InsertMany((IEnumerable<Dictionary<string, string>>)latest);

        }
    }
}
