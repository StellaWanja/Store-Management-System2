using System;
using System.Threading.Tasks;
using Management.Models;

namespace  Management.BusinessLogic
{
    public interface IBusinessLogicUser
    {
        Task<bool> RegisterUser(string firstName, string lastName, string email, string password);
        
        Task<int> LoginUser(string email, string password);
    }
}