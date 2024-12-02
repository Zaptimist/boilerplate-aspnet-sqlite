using Microsoft.Data.Sqlite;

namespace TestSqliteApi.Users;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task AddUserAsync(string name);
    Task CreateUsersTableAsync();
}

public class UserService(SqliteConnection sqliteConnection) : IUserService
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        sqliteConnection.Open();

        var command = sqliteConnection.CreateCommand();
        command.CommandText = "SELECT * FROM Users";
        var users = new List<User>();

        await using (SqliteDataReader reader = await command.ExecuteReaderAsync())
        {
            while (reader.Read())
            {
                users.Add(
                    new User
                    {
                        Id   = int.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString()
                    }
                );
            }
        }

        sqliteConnection.Close();

        return users;
    }

    public async Task AddUserAsync(string name)
    {
        sqliteConnection.Open();
        SqliteCommand command = sqliteConnection.CreateCommand();
        command.CommandText = $"INSERT INTO Users (Name) VALUES ('{name}')";
        await command.ExecuteReaderAsync();
        sqliteConnection.Close();
    }

    public async Task CreateUsersTableAsync()
    {
        sqliteConnection.Open();
        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL
            );
        ";

        await command.ExecuteReaderAsync();
        
        sqliteConnection.Close();
    }
}