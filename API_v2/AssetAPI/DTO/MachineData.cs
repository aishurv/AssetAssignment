namespace DataService.Model
{
    /// <summary>
    /// AssetSummary 
    /// </summary>
    public class AssetSummary
    {
        /// <summary>
        /// Asset Name
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Asset Series
        /// </summary>
        public required string Series { get; set; }
    }
    /// <summary>
    /// Machine Info 
    /// </summary>
    public class MachineData
    {
        /// <summary>
        /// Machine Model Name
        /// </summary>
        public required string ModelName { get; set; }
        /// <summary>
        /// Assets Name and Series Used By Machine 
        /// </summary>
        public List<AssetSummary> Assets { get; set; } = new List<AssetSummary>();

    }
}
