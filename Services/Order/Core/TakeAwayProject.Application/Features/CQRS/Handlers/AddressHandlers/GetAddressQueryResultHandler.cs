using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayProject.Application.Features.CQRS.Results.AddressResults;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;

namespace TakeAwayProject.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryResultHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryResultHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(x => new GetAddressQueryResult
            {
                City = x.City,
                AddressId = x.AddressId,
                Detail = x.Detail,
                District = x.District,
                Name = x.Name,
                UserId = x.UserId,
            }).ToList();

        }
    }
}
