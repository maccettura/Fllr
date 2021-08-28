using System;
using System.IO;
using Fllr.Infrastructure;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace Fllr.Generator.Default
{
    public abstract class BaseImageService
    {
        protected PlaceholdImage SaveImage(Image<Rgba32> image, DefaultImageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Extension))
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var outputStream = new MemoryStream();

            string mimeType;
            switch (request.Extension.ToLower())
            {
                case "gif":
                    image.SaveAsGif(outputStream);
                    mimeType = GifFormat.Instance.DefaultMimeType;
                    break;

                case "png":
                    image.SaveAsPng(outputStream);
                    mimeType = PngFormat.Instance.DefaultMimeType;
                    break;

                case "jpg":
                case "jpeg":
                default:
                    image.SaveAsJpeg(outputStream, new JpegEncoder { Quality = 100 });
                    mimeType = JpegFormat.Instance.DefaultMimeType;
                    break;
            }

            outputStream.Position = 0;
            return new PlaceholdImage
            {
                Payload = outputStream.ToArray(),
                MimeType = mimeType
            };
        }
    }
}