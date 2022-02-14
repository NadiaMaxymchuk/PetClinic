using BLL.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserViewModel Authenticate(LoginViewModel model);
        public UserViewModel GetById(int Id);
        public UserViewModel GetByEmail(string email);
        public int Register(CreateUserViewModels model);
    }
}
