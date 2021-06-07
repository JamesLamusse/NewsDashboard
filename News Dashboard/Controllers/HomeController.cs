using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NewsAPI.Constants;
using Microsoft.AspNetCore.Mvc.Routing;

namespace News_Dashboard.Controllers
{
    /// <summary>
    /// Code Generated Controller but it also the controller used from the Index to fetch the news
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Countries curCountry = Countries.ZA;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Load the Index view based on query and country code
        /// </summary>
        /// <param name="country"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public IActionResult Index(int country, string q)
        {
            curCountry = (Countries)(country);
            return View(News.News.HeadlinesQuery(curCountry, q));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Ajax post to return the Json result
        /// </summary>
        /// <param name="country"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewsHeadlines(int country, string q)
        {
            return Json(new { newUrl = Url.Action("Index", "Home", new { country = (country), q = q}) });
        }
    }
}
