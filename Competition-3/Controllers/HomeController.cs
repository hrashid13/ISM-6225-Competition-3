using Competition_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Competition_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private const string NewsApiUrl = "https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=e8d19e35f9c847b0a7b416ece862d332";

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(NewsApiUrl);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var newsData = JsonSerializer.Deserialize<NewsApiResponse>(jsonContent, options);

                return View(newsData?.Articles ?? new List<Article>());
            }
            catch (Exception)
            {
                return View(new List<Article>());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
