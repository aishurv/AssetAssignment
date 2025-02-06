﻿using Microsoft.AspNetCore.Components;
namespace AssetUI.Components.Pages
{
    public partial class AssetCard
    {
        [Parameter]
        public string AssetName { get; set; } = default!;
        
        [Parameter]
        public string AssetSeries { get; set; } = default!;
        
    }
}
