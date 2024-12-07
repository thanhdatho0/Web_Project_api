using api.DTOs.PImage;
using api.Interfaces;
using api.Mappers;

namespace api.Services;

public class ImageService(IImageRepository imageRepo, 
    IColorRepository colorRepo, 
    IProductRepository productRepo) 
    : IImageService
{
    public async Task<ImageDto> CreateProductImagesAsync(IFormFile file, ImageCreateDto imageDto, string baseUrl)
    {
        if (!await colorRepo.ColorExists(imageDto.ColorId))
            throw new ArgumentException("Color does not exist!");

        if (!await productRepo.ProductExists(imageDto.ProductId))
            throw new ArgumentException("Product does not exist!");

        if (file.Length == 0)
            throw new ArgumentException("No file provided!");

        var imageModel = imageDto.ToImageFromCreateDto();
        imageModel.Url = await CreateUrlAsync(file, baseUrl);

        await imageRepo.CreateAsync(imageModel);

        return imageModel.ToImageDto();
    }

    public async Task<string> CreateUrlAsync(IFormFile file, string baseUrl)
    {
        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var filePath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return $"{baseUrl}/images/{fileName}";
    }
}