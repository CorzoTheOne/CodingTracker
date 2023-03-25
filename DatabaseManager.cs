using System.Configuration;
using Microsoft.Data.Sqlite;
using ConsoleTableExt;

internal class DatabaseManager
{
    static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
    private static readonly SqliteConnection _connection = new SqliteConnection(connectionString);
    private static SqliteCommand _command = new SqliteCommand();

    public void CreateTable()
    {
        using (_connection)
        {
            _connection.Open();
            var tableCmd = _connection.CreateCommand();
            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS coding (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Duration TEXT
                )";

            tableCmd.ExecuteNonQuery();

            _connection.Close();
        }
    }

    public static void InsertSession(string duration)
    {
        DateTime date = DateTime.Now;
        string today = date.ToString("dd:MM");
        using (_connection)
        {
            _connection.Open();
            var tableCmd = _connection.CreateCommand();
            tableCmd.CommandType = System.Data.CommandType.Text;
            tableCmd.CommandText =
                $"INSERT INTO coding (date, duration) VALUES ('{today}', '{duration}')";

            tableCmd.ExecuteNonQuery();

            _connection.Close();
            Console.WriteLine("Session has ended and been added succesfully!");
            Console.WriteLine($"Your session was {duration} long\n");
        }
    }
    public static void ViewSessions()
    {
        using (_connection)
        {
            _connection.Open();
            string viewSessions = $"SELECT * FROM coding";
            _command = _connection.CreateCommand();
            _command.CommandText = viewSessions;
            SqliteDataReader reader = _command.ExecuteReader();
            Console.WriteLine($"{reader.GetName(0)}     {reader.GetName(1)}      {reader.GetName(2)}");
            Console.WriteLine("----------------------");
            while(reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} {reader["date"]} {reader["duration"]}");
            }
            _connection.Close();
        }
        Console.WriteLine("End of table\n");
    }
    public static void DeleteSession(string id)
    {
        using (_connection)
        {
            _connection.Open();
            string deleteSession = $"DELETE FROM coding WHERE id={int.Parse(id)}";
            _command = _connection.CreateCommand();
            _command.CommandText = deleteSession;

            _command.ExecuteNonQuery();

            _connection.Close();
        }
        Console.WriteLine($"Session with ID {id} has been deleted.\n");
    }
    public static void UpdateSession(string id, string duration)
    {
        using (_connection)
        {
            _connection.Open();
            string updateSession = $"UPDATE coding SET duration='{duration}' WHERE id={int.Parse(id)}";
            _command = _connection.CreateCommand();
            _command.CommandText = updateSession;

            _command.ExecuteNonQuery();

            _connection.Close();
        }
    }

}