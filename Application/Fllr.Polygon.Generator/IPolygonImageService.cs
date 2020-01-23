using Fllr.Application;

namespace Fllr.Polygon.Generator
{
    public interface IPolygonImageService
    {
        PlaceholdImage GenerateImage(PolygonImageRequest request);
    }
}