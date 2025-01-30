using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataService.Data;
using DataService.Model;
using MongoDB.Driver;

namespace DataService.MongoDB
{

    public class MachineRepository
    {

        private readonly DBService _DbService = new();
        private readonly IMongoCollection<MachineData>? _machineData;
        public MachineRepository()
        {
            _machineData = _DbService.Database?.GetCollection<MachineData>("machine");
        }
        public Task<List<MachineData>> GetAll()
        {
            return _machineData.Find(FilterDefinition<MachineData>.Empty).ToListAsync();
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
            return machines
            .Where(model => model.assets.All(asset =>
            txtToDataObject.LatestAssetSeries[asset.Name] == asset.Series))
            .Select(model => model.ModelName)
            .ToList();
        }
    }
}
