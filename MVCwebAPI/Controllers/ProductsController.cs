using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCwebAPI.Models;

namespace MVCwebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        static List<Product> _productList = new List<Product>()
        {
            new Product{ ID = 1, Name = "Mobile", Price = 450, Quantity = 2 },
            new Product{ ID = 2, Name = "TV", Price = 850, Quantity = 5 },
            new Product{ ID = 3, Name = "Laptop", Price = 1850, Quantity = 1 },
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productList);//suppose it's from database.
        }

        //httpGet capturing route parameters.
        //Route parameter names should be matched with action method's parameters.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productList.SingleOrDefault(x => x.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _productList.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id != null && id <= _productList.Count)
            {
                var product = _productList.Find(x => x.ID == id);
                _productList.Remove(product);
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            if (product != null)
            {
                var resultProduct = _productList.Find(x => x.ID == product.ID);
                resultProduct.ID = product.ID;
                resultProduct.Name = product.Name;
                resultProduct.Price = product.Price;
                resultProduct.Quantity = product.Quantity;
                return Ok(product);
            }
            return BadRequest();
        }
    }
}