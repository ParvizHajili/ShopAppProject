using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class OrderModel
    {
        [Display(Name ="Ad")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Display(Name = "Ünvan")]
        public string Address { get; set; }

        [Display(Name = "Qeyd")]
        public string Note { get; set; }

        [Display(Name = "Şəhər")]
        public string City { get; set; }

        [Display(Name = "Əlaqə Nömrəsi")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        //card info

        [Display(Name = "Kart Adı")]
        public string CardName { get; set; }

        [Display(Name = "Kart Nömrəsi")]
        public string CardNumber { get; set; }

        [Display(Name = "Ay")]
        public string ExpirationMonth { get; set; }

        [Display(Name = "İl")]
        public string ExpirationYear { get; set; }

        [Display(Name = "Cvv")]
        public string CVV { get; set; }


        public CartModel CartModel { get; set; }
    }
}
