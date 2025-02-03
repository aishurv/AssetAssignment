using Microsoft.AspNetCore.Components;
using DataService.Model;
using DataService.MongoDB;
namespace AssetUI.Components.Pages
{
    public partial class AssetsByMachine
    {
        [Parameter]
        public string MachineName { get; set; }
        public List<AssetData> AssetData { get; set; }
        private AssetRepository assetRepository = new AssetRepository();
        protected override void OnInitialized()
        {
            assetRepository = new AssetRepository();
            AssetData = assetRepository.GetAssetByMachineModel(MachineName);
        }

    }
}
