﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TakeAwayProject.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
