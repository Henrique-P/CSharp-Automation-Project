using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowNunit.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowNunit.step_definition
{
    [Binding]
    public class TesteCarrinhoSemLogin
    {
        private ScenarioContext context;
        private IWebDriver webDriver;
        private HomePage homePage;
        private PaginaCarrinho paginaCarrinho;
        private PaginaProduto paginaProduto;

        public TesteCarrinhoSemLogin(ScenarioContext context)
        {
            this.context = context;
            webDriver = this.context["WEB_DRIVER"] as IWebDriver;
            homePage = new HomePage(webDriver);
            paginaCarrinho = new PaginaCarrinho(webDriver);
            paginaProduto = new PaginaProduto(webDriver);
        }

        [Given(@"que estou na pagina home")]
        public void DadoQueEstouNaPaginaHome()
        {
            homePage.PaginaInicial();
        }

        [When(@"adiciono o produto numero '(.*)' da home page ao carrinho")]
        public void QuandoAdicionoOProdutoNumeroDaHomePageAoCarrinho(int indexProduto)
        {
            homePage.AdicionarProdutoAoCarrinho(indexProduto);
        }

        /*[When(@"adiciono o produto ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho()
        {
            homePage.AdicionarProdutoAoCarrinho(1);
        }*/

        [When(@"prossigo até o carrinho")]
        public void QuandoProssigoAteOCarrinho()
        {
            paginaProduto.IrParaCarrinho();
        }
        
        [When(@"removo o item do carrinho")]
        public void QuandoORemovoDoCarrinho()
        {
            paginaCarrinho.LimparCarrinho();
        }
        
        [Then(@"devo ver '(.*)' no carrinho")]
        public void EntaoDevoVerNoCarrinho(string mensagemAlerta)
        {
            Assert.True(paginaCarrinho.ValidaExclusao().Equals(mensagemAlerta));
        }

        [When(@"seleciono Continue shopping")]
        public void QuandoSelecionoContinueShopping()
        {
            paginaProduto.ContinuarComprando();
        }

        /*[When(@"adiciono um segundo produto ao carrinho")]
        public void QuandoAdicionoUmSegundoProdutoAoCarrinho()
        {
            homePage.AdicionarProdutoAoCarrinho(2);
        }*/

        [When(@"removo ambos itens do carrinho")]
        public void QuandoRemovoAmbosItensDoCarrinho()
        {
            paginaCarrinho.LimparCarrinho();
        }

        [When(@"clico na pagina de um produto")]
        public void QuandoClicoNaPaginaDeUmProduto()
        {
            homePage.ClicaPaginaProduto(1);
        }

        [When(@"clico em Add to Cart")]
        public void QuandoClicoEmAddToCart()
        {
            paginaProduto.AdicionarAoCarrinho();
        }

        [When(@"altero sua cor")]
        public void QuandoAlteroSuaCor()
        {
            paginaProduto.SelecionaCor("Blue");
        }

        [Then(@"devo ver '(.*)' no produto dentro do carrinho")]
        public void EntaoDevoVerProdutoDentroDoCarrinho(string mensagemValidacao)
        {
            Assert.True(paginaCarrinho.ValidaDetalhes().Equals(mensagemValidacao));
        }
    }
}
