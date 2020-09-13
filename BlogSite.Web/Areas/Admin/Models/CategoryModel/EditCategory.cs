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
    public class EditCategory : CommentBaseModel
    {
        public EditCategory(ICategoryService categoryService) : base(categoryService) { }
        public EditCategory() { }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        public void Edit()
        {

            var category = new Category
            {
                Id = this.Id,
                Name = this.Name
            };

            _categoryService.EditCategory(category);
        }

        internal void Load(int id)
        {
            var ctg = _categoryService.GetCategory(id);

            if (ctg != null)
            {
                Id = ctg.Id;
                Name = ctg.Name;

            }
        }
    }
}
