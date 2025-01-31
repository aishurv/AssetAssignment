using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class AssetSummary
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Series")]
        public string Series { get; set; }
    }
}
