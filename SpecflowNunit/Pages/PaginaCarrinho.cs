using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace SpecflowNunit.Pages
{
    public class PaginaCarrinho
    {
        private IWebDriver webDriver;
        
        [FindsBy(How = How.Id, Using = "1_1_0_0")]
        public IWebElement botaodeletarProduto1;

        [FindsBy(How = How.Id, Using = "2_7_0_0")]
        public IWebElement botaodeletarProduto2;

        [FindsBy(How = How.CssSelector, Using = "p.alert")]
        public IWebElement mensagemDeAlerta;

        [FindsBy(How = How.ClassName, Using = "standard-checkout")]
        public IWebElement proximaPage;

        public PaginaCarrinho(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public string ValidaExclusao()
        {
            while (mensagemDeAlerta.GetAttribute("style") != "")
            {
                Thread.Sleep(500);
            }
            return mensagemDeAlerta.Text;
        }

        public void DeletarProduto1()
        {
            botaodeletarProduto1.Click();
        }

        public void DeletarProduto2()
        {
            botaodeletarProduto2.Click();
        }

        public void ProximaPage()
        {
            proximaPage.Click();
        }
    }
}
