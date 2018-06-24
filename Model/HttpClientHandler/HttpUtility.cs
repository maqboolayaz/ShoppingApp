using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientHandler
{
    public class HttpUtility
    {

        public static async Task<T> PostAsync<T>(HttpClient client, Uri url, HttpContent httpContent) where T : class
        {
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(result).ToString();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Please check your Internet connectivity");
            }
            throw CheckResponseForException(response);

        }

        public static T PostTestAsync<T>(HttpClient client, Uri url, HttpContent httpContent) where T : class
        {
            HttpResponseMessage response;
            try
            {
                //For testing purposes, return hard-coded json

                //var jsonText = File.ReadAllText(@"Data/Orders.json");
                var jsonResult = JsonConvert.DeserializeObject(sampleJson).ToString();
                var ordersJson = JsonConvert.DeserializeObject<T>(jsonResult);
                return ordersJson;
            }
            catch (Exception ex)
            {
                throw new Exception("Please check your Internet connectivity");
            }
            throw CheckResponseForException(response);
        }

        public static async Task<HttpResponseMessage> PostResponseAsync(HttpClient client, Uri url, HttpContent httpContent = null)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Please check your Internet connectivity");
            }
            throw CheckResponseForException(response);
        }

        private static Exception CheckResponseForException(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                case HttpStatusCode.Unauthorized:
                    throw new Exception("User is not authorized");
                case HttpStatusCode.InternalServerError:
                    throw new Exception("Internal server error");
                case HttpStatusCode.RequestTimeout:
                    throw new Exception("Request Timed Out");
                case HttpStatusCode.BadRequest:
                    throw new Exception("Bad Request");
                default:
                    throw new Exception("Error Connecting to API Server");
            }
        }

        public static string sampleJson = @"[{
                            ""orderId"": ""a63884f0 - 3f7f - 4ddf - 80c7 - ca4fc99a3adf"",
                            ""orderNumber"": 407101,
                            ""productName"": ""Korkdichtungsbahnen - max. 120ºC"",
                            ""targetQtyBuom"": 5,
                            ""targetSize"": ""80x60"",
                            ""targetDeliveryAt"": ""2018-06-27T16:00:00.000Z"",
                            ""targetPsa"": ""Bauplatz 1"",
                            ""targetPsaBin"": ""Anlieferpunkt 3""
                        },
                        {
                            ""orderId"": ""39918d2e-c72f-4c87-b8f7-46f3f64b7935"",
                            ""orderNumber"": 407102,
                            ""productName"": ""Acryl-Dispersionsdichtungsmasse - Kartusche"",
                            ""targetQtyBuom"": 1,
                            ""targetSize"": ""310ml"",
                            ""targetDeliveryAt"": ""2018-06-26T16:30:00.000Z"",
                            ""targetPsa"": ""Bauplatz 4"",
                            ""targetPsaBin"": ""Anlieferpunkt 1""
                        },
                        {
                            ""orderId"": ""264df721-29e2-4b28-baa3-d06d8b591677"",
                            ""orderNumber"": 407103,
                            ""productName"": ""Dichtungspapier - max. 400ºC"",
                            ""targetQtyBuom"": 3,
                            ""targetSize"": ""120x120"",
                            ""targetDeliveryAt"": ""2018-06-23T15:20:00.000Z"",
                            ""targetPsa"": ""Bauplatz A2"",
                            ""targetPsaBin"": ""Anlieferpunkt 2""
                        },
                        {
                            ""orderId"": ""9a2c249a-d6ca-4a2f-b978-458f6ff70ee7"",
                            ""orderNumber"": 407104,
                            ""productName"": ""Dichtband - Teflon - standard"",
                            ""targetQtyBuom"": 1,
                            ""targetSize"": ""Breite 12 / Stärke 0,1mm"",
                            ""targetDeliveryAt"": ""2018-06-23T22:02:00.000Z"",
                            ""targetPsa"": ""Bauplatz 1"",
                            ""targetPsaBin"": ""Anlieferpunkt 1""
                        }]";

    }
}
