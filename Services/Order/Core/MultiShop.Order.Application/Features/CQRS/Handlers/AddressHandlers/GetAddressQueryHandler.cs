﻿using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var addresses = await _repository.GetAllAsync();
            return addresses.Select(x => new GetAddressQueryResult
            {
                Id = x.Id,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
