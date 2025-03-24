using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayProject.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;

namespace TakeAwayProject.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.ProductId = command.ProductId;
            value.ProductName = command.ProductName;
            value.Amount = command.Amount;
            value.OrderDetailId = command.OrderDetailId;
            value.Price = command.Price;
            value.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(value);
        }
    }
}
