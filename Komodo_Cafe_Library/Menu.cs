using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Library
{
    public enum MenuNumber
    {
        CheeseburgerFries = 1,
        HamburgerFries = 2,
        ChickenStripsFries = 3,
        FishSandwichFries = 4,
    }
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string MealItems { get; set; }
        public double Price { get; set; }

        public Menu() { }

        public Menu(int mealNumber, string mealName, string description, string mealItems, double price, MenuNumber menuNumber)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            MealItems = mealItems;
            Price = price;
        }


    }
}
