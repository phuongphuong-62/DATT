using Data.Infrastructure;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Models;
using System.Linq;

namespace UnitTest.ReponsitoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository  objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);

        }
        [TestMethod]
        public void PostCategory_Reponsitory_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void PostCategory_Reponsitory_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "test category";
            category.Alias= "test-category";
            category.Status =true;
            category.Image = "img";
            var result = objRepository.Add(category);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.ID);
        }
    }
}