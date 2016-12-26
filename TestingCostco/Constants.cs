using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCostco
{
    public static class Constants
    {
        public static string aut = "http://www.costco.com";
        public static Browser browser = Browser.Chrome;
        public static IWebDriver driver;

    }

    public enum Browser
    {
        IE,
        Chrome,
        Firefox
    }
}
