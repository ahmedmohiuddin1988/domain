using Domain.Core.Business;
using Domain.Core.Business.Agency;
using Domain.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.UnitTest
{
    [TestClass]
    public class AgencyTest
    {
        #region OTBRE Tests
        [TestMethod]
        public void OTBRE_Agency_Test_With_Non_Matching_Name_Address()
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
            var provider = AgencyFactory.GetProvider("OTBRE");                                        

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OTBRE_Agency_Test_With_Non_Matching()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                Name = "New Court High Apartments, Sydney",
                Address = "32 Lumely Crescent, Sydney NSW"
            };

            var agencyProperty = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW."
            };
            var provider = AgencyFactory.GetProvider("OTBRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OTBRE_Agency_Test_With_Matching_Address()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                Name = "New Court High Apartments, Sydney",
                Address = "32 Lumely Crescent, Sydney NSW"
            };

            var agencyProperty = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Lumely Crescent, Sydney, NSW."
            };
            var provider = AgencyFactory.GetProvider("OTBRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region LRE Tests
        [TestMethod]
        public void LRE_Agency_Test_With_Matching_Property()
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

            var provider = AgencyFactory.GetProvider("LRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LRE_Agency_Test_With_Non_Matching_AgencyCode()
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
                AgencyCode = "AE101",
                Latitude = -33.901191,
                Longitude = 151.207628
            };

            var provider = AgencyFactory.GetProvider("LRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LRE_Agency_Test_With_More_Than_200_Meters_Coordinates()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                AgencyCode = "AE101",
                Latitude = 32.950888,
                Longitude = 148.665204
            };

            var agencyProperty = new Property()
            {
                AgencyCode = "AE101",
                Latitude = -19.823827,
                Longitude = 133.742410
            };

            var provider = AgencyFactory.GetProvider("LRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region CRE Test
        [TestMethod]
        public void CRE_Agency_Test_With_Matching_Name()
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

            var provider = AgencyFactory.GetProvider("CRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CRE_Agency_Test_With_Non_Revers_Name()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                Name = "The Summit Apartments"
            };

            var agencyProperty = new Property()
            {
                Name = "The Summit Apartments"
            };

            var provider = AgencyFactory.GetProvider("CRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CRE_Agency_Test_With_Different_Name()
        {
            //Arrange
            var databaseProperty = new Property()
            {
                Name = "The Summit Apartments"
            };

            var agencyProperty = new Property()
            {
                Name = "The Nice Apartments"
            };

            var provider = AgencyFactory.GetProvider("CRE");

            //Action
            var result = provider.IsMatch(agencyProperty, databaseProperty);

            //Assert
            Assert.IsFalse(result);
        }
        #endregion

        #region Invalid Provider Test
        [TestMethod]
        public void Invalid_Agency_Provider_Test()
        {
            //Arrange 
            string invalid_Agency_provider = "DHL";
            
            //Action
            var provider = AgencyFactory.GetProvider(invalid_Agency_provider);
             
            //Assert
            Assert.IsNull(provider);
        }
        #endregion
        }
}
