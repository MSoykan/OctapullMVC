using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper {
    public class GeneralMapping : Profile {
        
        public GeneralMapping() { 
            CreateMap<User, ResultUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        
        }
    }
}
