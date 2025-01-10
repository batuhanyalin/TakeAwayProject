﻿using TakeAwayProject.Catalog.Dtos.SliderDtos;

namespace TakeAwayProject.Catalog.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto dto);
        Task UpdateSliderAsync(UpdateSliderDto dto);
        Task DeleteSliderAsync(string id);
        Task<GetByIdSliderDto> GetByIdSliderAsync(string id);
    }
}
