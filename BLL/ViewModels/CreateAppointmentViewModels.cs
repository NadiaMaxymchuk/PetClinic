using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public  class CreateAppointmentViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateVisit { get; set; }
        public int DoctorId { get; set; }
        public UserService Doctor { get; set; }
        public int PetId { get; set; }
        public PetService Pet { get; set; }
    }
}
