using Newtonsoft.Json;
using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace ActuarialIntelligence.Infrastructure.Consumers
{
    public static class Class1
    {
        public static void test()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest
                 .Create("http://localhost:5000/api/Domain/Test");
            request.Method = "POST";
            request.ContentType = "application/json";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                string json = serializer.Serialize(new ParseObject()
                {
                    array = new string[2]
                    { "async","bool"},
                    testValue1 = 1
                    ,
                    testValue2 = 2
                });
                sw.Write(json);
                sw.Flush();
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];
            // Reads 256 characters at a time.    
            int count = readStream.Read(read, 0, 256);
            Console.WriteLine("HTML...\r\n");
            var strP = "";
            while (count > 0)
            {
                // Dumps the 256 characters on a string and displays the string to the console.
                String str = new String(read, 0, count);
                Console.Write(str);
                strP += str;
                count = readStream.Read(read, 0, 256);
            }
            //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<ParseObject>(strP);
        }
        public class ParseObject
        {
            public String[] array;
            public decimal testValue1;
            public decimal testValue2;

        }

        public class TermCashflowYieldSet
        {
            public decimal cashflow;
            public decimal term;
            public DateTime date;
            //public SpotYield spotYield;
        }
    }
}
