using MerchantCore.Entities;
using MerchantInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Features.MerchantLocations.Interfaces;
using MerchantApplication.Features.MerchantLocations.Dto;
using MerchantApplication.Shared;
namespace MerchantInfrastructure.MerchantLocationRepositories
{
    public class MerchantLocationRepository : IMerchantLocationRepository
    {
        private readonly AppDbContext _context;
        public MerchantLocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<MerchantLocation?> GetZoneByID(int id)
        {

            return await _context.MerchantLocations
                                 .Include(l => l.Merchant) // optional: include merchant info
                                 .FirstOrDefaultAsync(l => l.ID == id);
        }

        public async Task<MerchantLocation> AddZoneAsync(MerchantLocation entity)
        {
            await _context.MerchantLocations.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<MerchantLocation> SoftDeleteAsync(MerchantLocation entity)
        {
            _context.MerchantLocations.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<MerchantLocation> UpdateZoneAsync(MerchantLocation entity)
        {
             _context.MerchantLocations.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<MerchantLocation>> GetAllZonesAsync()
        {
            return await _context.MerchantLocations
                                 .Include(l => l.Merchant) // optional
                                 .ToListAsync();
        }


    }
}
