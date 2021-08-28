using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Test()
            {
                // create service detials
                GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);
                ShareSkill ShareSkillObj = new ShareSkill();
                ShareSkillObj.EnterShareSkill();

                // listings
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.Listings();



                // assert create share skill
                AssertListings(Base.ShareSkillExcelPath, "ShareSkill");

                // update services details
                manageListingsObj.EditShareSkillFromListings();

                // assert update share skill
                manageListingsObj.Listings();
                AssertListings(Base.ShareSkillExcelPath, "UpdateShareSkill");

                manageListingsObj.DeleteShareSkillFromListings();

                // Assert for no listing message after delete
                AssertDelete();

            }


            private void AssertListings(string Filename, string sheetname)
            {
                GlobalDefinitions.ExcelLib.PopulateInCollection(Filename, sheetname);

                var categoryexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                var titleexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                var descriptionexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                var servicetypeexceldata = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");

                // xpath of Manage Listing table
                var elemTable = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table"));

                // Fetch all Row of the table
                List<IWebElement> listTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
                string strRowData = "";

                // Traverse each row
                foreach (var elemTr in listTrElem)
                {
                    // Fetch the columns from a particuler row
                    List<IWebElement> listTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                    if (listTdElem.Count > 0)
                    {
                        // Traverse each column
                        foreach (var elemTd in listTdElem)
                        {
                            // "\t\t" is used for Tab Space between two Text
                            strRowData = strRowData + elemTd.Text + "\t\t";
                            Console.WriteLine(elemTd.Text);
                        }

                        string CategoryTextListings = listTdElem[1].Text;
                        string TitleTextListings = listTdElem[2].Text;
                        string DescriptionTextListings = listTdElem[3].Text;
                        string ServiceTypeTextListings = listTdElem[4].Text;
                        Assert.AreEqual(categoryexceldata, CategoryTextListings);
                        Assert.AreEqual(titleexceldata, TitleTextListings);
                        Assert.AreEqual(descriptionexceldata, DescriptionTextListings);
                        Assert.True(servicetypeexceldata.Contains(ServiceTypeTextListings));                        
                        
                    }
                    else
                    {
                        // To print the data into the console
                        Console.WriteLine("This is Header Row");
                        Console.WriteLine(listTrElem[0].Text.Replace(" ", "\t\t"));
                    }
                    Console.WriteLine(strRowData);
                    strRowData = String.Empty;
                }

            }


            private void AssertDelete()
            {
                // make sure the following message is displayed
                var NoListingMessage = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h3"));
                Assert.AreEqual("You do not have any service listings!", NoListingMessage.Text);
            }
        }


    }
}
