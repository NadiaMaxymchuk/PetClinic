using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateVisit { get; set; }
        public int DoctorId { get; set; }
        public User Doctor { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
