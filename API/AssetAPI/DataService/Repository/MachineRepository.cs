using DataService.Model;
using MongoDB.Driver;
namespace DataService.MongoDB
{

    public class MachineRepository
    {

        private readonly IMongoCollection<MachineData>? _machineData;
        public MachineRepository()
        {
            _machineData = DbContext.Database?.GetCollection<MachineData>("machine");
        }
        public Task<List<MachineData>> GetAll()
        {
            return _machineData.Find(FilterDefinition<MachineData>.Empty).ToListAsync();
        }
        public Task<MachineData> GetById(string id)
        {
            var filter = Builders<MachineData>.Filter.Eq("_id", id);
            return _machineData.Find(filter).FirstOrDefaultAsync();
        }
        public List<string> GetMachineModelByAssetName(string assetName)
        {
            var machines = _machineData.Find(FilterDefinition<MachineData>.Empty).ToList();
            return machines
            .Where(model => model.assets.Any(asset => asset.Name == assetName))
            .Select(model => model.ModelName)
            .ToList();
        }
        public List<string> MachineWithLatestAssetSeries()
        {
            var machines = _machineData.Find(FilterDefinition<MachineData>.Empty).ToList();
            var latestAssetSeriesRepo = new LatestAssetSeriesRepository();
            var LatestAssetSeries = latestAssetSeriesRepo.GetLatestSeries();
            return machines
            .Where(model => model.assets.All(asset =>
            LatestAssetSeries[asset.Name!] == asset.Series))
            .Select(model => model.ModelName)
            .ToList();
        }

        public async Task AddMachineData(MachineData  machineData)
        {
            var filter = Builders<MachineData>.Filter.Eq("_id", machineData.ModelName);
            var data = await _machineData.Find(filter).FirstOrDefaultAsync();
            if (data == null)
            {

                Console.WriteLine("Trying to add Machine Data! ");
                _machineData!.InsertOne(machineData);
                Console.WriteLine("Machine Data Added ! ");
            }
        }
        public async Task AddMachinesData(List<MachineData> machinesData)
        {
            foreach (var machineData in machinesData)
            {
                await AddMachineData(machineData);
            }
        }
        public async Task DeleteAll()
        {
            await _machineData!.DeleteManyAsync(FilterDefinition<MachineData>.Empty);
        }
    }
}
