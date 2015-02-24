using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FreeLancaVS2012.Data
{
    public class HttpRequester
    {
        public static T Get<T>(string resourceUrl, IDictionary<string, string> headers = null)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = request.GetResponse();
            string responseString;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }
            var responseData = JsonConvert.DeserializeObject<T>(responseString);
            return responseData;
        }

        public static void Get(string resourceUrl)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            request.GetResponse();
        }

        public static void Post(string resourceUrl, object data)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";

            var jsonData = JsonConvert.SerializeObject(data);

            using (StreamWriter writer =
                new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }

            request.GetResponse();
        }

        public static T Post<T>(string resourceUrl,
            object data,
            IDictionary<string, string> headers = null)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var jsonData = JsonConvert.SerializeObject(data);

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }
            //try
            //{
            var response = request.GetResponse();
            string responseString;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
            }
            var responseData = JsonConvert.DeserializeObject<T>(responseString);
            return responseData;
            //}
            //catch (Exception)
            //{
            //    //var responseData = ""
            //    return T;
            //}


        }

        public static void Delete(string resourceUrl)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "DELETE";
            request.GetResponse();
        }

        internal static bool Put(string resourceUrl,
            IDictionary<string, string> headers = null)
        {
            var request = WebRequest.Create(resourceUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "PUT";

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            //var jsonData = JsonConvert.SerializeObject(data);

            using (StreamWriter writer =
                new StreamWriter(request.GetRequestStream()))
            {
                writer.Write("");
            }

            try
            {
                var response = request.GetResponse();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
