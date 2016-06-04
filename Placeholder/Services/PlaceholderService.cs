using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Placeholder
{
    public class PlaceholderService
    {
        public PlaceholderService()
        {
        }

        public async Task<List<Album>> GetAlbumsAsync() {
            var client = new DataClient("http://jsonplaceholder.typicode.com/albums");

            return await client.GetAsync<List<Album>>();
        }
           
        public async Task<List<Photo>> GetPhotosAsync(int albumId)
        {
            var client = new DataClient(string.Format("http://jsonplaceholder.typicode.com/albums/{0}/photos", albumId));

            return await client.GetAsync<List<Photo>>();
        }
    }
}

