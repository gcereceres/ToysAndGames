using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Dal;
using ToysAndGames.Dal.Models;

namespace ToysAndGames.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const string _serverErrorMsg = "There was an error on the server side if the problem persist call your administrator";
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

        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            _productRepository.CreateProduct(product);

            if (!_productRepository.Save())
            {
                return StatusCode(500, _serverErrorMsg);
            }

            return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, product);
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            if (productId < 0)
            {
                return BadRequest();
            }

            _productRepository.DeleteProduct(productId);

            if (!_productRepository.Save())
            {
                return StatusCode(500, _serverErrorMsg);
            }

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateProduct([FromBody] Product product)
        {
            if (!_productRepository.UpdateProduct(product))
            {
                return BadRequest();
            }
            else
            {
                if (!_productRepository.Save())
                {
                    return StatusCode(500, _serverErrorMsg);
                }

                return Ok();
            }
        }
    }
}
