using TakeAwayProject.Catalog.Dtos.FeatureDtos;

namespace TakeAwayProject.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto dto);
        Task UpdateFeatureAsync(UpdateFeatureDto dto);
        Task DeleteFeatureAsync(string id);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
