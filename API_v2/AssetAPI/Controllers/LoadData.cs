using DataService.Data;
using Microsoft.AspNetCore.Mvc;
namespace AssetAPI.Controllers
{
    /// <summary>
    /// Data Loading 
    /// </summary>
    [Route("/")]
    [ApiController]
    public class LoadData : ControllerBase
    {
        /// <summary>
        /// Loads Data From D:/Data.txt
        /// </summary>
        /// <returns> 200 Response After Loading </returns>
        [HttpGet("/loaddata")]
        public async Task<IActionResult> Loading()
        {
            DataObjectFromtxt.LoadData();
            await AddDataObjectToDB.AddDataListAsync(DataObjectFromtxt.DataFromFile);
            return Ok();
        }
    }
}