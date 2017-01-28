using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IHttpService
    {
        string URI { get; set; }

        Task<HttpResult<TResult>> GetAsync<TResult>(string endPoint, 
            params HttpHeader[] headers) where TResult : class;
        Task<HttpResult<TResult>> GetAsync<TResult>(string endPoint, string id, 
            params HttpHeader[] headers) where TResult : class;
        Task<HttpResult<TResult>> Post<TResult>(string endPoint, TResult data,
            params HttpHeader[] headers) where TResult : class;
        Task<HttpResult<TResult>> Put<TResult>(string endPoint, string id, TResult data,
            params HttpHeader[] headers) where TResult : class;
        Task<HttpResult<TResult>> Delete<TResult>(string endPoint, string id, 
            params HttpHeader[] headers) where TResult : class;
    }
}
