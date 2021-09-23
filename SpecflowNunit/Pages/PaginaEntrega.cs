using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Pages
{
    class PaginaEntrega
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Name, Using = "processCarrier")]
        public IWebElement proximaPage;

        [FindsBy(How = How.CssSelector, Using = "#uniform-cgv")]
        public IWebElement termsOfServiceCheckbox;

        public PaginaEntrega(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ProximaPage()
        {
            proximaPage.Click();
        }

        public void IConsent()
        {
            termsOfServiceCheckbox.Click();
        }

    }
}
