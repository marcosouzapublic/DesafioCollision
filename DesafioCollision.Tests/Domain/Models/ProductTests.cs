using DesafioCollision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Tests.Domain.Models
{
    [TestClass]
    public class ProductTests
    {
        private readonly Product _product;

        public ProductTests()
        {
            _product = new Product("iPhone", "the best smartphone created", 999, 999);
        }

        [TestMethod]
        public void CreateNewProduct_Success()
        {
            var product = new Product("iPhone", "the best smartphone created", 999, 999);

            Assert.IsTrue(product.IsValid);
        }

        [TestMethod]
        public void CreateNewProduct_FailByName()
        {
            var product = new Product("", "the best smartphone created", 999, 999);

            Assert.IsFalse(product.IsValid);
        }

        [TestMethod]
        public void CreateNewProduct_FailByDescription()
        {
            var product = new Product("iPhone", "", 999, 999);

            Assert.IsFalse(product.IsValid);
        }

        [TestMethod]
        public void CreateNewProduct_FailByPrice()
        {
            var product = new Product("iPhone", "the best smartphone created", -999, 999);

            Assert.IsFalse(product.IsValid);
        }

        [TestMethod]
        public void CreateNewProduct_FailByAmount()
        {
            var product = new Product("iPhone", "the best smartphone created", 999, -999);

            Assert.IsFalse(product.IsValid);
        }

        [TestMethod]
        public void Put_Success()
        {
            _product.Put("iPhone 13 Pro Max", "the best smartphone created", 999, 999);

            Assert.IsTrue(_product.IsValid);
        }

        [TestMethod]
        public void Put_FailByName()
        {
            _product.Put("", "", 0, 0);

            Assert.IsFalse(_product.IsValid);
        }
    }
}
