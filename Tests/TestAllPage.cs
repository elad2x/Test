using Allure.Commons;
using AutomationFrameworkV2.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkV2.Tests
{
    [Parallelizable]
    //we can add severity to the entire class:
    //[AllureSeverity(SeverityLevel.critical)]
    internal class TestAllPage : BaseTest
    {
        
        [Test,Description("Test filling information")]
        [AllureFeature("Fill information")]
        [AllureStory("first Story related to tasks")]
        [AllureSeverity(SeverityLevel.blocker)]
        //Test filling information
        public void TC01_Page1()
        {
            //Logs
            Console.WriteLine("Test log");
            AboutPage aboutPage = new AboutPage(driver);
            //Fill info
            aboutPage.FillInfo("Yoni", "Cohen", "yoni@gmail.com");
            AccountPage accountPage = new AccountPage(driver);
            //Ensure we moved to account page:
            Assert.That(accountPage.getPageTitle(), Is.EqualTo("What is your automation level? (checkboxes)"));
        }

        [Test, Description("Test selecting level")]
        [AllureSeverity(SeverityLevel.blocker)]
        //Test selecting level
        public void TC02_Page2()
        {
            AccountPage accountPage = new AccountPage(driver);
            accountPage.SelectLevel("Intermediate");
            AddressPage addressPage = new AddressPage(driver);
            //Ensure we moved to address page:
            Assert.That(addressPage.GetPageTitle(),Is.EqualTo("Are you living in a nice area?"));
        }

        [Test, Description("Test filling information")]
        [AllureSeverity(SeverityLevel.blocker)]
        //Test filling information
        public void TC03_Page3()
        {
            AddressPage addressPage = new AddressPage(driver);
            addressPage.FillInfo("Ben yehuda", "2", "Tel Aviv", "Israel");
            //Ensure we finished successfuly:
            Assert.That(addressPage.GetCompletionMessage(),Is.EqualTo("Congratulations!"));
        }

        [Test, Description("Test previous buton")]
        [AllureSeverity(SeverityLevel.critical)]
        //Test previous buton
        public void TC04_Page3()
        {
            AddressPage addressPage = new AddressPage(driver);
            addressPage.PreviousPage();
            AccountPage accountPage = new AccountPage(driver);
            Assert.That(accountPage.getPageTitle(), Is.EqualTo("What is your automation level? (checkboxes)"));
        }
        [Test, Description("Test previous buton")]
        [AllureSeverity(SeverityLevel.critical)]
        //Test previous button
        public void TC05_Page2()
        {
            AccountPage accountPage = new AccountPage(driver);
            accountPage.PreviousPage();
            AboutPage aboutPage = new AboutPage(driver);
            Assert.That(aboutPage.GetPageTitle(), Is.EqualTo("Let's start with the basic information (with validation)"));
        }

        [Test, Description("Test next button with out inforamtion")]
        [AllureSeverity(SeverityLevel.normal)]
        //Test next button w/o info
        public void TC06_Page1()
        {
            AboutPage aboutPage = new AboutPage(driver);
            aboutPage.DeleteInfo();
            Assert.That(aboutPage.GetPageTitle(), Is.EqualTo("Let's start with the basic information (with validation)"));
        }
        [Test, Description("Test invalid email")]
        [AllureSeverity(SeverityLevel.minor)]
        //Test invalid email
        public void TC07_Page1()
        {
            AboutPage aboutPage = new AboutPage(driver);
            aboutPage.FillInfo("Yoni", "Cohen", "yonigmail.com");
            Assert.That(aboutPage.GetEmailErr(), Is.EqualTo("Please enter a valid email address!"));
        }

        [Test, Description("Test empty first name")]
        [AllureSeverity(SeverityLevel.normal)]
        //Test empty first name 
        public void TC08_Page1()
        {
            AboutPage aboutPage = new AboutPage(driver);
            aboutPage.DeleteInfo();
            aboutPage.FillInfo("", "Cohen", "yoni@gmail.com");
            Assert.That(aboutPage.GetFirstNameErr,Is.EqualTo("This field is required."));
        }

    }
}
