using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public  class CreatePetViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public UserService Owner { get; set; }
        public string PetType { get; set; }
    }
}
