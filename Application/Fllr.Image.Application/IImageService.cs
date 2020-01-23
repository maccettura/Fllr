using Fllr.Application;

namespace Fllr.Image.Generator
{
    public interface IImageService
    {
        PlaceholdImage GenerateImage(ImageRequest request);
    }
}