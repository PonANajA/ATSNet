using ASTNet.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ASTNet.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly HttpClient _httpClient;

        public HolidayService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("ASTNet", "1.0"));

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<object> GetHolidaysAsync(int year, string countryCode)
        {
            var url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                //ไม่มีวันหยุด
                return Array.Empty<object>();
            }

            return JsonSerializer.Deserialize<object>(content)!;
        }

    }
}
