using System.ComponentModel.DataAnnotations;

namespace DataService.Model
{
    public class MachineData
    {
        public string ModelName { get; set; }

        public List<AssetSummary> assets { get; set; } = new List<AssetSummary>();

    }
}
