using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Data.Infrastructure;
using Service;
using System.Collections.Generic;
using Model.Models;

namespace UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategorySeviceTest
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
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {ID=1,Name="DM1",Status=true },
                new PostCategory() {ID=2,Name="DM2",Status=true },
                new PostCategory() {ID=3,Name="DM3",Status=true },
            };
        }
        [TestMethod]
        public void PosrCategory_Service_GetAll()
        {
            //setup method 
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);
            var result = _categoryService.GetAll() as List<PostCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
        [TestMethod]
        public void PosrCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "test category";
            category.Alias = "test-category";
            category.Status = true;
            category.Image = "img";
            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
                {
                    p.ID = 1;
                    return p;
                });
            var result = _categoryService.Add(category); 
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.ID);
        }
    }
}