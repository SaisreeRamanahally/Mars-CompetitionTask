using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[2]/i[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }
        //Click on Yes 
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement YesActionButton { get; set; }
        //on Alert box
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement SucessOrFailure { get; set; }
        



        internal void Listings()
        {
            // click Manage Listings tab
            manageListingsLink.Click();
        }


        internal void EditShareSkillFromListings()
        {

            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[8]/div[1]/button[2]/i[1]"), 8);

            // Click pen mark
            edit.Click();           
            
            // Call ShareSkill
            ShareSkill ShareSkillObj = new ShareSkill();
            ShareSkillObj.EditShareSkill();


        }


        internal void DeleteShareSkillFromListings()
        {
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]"), 5);

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ManagelistingsExcelPath, "ManageListings");

           // manageListingsLink.Click();
            GlobalDefinitions.wait(2);

            // Click X mark
            delete.Click();
            GlobalDefinitions.wait(1);

            //WebDriverWait wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.AlertIsPresent());

            string Deleteaction = (GlobalDefinitions.ExcelLib.ReadData(2, "Deleteaction"));

            if (Deleteaction.Equals(YesActionButton.Text))
            {
                YesActionButton.Click();
            }

            //Assertion

            //find xpath for sucess or failure message
            GlobalDefinitions.wait(2);
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 5);
            var alerttext = SucessOrFailure.Text;

            Console.WriteLine("alerttext delete " + alerttext);
            //assert expected result = actual result
            Assert.AreEqual("Selenium has been deleted", alerttext);



        }
    }
}

