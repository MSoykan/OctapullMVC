using EntityLayer.Concrete;
using EntityLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface IUserService {
        Task AddUser(CreateUserDto createUserDto);
        Task UpdateUser(UpdateUserDto updateUserDto);
        Task DeleteUserById(int userId);
        Task<ResultUserDto> GetByIdUserAsync(int userId);
        Task<List<User>> GetUserList();
    }
}
