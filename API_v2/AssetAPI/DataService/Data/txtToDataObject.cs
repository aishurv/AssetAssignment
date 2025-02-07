using DataService.Model;
namespace DataService.Data
{
    public static class txtToDataObject
    {
        static string FilePath = "D:/Data.txt"; //   D: /app
        public static List<DataModel> DataFromFile = [];
        static txtToDataObject()
        {
            LoadData();
        }
        public static void LoadData()
        {
            DataFromFile = new List<DataModel>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()!) != null)
                {
                    string[] values = line.Split(',')
                                                 .Select(value => value.Trim())
                                                 .ToArray();
                    DataFromFile.Add(new DataModel
                    {
                        MachineModel = values[0],
                        AssetName = values[1],
                        AssetSeries = values[2]
                    });
                }
            }
        }
        
    }
}
