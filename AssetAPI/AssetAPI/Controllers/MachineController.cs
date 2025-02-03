using DataService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.MongoDB;
using DataService.Model;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        MachineRepository machineRepository = new MachineRepository();
        [HttpGet("/Machines")]
        public async Task<IEnumerable<MachineData>> GetAll()
        {
            return await machineRepository.GetAll();
        }

        [HttpGet("/Machine/{id}")]
        public async Task<MachineData> GetById(string id)
        {
            return await machineRepository.GetById(id);
        }
        [HttpGet("/Machine/Asset/{AssetName}")]
        public List<string> GetMachineModelByAssetName(string AssetName)
        {
            return machineRepository.GetMachineModelByAssetName(AssetName);
        }
        [HttpGet("/MachineWithLatestAssetSeries")]
        public List<string> GetMachineWithLatestAssetSeries()
        {
            return machineRepository.MachineWithLatestAssetSeries();
        }
    }
}
