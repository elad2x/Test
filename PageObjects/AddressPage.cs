using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFrameworkV2.PageObjects
{
    internal class AddressPage : BasePage
    {
        public AddressPage(IWebDriver driver) : base(driver) { }
        public IWebElement StreetNameField => Driver.FindElement(By.CssSelector("[name='streetname']"));
        public IWebElement StreetNumberField => Driver.FindElement(By.CssSelector("[name='streetnumber']"));
        public IWebElement CityField => Driver.FindElement(By.CssSelector("[name='city']"));
        public IWebElement CountryField => Driver.FindElement(By.CssSelector("#country"));
        public IWebElement FinishBtn => Driver.FindElement(By.CssSelector("#finish"));
        public IWebElement Title => Driver.FindElement(By.CssSelector(".col-sm-12 > .info-text"));
        public IWebElement CompletionMessage => Driver.FindElement(By.CssSelector(".cta-title"));
        public IWebElement PreviousBtn => Driver.FindElement(By.CssSelector("[name='previous']"));
        public void FillInfo(string streetName, string streetNumber, string city, string country)
        {
            FillText(StreetNameField, streetName);
            FillText(StreetNumberField, streetNumber);
            FillText(CityField, city);
            Select(CountryField, country);
            //IWebElement select = Driver.FindElement(By.CssSelector("#country"));
            //SelectElement el = new SelectElement(select);
            //el.SelectByValue(country);
            Click(FinishBtn);

        }
        public string GetPageTitle()
        {
            return GetText(Title);
        }
        public string GetCompletionMessage()
        {
            return GetText(CompletionMessage);
        }

        public void PreviousPage()
        {
            Click(PreviousBtn);
        }
    }
}
