# Hotel API

## Funcionalidades

- Cadastro de clientes
- Reserva de quartos
- Consulta de reservas por email
- Edição de dados de clientes na opção de buscar minhas reservas
- Cancelamento e atualização de reservas na opção de buscar minhas reservas

## Tecnologias Utilizadas

- ASP.NET 8
- Entity Framework Core para operações de banco de dados
- SQL Server para armazenamento de dados
- Bootstrap para o front-end

## Configuração do Projeto

### Pré-requisitos

- .NET 8 SDK
- SQL Server
- Visual Studio ou similar IDE

### Configuração do Banco de Dados

1. Configure a string de conexão no arquivo appsettings.json com os detalhes do seu servidor SQL Server.
2. Use os scripts de criação do banco na raiz do projeto (scripts.sql)
   ```json
   "ConnectionStrings": {
       "ConexaoBD": "Server=(localdb)\\mssqllocaldb;Database=Hotel;Trusted_Connection=True;"
   }
   ```
