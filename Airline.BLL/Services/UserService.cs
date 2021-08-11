using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.DTOs;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.Domain.Entities;
using Airline.Domain.IdentityEntities;
using Microsoft.AspNet.Identity;

namespace Airline.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<OperationDetails> Create(UserDTO userDTO)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser
                    {Email = userDTO.Email, UserName = UserNameHelper.CreateUserName(userDTO.Email)};
                IdentityResult result = await Database.UserManager.CreateAsync(user,userDTO.Password);
                if (result.Errors.Any())
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }

                foreach (var role in userDTO.Role)
                {
                    if (role != null)
                    {
                        await Database.UserManager.AddToRoleAsync(user.Id, role);
                    }
                }
                ClientProfile clientProfile = new ClientProfile()
                    {Id = user.Id, Address = userDTO.Address, Name = userDTO.Name};
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Register Succeded!", "");
            }
            else
            {
                return new OperationDetails(false, "User with same login is exist!", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claim = default;
            ApplicationUser user = await Database.UserManager.FindAsync(UserNameHelper.CreateUserName(userDTO.Email), userDTO.Password);
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;

        }

        public async Task SetInitializer(UserDTO adminDTO, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDTO);
        }
        public void Dispose()
        {
            Database.Dispose();

        }
    }
}
