using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFrameworkV2.PageObjects
{
    internal class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver) { }
        public IWebElement BeginnerBtn => Driver.FindElement(By.CssSelector(".fa.fa-blind"));
        public IWebElement IntermediateBtn => Driver.FindElement(By.CssSelector(".fa.fa-child"));
        public IWebElement AdvancedBtn => Driver.FindElement(By.CssSelector(".fa.fa-star"));
        public IWebElement NextBtn => Driver.FindElement(By.CssSelector("[name='next']"));
        public IWebElement Title => Driver.FindElement(By.CssSelector(".tab-pane.active >.info-text"));
        public IWebElement PreviousBtn => Driver.FindElement(By.CssSelector("[name='previous']"));

        public void SelectLevel(string level)
        {
            switch (level)
            {
                case "Beginner":
                    Click(BeginnerBtn);
                    break;

                case "Intermediate":
                    Click(IntermediateBtn);
                    break;

                case "Advanced":
                    Click(AdvancedBtn);
                    break;

                default:
                    break;
            }
            Click(NextBtn);
        }
        public string getPageTitle()
        {
            return GetText(Title);
        }
        public void PreviousPage()
        {
            Click(PreviousBtn);
        }
    }
}
