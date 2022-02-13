using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }   
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Appointment> Appointments { get; set; }  
    }
}
