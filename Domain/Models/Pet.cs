using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string PetType { get; set; }

    }
}
