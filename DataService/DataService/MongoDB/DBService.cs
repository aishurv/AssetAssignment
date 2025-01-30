using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataService.MongoDB
{
    public class DBService
    {
        private readonly IMongoDatabase? _database;

        public DBService()
        {
            var connectionString = "mongodb://localhost:27017";  //"mongodb://localhost:27017";//_configuration.GetConnectionString("DbConnection");
            //"mongodb://mongodb:27017";
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase("Asset");
        }
        public IMongoDatabase? Database => _database;
    }
}
