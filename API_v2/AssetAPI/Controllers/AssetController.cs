using Microsoft.AspNetCore.Mvc;
using DataService.Model;
using AssetAPI.Repository;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private AssetRepository _assetRepository = new AssetRepository();

        /// <summary>
        /// Get All Assets
        /// </summary>
        /// <returns> List of AssetData </returns>
        [HttpGet("/assets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAssets()
        {
            var assets = _assetRepository.GetAll();
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
            var assets = _assetRepository.GetAssetByMachineModel(MachineModel);
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
            var assets = _assetRepository.GetLatestAssets();
            if(assets == null || assets.Count()==0)
                return NotFound();
            return Ok(assets);
        }

    }
}
