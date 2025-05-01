using Newtonsoft.Json;
using TakeAway.WebUI.Dtos.CatalogDtos;

namespace TakeAway.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductService> _logger;
        public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("http://localhost:8001/api/product");
                if (responseMessage != null)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                    return values;
                }
                else
                {
                    return new List<ResultProductDto>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürünleri alırken hata oluştu.");
                return new List<ResultProductDto>();
            }
        }
    }
}
