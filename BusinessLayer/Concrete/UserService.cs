using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class UserService : IUserService {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) { // need to inject this in program.cs
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task AddUser(CreateUserDto createUserDto) {
            var value = mapper.Map<User>(createUserDto);
            await userRepository.AddAsync(value);
        }

        public async Task DeleteUser(int userId) {
            await userRepository.DeleteAsync(u => u.Id == userId);
        }

        public async Task<ResultUserDto> GetByIdUserAsync(int userId) { 
            var user = await userRepository.GetAsync(u => u.Id == userId);
            return mapper.Map<ResultUserDto>(user); 
        }

        public async Task<List<User>> GetUserList() { // TO DO : CHange return type to result user dto
            return await userRepository.ListAsync(b => true);
        }

        public async Task UpdateUser(UpdateUserDto updateUserDto) {
            var user = mapper.Map<User>(updateUserDto);
            await userRepository.UpdateAsync(user);
        }

    }
}
