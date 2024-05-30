using AssignmentTask_Api.Returns;
using Newtonsoft.Json;
using System.Net;

namespace Assignmnt_Task.ClientHelper
{
    public static class HttpClientHelper
    {
        public static async Task<ApiReturnObj<List<T>>> Get<T>(string url) where T : class
        {
            try
            {
                HttpClient httpClient = new();
                var res = await httpClient.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var responce = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiReturnObj<List<T>>>(responce);
                }
                return new ApiReturnObj<List<T>> { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Value = null };
            }
            catch (Exception)
            {
                return new ApiReturnObj<List<T>> { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Value = null };
            }
        }
        public static async Task<ApiReturnObj<T>> GetById<T>(string url) where T : class
        {
            try
            {
                HttpClient httpClient = new();
                var res = await httpClient.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var responce = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiReturnObj<T>>(responce);
                }
                return new ApiReturnObj<T> { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Value = null };
            }
            catch (Exception)
            {
                return new ApiReturnObj<T> { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Value = null };
            }
        }
        public static async Task<ApiReturnObj<T>> Post<T, Y>(string url, Y model) where T : class
        {
            try
            {
                HttpClient httpClient = new();
                HttpResponseMessage res = await httpClient.PostAsJsonAsync(url, model);
                if (res.IsSuccessStatusCode)
                {
                    var responce = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiReturnObj<T>>(responce);
                }
                return new ApiReturnObj<T> { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Value = null };
            }
            catch (Exception)
            {
                return new ApiReturnObj<T> { HttpStatusCode = System.Net.HttpStatusCode.InternalServerError, Value = null };
            }
        }
        public static async Task<HttpStatusCode> Put<T>(string url, T model) where T : class
        {
            try
            {
                HttpClient httpClient = new();
                HttpResponseMessage res = await httpClient.PostAsJsonAsync(url, model);
                if (res.IsSuccessStatusCode)
                {
                    var responce = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<HttpStatusCode>(responce);
                }
                return HttpStatusCode.InternalServerError;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        public static async Task<HttpStatusCode> Delete(string url)
        {
            try
            {
                HttpClient httpClient = new();
                HttpResponseMessage res = await httpClient.DeleteAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var responce = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<HttpStatusCode>(responce);
                }
                return HttpStatusCode.InternalServerError;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
