using UoS_Hub.Models;

namespace UoS_Hub.Services.Database.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbConnection connection) : base(connection)
        {
        }
    }
}