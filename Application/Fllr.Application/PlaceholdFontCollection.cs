using System;
using System.Reflection;
using SixLabors.Fonts;

namespace Fllr.Application
{
    public sealed class PlaceholdFontCollection
    {
        private const string AssemblyNameString = "Fllr.Application";

        private static readonly AssemblyName AssemblyName = new AssemblyName(AssemblyNameString);

        private static readonly Lazy<FontCollection> Lazy = new Lazy<FontCollection>(LoadFontCollection);

        public static FontCollection Instance => Lazy.Value;

        private static FontCollection LoadFontCollection()
        {
            var collection = new FontCollection();

            var assembly = Assembly.Load(AssemblyName);

            var fontFiles = new[]
            {
                $"{AssemblyNameString}._fonts.DancingScript.ttf",
                $"{AssemblyNameString}._fonts.Lobster.ttf",
                $"{AssemblyNameString}._fonts.Montserrat.ttf",
                $"{AssemblyNameString}._fonts.Muli.ttf",
                $"{AssemblyNameString}._fonts.PTSerif.ttf"
            };

            foreach (var filename in fontFiles)
            {
                using (var stream = assembly.GetManifestResourceStream(filename))
                {
                    collection.Install(stream);
                }
            }

            return collection;
        }
    }
}