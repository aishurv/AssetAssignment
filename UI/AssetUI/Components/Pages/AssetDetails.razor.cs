using AssetUI.Services;
using DataService.Model;
using Microsoft.AspNetCore.Components;

namespace AssetUI.Components.Pages
{
    public partial class AssetDetails
    {
        [Inject]
        private AssetService? _assetService { get; set; }
        public List<AssetData>? AssetsData { get; set; }
        protected override async Task OnInitializedAsync()
        {
            AssetsData = await _assetService!.GetAllAsync();
            
        }
    }
}
