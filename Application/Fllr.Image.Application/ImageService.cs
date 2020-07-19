using Fllr.Application;
using Fllr.Application.Extensions;
using Fllr.Image.Generator.Extensions;
using SixLabors.ImageSharp.Processing;

namespace Fllr.Image.Generator
{
    public class ImageService : BaseImageService, IImageService
    {
        public PlaceholdImage GenerateImage(ImageRequest request)
        {
            using var image = request.ToImage();            
            image.Mutate(i => i.DrawText(request, request));

            return SaveImage(image, request);
        }
    }
}