using BirthdayWishes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BirthdayWishes.Services
{
    public class DoNotSendService : IDoNotSendService
    {
        private readonly HttpClient _httpClient;

        public DoNotSendService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<int>> GetAllDoNotSend()
        {
            //var response = await _httpClient.GetAsync("https://interview-assessment-1.realmdigital.co.za/do-not-send-birthday-wishes");
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress.AbsoluteUri);
            var res = response.Content.ReadAsStringAsync();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<DoNotSendList>(responseStream);

            throw new NotImplementedException();
        }
    }
}
