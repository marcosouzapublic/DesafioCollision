using DesafioCollision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Tests.Domain.Models
{
    [TestClass]
    public class CategoryTests
    {
        private readonly Category _category;

        public CategoryTests()
        {
            _category = new Category("Smartphone");
        }

        [TestMethod]
        public void CreateNewCategory_Success()
        {
            var category = new Category("Smartphone");

            Assert.IsTrue(category.IsValid);
        }

        [TestMethod]
        public void CreateNewCategory_Fail()
        {
            var category = new Category("");

            Assert.IsFalse(category.IsValid);
        }

        [TestMethod]
        public void ChangeName_Success()
        {
            _category.ChangeName("Cellphone");

            Assert.IsTrue(_category.IsValid);
        }

        [TestMethod]
        public void ChangeName_Fail()
        {
            _category.ChangeName("");

            Assert.IsFalse(_category.IsValid);
        }
    }
}
