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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                Amount = command.Amount,
                OrderDetailId = command.OrderingId,
                OrderingId = command.OrderingId,
                Price = command.Price,
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                TotalPrice = command.TotalPrice,
            });
        }
    }
}
