using DataService.Model;
using DataService.Data;
using AssetUI.Services;
using Microsoft.AspNetCore.Components;
namespace AssetUI.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private AssetService? assetService { get; set; }
        [Inject]
        private MachineDataService? machineDataService { get; set; }

        public List<MachineData>? machines;
        public List<AssetData>? assets;
        public Dictionary<string, string> LatestAssets = new();

        protected override async Task OnInitializedAsync()  
        {   
            LatestAssets = await assetService?.GetLatestAssetsAsync()!;
            assets = await assetService.GetAllAsync();
            machines = await machineDataService?.GetAllAsync()!;
        }
    }
}
