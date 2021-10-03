using System.Collections.Generic;
using System.Threading.Tasks;
using UoS_Hub.Models;

namespace UoS_Hub.Services.Network
{
    public class NetworkService : INetworkService
    {
        public async Task<bool> RegisterNewUser(User user)
        {
            throw new System.NotImplementedException();
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