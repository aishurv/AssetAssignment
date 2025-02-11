using MongoDB.Driver;

namespace DataService.MongoDB
{
    public class DbContext
    {
        private static readonly IMongoDatabase? _database;

        static DbContext()
        {
            var connectionString = "mongodb://localhost:27017";  //"mongodb://localhost:27017";//_configuration.GetConnectionString("DbConnection");
            //"mongodb://mongodb:27017"; assignment_mongodb
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase("Asset");
        }
        public static IMongoDatabase? Database => _database;
    }
}
