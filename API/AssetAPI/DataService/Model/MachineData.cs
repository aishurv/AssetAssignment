using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class MachineData
    {
        [BsonId]
        public required string ModelName { get; set; }

        public List<AssetSummary> assets { get; set; } = new List<AssetSummary>();

    }
}
