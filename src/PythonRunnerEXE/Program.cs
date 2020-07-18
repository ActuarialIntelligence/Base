using System;
using System.Diagnostics;

namespace PythonRunnerEXE
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
