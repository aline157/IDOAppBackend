using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDOApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace IDOApplication.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<User> GetUser(string email,string password)
        {
            return await appDbContext.Users.
                 FirstOrDefaultAsync(e => e.Email == email && e.Password== password);
        }

        public async Task<User> updatePassword(string email, string oldPassword,string newPassword)
        {

            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Email == email && e.Password == oldPassword);

            if (result != null)
            {
                result.Password = newPassword;


                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<User> getUserByEmail(string email)
        {
            return await appDbContext.Users.
                 FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User> addUser(string email,string password)
        {
            var user = new User(email, password);

            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> GetId(string email)
        {
            return await appDbContext.Users.
                 FirstOrDefaultAsync(e => e.Email == email);
        }


    }
}
