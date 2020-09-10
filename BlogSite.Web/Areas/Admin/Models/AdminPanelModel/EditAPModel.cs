using BlogSite.Framework.AdminPanelBS;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AdminPanelModel
{
    public class EditAPModel : APBaseModel
    {
        public EditAPModel(IAPService apService) : base(apService) { }
        public EditAPModel() { }

        public Guid Id { get; set; }
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
        public void Edit()
        {
            var user = new ApplicationUser
            {
                Id=this.Id,
                UserName = this.UserName,
                FullName = this.FullName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Status = this.Status
            };

            _apService.EditAP(user);
        }
        internal void Load(Guid id)
        {
            var user = _apService.GetUser(id);
            if (user != null)
            {
                Id = user.Id;
                UserName = user.UserName;
                FullName = user.FullName;
                Email = user.Email;
                PhoneNumber = user.PhoneNumber;
                Status = user.Status;
            }
        }
    }
}
