using AssetUI.Services;
using DataService.Model;
using Microsoft.AspNetCore.Components;

namespace AssetUI.Components.Pages
{
    public partial class MachineDetailsTable
    {
        [Inject]
        private MachineDataService? machineDataService { get; set; }
        public List<MachineData>? MachineData;
        protected async override Task OnInitializedAsync()
        {
            MachineData = await machineDataService?.GetAllAsync()!;
        }
    }
}
