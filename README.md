📋 Sistema de Controle de Funcionários (CRUD)

Aplicação de console desenvolvida em C# (.NET) para gerenciamento de funcionários, permitindo realizar operações de CRUD (Create, Read, Update, Delete) com persistência em banco de dados SQL Server utilizando Dapper.

🚀 Funcionalidades
✅ Cadastrar funcionário
✅ Atualizar funcionário
✅ Excluir funcionário
✅ Consultar funcionários
✅ Validação de dados (Nome, Matrícula e CPF)

🛠️ Tecnologias Utilizadas
C# / .NET
SQL Server (LocalDB)
Dapper (ORM leve)
Microsoft.Data.SqlClient

📂 Estrutura do Projeto
CRUDFuncionarios
│
├── Controllers
│   └── FuncionarioController.cs
│
├── Entities
│   └── Funcionario.cs
│
├── Repositories
│   └── FuncionarioRepository.cs
│
└── Program.cs

🧠 Regras de Negócio
Nome
Deve conter entre 10 e 150 caracteres
Matrícula
Deve conter exatamente 6 números
CPF
Deve conter exatamente 11 números

⚙️ Configuração do Banco de Dados
1. Criar o banco

Execute o script abaixo no SQL Server:

CREATE DATABASE BDFuncionarios;
GO

USE BDFuncionarios;
GO

CREATE TABLE FUNCIONARIOS (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    NOME VARCHAR(150) NOT NULL,
    MATRICULA VARCHAR(6) NOT NULL,
    CPF VARCHAR(11) NOT NULL
);
2. String de conexão

A aplicação utiliza o LocalDB:

Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDFuncionarios;Integrated Security=True;

Caso necessário, altere no arquivo:

FuncionarioRepository.cs

▶️ Como Executar
Clone o repositório:
git clone https://github.com/seu-usuario/seu-repositorio.git
Acesse a pasta:
cd CRUDFuncionarios
Execute o projeto:
dotnet run

💻 Uso do Sistema

Ao iniciar, o sistema exibirá o menu:

(1) Cadastrar Funcionário
(2) Atualizar Funcionário
(3) Excluir Funcionário
(4) Consultar Funcionários

Basta digitar a opção desejada e seguir as instruções.

⚠️ Observações
O sistema utiliza GUID como identificador do funcionário.
Para atualizar ou excluir, utilize o ID obtido na opção de consulta.
As validações são feitas diretamente na entidade (Funcionario).

📌 Possíveis Melhorias Futuras
Interface gráfica (WinForms ou Web API)
Validação de CPF real (com dígitos verificadores)
Paginação na consulta
Logs de operações
Testes automatizados

👨‍💻 Autor

Desenvolvido para fins de estudo de arquitetura em camadas e uso do Dapper.
