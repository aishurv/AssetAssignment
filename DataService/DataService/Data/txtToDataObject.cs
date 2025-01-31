

using DataService.Model;
using System;
using System.IO;

namespace DataService.Data
{
    public static class txtToDataObject
    {
        const string FilePath = "D:\\AssetAssignment\\DataService\\DataService\\Data\\Data.txt";
        public static List<MachineData> Machines;
        public static Dictionary<string, string> LatestAssetSeries = new Dictionary<string, string> ();
        public static List<AssetData> Assets;
        static txtToDataObject()
        {
            List<DataModel> DataFromFile = new List<DataModel>();
            
            using ( StreamReader sr = new StreamReader(FilePath))
            {
                string? line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',')
                                                 .Select(value => value.Trim())
                                                 .ToArray();
                    DataFromFile.Add(new DataModel { 
                        Model= values[0],
                        AssetType= values[1],
                        AssetSeries= values[2]
                    });
                }
            }
            if (Machines == null)
                Machines = new List<MachineData>();
            if (Assets == null)
                Assets = new List<AssetData>();
            ExtractMachineData(DataFromFile);
            ExtractAssetData(DataFromFile);
        }
        private static void ExtractMachineData(List<DataModel> DataFromFile)
        {
            foreach (var item in DataFromFile)
            {
                var existingMachine = Machines.FirstOrDefault(m => m.ModelName == item.Model);

                if (existingMachine == null)
                {
                    existingMachine = new MachineData
                    {
                        ModelName = item.Model,
                        assets = new List<AssetSummary>()
                    };
                    Machines.Add(existingMachine);
                }

                if (!existingMachine.assets.Any(a => a.Name == item.AssetType && a.Series == item.AssetSeries))
                {
                    existingMachine.assets.Add(new AssetSummary
                    {
                        Name = item.AssetType,
                        Series = item.AssetSeries
                    });
                }
            }
        }
        private static void ExtractAssetData(List<DataModel> DataFromFile)
        {
            foreach (var item in DataFromFile)
            {
                var existigAsset = Assets.FirstOrDefault(a => a.Name == item.AssetType && a.Series == item.AssetSeries);
                if (existigAsset == null)
                {
                    existigAsset = new AssetData
                    {
                        Name = item.AssetType,
                        Series = item.AssetSeries,
                        Machines = new List<string> { item.Model }
                    };
                    Assets.Add(existigAsset);
                }
                if (null == existigAsset.Machines.FirstOrDefault(s => s == item.Model))
                {
                    existigAsset.Machines.Add(item.Model);
                }
                //For LatestAssetSeries Maintainance
                if(LatestAssetSeries.ContainsKey(item.AssetType))
                {
                    var Series = LatestAssetSeries[item.AssetType];
                    LatestAssetSeries[item.AssetType] = GetLatestSeries(Series, item.AssetSeries);
                }
                else
                {
                    LatestAssetSeries[item.AssetType]=item.AssetSeries;
                }
                 
                
            }
        }
        private static string GetLatestSeries(string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            var n1 = int.Parse(s1[1..]); //var n1 = int.Parse(s1.Substring(1));
            var n2 = int.Parse(s2[1..]); // var n2 = int.Parse(s2.Substring(1));

            return n1>n2?s1:s2;
        }

    }
}
