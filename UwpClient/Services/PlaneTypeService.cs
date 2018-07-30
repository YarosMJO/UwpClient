using AirportWebApi.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UwpClient.Services
{
    public class PlaneTypeService
    {
        HttpClient client;
        private string Uri = App.BaseUri + "planeTypes/";

        public PlaneTypeService()
        {
            client = new HttpClient();
        }
        public async Task<IEnumerable<PlaneType>> GetAll()
        {
            string result = await client.GetStringAsync(Uri);
            return JsonConvert.DeserializeObject<IEnumerable<PlaneType>>(result);
        }

        public async Task<PlaneType> Get(int id)
        {
            string result = await client.GetStringAsync(Uri + "/" + id);
            return JsonConvert.DeserializeObject<PlaneType>(result);
        }

        public async Task Create(PlaneType PlaneType)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(PlaneType), Encoding.UTF8, "application/json");
            await client.PostAsync(Uri, stringContent).ConfigureAwait(false);
        }

        public async Task Update(PlaneType PlaneType)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(PlaneType), Encoding.UTF8, "application/json");
            await client.PutAsync(Uri + "/" + PlaneType.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(Uri + "/" + id).ConfigureAwait(false);
        }
    }
}
