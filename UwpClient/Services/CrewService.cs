using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class CrewService
    {
        HttpClient client;
        private string Uri = App.BaseUri + "crews";

        public CrewService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Crew>> GetAll()
        {
            string result = await client.GetStringAsync(Uri);
            return JsonConvert.DeserializeObject<IEnumerable<Crew>>(result);
        }

        public async Task<Crew> Get(int id)
        {
            string result = await client.GetStringAsync(Uri + "/" + id);
            return JsonConvert.DeserializeObject<Crew>(result);
        }

        public async Task Add(Crew Crew)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Crew), Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Crew Crew)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Crew), Encoding.UTF8, "application/json");
            await client.PutAsync(Uri + "/" + Crew.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(Uri + "/" + id).ConfigureAwait(false);
        }
    }
}
