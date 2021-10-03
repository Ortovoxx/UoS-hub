using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UoS_Hub.Models;

namespace UoS_Hub.Services.UserConfigManager
{
    public class UserConfigManager : IUserConfigManager
    {
        private readonly string PathToConfig =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userConfig.xml");
        private XmlSerializer _xmlSerializer = new XmlSerializer(typeof(UserConfig));
        public async Task<UserConfig> GetConfigAsync()
        {
            try
            {
                StreamReader reader = new StreamReader(PathToConfig);
                UserConfig userConfig = _xmlSerializer.Deserialize(reader) as UserConfig;
                reader.Dispose();
                return userConfig;
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                await SetConfigAsync(new UserConfig());
                return await GetConfigAsync();
            }
        }

        public async Task<bool> SetConfigAsync(UserConfig config)
        {
            StreamWriter streamWriter = new StreamWriter(PathToConfig);
            _xmlSerializer.Serialize(streamWriter, config);
            await streamWriter.FlushAsync();
            streamWriter.Dispose();
            return true;
        }
    }
}