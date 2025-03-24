using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayProject.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAwayProject.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TakeAwayProject.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace TakeAwayProject.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryResultHandler _getOrderDetailByIdQueryResultHandler;
        private readonly GetOrderDetailResultHandler _getOrderDetailResultHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailByIdQueryResultHandler getOrderDetailByIdQueryResultHandler, GetOrderDetailResultHandler getOrderDetailResultHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailByIdQueryResultHandler = getOrderDetailByIdQueryResultHandler;
            _getOrderDetailResultHandler = getOrderDetailResultHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _getOrderDetailResultHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value= await _getOrderDetailByIdQueryResultHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(RemoveOrderDetailCommand command)
        {
            await _removeOrderDetailCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla silindi.");
        }
        [HttpPost]
        public async Task<IActionResult>CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla güncellendi.");
        }
    }
}
