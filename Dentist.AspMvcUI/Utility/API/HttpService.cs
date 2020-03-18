using Dentist.Entities.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dentist.AspMvcUI.Utility.API
{
    public class HttpService
    {
        static Uri url = new Uri("https://localhost:44382/api/");
        //static Uri url = new Uri("http://dentist.reklamkafe.com/api/");

        public static string Get(string controllerName, string requestUri)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + controllerName + "/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 4)
                        result = string.Empty;
                    else
                        result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }

        public static string Get(string controllerName, string requestUri, int id)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + controllerName + "/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUri + "/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 4)
                        result = string.Empty;
                    else
                        result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }


        public static string Post(string controllerName, string requestUri, object model)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + controllerName + "/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync(requestUri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 4)
                        result = string.Empty;
                    else
                        result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }

        public static string Delete(string controllerName, string requestUri, int id)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + controllerName + "/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.DeleteAsync(requestUri + "/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 4)
                        result = string.Empty;
                    else
                        result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }

        public static string Update(string controllerName, string requestUri, object model)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + controllerName + "/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PutAsync(requestUri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 4)
                        result = string.Empty;
                    else
                        result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }
    }
}