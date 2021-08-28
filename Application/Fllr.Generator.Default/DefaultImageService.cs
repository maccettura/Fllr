﻿using Fllr.Generator.Default.Extensions;
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

            float padding = 10f;
            float textMaxWidth = request.Width - padding * 2; // width of image indent left & right by padding

            Color fontColor = request.TextColor.HexStringToColor();

            var family = PlaceholdFontCollection.Instance.Families.FirstOrDefault(x => string.Equals(x.Name, request.Font, StringComparison.CurrentCultureIgnoreCase));

            if (family == null)
            {
                family = PlaceholdFontCollection.Instance.Families.FirstOrDefault();
            }

            var drawingOptions = new DrawingOptions()
            {
                TextOptions = new TextOptions()
                {
                    WrapTextWidth = textMaxWidth,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    ApplyKerning = true
                }
            };

            var font = new Font(family, request.FontSize);

            image.Mutate(i => i.DrawText(drawingOptions, request.Text, font, fontColor, new PointF(0, request.Height / 2)));

            return SaveImage(image, request);
        }
    }
}