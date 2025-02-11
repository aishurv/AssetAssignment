using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    /// <summary>
    /// Asset Info
    /// </summary>
    public class AssetData 
    {
        /// <summary>
        /// Asset Name
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Asset Series
        /// </summary>
        public required string Series { get; set; }
        /// <summary>
        /// List of Machines Use This Asset
        /// </summary>
        public List<string> Machines { get; set; } = new List<string>();
    }
}
