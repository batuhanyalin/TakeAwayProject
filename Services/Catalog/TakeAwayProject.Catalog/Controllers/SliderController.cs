using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayProject.Catalog.Dtos.SliderDtos;
using TakeAwayProject.Catalog.Services.SliderServices;

namespace TakeAwayProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _SliderService;

        public SliderController(ISliderService SliderService)
        {
            _SliderService = SliderService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _SliderService.GetAllSliderAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _SliderService.CreateSliderAsync(createSliderDto);
            return Ok("Slider başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _SliderService.UpdateSliderAsync(updateSliderDto);
            return Ok("Slider başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _SliderService.DeleteSliderAsync(id);
            return Ok("Slider başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(string id)
        {
            var value = await _SliderService.GetByIdSliderAsync(id);
            return Ok(value);
        }
    }
}
