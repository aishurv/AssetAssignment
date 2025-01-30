using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
