﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;


namespace PythonRunnerEXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var pixcelList = GetPixcleList(@"C:\Users\rajiyer\Pictures\floorMarked.png");
            var filteredList = FilterForModel(pixcelList).OrderBy(u=>u.Key);
        }

        private static void CallProcessForexecution(string[] args)
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
        
        private static IDictionary<int, int> GetPixcleList(string path)
        {

            System.Drawing.Bitmap b = new System.Drawing.Bitmap(path);
            var colour = new Color();
            var col = Color.FromArgb(0, 255, 0);
            IDictionary<int,int> colorList = new Dictionary<int, int>();

                for (int y = 0; y < b.Height; y++)
                {
                    for (int x = 0; x < b.Width; x++)
                    {
                        if (b.GetPixel(x, y).ToArgb().Equals(col.ToArgb()))
                        {
                            colorList.TryAdd(x,y);
                        }
                    }
                }
            return colorList;
        }
        private static IDictionary<int, int> FilterForModel(IDictionary<int, int> keyValuePairs)
        {
            var filteredList = new Dictionary<int, int>();
            var allKeys = keyValuePairs.Keys;
            var allValues = keyValuePairs.Values;

            var groupedKVP = keyValuePairs.GroupBy(u => u.Value);
            var i = 0;
            foreach (var grouping in groupedKVP)
            {
                var elements = grouping.ElementAtOrDefault(i);
                filteredList.Add(elements.Key,elements.Value);
            }

            return filteredList;
        }
    }  
}
