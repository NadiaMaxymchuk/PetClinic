using AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Classes
{
    public  class PetService: IPetService
    {
        private readonly IMapper mapper;
        private readonly PetClinicDBContext context;

        public PetService(
            IMapper mapper,
            PetClinicDBContext context
            )
        {
            this.mapper = mapper;
            this.context = context;
        }

        public ICollection<PetViewModel> GetAll()
        {
            var pet = context.Pets.ToList();
            return mapper.Map<ICollection<PetViewModel>>(pet);
        }

        public PetViewModel GetById(int Id)
        {
            var pet = context.Pets.FirstOrDefault(x => x.Id == Id);
            return mapper.Map<PetViewModel>(pet);
        }

        public void AddPet(PetViewModel appointmentViewModel)
        {
            var pet = mapper.Map<Pet>(appointmentViewModel);
            context.Pets.Add(pet);

            context.SaveChanges();
        }

        public void DeletePet(int Id)
        {
            var pet = context.Pets.FirstOrDefault(y => y.Id == Id);
            context.Pets.Remove(pet);
            context.SaveChanges();
        }
    }
}
