using basecode.Model;
using basecode.Pages;
using System.Net.Http.Json;

namespace basecode.Services
{
    public class BoredService : IBoredService
    {
        private readonly HttpClient _httpClient;
        private Model.Bored? bored = null;
        public BoredService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Model.Bored> GetSuggestionAsync()
        {
            if(bored == null)
                bored =  await _httpClient.GetFromJsonAsync<Model.Bored>("/api/activity");

            return bored!;
        }
    }
}
