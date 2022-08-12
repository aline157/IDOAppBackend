using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDOApplication.Models;

namespace IDOApplication.Api.Repository
{
    public interface IUserRepository
    {
       
        Task<User> GetUser(string email,string password);
        Task<User> updatePassword(string email, string oldPassword, string newPassword);
        Task<User> getUserByEmail(string email);
        Task<User> addUser(string email, string password);
        Task<User> GetId(string email);
    }
}
