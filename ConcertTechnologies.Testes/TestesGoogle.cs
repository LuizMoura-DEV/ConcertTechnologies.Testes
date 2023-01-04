using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Selenium.Utils;
using System;
using Xunit.Sdk;
using System.Threading;

namespace ConcertTechnologies.Teste
{

    public class TestesGoogle
    {
        private IConfiguration _configuration;
        public TestesGoogle()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Ação", "Logar")]
        public void LogarGoogle(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            Assert.False(tela.VerificarLogado());
            tela.EfetuarLoginGoogle();
            Assert.True(tela.VerificarLogado());


        }

        [Theory]
        [InlineData(Browser.Chrome, "pepino")]
        [Trait("Ação", "Pesquisar")]
        public void FazerPesquisaComValorClickBotaoPesquisar(Browser browser, String pesquisa)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);

            tela.CarregarPagina();
            tela.PreencherCampoPesquisa(pesquisa);
            tela.ProcessarPesquisa();
            String resultado = tela.ObterValorURL();

            tela.Fechar();

            Assert.Contains(pesquisa, resultado);

        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Função", "Teclado Virtual")]
        public void VerificarTecladoVirtual(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            tela.BTTecladoVirtual();

            Assert.True(tela.VisibilidadeTecladoVirtual());

            tela.FecharTecladoVirtual();

            Assert.False(tela.VisibilidadeTecladoVirtual());

            tela.Fechar();


        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Função", "Pesquisa por Imagem")]
        public void VerificarPesquisaPorImagem(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            tela.BTPEsquisaImagem();
            tela.UploadImagem();
            Assert.Contains("visuais", tela.PaginaImagem());

            String resultado = tela.ObterValorURL();

            Assert.Contains("https://lens.google.com/", resultado);

            tela.Fechar();

        }


        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Função", "Estou com Sorte")]
        public void VerificarBotaoEstouComSorte(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            tela.BTEstouComSorte();
            String resultado = tela.ObterValorURL();

            tela.Fechar();

            Assert.Contains("https://www.google.com/doodles", resultado);
        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Links", "Sobre")]
        public void VerificarBotaoSobre(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            tela.BTSobre();
            Thread.Sleep(2000);
            String resultado = tela.ObterValorURL();

            tela.Fechar();

            Assert.Contains("about.google", resultado);
        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Links", "Publicidade")]
        public void VerificarBotaoPublicidade(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            tela.BTPublicidade();
            String resultado = tela.ObterValorURL();

            tela.Fechar();

            Assert.Contains("https://ads.google.com", resultado);
        }

        [Theory]
        [InlineData(Browser.Chrome)]
        [Trait("Links", "Negocios")]
        public void VerificarBotaoNegocios(Browser browser)
        {

            TelaGoogle tela = new TelaGoogle(_configuration, browser);
            tela.CarregarPagina();
            tela.BTNegocios();
            Thread.Sleep(2000);
            String resultado = tela.ObterValorURL();

            tela.Fechar();

            Assert.Contains("smallbusiness.withgoogle", resultado);
        }
    }
}