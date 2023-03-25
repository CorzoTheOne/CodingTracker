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
                    break;
            }
        }
    }
}
