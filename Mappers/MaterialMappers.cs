using api.DTOs.Material;
using api.Models;

namespace api.Mappers;

public static class MaterialMappers
{
    public static Material ToMaterialDto(this MaterialCreateDto materialCreateDto)
    {
        return new Material
        {
            MaterialType = materialCreateDto.MaterialType,
        };
    }
}