using Microsoft.AspNetCore.Mvc;
using AssetAPI.Extraction;
using Microsoft.VisualBasic;
namespace AssetAPI.Controllers
{
    /// <summary>
    /// Machine Controller 
    /// </summary>
    [Route("/")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly MachineService _machineService = new MachineService();
        /// <summary>
        /// Get All Machines Data
        /// </summary>
        /// <returns> List of MachineData </returns>

        [HttpGet("/machines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var machines = _machineService.GetAllMachines();
                return Ok(machines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get machine by its model name
        /// </summary>
        /// <param name="MachineModel"></param>
        /// <returns> return maodel name </returns>

        [HttpGet("/machine/{MachineModel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  IActionResult GetById(string MachineModel)
        {
            var machine =  _machineService.GetMachineById(MachineModel);
            
                return machine == null ? NotFound():Ok(machine);
        }
        /// <summary>
        /// Get Machine Model Names By Asset Name
        /// </summary>
        /// <param name="AssetName"></param>
        /// <returns> List of Machine Model Names </returns>
        [HttpGet("/machine/asset/{AssetName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMachineModelByAssetName(string AssetName)
        {
            var machineNames = _machineService.GetMachineModelsByAssetName(AssetName);
            if (machineNames.Count == 0)
                return NotFound();
            return Ok(machineNames);
        }
        /// <summary>
        /// List of Machine Model Name using All Latest Assets
        /// </summary>
        /// <returns>List of Machine Model Names</returns>
        [HttpGet("/machines_with_latest_assetseries")]
        public IActionResult GetMachineWithLatestAssetSeries()
        {
            var machineNames = _machineService.GetMachineWithLatestAssets();
            if (machineNames.Count == 0)
                return NotFound();
            return Ok(machineNames);
        }
    }
}
