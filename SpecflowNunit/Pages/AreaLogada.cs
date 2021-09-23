using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Pages
{
    public class AreaLogada
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.ClassName, Using = "page-heading")]
        public IWebElement tituloPage;

        public AreaLogada(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public string ValidaLogin()
        {
            return tituloPage.Text;
        }
    }
}
