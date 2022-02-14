using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public  class CreateUserViewModels
    {
       public int Id { get; set; }
       public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
