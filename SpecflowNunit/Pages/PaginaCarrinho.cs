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

        [FindsBy(How = How.CssSelector, Using = "p.alert")]
        public IWebElement mensagemDeAlerta;

        [FindsBy(How = How.ClassName, Using = "standard-checkout")]
        public IWebElement proximaPage;

        [FindsBy(How = How.CssSelector, Using = "a[title = 'Delete']")]
        public IList <IWebElement> botoesLixeira;

        [FindsBy(How = How.CssSelector, Using = "#order-detail-content small a")]
        public IWebElement detalhesProduto;



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

        public void ProximaPage()
        {
            proximaPage.Click();
        }

        public void LimparCarrinho()
        {
            foreach(var botao in botoesLixeira)
            {
                botao.Click();
            }
        }

        public string ValidaDetalhes()
        {
            return detalhesProduto.Text;
        }
    }
}
