using ShopApp.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ad" + UiMessages.RequiredMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad" + UiMessages.RequiredMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "İstifadəçi Adı" + UiMessages.RequiredMessage)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrə" + UiMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə Təkrarı" + UiMessages.RequiredMessage)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Email" + UiMessages.RequiredMessage)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
