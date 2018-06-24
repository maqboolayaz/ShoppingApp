using AppConstants;
using AppInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientHandler
{
    public class AppHttpServicesHandler : IHttpServicesHandler
    {
        public async Task<T> PostAsync<T>(Uri url, HttpContent content) where T : class
        {
            using (var client = new HttpClient())
            {
                try
                {
                        var response = await HttpUtility.PostAsync<T>(client, url, content);
                        return response;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        public T PostTestAsync<T>(Uri url, HttpContent content) where T : class
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = HttpUtility.PostTestAsync<T>(client, url, content);
                    return response;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        public async Task<HttpResponseMessage> PostAsync(Uri url, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                return await HttpUtility.PostResponseAsync(client, url, content);
            }
        }
    }
}
