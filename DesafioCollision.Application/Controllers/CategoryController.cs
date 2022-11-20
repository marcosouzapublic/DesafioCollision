using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using DesafioCollision.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCollision.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly ICategoryQueries _queries;

        public CategoryController(ICategoryService service, ICategoryQueries queries)
        {
            _service = service;
            _queries = queries;
        }

        /// <summary>
        ///   Returns all categories
        /// </summary>
        /// <response code="200">Returns all categories.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal server error.</response>
        /// <returns>Returns all categories.</returns>
        [HttpGet]
        [Route("get-all")]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return Ok(_queries.GetAll());
        }

        /// <summary>
        ///   Returns one category based on category id
        /// </summary>
        /// <response code="200">Returns one category based on category id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Category not found.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="id">Unique identifier for a category</param>
        /// <returns>Returns one category based on category id.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public ActionResult<Category> GetById(Guid id)
        {
            return Ok(_queries.GetById(id));
        }

        /// <summary>
        ///   Returns all categories that match with inputed name
        /// </summary>
        /// <response code="200">Returns all categories that match with inputed name.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="name">Category name</param>
        /// <returns>Returns all categories that match with inputed name.</returns>
        [HttpGet]
        [Route("get-by-name")]
        public ActionResult<IEnumerable<Category>> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("The parameter name cannot be blank");

            return Ok(_queries.GetByName(name));
        }

        /// <summary>
        ///   Create a new category
        /// </summary>
        /// <response code="200">Category created sucessfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="name">Category name</param>
        [HttpPost]
        public ActionResult Post(string name)
        {
            var category = new Category(name);

            if(!category.IsValid)
                return BadRequest(category.Notifications);

            _service.Add(category);
            _service.SaveChanges();
            return Ok();
        }

        /// <summary>
        ///   Update category data
        /// </summary>
        /// <response code="200">Category updated sucessfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Category not found.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="id">Unique identifier for a category</param>
        /// <param name="name">Category name</param>
        [HttpPut]
        public ActionResult Put(Guid id, string name)
        {
            var category = _queries.GetById(id);

            if (category == null)
                return NotFound("Category not found");

            category.ChangeName(name);

            if (!category.IsValid)
                return BadRequest(category.Notifications);

            _service.Put(category);
            _service.SaveChanges();
            return Ok();
        }

        /// <summary>
        ///   Delete category
        /// </summary>
        /// <response code="200">Category deleted sucessfully.</response>
        /// <response code="400">Bad request/This category is been used by a product</response>
        /// <response code="404">Category not found.</response>
        /// <response code="500">Internal server error.</response>
        /// <param name="id">Unique identifier for a category</param>
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var category = _queries.GetById(id);

            if (category == null)
                return NotFound("Category not found");

            var usedByAProduct = _queries.InUse(category);

            if (usedByAProduct)
                return BadRequest("This category is been used by a product");

            _service.Remove(category);
            _service.SaveChanges();
            return Ok();
        }
    }
}