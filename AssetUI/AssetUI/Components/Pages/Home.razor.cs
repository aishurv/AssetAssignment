using DataService.Model;
using DataService.Data;
namespace AssetUI.Components.Pages
{
    public partial class Home
    {
        public List<MachineData> machines = txtToDataObject.Machines;
        public List<AssetData> assets = txtToDataObject.Assets;
        public Dictionary<string,string> LatestAssets = txtToDataObject.LatestAssetSeries;
    }
}
