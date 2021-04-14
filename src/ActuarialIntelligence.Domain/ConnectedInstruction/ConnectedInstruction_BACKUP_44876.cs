using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ActuarialIntelligence.Domain.ConnectedInstruction
{
    public class ConnectedInstruction
    {
        private static IList<IList<double>> gridValues;
<<<<<<< HEAD
=======
        private readonly KXQueryConnection Qparser;
        private static readonly bool IsMemoryPointer = true;
        public ConnectedInstruction()
        {
            Qparser = new KXQueryConnection("localhost", 5000, "AFRICA/rajiyer:", "table"); ;
        }


>>>>>>> Integrated KDB ConnectedInstruction and parser objects. Tested
        //public static string expression;
        public static IList<IList<double>> ParseExpressionAndRunAgainstInMemmoryModel(IList<IList<double>> GridValues, string expression)
        {
            gridValues = GridValues;
<<<<<<< HEAD
=======
            //var conIns = new ConnectedInstruction();
            //var tempTest = (double) conIns.GetField(7, 4);
>>>>>>> Integrated KDB ConnectedInstruction and parser objects. Tested
            #region HandleNullGrids
            if (gridValues == null)
            {
                gridValues = new List<IList<double>>();
                gridValues.Add(new List<double>() { 1d, 2d, 3d, 4d, 5d, 6d, 0d });
                gridValues.Add(new List<double>() { 1d, 2d, 3d, 4d, 5d, 6d, 0d });
                gridValues.Add(new List<double>() { 1d, 2d, 3d, 4d, 5d, 6d, 0d });
            }
            #endregion            

            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });

            CompilerParameters cp;
            string code;
            ParseExpressionAgainstLoadedInMemoryData(expression, out cp, out code);
            CompilerParameters cpd;
            string codeD;
            DynamicallyParseExpressionDirectlyAgainstKDBDataInDirectMemmoryPointerFashion(expression, out cpd, out codeD);
            // "results" will usually contain very detailed error messages
            if (!IsMemoryPointer)
            {
                var results = csc.CompileAssemblyFromSource(cp, code);
                InvokeAndErrorhandle(results);
            }
            if (IsMemoryPointer)
            {
                var resultsD = csc.CompileAssemblyFromSource(cpd, codeD);
                InvokeAndErrorhandle(resultsD);
            }

            return gridValues;
        }

        private static void ParseExpressionAgainstLoadedInMemoryData(string expression, out CompilerParameters cp, out string code)
        {
            #region DynamicCodeInjectionForEfficientParsingOfScript
            cp = new CompilerParameters()
            {
                GenerateExecutable = false,
                OutputAssembly = "outputAssemblyName",
                GenerateInMemory = true
            };
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("ActuarialIntelligence.Domain.dll");
            cp.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);
            //StringBuilder sb = new StringBuilder();
            // This is Dangerous as it is open to code injection by design. Any implementation of this pattern
            // must be secured by the implementer

            // The string can contain any valid c# code and Rajah knows is best best stored in separate text class file
            code = @"

                using System;
                using System.Collections.Generic;
                namespace ActuarialIntelligence.Domain.ConnectedInstruction
                {
                    public class RuntimeClass
                    {
                        public static void Main (IList<IList<double>> gridValues)
                        {
<<<<<<< HEAD
                            ActionFunc(gridValues ,(u, v, w, x, y, z) => " + expression + @"); 
=======
                            return ActionFunc(gridValues ,(u, v, w, x, y, z) => " + expression + @"); 
>>>>>>> Integrated KDB ConnectedInstruction and parser objects. Tested
                        }

                        public static void ActionFunc(IList<IList<double>> gridValues,
                            Func<double, double, double,
                            double, double, double, double> expression)
                        {
                            //var result = new List<double>();
                            foreach (var row in gridValues)
                            {
                                var calc = expression(row[0], row[1], row[2], row[3], row[4], row[5]);
                                row.Add(calc);
<<<<<<< HEAD
=======
                                result.Add(calc);
>>>>>>> Integrated KDB ConnectedInstruction and parser objects. Tested
                                //Console.WriteLine(calc.ToString());
                            }
                        }
                    }
                }

                ";
            // "+ expression + @" 
            #endregion
        }

        private static void DynamicallyParseExpressionDirectlyAgainstKDBDataInDirectMemmoryPointerFashion(string expression, out CompilerParameters cpd, out string codeD)
        {
            #region DynamicCreationWithDirectPointersToKDBSource
            cpd = new CompilerParameters()
            {
                GenerateExecutable = false,
                OutputAssembly = "outputAssemblyName",
                GenerateInMemory = true
            };
            cpd.ReferencedAssemblies.Add("mscorlib.dll");
            cpd.ReferencedAssemblies.Add("System.dll");
            cpd.ReferencedAssemblies.Add("ActuarialIntelligence.Domain.dll");
            cpd.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);
            //StringBuilder sb = new StringBuilder();
            // This is Dangerous as it is open to code injection by design. Any implementation of this pattern
            // must be secured by the implementer

            // The string can contain any valid c# code
            codeD = @"

                using System;
                using System.Collections.Generic;
                namespace ActuarialIntelligence.Domain.ConnectedInstruction
                {
                    public class RuntimeClass
                    {
                        public static List<double> Main (IList<IList<double>> gridValues)
                        {
                            return ActionFunc(gridValues ,(u, v, w, x, y, z) => " + expression + @"); 
                        }

                        public static List<double> ActionFunc(IList<IList<double>> gridValues,
                            Func<double, double, double,
                            double, double, double, double> expression)
                        {
                            var result = new List<double>();
                            var c = new ConnectedInstruction();
                            var rowN = c.GetNumberOfRows();
                            for(int i=2;i<rowN;i++)
                            {
                                var calc = expression((double)c.GetField(i,0), (double)c.GetField(i,1), (double)c.GetField(i,2), (double)c.GetField(i,3), (double)c.GetField(i,4), (double)c.GetField(i,5));                            
                            }
                            c.DisposeQconnection();
                            return result;
                        }
                    }
                }

                ";
            // "+ expression + @" 
            #endregion
        }

        private static void InvokeAndErrorhandle(CompilerResults results)
        {
            if (results.Errors.HasErrors)
            {
                string errors = "";
                foreach (CompilerError error in results.Errors)
                {
                    errors += string.Format("Error #{0}: {1}\n", error.ErrorNumber, error.ErrorText);
                }
                Console.Write(errors);
            }
            else
            {
                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("ActuarialIntelligence.Domain.ConnectedInstruction.RuntimeClass");
                MethodInfo main = program.GetMethod("Main");
                object[] parameters = new object[1];
                parameters[0] = gridValues;
                List<double> returnType = new List<double>();
                main.Invoke(returnType, parameters);
                //Console.WriteLine("Square root = \u221A");
            }
        }
<<<<<<< HEAD
=======

>>>>>>> Integrated KDB ConnectedInstruction and parser objects. Tested
        public static void WritetoCsvu(IList<IList<double>> gridValues, string path)
        {
            Console.WriteLine("Write Begin " + DateTime.Now.ToString());
            var sw = new StreamWriter(path);
            var cnt = 0;
            foreach (var row in gridValues)
            {
                sw.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + row[3] + "," + row[4] + "," + row[5] + "," + row[6]);
                cnt++;
            }
            sw.Close();
            Console.WriteLine("Write Complete " + DateTime.Now.ToString());
        }
<<<<<<< HEAD
=======

        public double GetField(int row, int column)
        {
            return Convert.ToDouble(Qparser.GetQField(column, row));
        }

        public int GetNumberOfRows()
        {
            return Qparser.GetNumberOfRows();
        }

        public void DisposeQconnection()
        {
            Qparser.Dispose();
        }
>>>>>>> Integrated KDB ConnectedInstruction and parser objects. Tested
    }
}
