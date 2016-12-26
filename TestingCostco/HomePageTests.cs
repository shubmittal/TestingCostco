using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestingCostco.Utilities;
using TestingCostco.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace TestingCostco
{
    [TestClass]
    public class HomePageTests
    {
        IWebDriver driver;
        HomePage homepage;
        CostcoPharmacy pharmacy;

        public TestContext testcontext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            driver = AUTManager.LanchApp();

            homepage = new HomePage(driver);
        }

       

        [TestCleanup]
        public  void TestCleanup()
        {

            AUTManager.CloseApp();
        }



        [TestMethod]
        public void VerifyUserIsAtHomePage()
        {
            Assert.IsTrue(homepage.VerifyUserIsAt());
        }

        [TestMethod]
        public void VerifyBusinessCenterOptions()
        {
            var actualoptions = homepage.GetOptionsinBusinessCenter();
            var expectedoptions = new List<String>()
            {
                "Janitorial",
                "Office",
                "Tobacco",
                "Grocery"
            };

            Assert.IsTrue(expectedoptions.All(expectedoption => actualoptions.Contains(expectedoption)));
          
        }
        [TestMethod]
        public void VerifyUserCanGotoPAhrmacyPage()
        {
            homepage.GotoPharmacyPage().VerifyUserIsAt();
        }
    }
}
