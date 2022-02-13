using AutoMapper;
using BLL.Classes;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<CreateAppointmentViewModels, AppointmentService>()
               .ReverseMap();

            CreateMap<CreateUserViewModels, UserService>()
               .ReverseMap();

            CreateMap<CreatePetViewModels, PetService>()
               .ReverseMap();
        }
    }
}
