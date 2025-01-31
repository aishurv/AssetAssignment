using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class AssetData : AssetSummary
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<string> Machines { get; set; }
    }
}
