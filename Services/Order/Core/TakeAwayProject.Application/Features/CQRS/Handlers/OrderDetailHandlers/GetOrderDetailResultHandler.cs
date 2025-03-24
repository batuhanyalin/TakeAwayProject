using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayProject.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;

namespace TakeAwayProject.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailResultHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailResultHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailResult>> Handle()
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailResult
            {
                Amount = x.Amount,
                OrderDetailId = x.OrderDetailId,
                OrderingId = x.OrderingId,
                Price = x.Price,
                ProductName = x.ProductName,
                TotalPrice = x.TotalPrice,
                ProductId = x.ProductId,
            }).ToList();
        }

    }
}