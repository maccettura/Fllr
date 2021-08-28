namespace Fllr.Infrastructure
{
    public interface IImageService<T> where T: IImageRequest
    {
        PlaceholdImage GenerateImage(T request);
    }
}