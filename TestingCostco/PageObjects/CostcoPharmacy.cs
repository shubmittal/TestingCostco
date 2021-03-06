﻿using OpenQA.Selenium;
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

        By Search_searchbox = By.XPath("//*[contains(@class, 'search-input ui-autocomplete-input')]");
        By search_searchicon = By.XPath("//*[@class = 'ui-icon ui-icon-search']");
        By search_searchresults = By.XPath("//*[@id = 'drugResults']");
        By search_noresults = By.XPath("//*[contains(@id ,'drugNoResults')]");
        By search_resultsperpage = By.XPath("//*[@id = 'drugResults']//*[@id = 'pagination-header']//li[@class = 'item_link' and contains (text(),'96')]");
        By search_paginationsummary = By.XPath("//*[@id = 'pagination - summary']");
        By search_results = By.XPath("//*[@id = 'pagination-body']//*[@class = 'drug-directory-results']/a");

        
        By pagination_totalpages = By.XPath("//*[@id = 'pagination-footer']//div[@id = 'page-number']//ul/li[last()]");
        By pagination_currentpage = By.XPath("//*[@id = 'pagination-footer']//div[@id = 'page-number']//ul/li[contains(@class, 'page_link selected')]");

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

        public Dictionary<string, string> SeachforMedicine(string searchterm)
        {
            // Click on the searchbox and enter search term

            string seetsearchesperpage = "48";
            var results = new Dictionary<string, string>();

            driver.FindElement(Search_searchbox).Click();
            driver.FindElement(Search_searchbox).SendKeys(searchterm);
            driver.FindElement(search_searchicon).Click();

            //  wait.Until(ExpectedConditions.ElementIsVisible(search_searchresults) || ExpectedConditions.ElementIsVisible(search_noresults));

            wait.Until((driver) =>

                {
                    return ((driver.FindElement(search_noresults) != null) || (driver.FindElement(search_results) != null)) ? true : false;
                });

            //Check if results were obatined

            // var results = 
            var resultsfound = driver.FindElement(search_noresults).GetAttribute("style").Contains("none");

            if (resultsfound)
            {
                results.Add("Result Summary", "Results found");
                driver.FindElement(search_resultsperpage).Click();

                var searchresults = driver.FindElements(search_results);


                foreach (var item in searchresults)
                {
                    results.Add(item.Text, item.GetAttribute("href"));
                }



            }
            else
            {
                results.Add("Result Summary", "No results found");

            }

            return results;

            


             

        }
    }
}
