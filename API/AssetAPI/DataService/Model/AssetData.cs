﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataService.Model
{
    public class AssetData : AssetSummary
    {
        [BsonId]
        public string Id {
            get => GenerateID();
            set
            {
                if (Name != null && Series != null)
                    Id = GenerateID();
            }
        } 
        public List<string> Machines { get; set; } = new List<string>();

        public override required string? Name { get => base.Name!;
            set {
                base.Name = value;
                if (Series != null)                
                    GenerateID(); 
            }
        }
        public override required string? Series
        {
            get => base.Series!;
            set {
                base.Series = value;
                if (Name != null)
                    GenerateID();
            }
        }
       
        private string GenerateID()
        {
            string id = string.Empty;
            string firstChars = new string(Name!.Split(' ').Select(word => word[0]).ToArray());
            firstChars = firstChars.ToUpper();
            id= firstChars + Series;
            return id;
        }
    }
}
