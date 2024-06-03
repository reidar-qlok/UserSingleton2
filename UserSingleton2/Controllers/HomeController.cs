using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserSingleton2.Models;
using UserSingleton2.Models.Service;

namespace UserSingleton2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserSession _userSession;

        public HomeController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            // Sätt en session id
            //_userSession.SetSessionId("12345");
            // Sätt en session id om den inte redan är satt
            if (string.IsNullOrEmpty(_userSession.GetSessionId()))
            {
                _userSession.SetSessionId(Guid.NewGuid().ToString());
            }

            // Hämta och visa session id
            var sessionId = _userSession.GetSessionId();
            ViewData["SessionId"] = sessionId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
