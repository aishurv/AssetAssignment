using Microsoft.AspNetCore.Components;
using DataService.Model;
namespace AssetUI.Components.Pages
{
    public partial class AssetDetailsCard
    {
        [Parameter]
        public AssetData AssetData { get; set; } = default!;
        
    }
}
