using api.DTOs.PImage;

namespace api.Interfaces;

public interface IImageService
{
    Task<ImageDto> CreateImageAsync(IFormFile file, ImageCreateDto imageCreateDto, string baseUrl);
}