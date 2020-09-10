using Autofac.Extras.Moq;
using BlogSite.Framework.CategoryBS;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using BlogSite.Data;

namespace BlogSite.UnitTest
{
    [ExcludeFromCodeCoverage]
    public class CategoryServiceTest
    {
        private AutoMock _mock;
        private Mock<ICategoryRepository> categoryRepository;
        private ICategoryService categoryService;
        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {

            categoryRepository = _mock.Mock<ICategoryRepository>();
            categoryService = _mock.Create<CategoryService>();
        }
        [TearDown]
        public void Clean()
        {
            categoryRepository.Reset();
        }


        [Test]
        public void CreateCategory_CategoryInsert_ThroaghExcetion()
        {
            //Arrange
            var ctg = new Category
            {
                Id = 1,
                Name = "test"
            };



            categoryRepository.Setup(x => x.Add(ctg)).Verifiable();


            //Act

            categoryService.CreateCategory(ctg);


            //Assert
            categoryRepository.VerifyAll(); 
        }
    }
}