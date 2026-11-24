using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface ICartItemRepository
    {
        Task<CartItem?> GetByIdAsync(int id);
        Task<IReadOnlyList<CartItem>> GetByCartIdAsync(int cartId);
        Task AddAsync(CartItem cartItem);
        Task UpdateAsync(CartItem cartItem);
        Task DeleteAsync(CartItem cartItem);
        Task ClearAsync(int cartId);
    }
}
