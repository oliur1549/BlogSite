using Autofac;
using BlogSite.Framework.BlogBS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.BlogModel
{
    public class EditBlog : BlogBaseModel
    {
        public EditBlog(IBlogService blogService) : base(blogService) { }
        public EditBlog() { }


        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [StringLength(30)]

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Required]
        public DateTime datetime { get; set; }

        public string Image { get; set; }
        public int CategoryId { get; set; }

        public IFormFile imageFile { get; set; }


        public void Create()
        {
            var hostingEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();

            string wwwRootpath = hostingEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootpath + "/image/", fileName);

            var stream = new FileStream(path, FileMode.Create);
            imageFile.CopyToAsync(stream);

            var blog = new Blog
            {
                Title = this.Title,
                Text = this.Text,
                datetime = this.datetime,
                Image = this.Image,
                CategoryId = this.CategoryId
            };

            _blogService.Editblog(blog);
        }
    }
}
