# ConcertTechnologies.Testes

##Avaliação usabilidade

A interface em sim é bem simples e intuitiva, mas talvez essa simplicidade toda possa tambem ser um problema para determinados usuarios (em questão de encontrar os elementos) os botão de pesquisa mesmo poderia ver visalmente diferente para facilitar distinguir (até porque muitas vezes itilizamos dee cores ou icones para ajudar alguem. "-Clica no botão azul", "-Clica na lupinha"), o icone de lupa pode gerar uma pequana confusão, podendo ser confundido com o botão real responsavel por executar a pesquisa. Informações com ose você esta ou não logadopoderiam ficar um pouco mais evidentes

### Estrutura do Projeto

![image](https://user-images.githubusercontent.com/22231446/210656129-b69963c9-a661-401d-ae60-b7daa3a25d6e.png)

### Pacote Selenium.Utils

Este fica responsavel por manter e gerenciar as configurações base do seleniumWebDriver

#### **WebDriverExtensions.cs**

**LoadPage('_Objeto WebDriver_','_Tempo de espera_', '_urlPagina_') -> Carrega url enviada**

![image](https://user-images.githubusercontent.com/22231446/210658051-48b9b58a-09ee-4b89-8156-e87af20d8ded.png)


**GetText('_Objeto WebDriver_','_Locator do elemento_') -> Rertorna o texto contido no elemento**

![image](https://user-images.githubusercontent.com/22231446/210658101-09dab3fc-8c31-40fa-9d7b-347e4da650cd.png)


**GetText('_Objeto WebDriver_','_Locator do elemento_', '_Texto a ser preenchido') -> Preenche campo determinado com o texto enviado**

![image](https://user-images.githubusercontent.com/22231446/210657963-1c52b217-5e1e-4a5b-bc83-e7931fb48b28.png)


**Submit('_Objeto WebDriver_','_Locator do elemento_') -> Executa ação de clicar no elemento tipo Imput=submit - preparada para ser utilizada com IE**

![image](https://user-images.githubusercontent.com/22231446/210658218-90df7df3-cf54-4053-bc88-03be1eb38041.png)



#### **WebDriverFactory.cs**

**CreateWebDriver('_Navegador que rodará o teste_','_caminho do webDriverNavegador_', '_forma de execução_') -> Cria webDriver com base nos paramentros enviados, podendo assim definir qual navegador sera utilizado nos testes e se sera executado no modo "headless"**

![image](https://user-images.githubusercontent.com/22231446/210659140-07b8b69a-4cfe-4d6f-9083-13c54dffbc48.png)



### Pacote ConcertTechnologies.Teste

Este fica responsavel pelas funções direcionadas aos testes em si

#### **TelaGoogle.cs**


**TelaGoogle('_Objeto do tipo configuração_','_Navegador que sera utilizado_') -> Carregar as configurações com base nos dados do .json tratado e executar o teste no navegador informado"**

![image](https://user-images.githubusercontent.com/22231446/210659592-796fb24b-124f-4c14-be05-0f70eadabd5c.png)


**CarregarPagina() -> Carrega a url Base contida no .JSON"**

![image](https://user-images.githubusercontent.com/22231446/210660535-ac11fc3d-2154-4dbd-9d96-95d25c3f8175.png)


**CarregarPagina() -> Faz a verificação se esta logado ou nao em uma conta Google"**

![image](https://user-images.githubusercontent.com/22231446/210660738-a3ff83b7-1d9d-4524-bcf0-70e11da4f22e.png)


**EfetuarLoginGoogle() -> Faz o login utilizando os dados contidos no .JSON"**

![image](https://user-images.githubusercontent.com/22231446/210660844-1c02d6ee-3889-456f-a7fc-7b2b25b475df.png)


**PreencherCampoPesquisa(_'Valor que deseja pesquisar'_) -> insere o calor que deseja pesquisar no campo**

![image](https://user-images.githubusercontent.com/22231446/210661040-0fc99b4b-4b89-441b-b569-e78c49e7231b.png)


**ProcessarPesquisa() -> efetua a ação de clicar em pesquisar**

![image](https://user-images.githubusercontent.com/22231446/210661182-f8bdebd4-02b7-4652-b029-2309f3a6e617.png)


**BTTecladoVirtual() -> clica no botão responsavel po exibir o teclado virtual e aguarda ele ser exibido**

![image](https://user-images.githubusercontent.com/22231446/210661301-473bdf67-c115-4c86-a60b-8b4ddd84c0a1.png)


**VisibilidadeTecladoVirtual() -> verifica se o teclado virtual esta visivel na tela**

![image](https://user-images.githubusercontent.com/22231446/210661471-8eb51212-cfb3-4f4a-9824-9c17d79fcf35.png)


**FecharTecladoVirtual() -> fecha o teclado virtual**

![image](https://user-images.githubusercontent.com/22231446/210661634-97f9848e-6969-4cfe-9bba-1fb2d050367f.png)


**BTPEsquisaImagem() -> clica na opção que abilita pesquisar por imagem**

![image](https://user-images.githubusercontent.com/22231446/210661818-32167126-89d6-40ab-8549-48b556b64820.png)


**UploadImagem() -> efetua o upload de uma imagem para verificar funcionalidade, diretorio do arquivo é recebido no .JSON**

![image](https://user-images.githubusercontent.com/22231446/210661895-55cfb97c-e805-4c95-b37f-0aef917b6e42.png)


**PaginaImagem() -> verifica se a pagina com resultado da pesquisa foi carregada**

![image](https://user-images.githubusercontent.com/22231446/210662121-31dbf747-2d1b-4e58-9047-0a78cce86cd8.png)


**BTEstouComSorte() -> clica no botão'Estou com Sorte' para verificar funcionmalidade**

![image](https://user-images.githubusercontent.com/22231446/210662238-5fd61100-6d22-4f50-978e-b0d2bb0e31e1.png)


**BTSobre()**
**BTPublicidade()**
**BTNegocios() -> clica no Link referente as funcionalidades **

![image](https://user-images.githubusercontent.com/22231446/210662491-2dc138d9-b2fe-4804-99d0-13b8da809b12.png)


**ObterValorURL() -> retarna o valor da url atual no navegador **

![image](https://user-images.githubusercontent.com/22231446/210662563-fdbe48c8-fe9c-40f9-b380-393742585e9c.png)


**Feechar() -> fecha o navegador no qual o teste esta sendo executado **

![image](https://user-images.githubusercontent.com/22231446/210662657-85ade0d1-c2fd-4698-95a1-919eddf492e8.png)


#### **TelaGoogle.cs**

Contem os testes a serem executados fazendo as assertivas para garantir a verassidade dos testes.

![image](https://user-images.githubusercontent.com/22231446/210663610-d6c3a705-65b5-4635-bd16-4b93b3e8d701.png)



