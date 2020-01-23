using Fllr.Application.Interfaces;

namespace Fllr.Image.Generator
{
    public class ImageRequest : IWithExtension, IWithImageSize, IWithText
    {
        private const string DefaultTextColor = "A9A9A9";

        private const string DefaultBgColor = "D3D3D3";

        private const string DefaultExtension = "jpg";

        private const string DefaultFont = "Muli";

        public ImageRequest(int width, int height, string extension, string text, string font, string textColor, string bgColor)
        {
            Width = width;
            Height = height;
            Extension = extension ?? DefaultExtension;
            Font = font ?? DefaultFont;
            TextColor = textColor ?? DefaultTextColor;
            BackgroundColor = bgColor ?? DefaultBgColor;
            FontSize = Height / 10;

            if (string.IsNullOrWhiteSpace(text))
            {
                text = $"{width}x{height}";
            }

            Text = text;
        }

        public int Width { get; }

        public int Height { get; }

        public string BackgroundColor { get; }

        public string Extension { get; }

        public string Text { get; }

        public string Font { get; }

        public int FontSize { get; }

        public string TextColor { get; }
    }
}