using System;
using Fllr.Application.Extensions;
using Fllr.Image.Generator;
using Microsoft.AspNetCore.Mvc;

namespace Fllr.Controllers
{
    public class HomeController : BaseImageController
    {
        private readonly IImageService _imageService;

        public HomeController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("/{size}.{extension?}")]
        public IActionResult Index(string size, string extension)
        {
            var request = BuildAndValidateRequest(size, extension);

            var image = _imageService.GenerateImage(request);

            return BuildResponse(image);
        }

        [HttpGet("/{size}/{bgColor}.{extension?}")]
        public IActionResult Index(string size, string bgColor, string extension)
        {
            var request = BuildAndValidateRequest(size, extension, bgColor);

            var image = _imageService.GenerateImage(request);

            return BuildResponse(image);
        }

        [HttpGet("/{size}/{bgColor}/{textColor}.{extension?}")]
        public IActionResult Index(string size, string bgColor, string textColor, string extension)
        {
            var request = BuildAndValidateRequest(size, extension, bgColor, textColor);

            var image = _imageService.GenerateImage(request);

            return BuildResponse(image);
        }

        private ImageRequest BuildBaseRequest(
            string size,
            string extension,
            string bgColor = null,
            string textColor = null)
        {
            string text = HttpContext.Request.Query["t"];
            string font = HttpContext.Request.Query["f"];

            var sizes = size.ExtractSizes();

            return new ImageRequest(sizes.width, sizes.height, extension, text, font, textColor, bgColor);
        }

        private ImageRequest BuildAndValidateRequest(
            string size,
            string extension,
            string bgColor = null,
            string textColor = null)
        {
            var request = BuildBaseRequest(size, extension, bgColor, textColor);

            if (request.Width < 0 || request.Width > 4000)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Width));
            }

            if (request.Height < 0 || request.Height > 4000)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Height));
            }

            if (!request.TextColor.IsHexColor())
            {
                throw new ArgumentOutOfRangeException(nameof(request.TextColor));
            }

            if (!request.BackgroundColor.IsHexColor())
            {
                throw new ArgumentOutOfRangeException(nameof(request.BackgroundColor));
            }

            if (request.Text?.Length > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Text));
            }

            return request;
        }
    }
}