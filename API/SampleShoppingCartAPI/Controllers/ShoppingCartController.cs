using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SampleShoppingCartAPI.Business;
using SampleShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SampleShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IBaseBusiness _baseBusiness;
        private readonly IShoppingCartBusiness _shoppingCartBusiness;
        private readonly ShoppingCartSampleContext _context;
        public ShoppingCartController(IShoppingCartBusiness shoppingService, IBaseBusiness baseBusiness, ShoppingCartSampleContext shoppingContext)
        {
            _shoppingCartBusiness = shoppingService;
            _baseBusiness = baseBusiness;
            _context = shoppingContext;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var result = _shoppingCartBusiness.GetProducts();
            if (result != null)
                return Ok(new JsonResult(result) { StatusCode = (int)HttpStatusCode.OK });

            return BadRequest(new JsonResult("") { StatusCode = (int)HttpStatusCode.BadRequest });
        }
        [HttpGet("GetProductByID")]
        public IActionResult GetProductByID(int id)
        {
            var result = _shoppingCartBusiness.GetProductByID(id);
            if (result != null)
                return Ok(new JsonResult(result) { StatusCode = (int)HttpStatusCode.OK });

            return BadRequest(new JsonResult("") { StatusCode = (int)HttpStatusCode.BadRequest });
        }
        [HttpPost("AddToCart")]
        public IActionResult AddToCart(int id)
        {
            _shoppingCartBusiness.AddToCart(id);

            return Ok(new JsonResult("") { StatusCode = (int)HttpStatusCode.OK });


        }
        [HttpPost("DeleteCart")]
        public IActionResult DeleteCart(int id)
        {
            _shoppingCartBusiness.DeleteCart(id);

            return Ok(new JsonResult("") { StatusCode = (int)HttpStatusCode.OK });


        }
        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            var result = _shoppingCartBusiness.Checkout();
            if (result != null)
                return Ok(new JsonResult(result) { StatusCode = (int)HttpStatusCode.OK });

            return BadRequest(new JsonResult("") { StatusCode = (int)HttpStatusCode.BadRequest });
        }

        [HttpGet("getCartCount")]
        public IActionResult getCartCount()
        {
            int cartCount = 0;
            var result = _shoppingCartBusiness.getCartCount();
            if (result != null)
                return Ok(new JsonResult(result) { StatusCode = (int)HttpStatusCode.OK });

            return BadRequest(new JsonResult("") { StatusCode = (int)HttpStatusCode.BadRequest });
        }
    }
}
