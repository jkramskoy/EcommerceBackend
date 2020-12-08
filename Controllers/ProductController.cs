using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            int id = _context.Products.AsEnumerable().Last().Id + 1;

            Product pr = new Product
            {
                Id = id,
                Name = value.Name,
                Price = value.Price,
                PhotoPath = value.PhotoPath
            };

            _context.Products.Add(pr);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            Product pr = _context.Products.Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (pr != null)
            {
                pr.Name = value.Name;
                pr.Price = value.Price;

                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Product pr = _context.Products.Find(id);
            _context.Products.Remove(pr);
            _context.SaveChanges();
        }

    }
}
