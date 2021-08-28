namespace Fllr.Infrastructure
{
    public interface IImageRequest
    {
        public int Width { get; }

        public int Height { get; }

        public string Color { get; }

        public string Extension { get; }
    }
}