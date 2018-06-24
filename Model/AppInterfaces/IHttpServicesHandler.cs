using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppInterfaces
{
    public interface IHttpServicesHandler
    {
        Task<HttpResponseMessage> PostAsync(Uri url, HttpContent content);

        Task<T> PostAsync<T>(Uri url, HttpContent content) where T : class;

        T PostTestAsync<T>(Uri url, HttpContent content) where T : class;
    }
}
