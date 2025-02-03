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
        private AssetRepository _assetRepository = new AssetRepository();


        [HttpGet("/Assets")]
        public async Task<IEnumerable<AssetData>> GetAssets()
        {
            return await _assetRepository.GetAll();
        }
        [HttpGet("/Assets/{MachineModel}")]
        public List<AssetData> GetAssetByMachineModel(string MachineModel)
        {
            return _assetRepository.GetAssetByMachineModel(MachineModel);
        }
        [HttpGet("/LatestAssets")]
        public Dictionary<string,string> GetLatestAssets()
        {
            return _assetRepository.GetLatestAssets();
        }

    }
}
