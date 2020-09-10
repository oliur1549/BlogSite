using Autofac.Extras.Moq;
using BlogSite.Framework.CategoryBS;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using BlogSite.Data;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework;
using System;
using System.Linq.Expressions;
using Shouldly;
using Nest;
using System.Collections.Generic;
using System.Linq;

namespace BlogSite.UnitTest
{
    [ExcludeFromCodeCoverage]
    public class BlogServiceTest
    {
        private AutoMock _mock;
        private Mock<IBlogRepository> _blogRepository;
        private Mock<IBlogUnitOfWork> _blogUnitofWork;
        private IBlogService _blogService;
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
            _blogRepository = _mock.Mock<IBlogRepository>();
            _blogService = _mock.Create<BlogService>();
        }
        [TearDown]
        public void Clean()
        {
            _blogUnitofWork.Reset();
            _blogRepository.Reset();
        }


        [Test]
        public void CreateBlog_BlogInsert_ThroaghExcetion()
        {
            //Arrange
            var blog = new Blog
            {
                Id = 1,
                Title = "test2",
                Text = "Abcd",
                datetime=DateTime.Now,
                CategoryId=1
            };

            var blogMatching = new Blog
            {
                Title = "test1"
            };

            _blogUnitofWork.Setup(x => x.BlogRepository)
                .Returns(_blogRepository.Object);

            //for matching

            //_blogRepository.Setup(x => x.GetCount(
            //    It.Is<Expression<Func<Blog, bool>>>(y => y.Compile()(blog))))
            //    .Returns(1).Verifiable();

            _blogRepository.Setup(x => x.Add(blog)).Verifiable();
 

            //Act

             _blogService.Createblog(blog);


            //Assert
            _blogRepository.VerifyAll(); 
        }
        [Test]
        public void CreateBlog_BlogMatching_ThroaghExcetion()
        {
            //Arrange
            var blog = new Blog
            {
                Id = 1,
                Title = "test1",
                Text = "Abcd",
                datetime = DateTime.Now,
                CategoryId = 1
            };

            var blogMatching = new Blog
            {
                Title = "test1"
            };

            _blogUnitofWork.Setup(x => x.BlogRepository)
                .Returns(_blogRepository.Object);

            //for matching

            _blogRepository.Setup(x => x.GetCount(
                It.Is<Expression<Func<Blog, bool>>>(y => y.Compile()(blogMatching))))
                .Returns(1).Verifiable();




            //Act
            Should.Throw<DuplicationException>(()=>
            _blogService.Createblog(blog)
            );
            


            //Assert
            _blogRepository.VerifyAll();
        }
        [Test]
        public void UpdateBlog_BlogMatching_ThroaghExcetion()
        {
            //Arrange
            var blog = new Blog
            {
                Id = 1,
                Title = "test1",
                Text = "Abcd",
                datetime = DateTime.Now,
                CategoryId = 1
            };

            var blogMatching = new Blog
            {
                Title = "test1"
            };

            _blogUnitofWork.Setup(x => x.BlogRepository)
                .Returns(_blogRepository.Object);

            //for matching

            _blogRepository.Setup(x => x.GetCount(
                It.Is<Expression<Func<Blog, bool>>>(y => y.Compile()(blogMatching))))
                .Returns(1).Verifiable();




            //Act
            Should.Throw<DuplicationException>(() =>
            _blogService.Editblog(blog)
            );



            //Assert
            _blogRepository.VerifyAll();
        }
        [Test]
        public void DeleteBlog_BlogMatching_ThroaghExcetion()
        {
            //Arrange
            var blog = new Blog
            {
                Id = 1,
                Title = "test1",
                Text = "Abcd",
                datetime = DateTime.Now,
                CategoryId = 1
            };


            _blogUnitofWork.Setup(x => x.BlogRepository)
                .Returns(_blogRepository.Object);

            //for matching

            _blogRepository.Setup(x => x.GetById(blog.Id));
            
            //Act
            _blogService.Deleteblog(blog.Id);

            //Assert
            _blogRepository.VerifyAll();
        }
        [Test]
        public void GetBlog_BlogGetAll_GetAllRecords()
        {
            //Arrange
            var blog = new List<Blog>()
            {
                new Blog { Id = 1, Title="test", Text = "Apress", datetime=DateTime.Now, CategoryId = 1 },
                new Blog { Id = 2, Title="test1", Text = "Apress1", datetime=DateTime.Now, CategoryId = 1 },
                new Blog { Id = 3, Title="test2", Text = "Apress2", datetime=DateTime.Now, CategoryId = 1 }
                
            };


            _blogUnitofWork.Setup(x => x.BlogRepository)
                .Returns(_blogRepository.Object);

            //for matching

            _blogRepository.Setup(x => x.GetAll());

            //Act
            _blogService.GetBlog(0, 2, "test", "Title");

            //Assert
            _blogRepository.VerifyAll();
        }
        [Test]
        public void Getblog_GetBlogbyID_GetAllRecords()  
        {
            //Arrange
            var blog = new List<Blog>()
            {
                new Blog { Id = 1, Title="test", Text = "Apress", datetime=DateTime.Now, CategoryId = 1 },
                new Blog { Id = 2, Title="test1", Text = "Apress1", datetime=DateTime.Now, CategoryId = 1 },
                new Blog { Id = 3, Title="test2", Text = "Apress2", datetime=DateTime.Now, CategoryId = 1 }

            };


            _blogUnitofWork.Setup(x => x.BlogRepository)
                .Returns(_blogRepository.Object);

            //for matching

            _blogRepository.Setup(x => x.GetById(2));

            //Act
            _blogService.Getblog(2);

            //Assert
            _blogRepository.VerifyAll();
        }
        
    }
}