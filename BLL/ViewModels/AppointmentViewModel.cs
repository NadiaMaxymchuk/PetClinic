using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateVisit { get; set; }
        public int DoctorId { get; set; }
        public UserViewModel Doctor { get; set; }
        public int PetId { get; set; }
        public PetViewModel Pet { get; set; }
    }
}
