using MongoDB.Bson;
using MongoDB.Driver;

namespace DataService.MongoDB
{
    public class LatestAssetSeriesRepository
    {
        private readonly IMongoCollection<BsonDocument>? _latestSeries;
        public LatestAssetSeriesRepository()
        {
            _latestSeries = DbContext.Database?.GetCollection<BsonDocument>("latest");
        }
        public void Insert(Dictionary<string, string> data)
        {
            var bsonDoc = _latestSeries.Find(new BsonDocument()).FirstOrDefault();
            if (bsonDoc == null)
            {
                var InsertBsonDoc = new BsonDocument(data);
                _latestSeries.InsertOne(InsertBsonDoc);
            }
            else
            {
                foreach (var Asset in data.Keys)
                {
                    Update(Asset, data[Asset]);
                }

            }
        }
        public Dictionary<string, string> GetLatestSeries()
        {
            var bsonDoc = _latestSeries.Find(new BsonDocument()).FirstOrDefault();
            if (bsonDoc != null)
            {
                var LatestAssetSeries = new Dictionary<string, string>();
                foreach(var pair in bsonDoc.Elements)
                {
                    LatestAssetSeries[pair.Name] = pair.Value.ToString();
                }
                return LatestAssetSeries;
            }
            return new Dictionary<string, string>();
        }
        public void Update(string Asset, string AssetSeries)
        {

            var bsonDoc = _latestSeries.Find(new BsonDocument()).FirstOrDefault();
            var updateDefinition = new List<UpdateDefinition<BsonDocument>>();

            if(bsonDoc.Contains(Asset))
            {
                AssetSeries = AssetSeries.Trim();
                var UpdatedAssetSeries = GetLatestSeries(AssetSeries, bsonDoc[Asset].AsString);
                if (UpdatedAssetSeries != AssetSeries)
                    updateDefinition.Add(Builders<BsonDocument>.Update.Set(Asset, UpdatedAssetSeries));
            }

            if (updateDefinition.Count > 0)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", bsonDoc["_id"]);
                var update = Builders<BsonDocument>.Update.Combine(updateDefinition);

                _latestSeries.UpdateOne(filter, update);
                Console.WriteLine("Updated dictionary with selected values.");
            }
        }
        private static string GetLatestSeries(string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            var n1 = int.Parse(s1[1..]); //var n1 = int.Parse(s1.Substring(1));
            var n2 = int.Parse(s2[1..]); // var n2 = int.Parse(s2.Substring(1));

            return n1 > n2 ? s1 : s2;
        }
    }
}
