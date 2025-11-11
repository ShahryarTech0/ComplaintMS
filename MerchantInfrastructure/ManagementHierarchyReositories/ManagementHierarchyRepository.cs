using MerchantCore.Entities;
using MerchantInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Features.ManagementHierarchies.Interface;
using Microsoft.EntityFrameworkCore;
namespace MerchantInfrastructure.ManagementHierarchyReositories
{
    public class ManagementHierarchyRepository :IManagementHierarchy
    {
        private readonly AppDbContext _context;
        public ManagementHierarchyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ManagementHierarchy?> GetManagementByID(int id)
        {

            return await _context.ManagementHierarchies.FirstOrDefaultAsync(x=> x.ID == id);    
        }

        public async Task<ManagementHierarchy> AddManagementAsync(ManagementHierarchy Entity)
        {
            await _context.ManagementHierarchies.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
        //public async Task<ManagementHierarchy> SoftDeleteAsync(ManagementHierarchy entity)
        //{
        //    _context.MerchantLocations.Remove(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
        //public async Task<ManagementHierarchy> UpdateZoneAsync(ManagementHierarchy entity)
        //{
        //    _context.MerchantLocations.Update(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<IEnumerable<ManagementHierarchy>> GetAllZonesAsync()
        //{
        //    return await _context.MerchantLocations
        //                         .Include(l => l.Merchant) // optional
        //                         .ToListAsync();
        //}

    } 
}
