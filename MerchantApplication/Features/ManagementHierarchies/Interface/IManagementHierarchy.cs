using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.ManagementHierarchies.Interface
{
    public interface IManagementHierarchy
    {
        Task<ManagementHierarchy> AddManagementAsync(ManagementHierarchy entity);

        Task<ManagementHierarchy> GetManagementByID(int id);

       // Task<ManagementHierarchy> UpdateManagementAsync(ManagementHierarchy entity);

        //Task<ManagementHierarchy> DeleteManagementAsync(ManagementHierarchy entity);

        //Task<IEnumerable<ManagementHierarchy>> GetAllManagementAsync();

    }
}
