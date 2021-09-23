using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowNunit.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowNunit.step_definition
{
    [Binding]
    public class TesteEndToEndSteps
    {
        private ScenarioContext context;
        private IWebDriver webDriver;
        private HomePage homePage;
        private PaginaCarrinho paginaCarrinho;
        //private PaginaProduto paginaProduto;
        private PaginaEndereco paginaEndereco;
        private PaginaEntrega paginaEntrega;
        private PaginaPagamento paginaPagamento;

        public TesteEndToEndSteps(ScenarioContext context)
        {
            this.context = context;
            webDriver = this.context["WEB_DRIVER"] as IWebDriver;
            homePage = new HomePage(webDriver);
            paginaCarrinho = new PaginaCarrinho(webDriver);
            //paginaProduto = new PaginaProduto(webDriver);
            paginaEndereco = new PaginaEndereco(webDriver);
            paginaPagamento = new PaginaPagamento(webDriver);
            paginaEntrega = new PaginaEntrega(webDriver);
        }

        [Given(@"que estou logado e na pagina home")]
        public void DadoQueEstouLogadoENaPaginaHome()
        {
            homePage.PaginaInicial();
        }

        [When(@"prossigo para a pagina de endereço")]
        public void QuandoProssigoParaAPaginaDeEndereco()
        {
            paginaCarrinho.ProximaPage();
        }

        [When(@"prossigo para a pagina de forma de entrega")]
        public void QuandoProssigoParaAPaginaDeFormaDeEntrega()
        {
            paginaEndereco.ProximaPage();
        }

        [When(@"prossigo para a pagina de forma de pagamento")]
        public void QuandoProssigoParaAPaginaDeFormaDePagamento()
        {
            paginaEntrega.IConsent();
            paginaEntrega.ProximaPage();
        }

        [When(@"seleciono a forma de pagamento Bankwire")]
        public void QuandoSelecionoAFormaDePagamentoBankwire()
        {
            paginaPagamento.Bankwire();
        }


        [When(@"clico em Finalizar pedido")]
        public void QuandoClicoEmFinalizarPedido()
        {
            paginaPagamento.IConfirmMyOrder();
        }
        
        [Then(@"devo ver '(.*)' na pagina final")]
        public void EntaoDevoVerNaPaginaFinal(string mensagemSucesso)
        {
            Assert.True(paginaPagamento.ValidarMensagem().Equals(mensagemSucesso));
        }
    }
}
