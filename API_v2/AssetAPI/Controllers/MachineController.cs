using Microsoft.AspNetCore.Mvc;
using DataService.Model;
using AssetAPI.Repository;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        MachineRepository machineRepository = new MachineRepository();
        /// <summary>
        /// Get All Machines Data
        /// </summary>
        /// <returns> List of MachineData </returns>

        [HttpGet("/machines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var machines = await machineRepository.GetAll();
            if (machines == null)
                return NotFound();
            return Ok(machines);
        }
        /// <summary>
        /// Get machine by its model name
        /// </summary>
        /// <param name="MachineModel"></param>
        /// <returns> return maodel name </returns>

        [HttpGet("/machine/{MachineModel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string MachineModel)
        {
            var machine = await machineRepository.GetById(MachineModel);
            if (machine == null) 
                return NotFound();
            return Ok(machine);
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
            var machineNames = machineRepository.GetMachineModelByAssetName(AssetName);
            if (machineNames == null)
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
            var machineNames = machineRepository.MachineWithLatestAssetSeries();
            if (machineNames == null)
                return NotFound();
            return Ok(machineNames);
        }
    }
}
