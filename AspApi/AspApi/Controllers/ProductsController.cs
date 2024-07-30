using AspApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspApi.Controllers
{
    public class ProductsController:ControllerBase
    {
        private readonly AppDbcontext _dbcontext;
        public ProductsController(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var records = _dbcontext.Set<Product>().ToList();
            return Ok(records);

        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var record = _dbcontext.Set<Product>().Find(id);
            return record == null ? NotFound() : Ok(record);
        }
        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct(Product product)
        {
            product.Id = 0;
            _dbcontext.Set<Product>().Add(product);
             _dbcontext.SaveChanges();
            return Ok(product.Id);
        }
        [HttpPut]
        [Route("")]
        public ActionResult UpdateProduct(Product product)
        {
            var Existingproduct = _dbcontext.Set<Product>().Find(product.Id); 
                Existingproduct.Name=product.Name;   
                Existingproduct.Sku=product.Sku;
               _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var Existingproduct=_dbcontext.Set<Product>().Find(id);
            _dbcontext.Set<Product>().Remove(Existingproduct);  
            _dbcontext.SaveChanges() ;  
            return Ok();

        }


    }
}
