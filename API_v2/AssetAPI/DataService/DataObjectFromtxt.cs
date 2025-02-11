using DataService.Model;
namespace DataService.Data
{
    internal static class DataObjectFromtxt
    {
        static string FilePath = "D:/Data.txt"; //   D: /app
        public static List<MachineAssetSeries> DataFromFile = [];
        static DataObjectFromtxt()
        {
            LoadData();
        }
        public static void LoadData()
        {
            DataFromFile = new List<MachineAssetSeries>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()!) != null)
                {
                    string[] values = line.Split(',')
                                                 .Select(value => value.Trim())
                                                 .ToArray();
                    DataFromFile.Add(new MachineAssetSeries
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
