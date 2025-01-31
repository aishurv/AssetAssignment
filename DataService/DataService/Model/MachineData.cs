using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class MachineData
    {
        [BsonId]
        public string ModelName { get; set; }

        public List<AssetSummary> assets { get; set; } = new List<AssetSummary>();

    }
}
