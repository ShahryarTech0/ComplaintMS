using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Interfaces
{
    public interface IMerchantRepository
    {
        Task<Merchant> AddAsync(Merchant entity);

        Task<Merchant> GetByIdAsync(int id);
    }
}
