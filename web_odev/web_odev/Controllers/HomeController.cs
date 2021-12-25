﻿using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web_odev.Models;

namespace web_odev.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHtmlLocalizer<HomeController> _localizer;



        private readonly ILogger<HomeController> _logger;
        AracManager arm = new AracManager(new AracRepository());
        OpsiyonlarManager om = new OpsiyonlarManager(new OpsiyonlarRepository());
        GalleryManager gm = new GalleryManager(new GalleryRepository());
        public HomeController(ILogger<HomeController> logger,IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = gm.GetList();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult FiyatListeleri()
        {
            var values = arm.GetList();     
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult Opsiyon()
        {
            var values = om.GetList();
            return View(values);
        }
        [Authorize]
        public IActionResult ServisRandevu()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Kesfet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30)});
            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
