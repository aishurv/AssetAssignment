// See https://aka.ms/new-console-template for more information
using DataService.Data;
using DataService.MongoDB;

Console.WriteLine("Hello, World!");
AddDataObjectToDB addDataObjectToDB = new AddDataObjectToDB();
var data = txtToDataObject.Machines;
addDataObjectToDB.addMachines(data);
//addDataObjectToDB.addLatestAssetSeries(txtToDataObject.LatestAssetSeries);
var latestAssetSeriesRepo = new LatestAssetSeriesRepository();
latestAssetSeriesRepo.Insert(txtToDataObject.LatestAssetSeries);
//addDataObjectToDB.addAssets(data);
//foreach(var asset in data)
//{
//    Console.WriteLine(asset);
//}