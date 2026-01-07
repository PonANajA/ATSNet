using ASTNet.Services;
using ASTNet.Services.Interfaces;
using System.Net;
using System.Text;

namespace ASTNet.Tests.Services
{
    public class HolidayServiceTests
    {
        [Fact]
        public async Task GetHolidaysWhenApiReturnsJson()
        {
            var json = """
            [
              {
                "date": "2026-01-01",
                "localName": "วันขึ้นปีใหม่",
                "name": "New Year's Day",
                "countryCode": "TH"
              }
            ]
            """;

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var handler = new MockHttpMessageHandler(response);
            var httpClient = new HttpClient(handler);

            IHolidayService service = new HolidayService(httpClient);

            var result = await service.GetHolidaysAsync(2026, "AT");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHolidaysWhenApiReturnsEmptyBody()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            var handler = new MockHttpMessageHandler(response);
            var httpClient = new HttpClient(handler);

            IHolidayService service = new HolidayService(httpClient);

            var result = await service.GetHolidaysAsync(2026, "AT");

            Assert.NotNull(result);
        }
    }
}
