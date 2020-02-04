using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NesopsService.Domain.Models
{
    public partial class AspNetUsersCreateModel
    {
        #region Generated Properties
        #endregion
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
