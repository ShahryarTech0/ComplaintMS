using MerchantApplication.Interfaces;
using MerchantInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantCore.Entities;
using MerchantApplication.Interfaces;
namespace MerchantInfrastructure.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly AppDbContext _context;
        public MerchantRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Merchant> AddAsync(Merchant entity)
        {
            _context.Merchants.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Merchant?> GetByIdAsync(int id)
        {
            var merchant = await _context.Merchants.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            return merchant;
        }

        public async Task<Merchant?> UpdateAsync(Merchant entity)
        {
            _context.Merchants.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Merchant?> DeleteAsync(Merchant entity)
        {
             _context.Merchants.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
