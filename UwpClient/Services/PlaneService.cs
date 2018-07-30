using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class PlaneService
    {
        HttpClient client;
        private string Uri = App.BaseUri + "planes/";

        public PlaneService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Plane>> GetAll()
        {
            string result = await client.GetStringAsync(Uri);
            return JsonConvert.DeserializeObject<IEnumerable<Plane>>(result);
        }

        public async Task<Plane> Get(int id)
        {
            string result = await client.GetStringAsync(Uri + id);
            return JsonConvert.DeserializeObject<Plane>(result);
        }


        public async Task Create(Plane Plane)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Plane), Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Plane Plane)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Plane), Encoding.UTF8, "application/json");
            await client.PutAsync(Uri + Plane.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(Uri + id).ConfigureAwait(false);
        }
    }
}
