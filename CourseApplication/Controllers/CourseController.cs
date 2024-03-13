using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

// localhost            => home/index
// localhost/home       => home/index
// localhost/home/index => home/index



public class CourseController: Controller {

        public IActionResult Details(int? id)
    {   
        if(id == null){
            return Redirect("/course/list");
        }
        
        var kurs = Repository.GetById(id);      

        return View(kurs);
    }

    public IActionResult List()
    {   
        {
            return View("CourseList", Repository.Courses);
        }
    }
}