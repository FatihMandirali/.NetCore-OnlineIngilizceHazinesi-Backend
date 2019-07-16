using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KullanicilarService;
using Application.WordService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace OnlineIngilizceHazinesi.Controllers
{
    public class YonetimController : Controller
    {
        private readonly IKullanicilarAppService _kullaniciRepository;
        public YonetimController(IKullanicilarAppService kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }
        public IActionResult Index()
        {
          
                return View();
        }
        public IActionResult Kullanicilar(string userName, string password)
        {
            if (userName == null && password == null)
            {
                return RedirectToAction("AdminLogin", "Yonetim", new { userName = "Kullanicilar" });
            }
            else
                return View();
        }
        public IActionResult KullanicilarIncele()
        {
            //if (userName == null && password == null)
            //{
            //    return RedirectToAction("AdminLogin", "Yonetim", new { userName = "KullanicilarIncele" });
            //}
            //else
                return View();
        }
        public IActionResult Kelimeler(string userName, string password)
        {
            if (userName == null && password == null)
            {
                return RedirectToAction("AdminLogin", "Yonetim", new { userName = "Kelimeler" });
            }
            else
                return View();
        }

        public IActionResult KelimelerIncele()
        {
            //if (userName == null && password == null)
            //{
            //    return RedirectToAction("AdminLogin", "Yonetim", new { userName = "KelimelerIncele" });
            //}
            //else
                return View();
        }
        public IActionResult KelimeleOnayla(string userName, string password)
        {
            if (userName == null && password == null)
            {
                return RedirectToAction("AdminLogin", "Yonetim", new { userName = "KelimeleOnayla" });
            }
            else
                return View();
        }

        public IActionResult Genel(string userName, string password)
        {
            if (userName == null && password == null)
            {
                return RedirectToAction("AdminLogin", "Yonetim", new { userName = "Genel" });
            }
            else
                return View();
        }

        public IActionResult AdminLogin(string userName)
        {
            TempData["Page1"] = userName;
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(LoginRequest loginRequest)
        {
            BaseResponse baseResponse = _kullaniciRepository.Login(loginRequest);
            if (baseResponse.isOkey == true)
            {
                //HttpContext.Session.SetString("deneme", "Fatih Deneme");
                //TempData["kAdi"] = baseResponse.message;
                string page;
                if (loginRequest.page == null)
                    page = "Kullanicilar";
                else
                    page = loginRequest.page;
                return RedirectToAction(page, "Yonetim", new { userName = "basarili", password = "basarili" });
            }

            return View();
        }
    }
}