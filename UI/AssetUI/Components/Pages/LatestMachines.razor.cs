using AssetUI.Services;
using DataService.Model;
using Microsoft.AspNetCore.Components;

namespace AssetUI.Components.Pages
{
    public partial class LatestMachines
    {
        [Inject]
        private MachineDataService? machineDataService { get; set; }
        public List<string>? MachineData;
        protected async override Task OnInitializedAsync()
        {
            MachineData = await machineDataService?.GetLatestAssetSeriesMachines()!;
        }
    }
}
