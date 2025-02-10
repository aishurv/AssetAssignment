using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class AssetData 
    {
        public required string? Name { get; set; }
        public required string? Series { get; set; }
        public List<string> Machines { get; set; } = new List<string>();
    }
}
