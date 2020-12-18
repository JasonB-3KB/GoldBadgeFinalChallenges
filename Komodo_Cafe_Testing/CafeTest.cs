using Komodo_Cafe_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_Cafe_Testing
{
    [TestClass]
    public class CafeTest
    {
        private MenuRepository menuRepo;
        private Menu meals;
        
        [TestInitialize]
        public void Arrange()
        {
            menuRepo = new MenuRepository();
            meals = new Menu(1, "Cheeseburger with Fries", "Cheeseburger with lettuce, tomato, onion, mayo and ketchup, served with fries", "Cheeseburger and Fries", 5.00, MenuNumber.CheeseburgerFries);
            menuRepo.AddItemsToMenu(meals);
        }

        [TestMethod]
        public void TestCreateMethod()
        {
            //Arrange
            Menu content = new Menu();
            content.MealNumber = (1);
            MenuRepository menuRepository = new MenuRepository();

            //Act
            menuRepository.AddItemsToMenu(content);
            Menu menuItems = menuRepository.GetMealByNumber(1);

            //Assert
            Assert.IsNotNull(menuItems);
        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            //Arrange
            //Some included in test initialize
            Menu newContent = new Menu(1, "Hamburger with Fries", "Hamburger with lettuce, tomato, onion, mayo and ketchup, served with fries", "Hamburger and Fries", 4.50, MenuNumber.HamburgerFries);
            //Act
            bool updateMeal = menuRepo.UpdateExistingMenu(1, newContent);

            //Assert
            Assert.AreEqual(true, updateMeal);
        }
        [TestMethod]
        public void TestRemoveMethod()
        {
            //Arrange 
            //Some included in test initialize
            Menu removeContent = new Menu(1, "Hamburger with Fries", "Hamburger with lettuce, tomato, onion, mayo and ketchup, served with fries", "Hamburger and Fries", 4.50, MenuNumber.HamburgerFries);

            //Act
            bool deleteMeal = menuRepo.RemoveItemsFromMenu(1);

            //Assert
            Assert.IsTrue(deleteMeal);
        }
    }
}
