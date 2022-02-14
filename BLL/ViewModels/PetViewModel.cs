using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public UserViewModel Owner { get; set; }
        public string PetType { get; set; }
        public ICollection<AppointmentViewModel> Appointments { get; set; }
    }
}
