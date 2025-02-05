using DataService.Data;
using Microsoft.AspNetCore.Mvc;
namespace AssetAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class LoadData : ControllerBase
    {
        AddDataObjectToDB db = new AddDataObjectToDB();
        [HttpGet("/loaddata")]
        public async Task Loading()
        {
            txtToDataObject.LoadData();
            await db.AddAssets();
            await db.AddMachineData();
        }
    }
}