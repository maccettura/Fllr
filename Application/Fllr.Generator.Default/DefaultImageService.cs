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
        readonly float _padding = 10f;

        public PlaceholdImage GenerateImage(DefaultImageRequest request)
        {
            using var image = request.ToImage();
            if (string.IsNullOrWhiteSpace(request.Text))
            {
                return SaveImage(image, request);
            }

            float textMaxWidth = request.Width - _padding * 2; // width of image indent left & right by padding

            Color fontColor = request.TextColor.HexStringToColor();

            var family = PlaceholdFontCollection.Instance.Families.FirstOrDefault(x => string.Equals(x.Name, request.Font, StringComparison.CurrentCultureIgnoreCase));

            if (family == null)
            {
                family = PlaceholdFontCollection.Instance.Families.FirstOrDefault();
            }

            DrawingOptions drawingOptions = new()
            {
                TextOptions = new()
                {
                    WrapTextWidth = textMaxWidth,
                }
            };

            var font = new Font(family, request.FontSize);

            var size = TextMeasurer.Measure(request.Text, new RendererOptions(font, 72));

            float xPos = CalculatePos(request.Width, size.Width);
            float yPos = CalculatePos(request.Height, size.Height);

            image.Mutate(i => i.DrawText(drawingOptions, request.Text, font, fontColor, new PointF(xPos, yPos)));

            return SaveImage(image, request);
        }

        private float CalculatePos(int imgSize, float txtSize)
        {
            float area = imgSize - _padding * 2;

            float pos = (area - txtSize) / 2;

            if(pos < 0)
            {
                pos = _padding;
            }

            return pos;
        }
    }
}