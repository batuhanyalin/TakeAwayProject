using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayProject.Application.Features.Mediator.Queries.OrderingQueries;
using TakeAwayProject.Application.Features.Mediator.Results.OrderingResults;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;

namespace TakeAwayProject.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryResultHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryResultHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = value.OrderDate,
                OrderingId = value.OrderingId,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId,
            };
        }
    }
}
