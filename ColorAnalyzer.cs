using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Contactless_Dining_System
{
  internal class ColorAnalyzer
  {
    public static List<string> GetTop3FrequentColors(byte[] imageBytes)
    {
      List<string> top3Colors = new List<string>();

      using (var stream = new System.IO.MemoryStream(imageBytes))
      using (var image = Image.FromStream(stream))
      {
        // Create a dictionary to store color frequencies
        Dictionary<Color, int> colorFrequencies = new Dictionary<Color, int>();

        // Iterate through each pixel in the image
        for (int y = 0; y < image.Height; y++)
        {
          for (int x = 0; x < image.Width; x++)
          {
            Color pixelColor = ((Bitmap)image).GetPixel(x, y);

            // Increment the color's frequency count
            if (colorFrequencies.ContainsKey(pixelColor))
              colorFrequencies[pixelColor]++;
            else
              colorFrequencies[pixelColor] = 1;
          }
        }

        // Sort the colors by frequency in descending order
        List<Color> sortedColors = new List<Color>(colorFrequencies.Keys);
        sortedColors.Sort((a, b) => colorFrequencies[b].CompareTo(colorFrequencies[a]));

        // Get the top 3 most frequent colors
        for (int i = 0; i < Math.Min(3, sortedColors.Count); i++)
        {
          Color color = sortedColors[i];
          string hexCode = ColorToHexCode(color);
          top3Colors.Add(hexCode);
        }
      }

      return top3Colors;
    }

    private static string ColorToHexCode(Color color)
    {
      return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }
  }
}
