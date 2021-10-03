using System.Collections.Generic;
using System.Threading.Tasks;
using UoS_Hub.Models;

namespace UoS_Hub.Services.Network
{
    public interface INetworkService
    {
        Task<bool> RegisterNewUser(User user);
        Task<bool> Login(string username);
        Task<List<Lecture>> GetTimetable();
        Task<bool> UpdateFavouriteBuildings(List<Building> favourites);
        Task<List<Building>> GetTimetableBuildings();
    }
}