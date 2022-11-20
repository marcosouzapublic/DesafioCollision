using DesafioCollision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Tests.Domain.Models
{
    [TestClass]
    public class CategoryProductTests
    {
        private readonly CategoryProduct _categoryProduct;
        private readonly Product _product;
        private readonly Category _category;

        public CategoryProductTests()
        {
            _category = new Category("Smartphone");
            _product = new Product("iPhone", "the best smartphone created", 999, 999);
            _categoryProduct = new CategoryProduct(_product, _category);
        }

        [TestMethod]
        public void CreateNewRelationship_Success()
        {
            Assert.IsTrue(_categoryProduct.IsValid);
        }

        [TestMethod]
        public void CreateNewRelationship_FailByProduct()
        {
            var product = new Product("", "", 0, 0);
            var categoryProduct = new CategoryProduct(product, _category);
            Assert.IsFalse(categoryProduct.IsValid);
        }

        [TestMethod]
        public void CreateNewRelationship_FailByCategory()
        {
            var category = new Category("");
            var categoryProduct = new CategoryProduct(_product, category);
            Assert.IsFalse(categoryProduct.IsValid);
        }
    }
}
