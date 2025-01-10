using AutoMapper;
using MongoDB.Driver;
using TakeAwayProject.Catalog.Dtos.ProductDtos;
using TakeAwayProject.Catalog.Entities;
using TakeAwayProject.Catalog.Settings;

namespace TakeAwayProject.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMapper _mapper;

        public ProductService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            var map = _mapper.Map<Product>(dto);
            await _ProductCollection.InsertOneAsync(map);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _ProductCollection.DeleteOneAsync(id);
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _ProductCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _ProductCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            var map = _mapper.Map<Product>(dto);
            await _ProductCollection.FindOneAndReplaceAsync(x => x.ProductId == dto.ProductId, map);
        }
    }
}
