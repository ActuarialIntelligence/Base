using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuarialIntelligence.Domain.ConnectedInstruction
{
    public static class ConnectedInstruction
    {
        public static IList<IList<double>> gridValues;
        //public static string expression;
        public static IList<IList<double>> ParseExpressionAndRunAgainstInMemmoryModel(string expression)
        {
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
            var cp = new CompilerParameters()
            {
                GenerateExecutable = false,
                OutputAssembly = "outputAssemblyName",
                GenerateInMemory = true
            };

            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);
            //StringBuilder sb = new StringBuilder();
            // This is Dangerous as it is open to code injection by design. Any implementation of this pattern
            // must be secured by the implementer
            #region DynamicCodeInjectionForEfficientParsingOfScript
            // The string can contain any valid c# code
            string code = @"

                using System;
                using System.Collections.Generic;
                namespace demo.domain
                {
                    public class RuntimeClass
                    {
                        public static List<double> Main (IList<IList<double>> gridValues)
                        {
                            var res = ActionFunc(gridValues ,(u, v, w, x, y, z) => " + expression + @");
                            return res;
                        }

                        public static List<double> ActionFunc(IList<IList<double>> gridValues,
                            Func<double, double, double,
                            double, double, double, double> expression)
                        {
                            var result = new List<double>();
                            foreach (var row in gridValues)
                            {
                                var calc = expression(row[0], row[1], row[2], row[3], row[4], row[5]);
                                row[6] = calc;
                                result.Add(calc);
                                //Console.WriteLine(calc.ToString());
                            }
                            return result;
                        }
                    }
                }

                ";// "+ expression + @" 
            #endregion
            // "results" will usually contain very detailed error messages
            var results = csc.CompileAssemblyFromSource(cp, code);
            InvokeAndErrorhandle(results);
            return gridValues;
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
                Type program = assembly.GetType("demo.domain.RuntimeClass");
                MethodInfo main = program.GetMethod("Main");
                object[] parameters = new object[1];
                parameters[0] = gridValues;
                List<double> returnType = new List<double>();
                main.Invoke(returnType, parameters);
                //Console.WriteLine("Square root = \u221A");
            }
        }
    }
}
