using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestingCostco.PageObjects;
using TestingCostco.Utilities;

namespace TestingCostco
{
    [TestClass]
    public class PharmacyPageTests
    {

        IWebDriver driver;
        HomePage homepage;
        CostcoPharmacy pharmacy;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = AUTManager.LanchApp();
            driver.GotoPage("Pharmacy");

           pharmacy = new CostcoPharmacy(driver);

            
        }



        [TestCleanup]
        public void TestCleanup()
        {

            AUTManager.CloseApp();
        }

        [TestMethod]
        public void UserCanSearchForMeds()
        {
            pharmacy.SeachforMedicine("er");
        }
    }
}