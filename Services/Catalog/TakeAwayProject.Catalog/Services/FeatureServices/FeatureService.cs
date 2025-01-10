using AutoMapper;
using MongoDB.Driver;
using TakeAwayProject.Catalog.Dtos.FeatureDtos;
using TakeAwayProject.Catalog.Entities;
using TakeAwayProject.Catalog.Settings;

namespace TakeAwayProject.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _FeatureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FeatureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto dto)
        {
            var map = _mapper.Map<Feature>(dto);
            await _FeatureCollection.InsertOneAsync(map);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _FeatureCollection.DeleteOneAsync(id);
        }
        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _FeatureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _FeatureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto dto)
        {
            var map = _mapper.Map<Feature>(dto);
            await _FeatureCollection.FindOneAndReplaceAsync(x => x.FeatureId == dto.FeatureId, map);
        }
    }
}
