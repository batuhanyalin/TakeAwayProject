using AutoMapper;
using MongoDB.Driver;
using TakeAwayProject.Catalog.Dtos.SliderDtos;
using TakeAwayProject.Catalog.Entities;
using TakeAwayProject.Catalog.Settings;

namespace TakeAwayProject.Catalog.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _SliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _SliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto dto)
        {
            var map = _mapper.Map<Slider>(dto);
            await _SliderCollection.InsertOneAsync(map);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _SliderCollection.DeleteOneAsync(id);
        }
        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var values = await _SliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task<GetByIdSliderDto> GetByIdSliderAsync(string id)
        {
            var values = await _SliderCollection.Find(x => x.SliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSliderDto>(values);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto dto)
        {
            var map = _mapper.Map<Slider>(dto);
            await _SliderCollection.FindOneAndReplaceAsync(x => x.SliderId == dto.SliderId, map);
        }
    }
}
