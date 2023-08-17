using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace dockerApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly string apiUrl;
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        apiUrl = _configuration["ApiUrl"];
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> DockerApiGet()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var apiResponse = await httpClient.GetAsync(apiUrl);
        if(apiResponse.IsSuccessStatusCode){
            string responseContent = await apiResponse.Content.ReadAsStringAsync();
            return responseContent;
        }
        else{
            return "";
        }
    }



}
