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

            FontFamily family = PlaceholdFontCollection.Instance.Families.FirstOrDefault(x => string.Equals(x.Name, request.Font, StringComparison.CurrentCultureIgnoreCase));

            var font = new Font(family, request.FontSize);

            var size = TextMeasurer.Measure(request.Text, new TextOptions(font));

            int xPos = (int)((request.Width - size.Width) / 2);
            if(xPos < 0)
            {
                xPos = (int)_padding;
            }
            int yPos = (int)((request.Height - size.Height) / 2);

            image.Mutate(i => i.DrawText(request.Text, font, fontColor, new PointF(xPos, yPos)));

            return SaveImage(image, request);
        }
    }
}