using System;
using Airline.Domain.Entities;

namespace Airline.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}