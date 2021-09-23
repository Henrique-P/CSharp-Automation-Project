using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Pages
{
    class PaginaEndereco
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Name, Using = "processAddress")]
        public IWebElement proximaPage;

        public PaginaEndereco(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ProximaPage()
        {
            proximaPage.Click();
            //webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=order&step=2");
        }
    }
}
