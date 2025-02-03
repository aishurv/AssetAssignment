using Microsoft.AspNetCore.Components;
using DataService.Model;
using DataService.MongoDB;
using AssetUI.Services;
namespace AssetUI.Components.Pages
{
    public partial class AssetsByMachine
    {
        [Inject]
        private AssetService? _assetService { get; set; }
        [Parameter]
        public string? MachineName { get; set; }
        public List<AssetData>? AssetsData { get; set; }
        protected override async Task OnInitializedAsync()
        {
            AssetsData = await _assetService!.GetAssetByMachineModel(MachineName?.ToString() ??"CS300");
            if(AssetsData == null || AssetsData.Count()==0)
            {
                Console.WriteLine("not getting Data");
            }
        }

    }
}
