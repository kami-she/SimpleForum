using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumWebApplication.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@".+@.+\..+", ErrorMessage = "Your e-mail is incorrect")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}