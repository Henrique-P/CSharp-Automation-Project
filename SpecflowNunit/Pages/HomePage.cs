using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecflowNunit.Pages
{
    public class HomePage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "//*[@id='homefeatured']/li[2]/div/div[2]/h5/a")]
        public IWebElement botaoProduto2;

        [FindsBy(How = How.XPath, Using = "//*[@id='homefeatured']/li[1]/div/div[2]/h5/a")]
        public IWebElement botaoProduto1;

        [FindsBy(How = How.Name, Using = "Submit")]
        public IWebElement adicionarAoCarrinho;

        [FindsBy(How = How.CssSelector, Using = "a[title='Proceed to checkout']")]
        public IWebElement irParaCarrinho;

        
        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClicarProduto1()
        {
            botaoProduto1.Click();

        }
        public void ClicarProduto2()
        {
            botaoProduto2.Click();
        }
        public void PaginaInicial()
        {
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}
