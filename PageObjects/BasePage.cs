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
    internal class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }

        public void FillText(IWebElement el, string text)
        {
            el.Clear();
            el.SendKeys(text);
        }

        public void DeleteText(IWebElement el)
        {
            el.Clear();
        }

        public void Click(IWebElement el)
        {
            Thread.Sleep(3000);
            el.Click();
        }

        public void Select(IWebElement select, string value)
        {
            SelectElement el = new SelectElement(select);
            el.SelectByValue(value);
        }

        public string GetText(IWebElement el)
        {
            return el.Text;
        }


        public void HighlightElementV1(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 3px solid red;');", element);
        }

        public void HighlightElementV2(IWebElement element, String color)
        {
            //keep the old style to change it back
            String originalStyle = element.GetAttribute("style");

            String newStyle = "background-color:yellow;border: 4px solid " + color + ";" + originalStyle;
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            // Change the style 
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '" + newStyle + "');},0);",
                    element);

            // Change the style back after few miliseconds
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '"
                    + originalStyle + "');},800);", element);

        }

    }
}
