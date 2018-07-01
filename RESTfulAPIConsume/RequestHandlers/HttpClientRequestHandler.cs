using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using RESTfulAPIConsume.Constants;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class HttpClientRequestHandler: IRequestHandler
    {
        public JToken GetReleases(string url)
        {
            //httpClient is meant to be used asynchronously but here it is not for demo purposes.

            using (var httpClient = new HttpClient()) //httpClient is best implemented as a reusable object keeping one instance within the app for each API. Even better, httpClientHandler can be reused across calls.
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", RequestConstants.UserAgent);

                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                
                return JArray.Parse(response);
            }
        }
    }
}
