namespace api.DTOs.PImage
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    }
}