using DataService.Data;
using Microsoft.AspNetCore.Mvc;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class LoadData : ControllerBase
    {
        AddDataObjectToDB db = new AddDataObjectToDB();
        /// <summary>
        /// Loads Data From D:/Data.txt
        /// </summary>
        /// <returns> 200 Response After Loading </returns>
        [HttpGet("/loaddata")]
        public async Task<IActionResult> Loading()
        {
            txtToDataObject.LoadData();
            await db.AddAssets(txtToDataObject.Assets);
            await db.AddMachineData(txtToDataObject.Machines);
            return Ok();
        }
    }
}