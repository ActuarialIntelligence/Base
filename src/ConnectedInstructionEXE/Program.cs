using ActuarialIntelligence.Domain.ConnectedInstruction;
using Domain;
using Domain.ObservationObjects;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        if (expression.Substring(0, 19).ToLower().Equals("logisticregression "))
                        {
                            keepProcessing = true;
                            var paths = expression.Split(' '); 
                            #region Python
var script =@"
import pandas as pd
from sklearn.linear_model import LogisticRegression
from sklearn.cross_validation import train_test_split
from sklearn.metrics import confusion_matrix
from sklearn.metrics import accuracy_score

creditData = pd.read_csv("+paths[1]+@")

print(creditData.head())
print(creditData.describe())
print(creditData.corr())

features = creditData[['income', 'age', 'loan']]
target = creditData.default

feature_train, feature_test, target_train, target_test = train_test_split(features, target, test_size = 0.3)

model = LogisticRegression()
model.fit = model.fit(feature_train, target_train)
predictions = model.fit.predict(feature_test)

print(confusion_matrix(target_test, predictions))
print(accuracy_score(target_test, predictions))
";
                            var sw = new StreamWriter(@"c:\data\logistic.py");
                            sw.Write(script);
                            sw.Close();
                            #endregion
                            ProcessStartInfo start = new ProcessStartInfo();
                            Console.WriteLine("Starting Python Engine...");
                            start.FileName = @"C:\Users\rajiyer\PycharmProjects\TestPlot\venv\Scripts\python.exe";
                            start.Arguments = string.Format("{0} {1}", paths[1], args);
                            start.UseShellExecute = false;
                            start.RedirectStandardOutput = true;
                            Console.WriteLine("Starting Process..."+ DateTime.Now.ToString());
                            using (Process process = Process.Start(start))
                            {
                                using (StreamReader reader = process.StandardOutput)
                                {
                                    string result = reader.ReadToEnd();
                                    Console.Write(result);
                                }
                            }
                            Console.WriteLine("Process Succeeded..." + DateTime.Now.ToString());
                            //ScriptSource source = engine.CreateScriptSourceFromFile(@"c:\data\logistic.py");
                            //ScriptScope scope = engine.CreateScope();
                            ////List<String> argv = new List<String>();
                            //////Do some stuff and fill argv
                            ////argv.Add("foo");
                            ////argv.Add("bar");
                            ////engine.GetSysModule().SetVariable("argv", argv);
                            //source.Execute(scope);
                        }
                        if (expression.Substring(0,12).ToLower().Equals("kaplanmeier "))
                        {
                            keepProcessing = true;
                            var columnsOfconcern = expression.Split(' ');
                            Console.WriteLine("Preparing...");
                            var observations = new List<PairedObservation>();
                            var ca = GetColumn(grid,int.Parse(columnsOfconcern[1]));
                            var cb = GetColumn(grid, int.Parse(columnsOfconcern[2]));
                            var cc = GetColumn(grid, int.Parse(columnsOfconcern[3]));
                            for(int i=0;i<ca.Count;i++)
                            {
                                observations.Add(new PairedObservation((decimal)ca[i], (decimal)cb[i], (decimal)cc[i]));
                            }
                            var kp = new KaplanMeier(observations);
                        }
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

        public static IList<double> GetColumn(IList<IList<double>> gridValues, int column)
        {
            var columnValues = new List<double>();
            foreach (var row in gridValues)
            {
                columnValues.Add(row[column]);
            }
            return columnValues;
        }
    }
}
