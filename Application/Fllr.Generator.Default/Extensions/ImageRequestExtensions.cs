using Fllr.Infrastructure;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Fllr.Generator.Default.Extensions
{
    public static class ImageRequestExtensions
    {
        public static Image<Rgba32> ToImage(this DefaultImageRequest request)
        {
            return new Image<Rgba32>(
                Configuration.Default,
                request.Width,
                request.Height,
                request.Color.HexStringToColor());
        }
    }
}