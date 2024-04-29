namespace MovieMVC.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> EncodeImageAsync(IFormFile file);
        Task<byte[]> EncodeImageURLAsync(string imagePath);
        string DecodeImage(byte[] poster, string imageType);
    }
}
