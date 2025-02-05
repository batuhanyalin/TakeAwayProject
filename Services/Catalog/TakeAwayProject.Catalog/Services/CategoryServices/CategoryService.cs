using AutoMapper;
using MongoDB.Driver;
using TakeAwayProject.Catalog.Dtos.CategoryDtos;
using TakeAwayProject.Catalog.Entities;
using TakeAwayProject.Catalog.Settings;

namespace TakeAwayProject.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings _databaseSettings, IMapper mapper)
        
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            var map = _mapper.Map<Category>(dto);
            await _categoryCollection.InsertOneAsync(map);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var map = _mapper.Map<Category>(dto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == dto.CategoryId, map);
        }
    }
}
