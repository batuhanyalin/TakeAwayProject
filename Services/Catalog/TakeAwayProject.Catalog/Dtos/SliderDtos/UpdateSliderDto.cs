using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TakeAwayProject.Catalog.Dtos.SliderDtos
{
    public class UpdateSliderDto
    {
        public string SliderId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
