using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using AutoItX3Lib;
using NUnit.Framework;
using System.IO;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IList<IWebElement> ServiceTypeOptions { get; set; }
     
        //Select the radio button Hourlybasisservice type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement Hourlybasisservicetype { get; set; }

        //Select the radio button Hourlybasisservice label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/label")]
        private IWebElement HourlybasisservicetypeLabel { get; set; }

        //Select the radio button Oneoffservice type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement Oneoffservicetype { get; set; }

        //Select the radio button Oneoffservice label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/label")]
        private IWebElement OneoffservicetypeLabel { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Select the radio button On-site type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement Onsitetype { get; set; }

        //Select the radio button On-site label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label")]
         private IWebElement OnsitetypeLabel { get; set; }

        //Select the radio button Online type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement Onlinetype { get; set; }

        //Select the radio button Online label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/label")]
        private IWebElement OnlineLabel { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }
        
        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }        

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on EndTime 
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTime { get; set; }

        //Click on checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement CheckboxForDays { get; set; }

        //Click on checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[8]/div[1]/div/input")]
        private IWebElement SaturDay { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }        

        //Select the radio button Skillexchange type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement Skillexchangetype { get; set; }

        //Select the radio button SkillExchange Label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/label")]
        private IWebElement SkillExchangeLabel { get; set; }

        
        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement CreditAmountbox { get; set; }

        //Select the radio button Credit type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credittype { get; set; }

        //Select the radio button Credit Label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/label")]
        private IWebElement CreditLabel { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchangeTag { get; set; }


        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Select the radio button Active type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement Activetype { get; set; }

        //Select the radio button Active Label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/label")]
        private IWebElement ActiveLabel { get; set; }

        //Select the radio button Hidden type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement Hiddentype { get; set; }

        //Select the radio button Hidden Label
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/label")]
        private IWebElement HiddenLabel { get; set; }

        //Click on Work Sample File Upload
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSampleFileUpload { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //on Alert box
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement SucessOrFailure { get; set; }

        private static string imageFilePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + "\\ExcelData\\Wallpaper.jpg";


        internal void EnterShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ShareSkillExcelPath, "ShareSkill");

            //Click on ShareSkill Button
            ShareSkillButton.Click();

            //Enter the Title in textbox
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            GlobalDefinitions.wait(15);

            //Enter the Description in textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            GlobalDefinitions.wait(15);

            // find xpath forCategory  and assign input parameter level
            // select the drop down list
            //create select element object 
            var selectElement = new SelectElement(CategoryDropDown);
            // select by text
            selectElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            GlobalDefinitions.wait(15);

            // find xpath for SubCategory Dropdown
            // select the drop down list
            //create select element object 
            var SubcategoryElement = new SelectElement(SubCategoryDropDown);
            // select by text
            SubcategoryElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            GlobalDefinitions.wait(15);

            //Enter Tag names in textbox
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            GlobalDefinitions.wait(15);

            //Select the Service type
            string servicetype =  (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));           
            if (servicetype.Equals(HourlybasisservicetypeLabel.Text))
            {
                Hourlybasisservicetype.Click();

            } else if (servicetype.Equals(OneoffservicetypeLabel.Text))
            {
                Oneoffservicetype.Click();
            }

            GlobalDefinitions.wait(15);

            //Select the Location type
            string Locationtype = (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));
            if (Locationtype.Equals(OnsitetypeLabel.Text))
            {
                Onsitetype.Click();

            }
            else if (Locationtype.Equals(OnlineLabel.Text))
            {
                Onlinetype.Click();
            }

            GlobalDefinitions.wait(15);

            //Click on End Date       
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));        

            CheckboxForDays.Click();
            GlobalDefinitions.wait(15);

            // select by text
            StartTime.SendKeys((GlobalDefinitions.ExcelLib.ReadData(2, "Starttime")));
            // select by text
            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
        

            //Select the Skill Trade type
            string SkillTrade = (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));

            if (SkillTrade.Equals(SkillExchangeLabel.Text))
            {
                Skillexchangetype.Click();

            }
            else if (SkillTrade.Equals(CreditLabel.Text))
            {
                Credittype.Click();
            }
            GlobalDefinitions.wait(15);


            //Enter SkillExchange names in textbox
            SkillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchangeTag.SendKeys(Keys.Enter);

            Console.WriteLine("Image File Path " + @imageFilePath);
            // upload image 
            WorkSampleFileUpload.Click();

           
            AutoItX3 autoItX3 = new AutoItX3();
            autoItX3.WinActivate("Open");
            Thread.Sleep(1000);
            autoItX3.Send(@imageFilePath);           
            autoItX3.Send("{ENTER}");

            //Select the Active type
            string Active = (GlobalDefinitions.ExcelLib.ReadData(2, "Active"));


            if (Active.Equals(ActiveLabel.Text))
            {
                Activetype.Click();

            }
            else if (Active.Equals(HiddenLabel.Text))
            {
                Hiddentype.Click();
            }


            //Click on Save button
            Save.Click();
            GlobalDefinitions.wait(1);
            //Assertion

            //find xpath for sucess or failure message
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 8);
            var alerttext = SucessOrFailure.Text;

            // assert expected result = actual result
            Assert.AreEqual("Service Listing Added successfully", alerttext);
 
        }

        internal void EditShareSkill()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ShareSkillExcelPath, "UpdateShareSkill");

            //Update the Title in textbox
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            GlobalDefinitions.wait(5);
            //Update the Description in textbox
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            GlobalDefinitions.wait(5);

            // find xpath forCategory  
            // select the drop down list
            //create select element object            
            var selectElement = new SelectElement(CategoryDropDown);
         
            // select by text
            selectElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            GlobalDefinitions.wait(5);

            // find xpath for SubCategory Dropdown
            // select the drop down list
            //create select element object 

            var SubcategoryElement = new SelectElement(SubCategoryDropDown);
          
            // select by text
            SubcategoryElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            GlobalDefinitions.wait(5);

            //Update Tag names in textbox          
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            GlobalDefinitions.wait(5);

            //Select the Service type
            string servicetype = (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));
            if (servicetype.Equals(HourlybasisservicetypeLabel.Text))
            {
                Hourlybasisservicetype.Click();

            }
            else if (servicetype.Equals(OneoffservicetypeLabel.Text))
            {
                Oneoffservicetype.Click();
            }

            GlobalDefinitions.wait(15);

            //Select the Location type
            string Locationtype = (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));
            if (Locationtype.Equals(OnsitetypeLabel.Text))
            {
                Onsitetype.Click();

            }
            else if (Locationtype.Equals(OnlineLabel.Text))
            {
                Onlinetype.Click();
            }

            GlobalDefinitions.wait(15);

            //Update on End Date       
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            GlobalDefinitions.wait(5);

            //updating the starttime
            StartTime.SendKeys((GlobalDefinitions.ExcelLib.ReadData(2, "Starttime")));

            //updating the endtime
            EndTime.SendKeys((GlobalDefinitions.ExcelLib.ReadData(2, "Enddate")));

         
            //Update for checkbox
            SaturDay.Click();
            GlobalDefinitions.wait(5);

            //Update the Skill Trade type
            string SkillTrade = (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));


            if (SkillTrade.Equals(CreditLabel.Text))
            {
                Credittype.Click();

            }
            else if (SkillTrade.Equals(SkillExchangeLabel.Text))
            {
                Skillexchangetype.Click();
            }
        

            CreditAmountbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            GlobalDefinitions.wait(5);


            // upload image 
          
            WorkSampleFileUpload.Click();

            AutoItX3 autoItX3 = new AutoItX3();
            autoItX3.WinActivate("Open");
            Thread.Sleep(1000);
            autoItX3.Send(@imageFilePath);
            autoItX3.Send("{ENTER}");


            //Select the Active type
            string Active = (GlobalDefinitions.ExcelLib.ReadData(2, "Active"));


            if (Active.Equals(ActiveLabel.Text))
            {
                Activetype.Click();

            }
            else if (Active.Equals(HiddenLabel.Text))
            {
                Hiddentype.Click();
            }

            //Click on Save button
            Save.Click();
            GlobalDefinitions.wait(2);
            //Assertion
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[@class='ns-box-inner']"), 5);

            //find xpath for sucess or failure message
           
            var alerttext = SucessOrFailure.Text;
            Console.WriteLine("alerttext  " + alerttext);

            // assert expected result = actual result
            Assert.AreEqual("Service Listing Updated successfully", alerttext);


        }

    }
}

