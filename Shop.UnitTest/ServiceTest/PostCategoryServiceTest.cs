using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using Shop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>() {
                new PostCategory() { ID=1,Name="DK1",Status=true },
                new PostCategory() { ID=2,Name="DK2",Status=true },
                new PostCategory() { ID=3,Name="DK3",Status=true }
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method getall sẽ return ra _listCategory
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //call action
            var result =_categoryService.GetAll() as List<PostCategory>;

            //compare 

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "test";
            postCategory.Alias = "test";
            postCategory.Status = true;
            _mockRepository.Setup(x => x.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });
            var result = _categoryService.Add(postCategory);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
