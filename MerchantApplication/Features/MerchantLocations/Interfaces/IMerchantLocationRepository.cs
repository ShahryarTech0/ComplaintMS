using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MerchantApplication.Features.MerchantLocations.Interfaces
{
    public interface IMerchantLocationRepository
    {
        Task<MerchantLocation> AddZoneAsync(MerchantLocation entity);

        Task<MerchantLocation> GetZoneByID(int id);

        //Task<MerchantLocation> UpdateZoneAsync(MerchantLocation entity);

        //Task<MerchantLocation> DeleteZoneAsync(MerchantLocation entity);
    }
}
