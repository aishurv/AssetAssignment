using MongoDB.Bson;
using MongoDB.Driver;
using DataService.ExtensionMethods;
using DataService.Model;
namespace DataService.MongoDB
{
    public class LatestAssetSeriesRepository
    {
        private readonly IMongoCollection<BsonDocument>? _latestSeries;
        public LatestAssetSeriesRepository()
        {
            _latestSeries = DbContext.Database?.GetCollection<BsonDocument>("latest");
        }
        public void Insert(string AssetName , string Series)
        {
            var bsonDoc = _latestSeries.Find(new BsonDocument()).FirstOrDefault();
            if (bsonDoc == null)
            {
                var data = new Dictionary<string, string>();
                data[AssetName] = Series;
                var InsertBsonDoc = new BsonDocument(data);
                _latestSeries!.InsertOne(InsertBsonDoc);
            }
            else
            {
                Update(AssetName, Series, bsonDoc);
            }
        }
        
        public void Update(string Asset, string AssetSeries, BsonDocument bsonDoc)
        {
            var updateDefinition = new List<UpdateDefinition<BsonDocument>>();

            if(bsonDoc.Contains(Asset))
            {
                var UpdatedAssetSeries = AssetSeries.GetLatestSeries(bsonDoc[Asset].AsString);
                if (UpdatedAssetSeries == AssetSeries)
                    updateDefinition.Add(Builders<BsonDocument>.Update.Set(Asset, UpdatedAssetSeries));
            }
            else
            {
                updateDefinition.Add(Builders<BsonDocument>.Update.Set(Asset, AssetSeries));
            }
            if (updateDefinition.Count > 0)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", bsonDoc["_id"]);
                var update = Builders<BsonDocument>.Update.Combine(updateDefinition);

                _latestSeries!.UpdateOne(filter, update);
                Console.WriteLine("Updated dictionary with selected values.");
            }
        }
        public Dictionary<string, string> GetLatestSeries()
        {
            var bsonDoc = _latestSeries.Find(new BsonDocument()).FirstOrDefault();
            if (bsonDoc != null)
            {
                var LatestAssetSeries = new Dictionary<string, string>();
                foreach (var pair in bsonDoc.Elements)
                {
                    LatestAssetSeries[pair.Name] = pair.Value.ToString()!;
                }
                LatestAssetSeries.Remove("_id");
                return LatestAssetSeries;
            }
            return new Dictionary<string, string>();
        }
        public async Task DeleteAll()
        {
            await _latestSeries!.DeleteManyAsync(FilterDefinition<BsonDocument>.Empty);
        }

    }
}
