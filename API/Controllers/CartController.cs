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
    public class CartController : BaseApiController
    {
        private readonly ICartRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICartValidator _validator;

        public CartController(ICartRepository repo, IMapper mapper, ICartValidator validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult> AddToShopingCart(int customerId, int productId, int quantity)
        {
            var validation = _validator.AddToShopingCartValidate(customerId, productId, quantity);
            if (validation.Success == false)
                return BadRequest(validation.ErrorMessage);

            var response = await _repo.AddProductToCartAsync(customerId, productId, quantity);

            if (response.Success == false)
                return NotFound(response.ErrorMessage);
            return Ok(response.Value);
        }

        [HttpGet]
        public ActionResult GetCartContent(int customerId)
        {
            var validation = _validator.GetCartContentValidate(customerId);
            if (validation.Success == false)
                return BadRequest(validation.ErrorMessage);

            var response = _repo.GetCartContentByCustomerId(customerId);

            if (response.Success == false)
                return NotFound(response.ErrorMessage);
            return Ok(_mapper.Map<List<Cart>, List<CartDto>>(response.Value));
        }
    }
}
