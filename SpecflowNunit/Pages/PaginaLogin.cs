using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNunit.Pages
{
    public class PaginaLogin
    {
        private IWebDriver webDriver;
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement inputEmail;

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement btnSubmit;

        [FindsBy(How = How.CssSelector, Using = "#center_column > div.alert.alert-danger > ol > li")]
        public IWebElement mensagemAlerta;
            
        public PaginaLogin(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void PaginaDeLogin()
        {
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
        }

        public void PreencheEmail(string email)
        {
            inputEmail.SendKeys(email);
        }

        public void PreencheSenha(string password)
        {
            inputPassword.SendKeys(password);
        }

        public void ClicaSignIn()
        {
            btnSubmit.Click();
        }

        public string ValidaErroLogin()
        {
            return mensagemAlerta.Text;
        }
    }
}
