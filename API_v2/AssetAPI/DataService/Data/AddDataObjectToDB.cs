using AssetAPI.Repository;
using DataService.Model;

namespace DataService.Data
{
    public class AddDataObjectToDB
    {
        private DataModelRepository? _dataModel; 
        public AddDataObjectToDB()
        {
            _dataModel = new DataModelRepository();
        }

        public async Task AddDataList( List<DataModel> data)
        {
            await _dataModel!.AddDataList(data);
        }
    }
}
