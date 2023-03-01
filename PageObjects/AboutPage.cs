using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFrameworkV2.PageObjects
{
    internal class AboutPage : BasePage
    {
        public AboutPage(IWebDriver driver) : base(driver) { }
        public IWebElement FirstNameField => Driver.FindElement(By.CssSelector("#firstname"));
        public IWebElement LastNameField => Driver.FindElement(By.CssSelector("#lastname"));
        public IWebElement EmailField => Driver.FindElement(By.CssSelector("#email"));
        public IWebElement NextBtn => Driver.FindElement(By.CssSelector("[name='next']"));
        public IWebElement EmailError => Driver.FindElement(By.CssSelector("#email-error"));
        public IWebElement Title => Driver.FindElement(By.CssSelector("#about .info-text"));
        public IWebElement EmailErr => Driver.FindElement(By.CssSelector("#email-error"));
        public IWebElement FirstNameErr => Driver.FindElement(By.CssSelector("#firstname-error"));

        [AllureStep("Fill info {0},{1},{2}")]
        public void FillInfo(string firstName, string lastName, string email)
        {
            HighlightElementV2(FirstNameField,"red");
            FillText(FirstNameField, firstName);
            FillText(LastNameField, lastName);
            FillText(EmailField, email);
            HighlightElementV2(NextBtn,"red");
            Click(NextBtn);
        }
        public void DeleteInfo()
        {
            DeleteText(FirstNameField);
            DeleteText(LastNameField);
            DeleteText(EmailField);
            Click(NextBtn);
        }

        public string GetPageTitle()
        {
            return GetText(Title);
        }

        public string GetEmailErr()
        {
            return GetText(EmailErr);
        }

        public string GetFirstNameErr()
        {
            return GetText(FirstNameErr);
        }
    }
}
