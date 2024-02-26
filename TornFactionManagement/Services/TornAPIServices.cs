using System.Diagnostics;
using System.Net.Http.Json;
using TornFactionManagement.Model.ApiModel;

namespace TornFactionManagement.Services
{
    internal class TornAPIServices
    {
        private readonly HttpClient _httpClient;

        public TornAPIServices() 
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(APIConstants.API_BASE_URL);

            }
        public async Task<TornApiResponse?> GetData(string endpoint, string selection)
        {
             if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null; 
            }
            else
            {
                return await _httpClient.GetFromJsonAsync<TornApiResponse>($"{APIConstants.API_BASE_URL}{endpoint}/?selections={selection}&key={APIConstants.API_KEY}");
            }
 
        }
    }
}
