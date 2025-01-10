using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TakeAwayProject.Catalog.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
