using AssetUI.Services;
using DataService.Model;
using Microsoft.AspNetCore.Components;

namespace AssetUI.Components.Pages
{
    public partial class MachineByAssets
    {
        [Parameter]
        public string? assetName { get; set; }
        [Inject]
        private MachineDataService? _machineDataService { get; set; }
        
        private bool IsCardView {  get; set; } = false;
        private List<string>? machines { get; set; }

        protected override async Task OnInitializedAsync()
        {
            machines = await _machineDataService!.GetMachineModelByAssetName(assetName!);
            if (machines == null || machines.Count() == 0)
            {
                Console.WriteLine("not getting Data");
            }
        }
    }
}


