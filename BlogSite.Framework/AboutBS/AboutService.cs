using BlogSite.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.AboutBS
{
    public class AboutService : IAboutService
    {
        public IBlogUnitOfWork _blogUnitOfWork;
        public AboutService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public void CreateAbout(About ab)
        {
            var count = _blogUnitOfWork.AboutRepository.GetCount(x => x.Title == ab.Title);
            if (count > 0)
                throw new DuplicationException("Title already exists", nameof(ab.Title));

            _blogUnitOfWork.AboutRepository.Add(ab);
            _blogUnitOfWork.Save();
        }

        public About DeleteSlide(int id)
        {
            var aboutProp = _blogUnitOfWork.AboutRepository.GetById(id);
            _blogUnitOfWork.AboutRepository.Remove(aboutProp);
            _blogUnitOfWork.Save();
            return aboutProp;
        }

        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }

        public void EditAbout(About eab)
        {
            var aboutProp = _blogUnitOfWork.AboutRepository.GetById(eab.Id);
            aboutProp.Id = eab.Id;
            aboutProp.Title = eab.Title;
            aboutProp.Description = eab.Description;
            aboutProp.Image = eab.Image;
            _blogUnitOfWork.Save();
        }

        public (IList<About> records, int total, int totalDisplay) GetAbout(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.AboutRepository.GetAll();
            return (result, 0, 0);
        }

        public About GetAbout(int id)
        {
            return _blogUnitOfWork.AboutRepository.GetById(id);
        }
    }
}
