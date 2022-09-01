using System;
using System.Reflection;
using SixLabors.Fonts;

namespace Fllr.Generator.Default
{
    public sealed class PlaceholdFontCollection
    {
        private const string AssemblyNameString = "Fllr.Generator.Default";

        private static readonly AssemblyName AssemblyName = new(AssemblyNameString);

        private static readonly Lazy<FontCollection> Lazy = new(LoadFontCollection);

        public static FontCollection Instance => Lazy.Value;

        private static FontCollection LoadFontCollection()
        {
            var collection = new FontCollection();

            var assembly = Assembly.Load(AssemblyName);

            var fontFiles = new[]
            {
                $"{AssemblyNameString}._fonts.Montserrat.ttf",
                $"{AssemblyNameString}._fonts.PTSerif.ttf"
            };

            foreach (var filename in fontFiles)
            {
                using var stream = assembly.GetManifestResourceStream(filename);
                collection.Add(stream);
            }

            return collection;
        }
    }
}