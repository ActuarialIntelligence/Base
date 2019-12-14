using Newtonsoft.Json;
using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using ActuarialIntelligence.Domain.Enums;

namespace ActuarialIntelligence.Calculators.Helpers
{
    //"http://localhost:5000/api/Domain/Test"
    //"POST"
    public static class APIConsumerHelper
    {
        public static ReturnType ReceiveHTTPObjectPointer<ParameterType,ReturnType>(ParameterType parameterLObject, 
            string url,
            RESTMethodType methodType)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
                     .Create(url);
            request.Method = methodType.ToString();
            request.ContentType = "application/json";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                string json = serializer.Serialize(parameterLObject);
                sw.Write(json);
                sw.Flush();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            string strP = ReadResponseStream(receiveStream);
            var result = JsonConvert.DeserializeObject<ReturnType>(strP);
            return result;
        }

        private static string ReadResponseStream(Stream receiveStream)
        {
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
            return strP;
        }
    }
}
