using System.Xml.Linq;

namespace DataService.Model
{
    public class DataModel
    {
        public string _id{
            get
            {
                return GenerateId();
            }
        
        }
        public required string MachineModel { get; set; }
        public required string AssetName { get; set; }
        public required string AssetSeries {  get; set; }
        public string GenerateId()
        {
            string id = MachineModel.ToUpper();
            string firstChars = new string(AssetName!.Split(' ').Select(word => word[0]).ToArray());
            firstChars = firstChars.ToUpper();
            id = id + firstChars + AssetSeries;
            return id;
        }
    }
}
