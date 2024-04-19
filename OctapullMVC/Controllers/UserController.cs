using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace OctapullMVC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller {

        private readonly IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }
        //[HttpPost]
        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> Details(string id) {
            var user = await userService.GetByIdUserAsync(id);
            if (user == null) {
                return NotFound();
            }
            return View(user); // You need to create a corresponding view for this action
        }

        [HttpGet]
        public async Task<IActionResult> Create() {


            //await userService.AddUser(createUserDto);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto) {
            if(Request.Form.Files.Count> 0) {
                IFormFile file = Request.Form.Files[0];
                string fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(file.FileName);
                string filePath = "Image/" + fileName + fileExtension;
                using (FileStream fs = System.IO.File.Create(filePath)) {
                    file.CopyTo(fs);
                }
                createUserDto.ProfileImagePath=filePath;
            }
            await userService.AddUser(createUserDto);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto updateUserDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await userService.UpdateUser(updateUserDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id) {
            await userService.DeleteUserById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
