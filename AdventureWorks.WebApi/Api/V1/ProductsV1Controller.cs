using AdventureWorks.Services.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.WebApi.Api.V1
{
    [RoutePrefix("api/v1/products")]
    public class ProductsV1Controller : ApiController
    {
        private readonly IProductService productService = new ProductService();

        // GET: api/Products
        [Route("")]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }

        // GET: api/Products/5
        [Route("{id:int}")]
        public Product Get(int id)
        {
            return productService.GetProduct(id);
        }

        // POST: api/Products
        [Route("")]
        public void Post([FromBody]Product product)
        {
            productService.CreateProduct(product);
        }

        // PUT: api/Products/5
        [Route("{id:int}")]
        public void Put(int id, [FromBody]Product product)
        {
            product.Id = id;
            productService.UpdateProduct(product);
        }

        // DELETE: api/Products/5
        [Route("{id:int}")]
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}
