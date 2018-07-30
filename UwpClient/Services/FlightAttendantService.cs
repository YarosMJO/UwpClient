using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class FlightAttendanService
    {
        HttpClient client;
        private string uri = App.BaseURI + "flightAttendants";

        public FlightAttendanService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<FlightAttendant>> GetAll()
        {
            string result = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<IEnumerable<FlightAttendant>>(result);
        }

        public async Task<FlightAttendant> Get(int id)
        {
            string result = await client.GetStringAsync(uri + "/" + id);
            return JsonConvert.DeserializeObject<FlightAttendant>(result);
        }

        public async Task Create(FlightAttendant FlightAttendant)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(FlightAttendant), Encoding.UTF8, "application/json");
            await client.PostAsync(uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(FlightAttendant FlightAttendant)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(FlightAttendant), Encoding.UTF8, "application/json");
            await client.PutAsync(uri + "/" + FlightAttendant.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(uri + "/" + id).ConfigureAwait(false);
        }
    }
}
