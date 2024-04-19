using BusinessLayer.Abstract;
using EntityLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OctapullAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> UserList() {
            var values = await userService.GetUserList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id) {
            var values = await userService.GetByIdUserAsync(id);
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(string id) {
            await userService.DeleteUserById(id);
            return Ok("User with id " +id + " has been deleted succesfully" );
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserDto createUserDto) {
            await userService.AddUser(createUserDto);
            return Ok("User has been added succesfully.User Added: \n" + createUserDto.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto) {
            await userService.UpdateUser(updateUserDto);
            return Ok("User with id " + updateUserDto.Id + " has been updated succesfully. New use: " + updateUserDto.ToString());
        }
    }
}
