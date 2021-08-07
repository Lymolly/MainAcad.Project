using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Airline.BLL.DTOs;
using Airline.BLL.Infrastructure;

namespace Airline.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDTO);
        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
        Task SetInitializer(UserDTO adminDTO, List<string> roles);

    }
}