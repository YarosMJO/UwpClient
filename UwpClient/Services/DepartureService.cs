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
        private string Uri = App.BaseUri + "departures/";

        public DepartureService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Departure>> GetAll()
        {
            string result = await client.GetStringAsync(Uri);
            return JsonConvert.DeserializeObject<IEnumerable<Departure>>(result);
        }

        public async Task<Departure> Get(int id)
        {
            string result = await client.GetStringAsync(Uri + "/" + id);
            return JsonConvert.DeserializeObject<Departure>(result);
        }

        public async Task Create(Departure Departure)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Departure), Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Departure Departure)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Departure), Encoding.UTF8, "application/json");
            await client.PutAsync(Uri + "/" + Departure.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(Uri + "/" + id).ConfigureAwait(false);
        }
    }
}
