using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Library
{
    public class MenuRepository
    {
        private List<Menu> _menuItems = new List<Menu>();
        //create
        public void AddItemsToMenu(Menu content)
        {
            _menuItems.Add(content);
        }
        //read
        public List<Menu> GetMenu()
        {
            return _menuItems;
        }

        public void PrintMenu()
        {
            foreach (Menu content in _menuItems)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Meal Includes: {content.MealItems}\n" +
                    $"Price: {content.Price}\n");
            }
        }
        //update
        public bool UpdateExistingMenu(int originalItem, Menu newContent)
        {
            Menu oldContent = GetMealByNumber(originalItem);

            if (oldContent != null)
            {
                oldContent.MealNumber = newContent.MealNumber;
                oldContent.MealName = newContent.MealName;
                oldContent.Description = newContent.Description;
                oldContent.MealItems = newContent.MealItems;
                oldContent.Price = newContent.Price;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveItemsFromMenu(int mealName)
        {
            Menu content = GetMealByNumber(mealName);

            if (content == null)
            {
                return false;
            }
            int initialCount = _menuItems.Count;
            _menuItems.Remove(content);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Menu GetMealByNumber(int mealNumber)
        {
            foreach (Menu content in _menuItems)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
