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

        public CartController(ICartRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> AddToShopingCart(int customerId, int productId, int quantity)
        {
            var response = await _repo.AddProductToCartAsync(customerId, productId, quantity);

            if (response.Success == false)
                return NotFound(response.ErrorMessage);
            return Ok(response.Value);
        }

        [HttpGet]
        public ActionResult GetCartContent(int customerId)
        {
            var response = _repo.GetCartContentByCustomerId(customerId);

            if (response.Success == false)
                return NotFound(response.ErrorMessage);
            return Ok(response.Value);
        }
    }
}
