using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System.Linq;

namespace Shop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IPostCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]//chạy lần đầu tiên khi ứng dụng chạy
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll();
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category";
            category.Alias = "Test-Category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}