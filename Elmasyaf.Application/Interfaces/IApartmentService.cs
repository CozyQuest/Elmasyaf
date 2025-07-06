using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Application.DTOs;

namespace Elmasyaf.Application.Interfaces
{
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentCardDTO>> GetAllAsync();
        Task<ApartmentCardDTO> GetByIdAsync(long id);
        Task AddAsync(ApartmentCardDTO apartment);
        Task UpdateAsync(ApartmentCardDTO apartment);
        Task DeleteAsync(long id);
    }
}
