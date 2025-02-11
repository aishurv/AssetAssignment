using Microsoft.AspNetCore.Mvc;
using AssetAPI.Extraction;
namespace AssetAPI.Controllers
{
    /// <summary>
    /// Asset Controller
    /// </summary>
    [Route("/")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        //[Inject]
        private readonly AssetService _assetService = new AssetService();

        /// <summary>
        /// Get All Assets
        /// </summary>
        /// <returns> List of AssetData </returns>
        [HttpGet("/assets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAssets()
        {
            var assets = _assetService.GetAllAssets();
            if (assets == null)
                return NotFound();
             return Ok(assets);
        }
        /// <summary>
        /// Get Assets By Machine Model Name 
        /// </summary>
        /// <returns> List of AssetData </returns>
        /// 
        [HttpGet("/assets/machine/{MachineModel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAssetByMachineModel(string MachineModel)
        {
            var assets = _assetService.GetAssetByMachineModel(MachineModel);
            if (assets == null || assets.Count()==0)
                return NotFound();
            return Ok(assets);
        }
        /// <summary>
        /// Get Latest Series of Assets 
        /// </summary>
        /// <returns> List of AssetData </returns>
        /// 
        [HttpGet("/latestassets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetLatestAssets()
        {
            var assets = _assetService.GetLatestAssets();
            if(assets == null || assets.Count()==0)
                return NotFound();
            return Ok(assets);
        }

    }
}
