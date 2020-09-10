using Autofac;
using BlogSite.Framework.AboutBS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AboutModel
{
    public class CreateAboutModel : AboutBaseModel
    {
        public CreateAboutModel(IAboutService aboutService) : base(aboutService) { }
        public CreateAboutModel() : base() { }

        [StringLength(30)]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Image { get; set; }
        [Required]
        public IFormFile imageFile { get; set; }

        public void Create()
        {
            var hostingEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();

            string wwwRootpath = hostingEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootpath + "/about/", fileName);

            var stream = new FileStream(path, FileMode.Create);
            imageFile.CopyToAsync(stream);

            var ab = new About
            {
                Title = this.Title,
                Description = this.Description,
                Image = fileName
            };


            _aboutService.CreateAbout(ab);
        }
    }
}
