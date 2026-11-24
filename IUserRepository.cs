using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public  interface IUserRepository
    {
        Task<User?>GetUserAsync(int id); 
        Task<User?> GetUserByEmailAsync(string email);

        Task AddAsync(User user);
        Task UpdateAsync(User user);

        Task DeleteAsync(User user);



    }
}
