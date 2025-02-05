using AssetUI.Services;
using Microsoft.AspNetCore.Components;

namespace AssetUI.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        private DataLoadingService? _dataLoadingService { get; set; }
        public void LoadData()
        {
            _dataLoadingService!.LoadData();
        }
    }
}
