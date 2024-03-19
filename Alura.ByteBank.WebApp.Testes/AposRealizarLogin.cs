﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin
    {
        [Fact]
        public void AposRealizarLoginVerificaOpcaoAgenciaMenu()
        {

            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            var login = driver.FindElement(By.Id("Email")); //Seleciona elementos HTML
            var senha = driver.FindElement(By.Id("Senha")); //Seleciona elementos HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar")); //Seleciona elementos HTML

            login.SendKeys("rafael@email.com");
            senha.SendKeys("senha01");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("Agência", driver.PageSource);

            driver.Close();
        }

        [Fact]
        public void TentaLogarSemPreencherDados()
        {

            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            var login = driver.FindElement(By.Id("Email")); //Seleciona elementos HTML
            var senha = driver.FindElement(By.Id("Senha")); //Seleciona elementos HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar")); //Seleciona elementos HTML

            //login.SendKeys("rafael@email.com");
            //senha.SendKeys("senha01");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);

            driver.Close();
        }

        [Fact]
        public void SenhaInvalida()
        {

            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            var login = driver.FindElement(By.Id("Email")); //Seleciona elementos HTML
            var senha = driver.FindElement(By.Id("Senha")); //Seleciona elementos HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar")); //Seleciona elementos HTML

            login.SendKeys("rafael@email.com");
            senha.SendKeys("senha02");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("Login", driver.PageSource);

            driver.Close();
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadastraCliente()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Name("Email"));
            var senha = driver.FindElement(By.Name("Senha"));

            login.SendKeys("rafael@email.com");
            senha.SendKeys("senha01");

            driver.FindElement(By.Id("btn-logar")).Click();

            driver.FindElement(By.LinkText("Cliente")).Click();

            driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            driver.FindElement(By.Name("Identificador")).Click();
            driver.FindElement(By.Name("Identificador")).SendKeys("2df71922-ca7d-4d43-b142-0767b32f822a");
            driver.FindElement(By.Name("CPF")).Click();
            driver.FindElement(By.Name("CPF")).SendKeys("69981034096");
            driver.FindElement(By.Name("Nome")).Click();
            driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
            driver.FindElement(By.Name("Profissao")).Click();
            driver.FindElement(By.Name("Profissao")).SendKeys("Cientista");

            //Act
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.LinkText("Home")).Click();

            //Assert 
            Assert.Contains("Logout", driver.PageSource);
        }
    }
}
