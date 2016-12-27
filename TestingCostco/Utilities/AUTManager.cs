using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCostco;
using OpenQA.Selenium.IE;

namespace TestingCostco.Utilities
{
   public static  class AUTManager
    {
        static IWebDriver driver = null;

        public  static IWebDriver LanchApp()
        {
           
            Browser browser = Config.browser;

            switch (browser)
            {
                case Browser.IE:
                    driver = new InternetExplorerDriver();
                    break;
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.Firefox:
                default:
                    driver = new FirefoxDriver();
                    break;               
            }

            driver.Url = Config.aut;

            driver.Navigate();

            driver.Manage().Window.Maximize();

            
            
            return driver;
        }

        public static void CloseApp()
        {
            driver.Quit();
        }


        public static void GotoPage(this IWebDriver driver, string webpagename)
        {

            string relativeurl ="";

            switch (webpagename)
            {

               

                case ("Pharmacy"):
                    relativeurl = "/Pharmacy";
            break;


                default:
                            break;
            }

            String aut = Config.aut;

            driver.Navigate().GoToUrl(aut + relativeurl);


        }


    }
}
