using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class DepartureService
    {
        HttpClient client;
        private string uri = App.BaseURI + "departures";

        public DepartureService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Departure>> GetAll()
        {
            string result = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<IEnumerable<Departure>>(result);
        }

        public async Task<Departure> Get(int id)
        {
            string result = await client.GetStringAsync(uri + "/" + id);
            return JsonConvert.DeserializeObject<Departure>(result);
        }

        public async Task Create(Departure Departure)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Departure), Encoding.UTF8, "application/json");
            await client.PostAsync(uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Departure Departure)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Departure), Encoding.UTF8, "application/json");
            await client.PutAsync(uri + "/" + Departure.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(uri + "/" + id).ConfigureAwait(false);
        }
    }
}
