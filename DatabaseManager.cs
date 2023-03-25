using Microsoft.Data.Sqlite;
using ConsoleTableExt;

internal class DatabaseManager
{
    private readonly SqliteConnection _connection;
    private SqliteCommand _command;

    public DatabaseManager(string connectionString)
    {
        _connection = new SqliteConnection(connectionString);
        _command = _connection.CreateCommand();
    }
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

    public void InsertSession(string duration)
    {
        DateTime date = DateTime.Now;
        string today = date.ToString("dd:MM");
        using (_connection)
        {
            _connection.Open();
            var tableCmd = _connection.CreateCommand();
            tableCmd.CommandText =
                @$"INSERT INTO coding (
                  VALUES ({today}, {duration})";  
        }
    }
    public void ViewSessions()
    {
        using (_connection)
        {
            _connection.Open();
            string viewSessions = $"SELECT * FROM coding";
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
        Console.WriteLine("End of table");
    }
    public void DeleteSession(string Id)
    {
        using (_connection)
        {
            _connection.Open();
            string deleteSession = $"DELETE FROM coding WHERE id={int.Parse(Id)}";
            _command.CommandText = deleteSession;

            _connection.Close();
        }
    }
    public void UpdateSession()
    {
        using (_connection)
        {
            _connection.Open();
            string updateSession = $"UPDATE coding SET ";
        }
    }

}