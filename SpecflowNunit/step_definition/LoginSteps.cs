using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowNunit.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowNunit.step_definition
{
    [Binding]
    public class LoginSteps
    {
        private ScenarioContext context;
        private IWebDriver webDriver;
        private Login loginPage;
        private AreaLogada areaLogadaPage;

        public LoginSteps(ScenarioContext context)
        {
            this.context = context;
            webDriver = this.context["WEB_DRIVER"] as IWebDriver;
            loginPage = new Login(webDriver);
            areaLogadaPage = new AreaLogada(webDriver);
        }

        [Given(@"que estou na pagina de login")]
        public void DadoQueEstouNaPaginaDeLogin()
        {
            loginPage.PaginaDeLogin();
        }
        
        [When(@"preencho os campos email e senha com ""(.*)"" e ""(.*)""")]
        public void QuandoPreenchoOsCamposEmailESenhaComE(string email, string senha)
        {
            loginPage.PreencheEmail(email);
            loginPage.PreencheSenha(senha);
        }

        [When(@"clico em Sign in")]
        public void QuandoClicoEmSignIn()
        {
            loginPage.ClicaSignIn();
        }

        [Then(@"devo ver ""(.*)"" na área logada")]
        public void EntaoDevoVerNaAreaLogada(string tituloExperado)
        {
            Assert.True(areaLogadaPage.ValidaLogin().Equals(tituloExperado));
            //Assert.AreEqual(areaLogadaPage.ValidaLogin(), tituloExperado);
        }

        [Then(@"devo ver uma mensagem ""(.*)""")]
        public void EntaoDevoVerUmaMensagem(string mensagem)
        {
            Assert.True(loginPage.ValidaErroLogin().Equals(mensagem));
        }

    }
}
