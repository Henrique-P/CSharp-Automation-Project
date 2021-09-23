using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowNunit.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowNunit.step_definition
{
    [Binding]
    public class NoLoginSteps
    {
        private ScenarioContext context;
        private IWebDriver webDriver;
        private HomePage homePage;
        private PaginaCarrinho paginaCarrinho;
        private PaginaProduto paginaProduto;

        public NoLoginSteps(ScenarioContext context)
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

        [When(@"clico na pagina de um produto")]
        public void QuandoClicoNaPaginaDeUmProduto()
        {
            homePage.ClicarProduto1();
        }

        [When(@"adiciono o produto ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho()
        {
            paginaProduto.AdicionarAoCarrinho();
        }

        [When(@"prossigo até o carrinho")]
        public void QuandoProssigoAteOCarrinho()
        {
            paginaProduto.IrParaCarrinho();
        }
        
        [When(@"removo o item do carrinho")]
        public void QuandoORemovoDoCarrinho()
        {
            paginaCarrinho.DeletarProduto1();
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

        [When(@"retorno a Home")]
        public void QuandoRetornoAHome()
        {
            paginaProduto.VoltarHome();
        }


        [When(@"clico na segunda pagina de um produto")]
        public void QuandoClicoNaSegundaPaginaDeUmProduto()
        {
            homePage.ClicarProduto2();
        }

        [When(@"removo ambos itens do carrinho")]
        public void QuandoRemovoAmbosItensDoCarrinho()
        {
            paginaCarrinho.DeletarProduto1();
            //Thread.Sleep(1000);
            paginaCarrinho.DeletarProduto2();
        }



    }
}
