using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class AssetSummary
    {
        [BsonElement("Name")]
        public virtual string? Name { get; set; }
        [BsonElement("Series")]
        public virtual string? Series { get; set; }
    }
}
