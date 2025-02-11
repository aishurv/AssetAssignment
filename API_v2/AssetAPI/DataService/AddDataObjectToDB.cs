using AssetAPI.Repository;
using DataService.Model;

namespace DataService.Data
{
    internal class AddDataObjectToDB
    {
        private static AssetMachineRepository _dataModel; 
        static AddDataObjectToDB()
        {
            _dataModel = new AssetMachineRepository();
        }

        public static async Task AddDataListAsync( List<MachineAssetSeries> data)
        {
            await _dataModel.AddDataListAsync(data);
        }
    }
}
