using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //https://localhost:44318/

        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetHomePageProducts()
            };

            return View(productViewModel);
        }


        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> GetProductsFromRestApi()
        {
            var products = new List<Product>();

            using(var httpClient=new HttpClient())
            {
                using(var response= await httpClient.GetAsync("https://localhost:44377/api/products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(products);
        }

        public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}
