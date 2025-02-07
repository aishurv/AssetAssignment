using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class AssetData 
    {
        public required string? Name;
        public required string? Series;
        public List<string> Machines { get; set; } = new List<string>();
    }
}
