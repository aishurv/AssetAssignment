// See https://aka.ms/new-console-template for more information
using DataService.Data;

Console.WriteLine("Hello, World!");
AddDataObjectToDB addDataObjectToDB = new AddDataObjectToDB();
var data = txtToDataObject.Machines;
addDataObjectToDB.addMachines(data);
addDataObjectToDB.addLatestAssetSeries(txtToDataObject.LatestAssetSeries);
//addDataObjectToDB.addAssets(data);
//foreach(var asset in data)
//{
//    Console.WriteLine(asset);
//}