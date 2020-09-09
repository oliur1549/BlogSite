using Autofac;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.CategoryModel
{
    public class CreateCategory : CategoryBaseModel
    {
        public CreateCategory(ICategoryService categoryService) : base(categoryService) { }
        public CreateCategory() { }


        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public void Create()
        {
            
            var category = new Category
            {
                Name = this.Name
            };

            _categoryService.CreateCategory(category);
        }
    }
}
