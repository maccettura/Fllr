using System;
using SixLabors.ImageSharp.PixelFormats;

namespace Fllr.Application.Extensions
{
    public static class StringExtensions
    {
        public static (int width, int height) ExtractSizes(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (int.TryParse(input, out int size))
            {
                return (size, size);
            }

            string[] sizes = input.Split('X', 'x');

            if (sizes?.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(input));
            }

            if (!int.TryParse(sizes[0], out int w) || !int.TryParse(sizes[1], out int h))
            {
                throw new ArgumentException(nameof(input));
            }

            return (w, h);
        }

        public static Rgba32 HexToRgba32(this string input)
        {
            if (!input.IsHexColor())
            {
                throw new ArgumentException(nameof(input));
            }

            return ColorBuilder<Rgba32>.FromHex(input);
        }

        public static bool IsHexColor(this string input)
        {
            if (input == null || (input.Length != 3 && input.Length != 6))
            {
                return false;
            }
            for (var index = 0; index < input.ToCharArray().Length; index++)
            {
                char c = input[index];
                bool isHex = ((c >= '0' && c <= '9') ||
                              (c >= 'a' && c <= 'f') ||
                              (c >= 'A' && c <= 'F'));

                if (!isHex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}