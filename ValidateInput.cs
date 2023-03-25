using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class ValidateInput
    {
        public static string ValidateMainMenuSelect()
        {
            string input = default;
            bool approvedInput = true;
            while (approvedInput)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        approvedInput = false;
                        break;
                    case "2":
                        approvedInput = false;
                        break;
                    case "3":
                        approvedInput = false;
                        break;
                    case "4":
                        approvedInput = false;
                        break;
                    default:
                        Console.WriteLine("You're input does not match one of the options.");
                        continue;
                }
            }
            return input;
        }

        public static bool ValidIdUpdateSession()
        {
            Console.WriteLine("Please input the ID of the session you wish to update:");
            bool approvedInput = true;
            while (approvedInput)
            {
                string update = Console.ReadLine();
                
            }
            return true;
        }
    }
}
