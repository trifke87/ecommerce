using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(int customerId, AddressDto address, string phoneNumber)
        {
            var response = await _repo.CreateOrder(customerId, _mapper.Map<AddressDto, Address>(address), phoneNumber);

            if (response.Success == false)
                return NotFound(response.ErrorMessage);
            return Ok(_mapper.Map<Order,OrderDto>(response.Value));
        }
    }
}
