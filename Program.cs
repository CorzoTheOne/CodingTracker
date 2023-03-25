using System.Configuration;
using System.Collections.Specialized;
using CodingTracker;

internal class Program
{

    static void Main(string[] args)
    {
        bool programActive = true; 
        while (programActive)
        {
            MainMenu.DisplayMainMenu();
        }
    }
}