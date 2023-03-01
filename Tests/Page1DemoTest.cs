using AutomationFrameworkV2.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkV2.Tests
{
    [Parallelizable]
    internal class Page1DemoTest : BaseTest
    {
        //[Test]
        public void TC01_Page1()
        {
            AboutPage aboutPage = new AboutPage(driver);
            aboutPage.FillInfo("Yotam", "Levi", "Levi@gmail.com");
            AccountPage accountPage = new AccountPage(driver);          
            Assert.That(accountPage.getPageTitle(), Is.EqualTo("What is your automation level? (checkboxes)"));
        }

    }
}
