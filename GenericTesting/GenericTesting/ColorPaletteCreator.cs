using System;
using System.Collections.Generic;
using System.Drawing;

namespace GenericTesting
{
    internal static class ColorPaletteCreator
    {
        private static Color LightenRGB(Color colorIn, int magnitude)
        {
            int r = colorIn.R;
            int g = colorIn.G;
            int b = colorIn.B;

            Func<int, int> Increaser = x => (x + magnitude <= 255) ? x + magnitude : x;

            return Color.FromArgb(Increaser(r), Increaser(g), Increaser(b));
        }

        internal static List<Color> CreateColorsFromBaseColors(this List<Color> colorsIn, int levelsLighten)
        {
            int originalColorCount = colorsIn.Count;
            for (int j = 0; j < levelsLighten; j++)
            {
                var level = j;

                for (int i = 0; i < originalColorCount; i++)
                {
                    var incrementer = (j != 0 ? j * originalColorCount: 0);
                    var colorPrevious = colorsIn[i + incrementer];
                    colorsIn.Add(LightenRGB(colorPrevious, 5));
                }
            }
                
            
            return colorsIn;
        }
    }
}
