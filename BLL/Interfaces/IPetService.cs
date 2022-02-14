using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public  interface IPetService
    {
        public ICollection<PetViewModel> GetAll();
        public PetViewModel GetById(int Id);
        public void AddPet(PetViewModel appointmentViewModel);
        public void DeletePet(int Id);

    }
}
