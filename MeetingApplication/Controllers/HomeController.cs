using MeetingApps.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApps.Controllers
{
    public class HomeController: Controller 
    {
        // localhost/home    yada bir şey yazmasakta gelir. Controller = default
        // localhost
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

            ViewBag.Selamlama = saat > 12 ? "İyi Günler":"Günaydın";
            int UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();
            // ViewBag.UserName = "Gökhan";

            var MeetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "İstanbul, Turkcell",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = UserCount
            };
            
            return View(MeetingInfo);
        }
    }
}