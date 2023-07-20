using ShopApp.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Istifadəçi Adı" + UiMessages.RequiredMessage)]
        //public string UserName { get; set; }

        [Required(ErrorMessage = "Email" + UiMessages.RequiredMessage)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə" + UiMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
