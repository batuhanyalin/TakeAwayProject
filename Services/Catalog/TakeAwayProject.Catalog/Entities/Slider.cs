using MongoDB.Bson.Serialization.Attributes;

namespace TakeAwayProject.Catalog.Entities
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //Object Id
        public string SliderId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
