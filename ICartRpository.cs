using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

   

    namespace Domain.Interface
    {
        public interface ICartRepository
        {
            Task<Cart?> GetByUserIdAsync(int userId);
            Task<Cart?> GetByIdAsync(int id);
            Task AddAsync(Cart cart);
            Task UpdateAsync(Cart cart);
            Task DeleteAsync(Cart cart);
        }
    }


