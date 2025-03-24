using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayProject.Application.Features.CQRS.Commands.AddressCommands;
using TakeAwayProject.Application.Features.CQRS.Handlers.AddressHandlers;
using TakeAwayProject.Application.Features.CQRS.Queries.AddressQueries;

namespace TakeAwayProject.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryResultHandler _getAddressQueryResultHandler;
        private readonly GetAddressByIdQueryResultHandler _getAddressByIdQueryResultHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryResultHandler getAddressQueryResultHandler, GetAddressByIdQueryResultHandler getAddressByIdQueryResultHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressQueryResultHandler = getAddressQueryResultHandler;
            _getAddressByIdQueryResultHandler = getAddressByIdQueryResultHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _getAddressQueryResultHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Hanlde(command);
            return Ok("Kayıt başarılya güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(RemoveAddressCommand command)
        {
            await _removeAddressCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var value = await _getAddressByIdQueryResultHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }
    }
}
