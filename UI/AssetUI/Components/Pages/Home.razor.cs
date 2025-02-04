using DataService.Model;
using AssetUI.Services;
using Microsoft.AspNetCore.Components;
namespace AssetUI.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private AssetService? _assetService { get; set; }
        [Inject]
        private MachineDataService? machineDataService { get; set; }

        public List<MachineData>? machines;
        public List<AssetData>? assets;
        public Dictionary<string, string> LatestAssets = [];

        protected override async Task OnInitializedAsync()  
        {   
            LatestAssets = await _assetService?.GetLatestAssetsAsync()!;
            assets = await _assetService.GetAllAsync();
            machines = await machineDataService?.GetAllAsync()!;
        }
    }
}
