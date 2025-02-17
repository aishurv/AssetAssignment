﻿
using DataService.Model;
namespace DataService.Data
{
    public static class txtToDataObject
    {
        static string FilePath = "D:/Data.txt"; //   D: /app
        public static List<MachineData> Machines = [];
        public static List<AssetData> Assets = [];
        static txtToDataObject()
        {
            LoadData();
        }
        public static void LoadData()
        {
            List<DataModel> DataFromFile = new List<DataModel>();

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

            Machines = new List<MachineData>();
            Assets = new List<AssetData>();
            ExtractMachineData(DataFromFile);
            ExtractAssetData(DataFromFile);
        }
        private static void ExtractMachineData(List<DataModel> DataFromFile)
        {
            foreach (var item in DataFromFile)
            {
                var existingMachine = Machines.FirstOrDefault(m => m.ModelName == item.MachineModel);

                if (existingMachine == null)
                {
                    existingMachine = new MachineData
                    {
                        ModelName = item.MachineModel,
                        assets = new List<AssetSummary>()
                    };
                    Machines.Add(existingMachine);
                }

                if (!existingMachine.assets.Any(a => a.Name == item.AssetName && a.Series == item.AssetSeries))
                {
                    existingMachine.assets.Add(new AssetSummary
                    {
                        Name = item.AssetName,
                        Series = item.AssetSeries
                    });
                }
            }
        }
        private static void ExtractAssetData(List<DataModel> DataFromFile)
        {
            foreach (var item in DataFromFile)
            {
                var existigAsset = Assets.FirstOrDefault(a => a.Name == item.AssetName && a.Series == item.AssetSeries);
                if (existigAsset == null)
                {
                    existigAsset = new AssetData
                    {
                        Name = item.AssetName,
                        Series = item.AssetSeries,
                        Machines = new List<string> { item.MachineModel }
                    };
                    Assets.Add(existigAsset);
                }
                if (null == existigAsset.Machines.FirstOrDefault(s => s == item.MachineModel))
                {
                    existigAsset.Machines.Add(item.MachineModel);
                }
            }
        }
    }
}
