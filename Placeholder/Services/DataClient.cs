using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Placeholder
{
    public class DataClient
    {
        string _uri;

        public DataClient(string uri)
        {
            _uri = uri;
        }

        public async Task<T> GetAsync<T>()
        {
            using (var client = new HttpClient()) 
            {
                try
                {
                    var response = await client.GetAsync(_uri);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);    
                }
                catch
                {
                    return default(T);
                }
            }
        }
    }
}

