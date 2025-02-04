using AssetUI.Services;
using DataService.Model;
using Microsoft.AspNetCore.Components;

namespace AssetUI.Components.Pages
{
    public partial class MachineDetailsCard
    {
        [Inject]
        private MachineDataService? machineDataService {  get; set; }
        [Parameter]
        public string Model { get; set; } = default!;
        public MachineData? MachineData;
        protected async override Task OnInitializedAsync()
        {
            MachineData = await machineDataService?.GetById(Model)!;
        }
    }
}
