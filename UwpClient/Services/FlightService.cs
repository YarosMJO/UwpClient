using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class FlightService
    {
        HttpClient client;
        private string Uri = App.BaseUri + "flights";

        public FlightService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Flight>> GetAll()
        {
            string result = await client.GetStringAsync(Uri);
            return JsonConvert.DeserializeObject<IEnumerable<Flight>>(result);
        }

        public async Task<Flight> Get(int id)
        {
            string result = await client.GetStringAsync(Uri + "/" + id);
            return JsonConvert.DeserializeObject<Flight>(result);
        }

        public async Task Create(Flight flight)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Flight flight)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            await client.PutAsync(Uri + "/" + flight.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(Uri + "/" + id).ConfigureAwait(false);
        }



    }
}
