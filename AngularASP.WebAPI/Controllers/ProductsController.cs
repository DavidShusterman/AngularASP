using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using APM.WebAPI.Models;

namespace AngularASP.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:6197","*","*")]
    public class ProductsController : ApiController
    {
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve();
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
