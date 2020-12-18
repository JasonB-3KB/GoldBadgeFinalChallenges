using Komodo_Badge_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Badge_Testing
{
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepo badgeRepo;
        private Badge badge;

        [TestInitialize]
        public void Arrange()
        {
            badgeRepo = new BadgeRepo();
            badge = new Badge(1000, new List<string> { "A7" });
            badgeRepo.AddBadge(badge);
        }
        [TestMethod]
        public void TestCreateMethod()
        {
            //Arrange
            Badge content = new Badge();
            content.BadgeID = (1010);
            content.DoorAccess = new List<string> { "A7" };

            //Act
            badgeRepo.AddBadge(content);
            KeyValuePair<int, List<string>> badge = badgeRepo.GetBadgeByID(1010);

            //Assert
            Assert.IsNotNull(badge.Key);
        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            //Arrange
            Badge content = new Badge(1000, new List<string> { "A7" });

            //Act
            bool updateBadge = badgeRepo.GiveAccess(1000, "A5");

            //Assert
            Assert.IsTrue(updateBadge);
        }
        [TestMethod]
        public void TestRemoveMethod()
        {
            //Arrange
            Badge content = new Badge(1000, new List<string> { "A7" });

            //Act
            bool removeDoor = badgeRepo.RemoveAccess(1000, "A7");

            //Assert
            Assert.IsTrue(removeDoor);
        }


    }

}

