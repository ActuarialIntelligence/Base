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

        public static IList<Point<int, int>> GetPixcleList(string path)
        {

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(path);
            var col = Color.FromArgb(0, 255, 0);
            //IDictionary<int, int> colorList = new Dictionary<int, int>();
            var points = new List<Point<int, int>>();

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    if (b.GetPixel(x, y).ToArgb().Equals(col.ToArgb()))
                    {
                        var point = new Point<int, int>(x, y);
                        points.Add(point);
                    }
                }
            }
            return points;
        }
        //public static IDictionary<int, int> FilterForModel(IDictionary<int, int> keyValuePairs)
        //{
        //    var filteredList = new Dictionary<int, int>();
        //    var allKeys = keyValuePairs.Keys;
        //    var allValues = keyValuePairs.Values;

        //    var groupedKVP = keyValuePairs.GroupBy(u => u.Value);
        //    var i = 0;
        //    foreach (var grouping in groupedKVP)
        //    {
        //        var elements = grouping.ElementAtOrDefault(i);
        //        filteredList.Add(elements.Key, elements.Value);
        //    }

        //    return filteredList;
        //}

        public static IList<Point<_3Vector, _3Vector>> 
            PointsToVectorList(IList<Point<int, int>> points)
        {
            var uniqueX = new List<int>();
            foreach(var point in points)
            {
                if(!uniqueX.Contains(point.Xval))
                {
                    uniqueX.Add(point.Xval);
                }
            }
            var uniqueY = new List<int>();
            foreach (var point in points)
            {
                if (!uniqueY.Contains(point.Yval))
                {
                    uniqueY.Add(point.Yval);
                }
            }
            var vectorList = new List<Point<_3Vector, _3Vector>>();

            foreach (var val in uniqueX)
            {
                var pointsWhere = points.Where(u => u.Xval == val).ToList();
                vectorList.AddRange(ToVectorList(pointsWhere));
            }
            foreach (var val in uniqueY)
            {
                var pointsWhere = points.Where(u => u.Yval == val).ToList();
                vectorList.AddRange(ToVectorList(pointsWhere));
            }
            return vectorList;
        }

        private static List<Point<_3Vector, _3Vector>> ToVectorList(IList<Point<int, int>> points)
        {
            var vectorList = new List<Point<_3Vector, _3Vector>>();
            var i = 0;
            var cnt = points.Count;
            foreach (var kvp in points)
            {
                if (i + 1 < cnt)
                {
                    var vec1 = new _3Vector(kvp.Xval, kvp.Yval, 0);

                    var pair2 = points.ElementAt(i + 1);
                    var vec2 = new _3Vector(pair2.Xval, pair2.Yval, 0);
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
