using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.EmailServices;
using ShopApp.WebUI.Extensions;
using ShopApp.WebUI.Helpers;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;
        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager, IEmailSender emailSender, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
        }
        public IActionResult Login(string ReturnUrl=null)
        {

            return View(new LoginModel
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Login(LoginModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginModel);
            }

            //var user = await _userManager.FindByNameAsync(loginModel.UserName);
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if(user==null)
            {
                ModelState.AddModelError("", "İstifadəçi adı mövcud deyil");
                return View(loginModel);
            }

            if(! await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Zəhmət olmasa email adresinizə gələn link ilə hesabınızı təsdiqləyin");

                return View(loginModel);
            }


            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false,false);
            if(result.Succeeded)
            {
                return Redirect(loginModel.ReturnUrl??"~/");
            }
            ModelState.AddModelError("", "Istifadəçi adı və ya şifrə yanlışdır");
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(RegisterModel registerModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var user = new User()
            {
                FirstName = registerModel.FirstName,
                LastName=registerModel.LastName,
                UserName=registerModel.UserName,
                Email=registerModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if(result.Succeeded)
            {
                //////////////////////////////////////////////
                await _userManager.AddToRoleAsync(user, "Customer");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new { 
                    userId=user.Id,
                    token=code
                });
                await _emailSender.SendEmailAsync(registerModel.Email, "Hesab Doğrulaması",$"Zəhmət olmasa hesabınızı təsdiqləmək üçün linkə <a href='https://localhost:44318{url}'> keçid edin </a>");

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("Password", "Bilinməyən xəta baş verdi zəhmət olmasa yenidən cəhd edin");
            return View(registerModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData.Put("message", new AlertMessage()
            {
                Title = "Hesabdan çıxış edildi",
                Message = " ",
                AlertType = "success"
            });

            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId==null || token==null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title= "Invalid Token",
                    Message= "Invalid Token",
                    AlertType= "danger"
                });
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //create cart object
                    _cartService.InitializeCart(userId);
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Hesabınız Təsdiqləndi",
                        Message = "Hesabınız Təsdiqləndi",
                        AlertType = "success"
                    });
                    return View();
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Hesabınız Təsdiqlənmədi",
                Message = "Hesabınız Təsdiqlənmədi",
                AlertType = "warning"
            });
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if(user==null)
            {
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            await _emailSender.SendEmailAsync(Email, "Şifrənizi yeniləyin", $"Şifrənizi yeniləmək üçün linkə <a href='https://localhost:44318{url}'>keçid edin!</a>");

            return View();

        }

        public IActionResult ResetPassword(string userId,string token)
        {
            if(userId==null || token==null)
            {
                return RedirectToAction("Home", "Index");
            }

            var model = new ResetPasswordModel { Token = token };

            return View();
        }

        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if(!ModelState.IsValid)
            {
                return View(resetPasswordModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if(user==null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }


            return View(resetPasswordModel);
        }

        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
