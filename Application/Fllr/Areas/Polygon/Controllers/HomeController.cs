using System;
using Fllr.Application.Extensions;
using Fllr.Controllers;
using Fllr.Polygon.Generator;
using Microsoft.AspNetCore.Mvc;

namespace Fllr.Areas.Polygon.Controllers
{
    [Area("Polygon")]
    public class HomeController : BaseImageController
    {
        private readonly IPolygonImageService _polygonImageService;

        public HomeController(IPolygonImageService polygonImageService)
        {
            _polygonImageService = polygonImageService ?? throw new ArgumentNullException(nameof(polygonImageService));
        }

        [HttpGet("p/{size}.{extension?}")]
        public IActionResult Index(string size, string extension)
        {
            var request = BuildAndValidateRequest(size, extension);

            var image = _polygonImageService.GenerateImage(request);

            return BuildResponse(image);
        }

        [HttpGet("p/{size}/{color1}/{color2}.{extension?}")]
        public IActionResult Index(string size, string color1, string color2, string extension)
        {
            var request = BuildAndValidateRequest(size, extension, color1, color2);

            var image = _polygonImageService.GenerateImage(request);

            return BuildResponse(image);
        }

        [HttpGet("p/{size}/{color1}/{color2}/{count}.{extension?}")]
        public IActionResult Index(string size, string color1, string color2, int count, string extension)
        {
            var request = BuildAndValidateRequest(size, extension, color1, color2, count);

            var image = _polygonImageService.GenerateImage(request);

            return BuildResponse(image);
        }

        private static PolygonImageRequest BuildBaseRequest(
            string size,
            string extension,
            string color1 = null,
            string color2 = null,
            int? count = null)
        {
            (int width, int height) sizes = size.ExtractSizes();

            return new PolygonImageRequest(sizes.width, sizes.height, extension, color1, color2, count);
        }

        private PolygonImageRequest BuildAndValidateRequest(
            string size,
            string extension,
            string color1 = null,
            string color2 = null,
            int? count = null)
        {
            var request = BuildBaseRequest(size, extension, color1, color2, count);

            if (request.Width < 0 || request.Width > 4000)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Width));
            }

            if (request.Height < 0 || request.Height > 4000)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Height));
            }

            if (!string.IsNullOrWhiteSpace(request.Color1) && !request.Color1.IsHexColor())
            {
                throw new ArgumentOutOfRangeException(nameof(request.Color1));
            }

            if (!string.IsNullOrWhiteSpace(request.Color2) && !request.Color2.IsHexColor())
            {
                throw new ArgumentOutOfRangeException(nameof(request.Color2));
            }

            if (count > 200)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Count));
            }

            return request;
        }
    }
}