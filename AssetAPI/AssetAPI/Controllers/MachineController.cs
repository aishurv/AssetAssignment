﻿using DataService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.MongoDB;
using DataService.Model;
namespace AssetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        MachineRepository machineRepository = new MachineRepository();
        [HttpGet]
        public async Task<IEnumerable<MachineData>> GetAll()
        {
            return await machineRepository.GetAll();
        }
        [HttpGet("{name}")]
        public List<string> GetMachineModelByAssetName(string name)
        {
            return machineRepository.GetMachineModelByAssetName(name);
        }
        [HttpGet("/MachineWithLatestAssetSeries")]
        public List<string> GetMachineWithLatestAssetSeries()
        {
            return machineRepository.MachineWithLatestAssetSeries();
        }
    }
}
