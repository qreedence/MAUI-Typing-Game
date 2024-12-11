using System.Net.Http.Json;

namespace MAUIEden.Services
{
    public class RandomWordService
    {
        HttpClient _httpClient;
        List<string> words = new List<string>();

        public RandomWordService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> GetRandomWords(string language, int? amount)
        {
            string url = $"https://random-word-api.herokuapp.com/word?number={amount}";
            if (language != "en")
            {
                url += $"&lang={language}";
            }
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                    words = await response.Content.ReadFromJsonAsync<List<string>>();
            }
            return words;
        }
    }
}
