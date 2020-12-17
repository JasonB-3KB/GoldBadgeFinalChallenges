using Komodo_Claims_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Console
{
    class ProgramUI
    {
        private ClaimsRepository _claimsInfo = new ClaimsRepository();

        public void Run()
        {
            SeedList();
            UserInterface();
        }

        private void UserInterface()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Make your selection:\n" +
                    "1. Enter a New Claim\n" +
                    "2. See all Claims\n" +
                    "3. Find Claim by ID\n" +
                    "4. Update a Claim\n" +
                    "5. Delete a Claim\n" +
                    "6. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EnterAClaim();
                        break;
                    case "2":
                        ViewAllClaims();
                        break;
                    case "3":
                        DisplayByClaimID();
                        break;
                    case "4":
                        UpdateClaim();
                        break;
                    case "5":
                        DeleteAClaim();
                        break;
                    case "6":
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
        private void EnterAClaim()
        {
            Console.Clear();
            Claims newContent = new Claims();

            Console.WriteLine("What ID number would you like to use for this claim?");
            newContent.ClaimID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number for Claim Type?\n "  +
                " 1. Car\n " +
                " 2. Home\n " +
                " 3. Theft \n " +
                " 4. Boat");
            newContent.ClaimType = (ClaimType)int.Parse(Console.ReadLine());

            Console.WriteLine("Give a brief description of this claim:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("What is the amount of the claim?");
            newContent.ClaimAmount = Double.Parse(Console.ReadLine());

            Console.WriteLine("What is the date of incident? eg. yyyy/mm/dd");
            newContent.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("What is the date of the claim? eg. yyyy/mm/dd");
            newContent.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimsInfo.AddClaim(newContent);
        }

        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claims> listOfItems = _claimsInfo.GetList();
            Console.WriteLine("{0, -8} {1, -8} {2, -30} {3, -18} {4, -20} {5, -15} {6, -7}\n", "ClaimID", "Type", "Description", "Claim Amount", "Date of Incident", "Date of Claim", "Is Valid");

            foreach (Claims content in listOfItems)
            {
                Console.WriteLine("{0, -8} {1, -8} {2, -30} {3, -18} {4, -20} {5, -15} {6, -7}", $"{content.ClaimID}", $"{content.ClaimType}", $"{content.Description}", $"{content.ClaimAmount:C}", $"{content.DateOfIncident:d}", $"{content.DateOfClaim:d}", $"{content.IsValid}");
            }
        }
        private void DisplayByClaimID()
        {
            Console.Clear();
            Console.WriteLine("Enter the Claim ID:");
            int claimNumber = int.Parse(Console.ReadLine());
            Claims content = _claimsInfo.GetClaimByNumber(claimNumber);
            Console.WriteLine("{0, -8} {1, -8} {2, -30} {3, -18} {4, -20} {5, -15} {6, -7}\n", "ClaimID", "Type", "Description", "ClaimAmount", "Dateof Incident", "Dateof Claim", "IsValid");

            if (content != null)
            {
                Console.WriteLine("{0, -8} {1, -8} {2, -30} {3, -18} {4, -20} {5, -15} {6, -7}", $"{content.ClaimID}", $"{content.ClaimType}", $"{content.Description}", $"{content.ClaimAmount:C}", $"{content.DateOfIncident:d}", $"{content.DateOfClaim:d}", $"{content.IsValid}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No claim found for that ID.");
                Console.ResetColor();
            }

        }
        private void UpdateClaim()
        {
            ViewAllClaims();
            Console.WriteLine("Enter the ID you would like to update");
            int oldClaimNumber = int.Parse(Console.ReadLine());
            Claims newContent = new Claims();

            Console.WriteLine("Enter an ID Number:");
            newContent.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number for Claim Type?\n " +
                " 1. Car\n " +
                " 2. Home\n " +
                " 3. Theft \n " +
                " 4. Boat");
            newContent.ClaimType = (ClaimType)int.Parse(Console.ReadLine());

            Console.WriteLine("Give a brief description of this claim:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("What is the amount of the claim?");
            newContent.ClaimAmount = Double.Parse(Console.ReadLine());

            Console.WriteLine("What is the date of incident? eg. yyyy/mm/dd");
            newContent.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("What is the date of the claim? eg. yyyy/mm/dd");
            newContent.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            bool wasUpdated = _claimsInfo.UpdateExistingClaims(oldClaimNumber, newContent);
            if (wasUpdated)
            {
                Console.WriteLine("Claim updated successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not update the claim.");
                Console.ResetColor();
            }
        }
        public void DeleteAClaim()
        {
            ViewAllClaims();
            Console.WriteLine("\nEnter the Claim ID you would like to delete:");
            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _claimsInfo.RemoveClaims(input);
            if (wasDeleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The claim was successfully deleted.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The claim was not deleted.");
                Console.ResetColor();
            }
            
        }
        private void SeedList()
        {
            Claims one = new Claims(1, ClaimType.Car, "Car Accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claims two = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000, new DateTime(2018, 4, 11) , new DateTime(04, 12, 18), true);
            Claims three = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01), false);
            Claims four = new Claims(4, ClaimType.Car, "Wreck on I-70", 2000, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28), true);
            

            _claimsInfo.AddClaim(one);
            _claimsInfo.AddClaim(two);
            _claimsInfo.AddClaim(three);
            _claimsInfo.AddClaim(four);
        }
    }
}
