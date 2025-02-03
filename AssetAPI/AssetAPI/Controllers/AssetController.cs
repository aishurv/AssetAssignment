using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.Data;
using System.Collections.Immutable;
using DataService.Model;
using DataService.MongoDB;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        AssetRepository assetRepository = new AssetRepository();


        [HttpGet("/Assets")]
        public async Task<IEnumerable<AssetData>> GetAssets()
        {
            return await assetRepository.GetAll();
        }
        [HttpGet("/Assets/{MachineModel}")]
        public List<AssetData> GetAssetByMachineModel(string MachineModel)
        {
            return assetRepository.GetAssetByMachineModel(MachineModel);
        }


        //[HttpGet("/latestAssets")]
        //public Dictionary<string, string> GetLatestAssetSeries()
        //{
        //    return txtToDataObject.LatestAssetSeries;
        //}
    }
}
