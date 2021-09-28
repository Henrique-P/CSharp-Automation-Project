using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecflowNunit.Pages
{
    public class HomePage
    {
        private IWebDriver webDriver;
        private Actions action;

        [FindsBy(How = How.CssSelector, Using = "a[title='Proceed to checkout']")]
        public IWebElement irParaCarrinho;

        [FindsBy(How = How.CssSelector, Using = "ul#homefeatured")]
        public IWebElement listaProdutos;

        [FindsBy(How = How.CssSelector, Using = "li.hovered a[class*='add_to_cart']")]
        public IWebElement botaoAddToCart;

        [FindsBy(How = How.CssSelector, Using = "li.hovered a[class*='lnk_view']")]
        public IWebElement botaoAbrePaginaProduto;



        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            action = new Actions(this.webDriver);
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClicarProduto1()
        {
            action.MoveToElement(GetProdutosNaLista()[0]).Perform();
            botaoAddToCart.Click();
        }

        public void ClicarProduto2()
        {
            action.MoveToElement(GetProdutosNaLista()[1]).Perform();
            botaoAddToCart.Click();
        }

        public void PaginaInicial()
        {
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public IList<IWebElement> GetProdutosNaLista()
        {
            return listaProdutos.FindElements(By.CssSelector("a[class=product_img_link]"));
        }

        public void AdicionarProdutoAoCarrinho(int indexProduto)
        {
            action.MoveToElement(GetProdutosNaLista()[indexProduto - 1]).Perform();
            botaoAddToCart.Click();
        }

        public void ClicaPaginaProduto(int indexProduto)
        {
            action.MoveToElement(GetProdutosNaLista()[indexProduto - 1]).Perform();
            botaoAbrePaginaProduto.Click();
        }
    }
}
//return listaProdutos.FindElements(By.CssSelector("a[class*=add_to_cart_button]"));
