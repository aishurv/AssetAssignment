﻿
using DataService.Model;
using DataService.Data;
using Microsoft.AspNetCore.Components;
namespace AssetUI.Components.Pages
{
    public partial class MachineCard
    {
        [Parameter]
        public MachineData Machine { get; set; } = default!;

    }
}
