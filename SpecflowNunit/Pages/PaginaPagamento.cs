using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Pages
{
    class PaginaPagamento
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.ClassName, Using = "bankwire")]
        public IWebElement bankwire;

        [FindsBy(How = How.CssSelector, Using = "#cart_navigation > button")] //#cart_navigation button[type='submit']
        public IWebElement iConfirmMyOrder;   ////span[contains(text(),'I confirm my order')]//..//..//button

        [FindsBy(How = How.CssSelector, Using = "#center_column > div > p > strong")]
        public IWebElement mensagemSucesso;

        public PaginaPagamento(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void Bankwire()
        {
            bankwire.Click();
        }

        public void IConfirmMyOrder()
        {
            iConfirmMyOrder.Click();
        }

        public string ValidarMensagem()
        {
            return mensagemSucesso.Text;
        }
    }
}
