using Fllr.Application.Interfaces;

namespace Fllr.Polygon.Generator
{
    public class PolygonImageRequest : IWithExtension, IWithImageSize
    {
        private const string DefaultExtension = "jpg";

        private const int DefaultCount = 15;

        public PolygonImageRequest(
            int width,
            int height,
            string extension,
            string color1,
            string color2,
            int? count)
        {
            Width = width;
            Height = height;
            Extension = extension ?? DefaultExtension;
            Color1 = color1;
            Color2 = color2;
            Count = count ?? DefaultCount;
        }

        public string Color1 { get; }

        public string Color2 { get; }

        public int Count { get; }

        public int Width { get; }

        public int Height { get; }

        public string Extension { get; }
    }
}