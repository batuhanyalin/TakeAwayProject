using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayProject.Application.Features.CQRS.Queries.AddressQueries;
using TakeAwayProject.Application.Features.CQRS.Results.AddressResults;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;

namespace TakeAwayProject.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryResultHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryResultHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                City = value.City,
                Detail = value.Detail,
                District = value.District,
                Name = value.Name,
                UserId = value.UserId,
            };
        }
    }
}
