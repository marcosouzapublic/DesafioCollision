using DesafioCollision.Domain.Queries;
using DesafioCollision.Tests.Infra.Queries.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Tests.Infra.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private readonly IProductQueries _queries;

        public ProductQueriesTests()
        {
            _queries = new MockProductQueries();
        }

        [TestMethod]
        public void GetAll()
        {
            Assert.AreNotEqual(0, _queries.GetAll());
        }

        [TestMethod]
        public void GetById_Success()
        {
            var firstElement = _queries.GetAll().First();

            Assert.IsNotNull(_queries.GetById(firstElement.Id));
        }

        [TestMethod]
        public void GetById_Fail()
        {
            Assert.IsNull(_queries.GetById(Guid.NewGuid()));
        }

        [TestMethod]
        public void GetByName_Success()
        {
            var firstElement = _queries.GetAll().First();

            Assert.AreNotEqual(0, _queries.GetByName(firstElement.Name).Count());
        }

        [TestMethod]
        public void GetByName_Fail()
        {
            Assert.AreEqual(0, _queries.GetByName("blabla").Count());
        }
    }
}
