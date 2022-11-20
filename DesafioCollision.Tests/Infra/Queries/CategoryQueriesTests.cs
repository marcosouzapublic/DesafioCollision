using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using DesafioCollision.Tests.Infra.Queries.Mocks;

namespace DesafioCollision.Tests.Infra.Queries
{
    [TestClass]
    public class CategoryQueriesTests
    {
        private readonly ICategoryQueries _queries;

        public CategoryQueriesTests()
        {
            _queries = new MockCategoryQueries();
        }

        [TestMethod]
        public void GetAll()
        {
            Assert.AreNotEqual(0, _queries.GetAll().Count());
        }

        [TestMethod]
        public void GetAllById_Success()
        {
            var firstItem = _queries.GetAll().First();

            Assert.IsNotNull(_queries.GetById(firstItem.Id));
        }

        [TestMethod]
        public void GetAllById_Fail()
        {
            var randomGuid = Guid.NewGuid();

            Assert.IsNull(_queries.GetById(randomGuid));
        }

        [TestMethod]
        public void GetAllByName_Success()
        {
            var firstItem = _queries.GetAll().First();

            Assert.AreNotEqual(0, _queries.GetByName(firstItem.Name).Count());
        }

        [TestMethod]
        public void GetAllByName_Fail()
        {
            var firstItem = string.Empty;

            Assert.AreEqual(0, _queries.GetByName(firstItem).Count());
        }

        [TestMethod]
        public void GetCategoriesFromGuidList_Success()
        {
            var firstItem = _queries.GetAll().First().Id;
            var secondItem = _queries.GetAll().ElementAt(1).Id;
            var list = new List<Guid>() { firstItem, secondItem };

            Assert.AreNotEqual(0, _queries.GetCategoriesFromGuidList(list).Count());
        }

        [TestMethod]
        public void GetCategoriesFromGuidList_Fail()
        {
            var firstItem = Guid.NewGuid();
            var secondItem = Guid.NewGuid();
            var list = new List<Guid>() { firstItem, secondItem };

            Assert.AreEqual(0, _queries.GetCategoriesFromGuidList(list).Count());
        }

        [TestMethod]
        public void InUse_TrueCase()
        {
            var firstItem = _queries.GetAll().First();

            Assert.IsTrue(_queries.InUse(firstItem));
        }

        [TestMethod]
        public void InUse_FalseCase()
        {
            var category = new Category("new name");

            Assert.IsFalse(_queries.InUse(category));
        }
    }
}
