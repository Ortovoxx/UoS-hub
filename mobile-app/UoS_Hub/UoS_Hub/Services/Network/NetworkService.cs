using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UoS_Hub.Models;

namespace UoS_Hub.Services.Network
{
    public class NetworkService : INetworkService
    {
        private readonly HttpClient _httpClient;

        public NetworkService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://uos-hub.herokuapp.com/api/v1/");
            
        }
        public async Task<bool> RegisterNewUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var response = await _httpClient.PostAsync("user/register", new StringContent(json, Encoding.Unicode));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Login(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Lecture>> GetTimetable()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateFavouriteBuildings(List<Building> favourites)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Building>> GetTimetableBuildings()
        {
            throw new System.NotImplementedException();
        }
    }
}