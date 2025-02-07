namespace DataService.Model
{
    public class AssetSummary
    {
        public string? Name { get; set; }
        public string? Series { get; set; }
    }
    public class MachineData
    {
        public required string ModelName { get; set; }

        public List<AssetSummary> assets { get; set; } = new List<AssetSummary>();

    }
}
