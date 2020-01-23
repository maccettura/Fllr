using System;
using Fllr.Application;
using Fllr.Application.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace Fllr.Polygon.Generator
{
    public class PolygonImageService : BaseImageService, IPolygonImageService
    {
        private static readonly Random Random = new Random();

        public PlaceholdImage GenerateImage(PolygonImageRequest request)
        {
            Rgba32 color1;
            Rgba32 color2;

            if (!request.Color1.IsHexColor() && !request.Color2.IsHexColor())
            {
                var colors = GetRandomColorPair();
                color1 = ColorBuilder<Rgba32>.FromHex(colors.color1);
                color2 = ColorBuilder<Rgba32>.FromHex(colors.color2);
            }
            else
            {
                color1 = ColorBuilder<Rgba32>.FromHex(request.Color1);
                color2 = ColorBuilder<Rgba32>.FromHex(request.Color2);
            }

            var points = GenerateVerticies(request.Width, request.Height, request.Count);

            using (var image = new Image<Rgba32>(request.Width, request.Height))
            {
                for (var xAxis = 0; xAxis < points.GetLength(0); xAxis++)
                {
                    for (var yAxis = 0; yAxis < points.GetLength(1); yAxis++)
                    {
                        if (xAxis + 1 < points.GetLength(0) && yAxis + 1 < points.GetLength(1))
                        {
                            var t1 = new[]
                            {
                                new PointF(points[xAxis, yAxis].Item1, points[xAxis, yAxis].Item2),
                                new PointF(points[xAxis + 1, yAxis].Item1, points[xAxis + 1, yAxis].Item2),
                                new PointF(points[xAxis, yAxis + 1].Item1, points[xAxis, yAxis + 1].Item2)
                            };

                            var t2 = new[]
                            {
                                new PointF(points[xAxis + 1, yAxis].Item1, points[xAxis + 1, yAxis].Item2),
                                new PointF(points[xAxis + 1, yAxis + 1].Item1, points[xAxis + 1, yAxis + 1].Item2),
                                new PointF(points[xAxis, yAxis + 1].Item1, points[xAxis, yAxis + 1].Item2)
                            };

                            image.Mutate(x => x.FillPolygon(new GraphicsOptions(true), color1, t1));

                            image.Mutate(x => x.FillPolygon(new GraphicsOptions(true), color2, t2));
                        }
                    }
                }

                return SaveImage(image, request);
            }
        }

        private static (int, int)[,] GenerateVerticies(int width, int height, int steps)
        {
            var map = new (int, int)[steps + 1, steps + 1];

            int sectionWidth = width / steps;
            int sectionHeight = height / steps;

            for (var x = 0; x < steps + 1; x++)
            {
                for (var y = 0; y < steps + 1; y++)
                {
                    map[x, y] = (CalculatePoint(x, sectionWidth, steps), CalculatePoint(y, sectionHeight, steps));
                }
            }
            return map;
        }

        private static int CalculatePoint(int index, int dimension, int steps)
        {
            if (index == 0)
            {
                return (index * dimension) + (dimension / -2);
            }
            if (index == steps)
            {
                return (int)Math.Ceiling((double)(index * dimension + dimension / 2));
            }
            return (index * dimension) + (dimension / -2) + Random.Next(0, dimension);
        }

        private static (string color1, string color2) GetRandomColorPair()
        {
            string hex1 = string.Empty;
            string hex2 = string.Empty;

            for (var i = 0; i < 6; i++)
            {
                int val = Random.Next(0, 15);
                hex1 += val.ToString("X");
                hex2 += (15 - val).ToString("X");
            }

            return (hex1, hex2);
        }
    }
}