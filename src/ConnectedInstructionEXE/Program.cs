using ActuarialIntelligence.Domain.ConnectedInstruction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace testObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Stream: " + DateTime.Now.ToString());
            var sr = new StreamReader(@"C:\data\table.csv");
            var grid = new List<IList<double>>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var fieldValues = line.Split(',');
                var fields = new List<double>();
                var rdm = new Random(100000);
                foreach (var field in fieldValues)
                {
                    var res = 0d;
                    var add = double.TryParse(field, out res) == true ? res : rdm.NextDouble();
                    fields.Add(add);
                }
                grid.Add(fields);
            }
            Console.WriteLine("Grid loaded successfully!! " + DateTime.Now.ToString());
            var keepProcessing = true;
            while (keepProcessing)
            {
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Enter Expression:");
                var expression = Console.ReadLine();
                if (expression.ToLower() == "exit")
                {
                    keepProcessing = false;
                }
                else
                {
                    try
                    {
                        if (expression.Equals("write"))
                        {
                            keepProcessing = true;
                            ConnectedInstruction.WritetoCsvu(grid, @"c:\data\temp.csv");
                        }
                        if (expression.Substring(0, 9) == "getvalue(")
                        {
                            keepProcessing = true;
                            Regex r = new Regex(@"\(([^()]+)\)*");
                            var res = r.Match(expression);
                            var val = res.Value.Split(',');
                            try
                            {
                                var gridVal = grid[int.Parse(val[0].Replace("(", "").Replace(")", ""))]
                                    [int.Parse(val[1].Replace("(", "").Replace(")", ""))];
                                Console.WriteLine(gridVal.ToString() + "\n");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Hmmm,... apologies, can't seem to find that within range...");
                            }
                        }
                        else
                        {
                            keepProcessing = true;
                            Console.WriteLine("Process Begin:" + DateTime.Now.ToString());
                            var result = ConnectedInstruction.ParseExpressionAndRunAgainstInMemmoryModel(grid, expression);
                            Console.WriteLine("Process Ended:" + DateTime.Now.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }
                }
            }
        }
    }
}
