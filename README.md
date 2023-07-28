## Aplicação de Exemplo: Upload de Arquivos .txt
Esta é uma aplicação de exemplo que combina o Angular e o .NET Core 6. Foi desenvolvido uma ferramenta que permite fazer o upload de arquivos .txt com dados de lojas e os mesmos são incluídos na base de dados utilizando o SQL Server.

![](https://s11.gifyu.com/images/ScTLJ.gif)

### Tecnologias Utilizadas
**Angular:** um framework de desenvolvimento de aplicativos web em TypeScript.

**.NET Core 6:** usado para criar aplicativos Windows e Web utilizando o C#.
### Visão Geral da Estrutura do Projeto
A aplicação é composta por duas partes principais: o front-end em Angular e o back-end em .NET Framework.

### Front-end (Angular)
A parte frontend da aplicação foi desenvolvida usando o Angular, um framework JavaScript baseado em TypeScript para construção de aplicações web modernas. Para efetuar as requisições HTTP, foi utilizado o Axios.

*src/app:* Esta pasta contém os componentes, serviços e modelos relacionados à lógica do frontend.

### Back-end (.NET Framework)
A parte do backend da aplicação foi desenvolvida usando o .NET Core 6, uma plataforma de desenvolvimento robusta para criar aplicativos Windows e web usando a linguagem C#.

**Cnab.API:** contém as Controllers necessárias para cada requisição. Também possui Model para requests;

**Cnab.Service:** camada responsável pelas regras de negócios. Nela há a classe ArquivoCnabService, onde é responsável por processar os arquivos. Também possui um "DictionaryHelper" para retornar tipos de manter cada classe com sua devida responsabilidade.

**Cnab.Domain:** camada que contém as classes de modelo que representam os objetos de domínio da aplicação. Nela temos DTOs, entidades, enums, interfaces e modelo de Request/Response.

**Cnab.Application:** contém as classes de modelo que representam os objetos de domínio da aplicação. Nela temos DTOs, entidades, enums, interfaces e modelo de Request/Response.

**Cnab.Infra:** camada feita para armazenar toda a configuração de acesso ao banco de dados, bem como seus métodos de consultas. Foi utilizado o EF.

**Cnab.UnitTests:** responsável pelos testes unitários do projeto. Foi utilizado o XUnit.

### Como Executar a Aplicação
1. Certifique-se de ter o Node.js e o Angular CLI instalados em seu ambiente de desenvolvimento.
2. Clone o repositório do projeto em sua máquina local através do comando `git clone https://github.com/diogomarv/desafio-dev`
3. Navegue para a pasta do projeto front-end (cd frontend) e execute o comando `npm install` ou `npm i` para instalar as dependências do projeto.
4. Execute o comando `npm start` para iniciar o servidor de desenvolvimento do Angular.
5. Navegue para a pasta do projeto back-end e execute o projeto usando sua IDE ou executando `dotnet run` no terminal.
6. Agora você pode acessar a aplicação em seu navegador em http://localhost:4200 e começar a usar a calculadora de investimento CDB.
7. O back-end roda na porta 7220 (`https://localhost:7220`) e a rota no qual o front-end chama em toda renderização é: `https://localhost:7220/api/` através de um método GET.

### Como executar os Testes Unitários?
**Back-end:** No Visual Studio, clique com o botão direito do mouse no projeto de testes e depois clique em "Run Tests". Certifique-se de efetuar um "Clean" antes de rodar o projeto. OBS: foi utilizado o padrão GWT (Given-When-Then) e AAA nos testes unitários.

**Front-end:** No Visual Studio Code ou editor de sua preferência, navegue até a pasta do projeto e digite `npm test`
### Observações
##### 1. Não foi utilizado nenhuma biblioteca para validação, como o FluentValidation.
##### Em projetos maiores o recomendável é seguir todas as práticas e padrões de projeto, incluindo libs para facilitar o desenvolvimento, porém em projetos menores, menos, pode ser mais.
