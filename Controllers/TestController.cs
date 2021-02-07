using Microsoft.AspNetCore.Mvc;

namespace MyWebApplications.Controllers{
    public class TestController:Controller{
        
        public IActionResult Index(){
            return View();
        }
    }
}