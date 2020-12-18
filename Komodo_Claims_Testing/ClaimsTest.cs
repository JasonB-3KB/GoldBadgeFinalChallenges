using Komodo_Claims_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_Claims_Testing
{
    [TestClass]
    public class Testing
    {
        private ClaimsRepository  _claimsRepo;
        private Claims _claims;
        

        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepository();
            _claims = new Claims(1, ClaimType.Car, "Car Accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            _claimsRepo.AddClaim(_claims);
        }
        [TestMethod]
        public void TestCreateMethod()
        {
            //Arrange
            Claims content = new Claims();
            content.ClaimID = (1);
            ClaimsRepository claimsRepository = new ClaimsRepository();

            //Act
            claimsRepository.AddClaim(content);
            Claims claims = claimsRepository.GetClaimByNumber(1);

            //Assert
            Assert.IsNotNull(claims);
        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            //Arrange
            Claims content = new Claims(1, ClaimType.Car, "Car Accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);

            //Act
            bool updateClaim = _claimsRepo.UpdateExistingClaims(1, content);

            //Assert
            Assert.AreEqual(true, updateClaim);
        }
        [TestMethod]
        public void TestRemoveMethod()
        {
            //Arrange
            Claims removeContent = new Claims(1, ClaimType.Car, "Car Accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);

            //Act
            bool deleteClaim = _claimsRepo.RemoveClaims(1);

            //Assert
            Assert.IsTrue(deleteClaim);
        }
    }
}
   
