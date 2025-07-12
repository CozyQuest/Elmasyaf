using AutoMapper;
using Elmasyaf.Domain.Entities;
using Elmasyaf.Application.DTOs;

namespace Elmasyaf.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Property, ApartmentCardDTO>().ReverseMap();
        }
    }
}
