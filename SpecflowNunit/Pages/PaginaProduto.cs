using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecflowNunit.Pages
{
    class PaginaProduto
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Name, Using = "Submit")]
        public IWebElement adicionarAoCarrinho;

        [FindsBy(How = How.CssSelector, Using = "a[title='Proceed to checkout']")]
        public IWebElement irParaCarrinho;

        [FindsBy(How = How.ClassName, Using = "continue")]
        public IWebElement continuarComprando;

        [FindsBy(How = How.ClassName, Using = "home")]
        public IWebElement voltarHome;

        public PaginaProduto(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }
        public void AdicionarAoCarrinho()
        {
            adicionarAoCarrinho.Click();
        }
        public void IrParaCarrinho()
        {
            //Thread.Sleep(10000);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(irParaCarrinho)).Click();
            //irParaCarrinho.Click();
        }

        public void ContinuarComprando()
        {
            continuarComprando.Click();
        }

        public void VoltarHome()
        {
            voltarHome.Click();
        }
    }
}
