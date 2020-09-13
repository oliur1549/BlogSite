using Autofac.Extras.Moq;
using BlogSite.Framework.CategoryBS;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using BlogSite.Data;
using BlogSite.Framework;
using System.Linq.Expressions;
using System;
using Shouldly;

namespace BlogSite.UnitTest
{
    [ExcludeFromCodeCoverage]
    public class CategoryServiceTest
    {
        private AutoMock _mock;
        private Mock<ICategoryRepository> categoryRepository;
        private Mock<IBlogUnitOfWork> _blogUnitofWork;
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
            _blogUnitofWork = _mock.Mock<IBlogUnitOfWork>();
            categoryRepository = _mock.Mock<ICategoryRepository>();
            categoryService = _mock.Create<CategoryService>();
        }
        [TearDown]
        public void Clean()
        {
            _blogUnitofWork.Reset();
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
            var ctgMatching = new Category
            {
                Name = "test"
            };


            _blogUnitofWork.Setup(x => x.CategoryRepository)
                .Returns(categoryRepository.Object);

            categoryRepository.Setup(x => x.GetCount(
                It.Is<Expression<Func<Category, bool>>>(y => y.Compile()(ctgMatching))))
                .Returns(1).Verifiable();

            //Act
            Should.Throw<DuplicationException>(() =>
            categoryService.CreateCategory(ctg));
            
            
            //Assert
            categoryRepository.VerifyAll(); 
        }
        [Test]
        public void DeleteCategory_Categorydelete_DeleteById()
        {
            //Arrange
            var ctg = new Category
            {
                Id = 1,
                Name = "test"
            };
            var ctgMatching = new Category
            {
                Name = "test"
            };


            _blogUnitofWork.Setup(x => x.CategoryRepository)
                .Returns(categoryRepository.Object);

            categoryRepository.Setup(x => x.GetCount(
                It.Is<Expression<Func<Category, bool>>>(y => y.Compile()(ctgMatching))))
                .Returns(1).Verifiable();

            //Act
            Should.Throw<DuplicationException>(() =>
            categoryService.CreateCategory(ctg));


            //Assert
            categoryRepository.VerifyAll();
        }
    }
}