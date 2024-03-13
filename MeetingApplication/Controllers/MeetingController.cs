using MeetingApps.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApps.Controllers
{
    public class MeetingController: Controller
    {   

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {
            if(ModelState.IsValid){

                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.Users.Where(info => info.WillAttend == true).Count(); //Gelen her kişi için count ile sayım yapıp pozitifleri bize vericek.
                return View("Thanks", model);

            } else {
                return View(model);
            }

        }
        
        [HttpGet]
        public IActionResult List()
        {  
            return View(Repository.Users);
        }
        
    
        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}