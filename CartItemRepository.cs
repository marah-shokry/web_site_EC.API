
using Domain.Entities;
using Domain.Interface;
using Infrastrcuture.AppDBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcuture.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await _context.CartItems
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IReadOnlyList<CartItem>> GetByCartIdAsync(int cartId)
        {
            return await _context.CartItems
                .AsNoTracking()
                .Include(i => i.Product)
                .Where(i => i.CartId == cartId)
                .ToListAsync();
        }

        public async Task AddAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAsync(int cartId)
        {
            var items = await _context.CartItems
                .Where(i => i.CartId == cartId)
                .ToListAsync();

            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
