using System;
using System.Text;
using kx;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ActuarialIntelligence.Infrastructure.Data.Dtos;

namespace ActuarialIntelligence.Domain.ConnectedInstruction
{
    public class KXQueryConnection
    {
        private readonly c c;
        private readonly Object result;
        public KXQueryConnection(string host, int port,
string Credentials, string ReturnQuery)
        {
            c = new c(host, port, Credentials);
            result = c.k(ReturnQuery); // query the table using a sync msg (c.k)
        }
        /// <summary>
        /// Make use of function pointer and Function to take a string argument and parse this into parameters for training Python 
        /// or Plotting Algorithms
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="trade"></param>
        /// <param name="func"></param>
        public static void Subscribe(string host, int port, string trade, Func<string, Task> func)
        {
            c c = null;
            try
            {
                c = new c(host == "" ? "localhost" : host, port == 0 ? 80 : port); // user:pass as parameter
                c.k(trade == "" ? "sub[`trade;`MSFT.O`IBM.N]" : trade);
                while (true)
                {
                    object result = c.k();
                    c.Flip flip = c.td(result);
                    int nRows = c.n(flip.y[0]);
                    int nColumns = c.n(flip.x);
                    for (int row = 0; row < nRows; row++)
                    {
                        for (int column = 0; column < nColumns; column++)
                            // Define a delimiter within config.
                            func((column > 0 ? "," : "") + c.at(flip.y[column], row) + "\n"); // make use of function pointer in different framework (as these dont simultaneously exist in both frameworks), to make call for EventHub. Only parsing the message string {RAW}
                        System.Console.WriteLine();
                    }
                }
            }
            finally
            {
                if (c != null) c.Close();
            }
        }
        public static void KxQuery(string host, int port, string Credentials)
        {
            var list = new List<string>();
            c c = new c(host, port, Credentials);
            Console.WriteLine("Connected to Q Successfully!! \n");
            Console.WriteLine("Begin q script: \n");
            while (true)
            {
                var str = Console.ReadLine();
                var lis = str.Split('\n').ToList();
                list.AddRange(lis);
                if (str == "EXIT")
                {
                    break;
                }
            }

            foreach (var a in list)
            {
                Console.WriteLine("Executing : " + a + "\n");
                c.ks(a); // create example table using async msg (c.ks)                   
            }
            Console.WriteLine("\n Scripts Executed Successfully!!");

            c.Close();
        }
        public static void OptimizedMoveQueryAndWriteToFile(string host, int port,
            string Credentials,
    string SaveQuery, string ReturnQuery)
        {
            c c = new c(host, port, Credentials);
            Object result = c.k(ReturnQuery); // query the table using a sync msg (c.k)
            c.ks(SaveQuery); // save table
                             // A flip is a table. A keyed table is a dictionary where the key and value are both flips.
            Console.WriteLine("Successfully Written!! " + SaveQuery);
            c.Flip flip = c.td(result); // if the result set is a keyed table, this removes the key. 
            int nRows = c.n(flip.y[0]); // flip.y is an array of columns. Get the number of rows from the first column.
            int nColumns = c.n(flip.x); // flip.x is an array of column names
            Console.WriteLine("Number of columns: " + c.n(flip.x));
            Console.WriteLine("Number of rows:    " + nRows);
            c.Close();
        }


        public static Object GetQTable(string host, int port,
    string Credentials, string ReturnQuery)
        {
            c c = new c(host, port, Credentials);
            Object result = c.k(ReturnQuery); // query the table using a sync msg (c.k)
            c.Close();
            return result;
        }

        public static IList<string> GetQRows(string host, int port,
string Credentials, string ReturnQuery, int column, List<int> rows)
        {
            c c = new c(host, port, Credentials);
            Object result = c.k(ReturnQuery); // query the table using a sync msg (c.k)
            c.Flip flip = c.td(result);
            var returnList = new List<string>();
            foreach (var row in rows)
            {
                var pointer = (string)c.at(flip.y[column], row);
                returnList.Add(pointer);
            }
            c.Close();
            return returnList;
        }

        public object GetQField(int column, int row)
        {

            c.Flip flip = c.td(result);
            var pointer = c.at(flip.y[column], row);

            return pointer;
        }

        public int GetNumberOfRows()
        {
            c.Flip flip = c.td(result);
            return c.n(flip.x);
        }

        public void Dispose()
        {
            c.Close();
        }


        public static void OptimizedMoveQueryAndWriteToFileForReadingIntoMemmory(string host, int port, string Credentials,
string script, string SaveQuery, string ReturnQuery)
        {
            c c = new c(host, port, Credentials);
            var scriptLines = script.Split('\t').ToList();
            foreach (var qry in scriptLines)
            {
                c.ks(qry); // run script in KDB  

            }
            Object result = c.k(ReturnQuery);
            c.ks(SaveQuery);
            Console.WriteLine("Successfully Written!!");
            c.Flip flip = c.td(result); // if the result set is a keyed table, this removes the key. 
            int nRows = c.n(flip.y[0]); // flip.y is an array of columns. Get the number of rows from the first column.
            int nColumns = c.n(flip.x); // flip.x is an array of column names
            Console.WriteLine("Number of columns: " + c.n(flip.x));
            Console.WriteLine("Number of rows:    " + nRows);
            c.Close();
        }

        //\p [rp,][hostname:][portnumber|servicename]
        public static QueryResultObject Query(string host, int port, string Credentials,
            string CreateQuery, string ReturnQuery)
        {
            c c = new c(host, port, Credentials);

            Object result = c.k(ReturnQuery); // query the table using a sync msg (c.k)
            c.ks(CreateQuery); // create example table using async msg (c.ks)  
            c.Flip flip = c.td(result); // if the result set is a keyed table, this removes the key. 
            int nRows = c.n(flip.y[0]); // flip.y is an array of columns. Get the number of rows from the first column.
            int nColumns = c.n(flip.x); // flip.x is an array of column names
            Console.WriteLine("Number of columns: " + c.n(flip.x));
            Console.WriteLine("Number of rows:    " + nRows);
            string csvMessage = "";
            var lst = new List<string>();
            csvMessage = FormatData(flip, nRows, nColumns, csvMessage, lst);
            var queryObject = new QueryResultObject();
            queryObject.result = csvMessage;
            System.Console.WriteLine("\n Sent Event: " + csvMessage);
            c.Close();
            return queryObject;
        }

        private static string FormatData(c.Flip flip, int nRows, int nColumns,
            string csvMessage, List<string> rowList)
        {

            for (int column = 0; column < nColumns; column++)
                System.Console.Write((column > 0 ? "," : "") + flip.x[column]);

            for (int row = 0; row < nRows; row++)
            { // Define a Delimiter
                for (int column = 0; column < nColumns; column++)
                {
                    csvMessage += "," + c.at(flip.y[column], row);
                    Console.WriteLine("Formatted:" + row.ToString());
                }
            }

            var length = csvMessage.Length;
            var result = csvMessage.Substring(1, length - 1).Replace(',', '\t');
            return result;
        }

        public static void Query(string host, int port, string CreateQuery, string ReturnQuery, Func<string, string> func)
        {
            c c = new c("localhost", 5000, @"AFRICA/rajiyer:UnicalcTensor1");
            // c.ks("mytable:([]sym:10?`1;time:.z.p+til 10;price:10?100.;size:10?1000)"); // create example table using async msg (c.ks)
            Object result = c.k("tab4"); // query the table using a sync msg (c.k)
                                         // A flip is a table. A keyed table is a dictionary where the key and value are both flips.
            c.Flip flip = c.td(result); // if the result set is a keyed table, this removes the key. 
            int nRows = c.n(flip.y[0]); // flip.y is an array of columns. Get the number of rows from the first column.
            int nColumns = c.n(flip.x); // flip.x is an array of column names
            Console.WriteLine("Number of columns: " + c.n(flip.x));
            Console.WriteLine("Number of rows:    " + nRows);
            string csvMessage = "";
            for (int column = 0; column < nColumns; column++)
                System.Console.Write((column > 0 ? "," : "") + flip.x[column]);

            for (int row = 0; row < nRows; row++)
            { // Define a Delimiter
                for (int column = 0; column < nColumns; column++)
                {
                    csvMessage += (column > 0 ? "," : "") + c.at(flip.y[column], row);
                }
            }
            func(csvMessage);
            System.Console.WriteLine("Sent Event: " + csvMessage);
            c.Close();
        }
    }
}
