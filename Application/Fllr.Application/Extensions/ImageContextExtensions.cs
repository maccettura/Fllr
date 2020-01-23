using System;
using System.Linq;
using Fllr.Application.Interfaces;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace Fllr.Application.Extensions
{
    public static class ImageContextExtensions
    {
        public static IImageProcessingContext<Rgba32> DrawText(
            this IImageProcessingContext<Rgba32> source, IWithText textRequest, IWithImageSize imageSize)
        {
            if (string.IsNullOrWhiteSpace(textRequest.Text))
            {
                return source;
            }

            float padding = 10f;
            float textMaxWidth = imageSize.Width - (padding * 2); // width of image indent left & right by padding

            var tgo = new TextGraphicsOptions(true)
            {
                WrapTextWidth = textMaxWidth,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                ApplyKerning = true
            };

            var fontColor = textRequest.TextColor.HexToRgba32();

            var family = PlaceholdFontCollection.Instance.Families.FirstOrDefault(x => string.Equals(x.Name, textRequest.Font, StringComparison.CurrentCultureIgnoreCase));

            if (family == null)
            {
                family = PlaceholdFontCollection.Instance.Families.FirstOrDefault();
            }

            var font = new Font(family, textRequest.FontSize);

            source.DrawText(tgo, textRequest.Text, font, fontColor, new PointF(0, imageSize.Height / 2));

            return source;
        }
    }
}