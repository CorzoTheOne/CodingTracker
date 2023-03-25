using System.Configuration;
using System.Collections.Specialized;
using CodingTracker;

internal class Program
{

    static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
    static void Main(string[] args)
    {
        DatabaseManager databaseManager = new(connectionString);

        bool programActive = true; 
        while (programActive)
        {

            MainMenu.DisplayMainMenu();


        }
    }
}