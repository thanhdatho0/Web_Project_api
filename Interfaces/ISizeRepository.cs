using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Size;
using api.Models;

namespace api.Interfaces
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetAllAsync();
        Task<Size?> GetByIdAsync(int id);
        Task<Size> CreateAsync(Size size);
        Task<Size?> UpdateAsync(int id, SizeUpdateDto sizeUpdateDto);
        Task<Size?> DeleteAsync(int id);
        Task<bool> SizeExists(int id);
    }
}