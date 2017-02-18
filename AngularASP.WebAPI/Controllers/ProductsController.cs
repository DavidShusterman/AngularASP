using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using APM.WebAPI.Models;

namespace AngularASP.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:6197", "*", "*")]
    [EnableQuery]
    public class ProductsController : ApiController
    {
        // GET: api/Product
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.AsQueryable();
        }

        [EnableQuery]
        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();

            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }
            return product;

        }

        // POST: api/Product
        public void Post([FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var updatedProduct = productRepository.Save(id,product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
