using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayProject.Application.Features.CQRS.Queries.OrderDetailQueries;
using TakeAwayProject.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;

namespace TakeAwayProject.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryResultHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryResultHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value= await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdResult
            {
                Amount = value.Amount,
                OrderDetailId = value.OrderDetailId,
                OrderingId = value.OrderingId,
                Price = value.Price,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                TotalPrice=value.TotalPrice,
            };
        }
    }
}
