using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace OctapullMVC.Controllers {
    public class UserController : Controller {

        private readonly IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
