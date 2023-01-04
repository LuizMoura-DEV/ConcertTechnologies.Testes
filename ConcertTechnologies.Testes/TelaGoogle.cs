using System;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace ConcertTechnologies.Teste
{
    public class TelaGoogle
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;

        public TelaGoogle(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver =
                    _configuration.GetSection("Configuracoes:CaminhoDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver =
                    _configuration.GetSection("Configuracoes:CaminhoDriverChrome").Value;
            }
            
            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver, bool.Parse(_configuration.GetSection("Configuracoes:HeadlessMODE").Value));



          

        }
        public void CarregarPagina()
        {

            _driver.LoadPage(
                TimeSpan.FromSeconds(5),
                _configuration.GetSection("Configuracoes:UrlBase").Value);

        }

        public bool VerificarLogado()
        {
            try
            {
                _driver.FindElement(By.XPath("//a[contains(text(),\"Fazer login\")]"));
                return false;
            }
            catch (NoSuchElementException e)
            {
                _driver.FindElement(By.XPath("//a[contains(@aria-label,'qa03012023')]"));
                return true;
            }
        
        }

        public void EfetuarLoginGoogle()
        {
            _driver.FindElement(By.XPath("//a[contains(text(),\"Fazer login\")]")).Click();

            _driver.SetText(
                By.XPath("//input[@id=\"identifierId\"]"),
                _configuration.GetSection("Configuracoes:EmailValido").Value);

            _driver.FindElement(By.XPath("//button/span[contains(text(),\"Avançar\")]")).Click();


            WebDriverWait wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.XPath("//input[@type=\"password\"]")).Displayed);


            _driver.SetText(
                By.XPath("//input[@type=\"password\"]"),
                _configuration.GetSection("Configuracoes:SenhaValida").Value);

            _driver.FindElement(By.XPath("//button/span[contains(text(),\"Avançar\")]")).Click();


            Thread.Sleep(2000);

        }

        public void PreencherCampoPesquisa(String valor)
        {

            _driver.SetText(
                By.Name("q"),
                valor);

            WebDriverWait wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.XPath("(//input[@name=\"btnK\"])[2]")).Displayed);

        }

        public void ProcessarPesquisa()
        {

            _driver.FindElement(By.XPath("(//input[@name=\"btnK\"])[1]")).Click();

            WebDriverWait wait = new WebDriverWait(
               _driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.XPath("(//div[@id=\"result-stats\"])")).Displayed);
        }

        public void BTTecladoVirtual()
        {

            _driver.FindElement(By.XPath("//img[@tia_field_name=\"q\"]/..")).Click();
            WebDriverWait wait = new WebDriverWait(
               _driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.XPath("//div[@id=\"kbd\"]")).Displayed);

        }

        public bool VisibilidadeTecladoVirtual()
        {

            return _driver.FindElement(By.XPath("//div[@id=\"kbd\"]")).Displayed;

        }

        public void FecharTecladoVirtual()
        {

            _driver.FindElement(By.XPath("//div[@id=\"kbd\"]/div/div/div/div")).Click();

        }

        public void BTPEsquisaImagem()
        {

            _driver.FindElement(By.XPath("//div[@aria-label=\"Pesquisa por imagem\"]")).Click();

        }

        public void UploadImagem()
        {

            IWebElement fileUpload = _driver.FindElement(By.Name("encoded_image"));

            fileUpload.SendKeys(_configuration.GetSection("Configuracoes:IMGFile").Value);

            Thread.Sleep(2000);

        }

        public String PaginaImagem()
        {
            return _driver.FindElement(By.XPath("/html/body//h2")).Text;
        }

        public void BTEstouComSorte()
        {

            _driver.FindElement(By.XPath("(//input[@name=\"btnI\"])[2]")).Click();

        }
        public void BTSobre()
        {

            _driver.FindElement(By.XPath("//a[contains(text(),\"Sobre\")]")).Click();

        }
        public void BTPublicidade()
        {

            _driver.FindElement(By.XPath("//a[contains(text(),\"Publicidade\")]")).Click();

        }
        public void BTNegocios()
        {

            _driver.FindElement(By.XPath("//a[contains(text(),\"Negócios\")]")).Click();

        }

        public String ObterValorURL()  {

            return _driver.Url;

        }

        public void Fechar()    {

            _driver.Quit();
            _driver = null;

        }
    }
}