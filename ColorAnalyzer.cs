using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Restaurant_Contactless_Dining_System
{
  internal class ColorAnalyzer
  {
    public static List<string> GetTop3DistinctColors(byte[] imageBytes)
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

        // Get the top 3 most frequent and distinct colors
        int threshold = 30; // Adjust this threshold as needed
        for (int i = 0; i < Math.Min(3, sortedColors.Count); i++)
        {
          Color color = sortedColors[i];

          // Check if the color is distinct from the previously selected colors
          if (!IsColorDistinct(color, top3Colors, threshold))
            continue;

          string hexCode = ColorToHexCode(color);
          top3Colors.Add(hexCode);
        }
      }

      return top3Colors;
    }

    private static bool IsColorDistinct(Color color, List<string> selectedColors, int threshold)
    {
      foreach (string hexCode in selectedColors)
      {
        Color selectedColor = HexCodeToColor(hexCode);
        int difference = Math.Abs(color.R - selectedColor.R) +
                         Math.Abs(color.G - selectedColor.G) +
                         Math.Abs(color.B - selectedColor.B);

        if (difference < threshold)
          return false;
      }

      return true;
    }

    private static string ColorToHexCode(Color color)
    {
      return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }

    private static Color HexCodeToColor(string hexCode)
    {
      if (hexCode.StartsWith("#") && hexCode.Length == 7)
      {
        string rHex = hexCode.Substring(1, 2);
        string gHex = hexCode.Substring(3, 2);
        string bHex = hexCode.Substring(5, 2);

        if (int.TryParse(rHex, System.Globalization.NumberStyles.HexNumber, null, out int r) &&
            int.TryParse(gHex, System.Globalization.NumberStyles.HexNumber, null, out int g) &&
            int.TryParse(bHex, System.Globalization.NumberStyles.HexNumber, null, out int b))
        {
          return Color.FromArgb(r, g, b);
        }
      }

      throw new ArgumentException("Invalid hex code: " + hexCode);
    }
  }
}
