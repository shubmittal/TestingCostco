using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCostco.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        Actions actions;
        WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        }
        public bool VerifyUserIsAt()
        {

            bool result = false;
            //Verify cart icon present

            By carticon = By.ClassName("co-cart-rwd");

            By topnavbar = By.ClassName("top-links hidden-sm");

            // By[] topnavbaroptions = topnavbar.FindElements(By.ClassName("list-group-item"));

            if (driver.FindElement(carticon) != null) result = true;

            return result;




        }

        public List<string> GetOptionsinBusinessCenter()
        {

            By BusinessCenterOption = By.Id("Home_Ancillary_1");
            By popoverBCOption = By.XPath("//*[@data-bi-placement='Home_Ancillary_Popover_1']");

            IWebElement businnercenter = driver.FindElement(BusinessCenterOption);

            actions.MoveToElement(driver.FindElement(BusinessCenterOption)).Perform();

            //data-bi-placement="Home_Ancillary_Popover_1"

            wait.Until(ExpectedConditions.ElementIsVisible(popoverBCOption));

            IWebElement hover = driver.FindElement(popoverBCOption);

            var options = hover.FindElements(By.ClassName("sub-item"));

            var optionstext = new List<string>();

            foreach (var item in options)
            {
                optionstext.Add(item.Text);
            }

            return optionstext;

        }

        public CostcoPharmacy GotoPharmacyPage()
        {

            By PharmacyLink = By.Id("Home_Ancillary_3");

            driver.FindElement(PharmacyLink).Click();

           // wait.Until(ExpectedConditions.TitleIs())

            
            return new CostcoPharmacy(driver);

        }

    }
}
