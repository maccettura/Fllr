using SixLabors.ImageSharp;
using System;
using Fllr.Infrastructure.Extensions;

namespace Fllr.Generator.Default.Extensions
{
    public static class StringExtensions
    {
        public static Color HexStringToColor(this string input)
        {
            if (!input.IsHexColor())
            {
                throw new ArgumentException(nameof(input));
            }

            return Color.ParseHex(input);
        }
    }
}