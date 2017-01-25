using Core.Helpers;
using ModernHttpClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Services
{
    public class HttpService
    {
        private static string _baseURI = null;

        public HttpService()
        {

        }

        public string URI
        {
            get { return _baseURI; }
            set { _baseURI = value; }
        }

        public async Task<HttpResult<TResult>> Get<TResult>(string endPoint, params HttpHeader[] headers) where TResult : class
        {
            if (_baseURI == null)
            {
                return await Task.Run(() =>
                {
                    return new HttpResult<TResult>(System.Net.HttpStatusCode.NotFound,
                        "Please, configure the URI before use the class");
                });
            }

            string url = string.Format("{0}{1}", _baseURI, endPoint);

            var httpClient = new HttpClient(new NativeMessageHandler());

            for (int i = 0; i < headers.Length; i++)
            {
                httpClient.DefaultRequestHeaders.Add(headers[i].Type, headers[i].Value);
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.SendAsync(request);
            string jsonObj = await response.Content.ReadAsStringAsync();

            return await Task.Run(() =>
            {
                var obj = JsonConvert.DeserializeObject<IList<TResult>>(jsonObj);
                return new HttpResult<TResult>(obj, response.StatusCode);
            });
        }

        //protected async Task<TResult> Get<TResult>(string endPoint, string id) where TResult : class
        //{
        //    string url = string.Format("{0}{1}/{2}", ConfigApp.RestApiBaseUrl, endPoint, id);

        //    HttpClient httpClient = new HttpClient();
        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = await httpClient.SendAsync(request);
        //    string result = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<TResult>(result);
        //}

        //protected async Task<TResult> Post<TResult>(string endPoint, TResult data) where TResult : class
        //{
        //    string url = string.Format("{0}{1}", ConfigApp.RestApiBaseUrl, endPoint);

        //    HttpClient httpClient = new HttpClient();
        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = await httpClient.SendAsync(request);
        //    string result = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<TResult>(result);
        //}

        //protected async Task<TResult> Put<TResult>(string endPoint, string id, TResult data) where TResult : class
        //{
        //    string url = string.Format("{0}{1}/{2}", ConfigApp.RestApiBaseUrl, endPoint, id);

        //    HttpClient httpClient = new HttpClient();
        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = await httpClient.SendAsync(request);
        //    string result = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<TResult>(result);
        //}

        //protected async Task<bool> Delete(string endPoint, string id)
        //{
        //    string url = string.Format("{0}{1}/{2}", ConfigApp.RestApiBaseUrl, endPoint, id);

        //    HttpClient httpClient = new HttpClient();
        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
        //    HttpResponseMessage response = await httpClient.SendAsync(request);
        //    await response.Content.ReadAsStringAsync();
        //    return true;
        //}
    }
}
