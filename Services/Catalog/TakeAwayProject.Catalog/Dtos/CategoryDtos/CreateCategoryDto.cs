using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TakeAwayProject.Catalog.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
