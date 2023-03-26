using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    public class MainMenu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Get Codin' brother!");
            Console.WriteLine("You have the following options: ");
            Console.WriteLine("1. Start a coding session");
            Console.WriteLine("2. Search Sessions");
            Console.WriteLine("3. Delete a session");
            Console.WriteLine("4. Update a session");

            string option = ValidateInput.ValidateMainMenuSelect();
            MainMenuOptionSelector(option);
        }
        public static void MainMenuOptionSelector(string option)
        {
            switch (option)
            {
                case "1":
                    CodingSession.CodingSessionActive();
                    break;
                case "2":
                    DatabaseManager.ViewSessions();
                    DatabaseManager.Get();
                    break;
                case "3":
                    Console.WriteLine("Enter the ID of the session you want to delete: ");
                    string sesId = Console.ReadLine();
                    DatabaseManager.DeleteSession(sesId);
                    break;
                case "4":
                    Console.WriteLine("Enter the ID of the session you want to delete: ");
                    string updateSesId = Console.ReadLine();
                    Console.WriteLine("Enter the new duration you want to add: Format: (Hh Mm Ss)");
                    string updateSesDuration = Console.ReadLine();
                    DatabaseManager.UpdateSession(updateSesId, updateSesDuration);
                    break;
            }
        }
    }
}
