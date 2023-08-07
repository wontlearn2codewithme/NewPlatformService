using System;
using System.Text;
using System.Text.Json;
using NewPlatformService.DTOs;

namespace NewPlatformService.SyncDataServices.Http
{
	public class HttpCommandDataClient : ICommandDataClient
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
		{
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlantformToCommand(PlatformReadDTO platformReadDTO)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platformReadDTO),
                Encoding.UTF8,
                "application/json");
            Console.WriteLine("here is de url!: " + _configuration["CommandServiceCheck"]);
            var response = await _httpClient.PostAsync(_configuration["CommandServiceCheck"], httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync post to command service was OK");
            }
            else
            {
                Console.WriteLine("--> Sync post to command service was NOT OK :(");
            }
        }
    }
}

