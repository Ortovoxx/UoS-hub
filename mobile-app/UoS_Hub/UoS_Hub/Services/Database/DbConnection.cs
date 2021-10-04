using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using UoS_Hub.Models;

namespace UoS_Hub.Services.Database
{
    public class DbConnection
    {
        public static string DB_PATH =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydb.db3");
        private static readonly Lazy<SQLiteAsyncConnection> LazyDbInitializer =
            new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(DB_PATH), true);

        public SQLiteAsyncConnection Database { get; } = LazyDbInitializer.Value;
        private bool _setup = false;

        public async Task Init()
        {

            var tableTypes = new[]
            {
                typeof(User),
                typeof(Building),
                typeof(Lecture),
                typeof(Map),
            };
            if (!_setup)
            { 
                //check if each model type in the list has a corresponding table in the db
                //if not, drop db and create a new one
                bool missedTable = Database.TableMappings.Count() != tableTypes.Length;
                foreach (var tableMapping in Database.TableMappings)
                {
                    if (tableTypes.FirstOrDefault(x => x.Name == tableMapping.TableName) == null)
                        missedTable = true;
                    break;

                }
                if (missedTable)
                {
                    await Database.CreateTablesAsync(CreateFlags.None, tableTypes).ConfigureAwait(false);
                }
                _setup = true;
            }
        }
    }
}