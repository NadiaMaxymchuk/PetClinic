using AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Classes
{
    public class UserService: IUserService
    {
        private readonly IMapper mapper;
        private readonly PetClinicDBContext context;

        public UserService(
            IMapper mapper,
            PetClinicDBContext context
            )
        {
            this.mapper = mapper;
            this.context = context;
        }
        public int Register(CreateUserViewModels model)
        {
            var account = mapper.Map<CreateUserViewModels, User>(model);

            account.IsActive=true;
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            context.Add(account);

            context.SaveChanges();

            return account.Id;
        }

        public UserViewModel Authenticate(LoginViewModel model)
        {
            var account = context.Users.FirstOrDefault(e=>e.Email == model.Email);
            if (account != null && BCrypt.Net.BCrypt.Verify(model.Password, account.PasswordHash))
                return mapper.Map<UserViewModel>(account);
            return null;
        }

        public UserViewModel GetByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(e => e.Email == email);

            return mapper.Map<UserViewModel>(user);
        }

        public UserViewModel GetById(int Id)
        {
            var user = context.Users.FirstOrDefault(x=>x.Id == Id);
            return mapper.Map<UserViewModel>(user);
        }

        public void BlockUserById(int Id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == Id);
            if (user != null)
            {
                user.IsActive = false;
            }

            context.SaveChanges();
        }
    }
}
