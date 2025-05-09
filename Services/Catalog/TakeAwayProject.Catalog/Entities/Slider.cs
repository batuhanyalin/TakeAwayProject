﻿using MongoDB.Bson.Serialization.Attributes;

namespace TakeAwayProject.Catalog.Entities
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //Object Id guid bir değer almasını sağlıyor.
        public string SliderId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
