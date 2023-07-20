using ShopApp.Entity;
using ShopApp.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Name = "Name", Prompt = "Enter Product Name")]
        [Required(ErrorMessage = "Məhsul Adı" + UiMessages.RequiredMessage)]
        [StringLength(maximumLength: 50, ErrorMessage = "Məhsul adı 50" + UiMessages.StringLengthMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url"+ UiMessages.RequiredMessage)]
        [StringLength(maximumLength: 50, ErrorMessage = "Url 50" + UiMessages.StringLengthMessage)]
        public string Url { get; set; }

        [Required(ErrorMessage = "Qiymət" + UiMessages.RequiredMessage)]
        [Range(minimum: 1, maximum: 100000, ErrorMessage = "Qiymət mənfi və 0 ola bilməz")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Açıqlama"+ UiMessages.RequiredMessage)]
        [StringLength(maximumLength: 10000, ErrorMessage = "Açıqlama 5000" + UiMessages.StringLengthMessage)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Şəkil"+ UiMessages.RequiredMessage)]
        public string ImageUrl { get; set; }

        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
