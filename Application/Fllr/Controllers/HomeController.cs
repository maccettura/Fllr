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

        [Route("{*url}", Order = 999)]
        public IActionResult Index()
        {
            Response.StatusCode = 400;
            return File(System.IO.File.ReadAllBytes("wwwroot/broken.jpg"), "image/jpg");
        }

        [HttpGet("/{size}.jpg")]
        public IActionResult Index(string size)
        {
            var request = BuildAndValidateRequest(size, "jpg");

            var image = _imageService.GenerateImage(request);

            return BuildResponse(image);
        }

        [HttpGet("/{size}/{bgColor}/{textColor}.jpg")]
        public IActionResult Index(string size, string bgColor, string textColor)
        {
            var request = BuildAndValidateRequest(size, "jpg", bgColor, textColor);

            var image = _imageService.GenerateImage(request);

            return BuildResponse(image);
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return File(System.IO.File.ReadAllBytes("wwwroot/broken.png"), "image/png");
        }

        private ImageRequest BuildBaseRequest(
            string size,
            string extension,
            string bgColor = null,
            string textColor = null)
        {
            string text = HttpContext.Request.Query["t"];
            string font = HttpContext.Request.Query["f"];

            var (width, height) = size.ExtractSizes();

            return new ImageRequest(width, height, extension, text, font, textColor, bgColor);
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