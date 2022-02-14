using AutoMapper;
using BLL.Classes;
using BLL.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<CreateAppointmentViewModels, Appointment>()
               .ReverseMap();

            CreateMap<CreateUserViewModels, User>()
                .ForMember(l => l.PasswordHash, opt => opt.MapFrom(c => c.Password))
               .ReverseMap();

            CreateMap<LoginViewModel, User>()
                .ForMember(l => l.PasswordHash, opt => opt.MapFrom(c => c.Password))
                .ReverseMap();

            CreateMap<CreatePetViewModels, Pet>()
               .ReverseMap();

            CreateMap<AppointmentViewModel, Appointment>()
                .ReverseMap();

            CreateMap<PetViewModel, Pet>()
                .ReverseMap();

            CreateMap<UserViewModel, User>()
                .ReverseMap();
        }
    }
}
