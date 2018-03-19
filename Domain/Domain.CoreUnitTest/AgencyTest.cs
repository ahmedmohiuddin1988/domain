using Domain.Core.Business.Agency;
using Domain.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CoreUnitTest
{
    [TestClass]
    public class AgencyTest
    {
        [TestMethod]
        public void OTBRE_Agency_Test_With_Matching_Address()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };

            var agencyProperty = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW."
            };

            //Action
            var result = new OTBREAgency().IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void LRE_Agency_Test_With_Matching_Address()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                AgencyCode = "21212er222",
                Latitude = -33.9014586,
                Longitude = 151.206287
            };

            var agencyProperty = new Property()
            {
                AgencyCode = "21212er222",
                Latitude = -33.901191,
                Longitude = 151.207628
            };

            //Action
            var result = new LREAgency().IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CRE_Agency_Test_With_Matching_Address()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                Name = "The Summit Apartments"
            };

            var agencyProperty = new Property()
            {
                Name = "Apartments Summit The"
            };

            //Action
            var result = new CREAgency().IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
