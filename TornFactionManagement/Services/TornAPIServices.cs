using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using TornFactionManagement.Model.ApiModel;

namespace TornFactionManagement.Services
{
    internal class TornAPIServices
    {
        private readonly HttpClient httpClient;

        public TornAPIServices() 
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(APIConstants.API_BASE_URL);

            }


        public async Task<TornApiResponse?> GetData(string endpoint, string selection)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }
            else
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{APIConstants.API_BASE_URL}{endpoint}/?selections={selection}&key={APIConstants.API_KEY}");

                if (response.IsSuccessStatusCode)
                {
                    
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(jsonResponse);
               
                    return null; 
                }
                else
                {
                    Debug.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }
    }
}
