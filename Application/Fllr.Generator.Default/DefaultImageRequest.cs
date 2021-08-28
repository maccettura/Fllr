namespace Fllr.Infrastructure
{
    public struct DefaultImageRequest : IImageRequest
    {
        private const string DefaultTextColor = "A9A9A9";

        private const string DefaultBgColor = "D3D3D3";

        private const string DefaultExtension = "jpg";

        private const string DefaultFont = "Montserrat";

        public DefaultImageRequest(int width, int height, string extension, string text, string font, string textColor, string bgColor)
        {
            Width = width;
            Height = height;
            Extension = extension ?? DefaultExtension;
            Font = font ?? DefaultFont;
            TextColor = textColor ?? DefaultTextColor;
            Color = bgColor ?? DefaultBgColor;
            FontSize = Height / 10;

            if (string.IsNullOrWhiteSpace(text))
            {
                text = $"{width}x{height}";
            }

            Text = text;
        }

        public int Width { get; }

        public int Height { get; }

        public string Color { get; }

        public string Extension { get; }

        public string Text { get; }

        public string Font { get; }

        public int FontSize { get; }

        public string TextColor { get; }
    }
}