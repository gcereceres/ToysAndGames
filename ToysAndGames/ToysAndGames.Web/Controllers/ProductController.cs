using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Dal;
using ToysAndGames.Web.ViewModels;

namespace ToysAndGames.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(_productRepository.GetProducts());
        }

        [HttpGet("{productId}")]
        public ActionResult GetProductById(int productId)
        {
            return Ok(_productRepository.GetProductById(productId));
        }
    }
}
