using api.DTOs.PImage;

namespace api.Interfaces;

public interface IImageService
{
    Task<ImageDto> CreateProductImagesAsync(IFormFile file, ImageCreateDto imageCreateDto, string baseUrl);
    Task<string> CreateUrlAsync(IFormFile file, string baseUrl);
}