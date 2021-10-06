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

        [FindsBy(How = How.CssSelector, Using = "ul#color_to_pick_list a")]
        public IList<IWebElement> listaCores;

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
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(irParaCarrinho)).Click();
        }

        public void ContinuarComprando()
        {
            continuarComprando.Click();
        }

        public void VoltarHome()
        {
            voltarHome.Click();
        }

        //public IList<IWebElement> CapturarListaDeCores()
        //{
        //    return listaCores.FindElements(By.CssSelector("a"));
        //}

        public void SelecionaCor(string corProduto)
        {
            //CapturarListaDeCores()[corProduto].Click();
            //listaCores[corProduto].Click();
            foreach (var cor in listaCores)
            {
                if (cor.GetAttribute("title") == corProduto)
                {
                    cor.Click();
                    break;
                }
            } 
        }
    }
}
