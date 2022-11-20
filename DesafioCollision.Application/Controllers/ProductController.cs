using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using DesafioCollision.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DesafioCollision.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ICategoryProductService _categoryProductService;
        private readonly IProductQueries _productQueries;
        private readonly ICategoryQueries _categoryQueries;

        public ProductController(IProductService service, IProductQueries productQueries, ICategoryQueries categoryQueries, ICategoryProductService categoryProductService)
        {
            _service = service;
            _productQueries = productQueries;
            _categoryQueries = categoryQueries;
            _categoryProductService = categoryProductService;
        }

        /// <summary>
        ///   Returns all products
        /// </summary>
        /// <response code="200">Returns all products.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal server error.</response>
        /// <returns>Returns all products.</returns>
        [HttpGet]
        [Route("get-all")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productQueries.GetAll());
        }

        /// <summary>
        ///   Returns one product based on product id
        /// </summary>
        /// <response code="200">Returns one product based on product id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Product not found.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="id">Unique identifier for a product</param>
        /// <returns>Returns one product based on product id.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public ActionResult<Category> GetById(Guid id)
        {
            return Ok(_productQueries.GetById(id));
        }

        /// <summary>
        ///   Returns all products that match with inputed name
        /// </summary>
        /// <response code="200">Returns all products that match with inputed name.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="name">Product name</param>
        /// <returns>Returns all products that match with inputed name.</returns>
        [HttpGet]
        [Route("get-by-name")]
        public ActionResult<IEnumerable<Category>> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("The parameter name cannot be blank");

            return Ok(_productQueries.GetByName(name));
        }

        /// <summary>
        ///   Create a new product
        /// </summary>
        /// <response code="200">Product created sucessfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="name">Product name</param>
        /// <param name="description">A brief description about the product</param>
        /// <param name="price">Product price</param>
        /// <param name="amount">Product amount</param>
        /// <param name="categoriesGuidList">Categories guid list</param>
        [HttpPost]
        public ActionResult Post(string name, string description, decimal price, decimal amount, ICollection<Guid> categoriesGuidList)
        {
            if (categoriesGuidList.IsNullOrEmpty())
                return BadRequest("The category list cannot be empty");

            var product = new Product(name, description, price, amount);

            if (!product.IsValid)
                return BadRequest(product.Notifications);

            var relationship = new List<CategoryProduct>();

            foreach (var guid in categoriesGuidList)
                relationship.Add(new CategoryProduct(product, _categoryQueries.GetById(guid)));

            _service.Add(product);
            _service.SaveChanges();

            //structure to revert the new product added.
            try
            {
                _categoryProductService.AddRange(relationship);
                _categoryProductService.SaveChanges();
            }
            catch (Exception exception)
            {
                _service.Remove(product);
                _service.SaveChanges();

                throw new Exception("The operation was reverted: " + exception.Message);
            }            

            return Ok();
        }

        /// <summary>
        ///   Update product data
        /// </summary>
        /// <response code="200">Product updated sucessfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Product not found.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="id">Unique identifier for a product</param>
        /// <param name="name">Product name</param>
        /// <param name="description">A brief description about the product</param>
        /// <param name="price">Product price</param>
        /// <param name="amount">Product amount</param>
        /// <param name="categoriesGuidList">Categories guid list</param>
        [HttpPut]
        public ActionResult Put(Guid id, string name, string description, decimal price, decimal amount, ICollection<Guid> categoriesGuidList)
        {
            if (categoriesGuidList.IsNullOrEmpty())
                return BadRequest("The category list cannot be empty");

            var product = _productQueries.GetById(id);
            var productCopy = product;

            if (product == null)
                return NotFound("Product not found");

            product.Put(name, description, price, amount);

            if (!product.IsValid)
                return BadRequest(product.Notifications);

            //Deleting old categories
            _categoryProductService.RemoveAllByProductId(id);

            //Adding new categories
            var relationship = new List<CategoryProduct>();
            foreach (var guid in categoriesGuidList)
                relationship.Add(new CategoryProduct(product, _categoryQueries.GetById(guid)));

            _service.Put(product);
            _service.SaveChanges();

            //structure to revert the changes.
            try
            {
                _categoryProductService.AddRange(relationship);
                _categoryProductService.SaveChanges();
            }
            catch (Exception exception)
            {
                _service.Put(productCopy);
                _service.SaveChanges();

                throw new Exception("The operation was reverted: " + exception.Message);
            }

            return Ok();
        }

        /// <summary>
        ///   Delete product
        /// </summary>
        /// <response code="200">Product deleted sucessfully.</response>
        /// <response code="404">Product not found.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="id">Unique identifier for a product</param>
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var product = _productQueries.GetById(id);

            if (product == null)
                return NotFound("Product not found");

            _service.Remove(product);
            _service.SaveChanges();
            return Ok();
        }
    }
}
