using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class TicketService
    {
        HttpClient client;
        private string Uri = App.BaseUri + "tickets";

        public TicketService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            string result = await client.GetStringAsync(Uri);
            return JsonConvert.DeserializeObject<IEnumerable<Ticket>>(result);
        }

        public async Task<Ticket> Get(int id)
        {
            string result = await client.GetStringAsync(Uri + "/" + id);
            return JsonConvert.DeserializeObject<Ticket>(result);
        }

        public async Task Create(Ticket Ticket)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Ticket), Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Ticket Ticket)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Ticket), Encoding.UTF8, "application/json");
            await client.PutAsync(Uri + "/" + Ticket.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(Uri + "/" + id).ConfigureAwait(false);
        }
    }
}
