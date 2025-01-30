using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.Data;
using System.Collections.Immutable;
using DataService.Model;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        [HttpGet("/Assets")]
        public IEnumerable<AssetData> GetAssets()
        {
            return txtToDataObject.Assets;
        }

        [HttpGet("/Machine")]
        public IEnumerable<MachineData> GetMachines()
        {
            return txtToDataObject.Machines;
        }
        [HttpGet("/latestAssets")]
        public Dictionary<string, string> GetLatestAssetSeries()
        {
            return txtToDataObject.LatestAssetSeries;
        }
        [HttpGet("/Assets/{model}")]
        public List<AssetData> GetAssetByMachineModel(string model)
        {
            return txtToDataObject.Assets.Where(a => a.Machines.Contains(model)).ToList();
        }
        [HttpGet("/Machine/{name}")]
        public List<string> GetMachineModelByAssetName(string name)
        {
            List<string> machines = txtToDataObject.Machines
            .Where(model => model.assets.Any(asset => asset.Name == name))
            .Select(model=>model.ModelName)
            .ToList();
            return machines;
        }
        [HttpGet("/MachineWithLatestAssetSeries")]
        public List<string> GetMachineWithLatestAssetSeries()
        {
            List<string> machines = txtToDataObject.Machines
            .Where(model => model.assets.All(asset => 
            txtToDataObject.LatestAssetSeries[asset.Name] == asset.Series))
            .Select(model=> model.ModelName)
            .ToList();
            return machines;
        }
    }
}
