using Fllr.Generator.Default.Extensions;
using Fllr.Infrastructure;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using System;
using System.Linq;

namespace Fllr.Generator.Default
{
    public class DefaultImageService : BaseImageService, IImageService<DefaultImageRequest>
    {
        public PlaceholdImage GenerateImage(DefaultImageRequest request)
        {
            using var image = request.ToImage();
            if (string.IsNullOrWhiteSpace(request.Text))
            {
                return SaveImage(image, request);
            }

            Color fontColor = request.TextColor.HexStringToColor();

            var family = PlaceholdFontCollection.Instance.Families.FirstOrDefault(x => string.Equals(x.Name, request.Font, StringComparison.CurrentCultureIgnoreCase));

            if (family == null)
            {
                family = PlaceholdFontCollection.Instance.Families.FirstOrDefault();
            }

            var font = new Font(family, request.FontSize);

            var size = TextMeasurer.Measure(request.Text, new RendererOptions(font, 72));
            int xPos = (int)((request.Width - size.Width) / 2);
            int yPos = (int)((request.Height - size.Height) / 2);

            image.Mutate(i => i.DrawText(request.Text, font, fontColor, new PointF(xPos, yPos)));

            return SaveImage(image, request);
        }
    }
}