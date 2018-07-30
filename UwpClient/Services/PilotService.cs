using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class PilotService
    {
        HttpClient client;
        private string uri = App.BaseURI + "pilots";

        public PilotService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Pilot>> GetAll()
        {
            string result = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<IEnumerable<Pilot>>(result);
        }

        public async Task<Pilot> Get(int id)
        {
            string result = await client.GetStringAsync(uri + "/" + id);
            return JsonConvert.DeserializeObject<Pilot>(result);
        }

        public async Task Create(Pilot Pilot)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
            await client.PostAsync(uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Pilot Pilot)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
            await client.PutAsync(uri + "/" + Pilot.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(uri + "/" + id).ConfigureAwait(false);
        }
    }
}
