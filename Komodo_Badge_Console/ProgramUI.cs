using Komodo_Badge_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Komodo_Badge_Library.Badge;

namespace Komodo_Badge_Console
{
    class ProgramUI
    {
        private BadgeRepo _badgeInfo = new BadgeRepo();

        public void Run()
        {
            SeedData();
            UserInterface();
        }

        private void UserInterface()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?:\n" +
                    "1. Add a Badge\n" +
                    "2. List all Badges\n" +
                    "3. Update a Badge\n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        ViewAllBadges();
                        break;
                    case "3":
                        UpdateDoorAccess();
                        break;
                    case "4":
                        Console.WriteLine("Have a Wonderful rest of your Day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            Badge content = new Badge();
            content.DoorAccess = new List<string>();


            Console.WriteLine("What is the number on the badge?");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter a door that Badge#{content.BadgeID} needs access to: \n\n");
            content.DoorAccess.Add(Console.ReadLine().ToUpper());

            Console.WriteLine("Would you like to add another door access to this badge? Y/N");
            bool answer = GetYesNoAnswer();
            if (answer)
            {
                Console.WriteLine($"Enter another door that Badge#{content.BadgeID} needs access to: \n\n");
                content.DoorAccess.Add(Console.ReadLine().ToUpper());
            }
            else
            {
                Console.WriteLine("Ok you can always add at a later time");
            }

            _badgeInfo.AddBadge(content);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Badge #{content.BadgeID} was created successfully!");
            Console.ResetColor();

        }
        private bool GetYesNoAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Please enter valid input");
            }
        }

        public void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> viewAll = _badgeInfo.GetDictionary();
            Console.WriteLine("Badge #\t Door Access");
            foreach (KeyValuePair<int, List<string>> badge in viewAll)
            {
                Console.Write($"{badge.Key}\t");
                foreach (string door in badge.Value)
                {
                    Console.Write($"{door} ");
                }
                Console.WriteLine();
            }
            /*private void DisplayByBadgeID()
            {
                Console.Clear();
                Console.WriteLine("Select a Badge ID:");


                int badgeID = int.Parse(Console.ReadLine());
                Badge content = _badgeInfo.GiveAccess();
                Console.WriteLine("{0, -8} {1, -8}\n", "Badge #", "Door Access");

                if (content != null)
                {
                    Console.WriteLine("{0, -8} {1, -8}", $"{content.BadgeID}", $"{content.DoorAccess}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing deleted.");
                    Console.ResetColor();
                }
            */
        }
        private void UpdateDoorAccess()
        {
            Badge content = new Badge();
            content.DoorAccess = new List<string>();

            Console.Clear();
            ViewAllBadges();
            Console.WriteLine("Enter the ID you would like to update");
            int badgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"What would you like to do with {badgeID}\n" +
            $"\n" +
            $"1. Add a door\n" +
            $"2. Remove a door\n" +
            $"3. Return to menu\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddDoorUpdate(badgeID);
                    break;
                case "2":
                    RemoveDoorUpdate(badgeID);
                    break;
                case "3":
                    UserInterface();
                    break;
            }
        }
        public void AddDoorUpdate(int badgeID)
        {
            Console.WriteLine("Enter a door to add:");
            string door = Console.ReadLine();
            _badgeInfo.GiveAccess(badgeID, door);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Door access has been added!");
            Console.ResetColor();


            Console.ReadKey();

        }

        public void RemoveDoorUpdate(int badgeID)
        {
            Console.WriteLine("Enter a door that you would like to remove:");
            string door = Console.ReadLine();
            _badgeInfo.RemoveAccess(badgeID, door);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Door access has been revoked!");
            Console.ResetColor();


            Console.ReadKey();
        }

        private void SeedData()
        {
            Badge one = new Badge(1000, new List<string> { "A7" });
            Badge two = new Badge(1010, new List<string> { "A1", "A4", "B1", "B2" });
            Badge three = new Badge(1020, new List<string> { "A4", "A5" });
            Badge four = new Badge(1030, new List<string> { "A10" });

            _badgeInfo.AddBadge(one);
            _badgeInfo.AddBadge(two);
            _badgeInfo.AddBadge(three);
            _badgeInfo.AddBadge(four);
        }
    }
}

