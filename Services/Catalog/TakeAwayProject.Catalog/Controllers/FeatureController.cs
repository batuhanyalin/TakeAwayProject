using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayProject.Catalog.Dtos.FeatureDtos;
using TakeAwayProject.Catalog.Services.FeatureServices;

namespace TakeAwayProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;

        public FeatureController(IFeatureService FeatureService)
        {
            _FeatureService = FeatureService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _FeatureService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _FeatureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Özellik başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _FeatureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Özellik başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _FeatureService.DeleteFeatureAsync(id);
            return Ok("Özellik başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(string id)
        {
            var value = await _FeatureService.GetByIdFeatureAsync(id);
            return Ok(value);
        }
    }
}
