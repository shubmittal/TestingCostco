using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCostco.PageObjects
{
    public class CostcoPharmacy
    {
        IWebDriver driver;
        WebDriverWait wait;

        By costcoPharmacyimage = By.XPath("//*[@src = '/wcsstore/CostcoUSBCStorefrontAssetStore/images/costco-rx-logo_217x59.png']");
        By costcoLogo = By.XPath("//*[text()= 'Save Money, Stay Healthy - Costco Immunizations']");

        public CostcoPharmacy(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));            
            wait.Until(ExpectedConditions.ElementExists(costcoPharmacyimage));
        }

        public bool VerifyUserIsAt()
        {
            bool result = true;
           

            if (driver.FindElement(costcoLogo) == null || driver.FindElement(costcoPharmacyimage) == null) result = false;

            return result;

        }
    }
}
