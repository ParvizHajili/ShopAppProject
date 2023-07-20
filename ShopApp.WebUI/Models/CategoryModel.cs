using ShopApp.Entity;
using ShopApp.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kateqoriya Adı"+UiMessages.RequiredMessage)]
        [StringLength(maximumLength:50,ErrorMessage = "Kateqoriya Adı"+UiMessages.StringLengthMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url" + UiMessages.RequiredMessage)]
        [StringLength(maximumLength: 50, ErrorMessage = "Url 50" + UiMessages.StringLengthMessage)]
        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}
