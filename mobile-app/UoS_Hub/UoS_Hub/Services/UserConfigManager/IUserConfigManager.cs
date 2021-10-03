using System.Threading.Tasks;
using UoS_Hub.Models;

namespace UoS_Hub.Services.UserConfigManager
{
    public interface IUserConfigManager
    {
        Task<UserConfig> GetConfigAsync();
        Task<bool> SetConfigAsync(UserConfig config);
    }
}