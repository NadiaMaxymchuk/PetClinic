using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public  class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PetViewModel> Pets { get; set; }
        public ICollection<AppointmentViewModel> Appointments { get; set; }
    }
}
