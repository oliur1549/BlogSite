using BlogSite.Framework.AdminPanelBS;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AdminPanelModel
{
    public class CreateAPModel : APBaseModel
    {
        public CreateAPModel(IAPService apService) : base(apService) { }
        public CreateAPModel() { }


        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }


        public void Create()
        {
            var user = new ApplicationUser
            {
                UserName = this.UserName,
                FullName = this.FullName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Status = this.Status
            };

            _apService.CreateAP(user);
        }
    }
}
