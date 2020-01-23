using Fllr.Application.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Fllr.Image.Generator.Extensions
{
    public static class ImageRequestExtensions
    {
        public static Image<Rgba32> ToImage(this ImageRequest request)
        {
            return new Image<Rgba32>(
                Configuration.Default,
                request.Width,
                request.Height,
                request.BackgroundColor.HexToRgba32());
        }
    }
}