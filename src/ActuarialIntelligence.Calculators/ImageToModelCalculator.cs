using ActuarialIntelligence.Domain.ContainerObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace ActuarialIntelligence.Calculators
{
    public static class ImageToModelCalculator
    {
        public static void CallProcessForexecution(string[] args)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = args[0];
            var script = args[1];
            var imageLocations = args[2].Split('|');

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var errors = "";
            var results = "";

            foreach (var location in imageLocations)
            {
                psi.Arguments = $"\"{script}\",\"{location}\"";

                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }

                Console.WriteLine("ERRORS:");
                Console.WriteLine(errors);
                Console.WriteLine();
                Console.WriteLine("Results:");
                Console.WriteLine(results);
            }


        }

        public static IDictionary<int, int> GetPixcleList(string path)
        {

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(path);
            var colour = new Color();
            var col = Color.FromArgb(0, 255, 0);
            IDictionary<int, int> colorList = new Dictionary<int, int>();

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    if (b.GetPixel(x, y).ToArgb().Equals(col.ToArgb()))
                    {
                        if (x != 0 && y != 0)
                        {
                            if (!colorList.ContainsKey(x))
                            {
                                colorList.Add(x, y);
                            }
           
                        }
                    }
                }
            }
            return colorList;
        }
        public static IDictionary<int, int> FilterForModel(IDictionary<int, int> keyValuePairs)
        {
            var filteredList = new Dictionary<int, int>();
            var allKeys = keyValuePairs.Keys;
            var allValues = keyValuePairs.Values;

            var groupedKVP = keyValuePairs.GroupBy(u => u.Value);
            var i = 0;
            foreach (var grouping in groupedKVP)
            {
                var elements = grouping.ElementAtOrDefault(i);
                filteredList.Add(elements.Key, elements.Value);
            }

            return filteredList;
        }

        public static IList<Point<_3Vector, _3Vector>> 
            PointsToVectorList(IDictionary<int, int> dictionaryOfPoints)
        {
            var groupedDictionary = dictionaryOfPoints.OrderBy(u => u.Key).ToDictionary(u=>u.Key,u=>u.Value);
            var vectorList = new List<Point<_3Vector, _3Vector>>();
            var i = 0;
            var cnt = groupedDictionary.Count;
            foreach(var kvp in groupedDictionary)
            {
                if(i+1<cnt)
                {
                    var vec1 = new _3Vector(kvp.Key, kvp.Value, 0);
                    
                    var pair2 = groupedDictionary.ElementAt(i+1);
                    var vec2 = new _3Vector(pair2.Key,pair2.Value,0);
                    vectorList.Add(new Point<_3Vector, _3Vector>(vec1, vec2));
                    i++;
                }
            }
            return vectorList;
        }

        public static IList<Point<_3Vector, _3Vector>>
    PointsToVectorList(IDictionary<int, int> dictionaryOfPoints,int zOffset)
        {
            var vectorList = new List<Point<_3Vector, _3Vector>>();
            var i = 0;
            var cnt = dictionaryOfPoints.Count;
            foreach (var kvp in dictionaryOfPoints)
            {
                if (i + 1 < cnt)
                {
                    var vec1 = new _3Vector(kvp.Key, kvp.Value, zOffset);

                    var pair2 = dictionaryOfPoints.ElementAt(i + 1);
                    var vec2 = new _3Vector(pair2.Key, pair2.Value, zOffset);
                    vectorList.Add(new Point<_3Vector, _3Vector>(vec1, vec2));
                }
            }
            return vectorList;
        }
    }
}
