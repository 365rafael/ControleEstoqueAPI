
# 📦 Controle de Estoque API

API REST desenvolvida em **ASP.NET Core 8.0** com **SQL Server**, seguindo as melhores práticas profissionais: arquitetura em camadas com **Repository + Service + DTOs**, geração de **relatórios em PDF**, e endpoints para controle completo de estoque, fornecedores, entradas e saídas de produtos.

## 🚀 Funcionalidades

- ✅ CRUD de **Fornecedores**
- ✅ CRUD de **Produtos**
- ✅ Controle de **Entradas de Estoque**
- ✅ Controle de **Saídas de Estoque**
- ✅ Consulta de **Estoque Atual**
- ✅ Relatórios de **Entradas e Saídas por Período**
- ✅ Relatório Financeiro (Total de vendas, custos e lucros)
- ✅ **Dashboard** com resumo geral e top 5 produtos mais vendidos
- ✅ **Geração de Relatórios em PDF**

## 🛠️ Tecnologias e Ferramentas

- ✔️ ASP.NET Core 8.0
- ✔️ Entity Framework Core
- ✔️ SQL Server
- ✔️ DinkToPdf (para geração de PDFs)
- ✔️ Swagger (documentação da API)
- ✔️ AutoMapper
- ✔️ Padrão Repository + Service
- ✔️ Clean Code

## 🗂️ Arquitetura

```
/ControleEstoqueAPI
│
├── Controllers         
├── Dtos                
├── Models              
├── Repositories        
├── Services            
├── Helpers             
├── DinkToPdfNative     
└── Program.cs          
```

## 🔗 Documentação Swagger

```
https://localhost:{porta}/swagger
```

## 🔥 Como Executar Localmente

### ✅ Pré-requisitos:

- Visual Studio 2022 ou superior
- SQL Server instalado
- .NET 8.0 SDK
- Instalar o **Visual C++ Redistributable**  
👉 [Baixar aqui](https://learn.microsoft.com/pt-br/cpp/windows/latest-supported-vc-redist)

### ✅ Clonar o projeto:

```bash
git clone https://github.com/SEU_USUARIO/ControleEstoqueAPI.git
```

### ✅ Configurar o Banco de Dados:

1. Crie um banco SQL Server chamado, por exemplo, `ControleEstoqueDB`.
2. No arquivo `appsettings.json`, configure sua string de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ControleEstoqueDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Execute as migrações (se configurado) ou rode o script SQL fornecido.

### ✅ Restaurar dependências e executar:

No Visual Studio → **F5** ou **Ctrl + F5**.

## 📄 Endpoints principais

| Recurso        | Verbo | Rota                                      | Descrição                           |
|----------------|-------|-------------------------------------------|--------------------------------------|
| Fornecedores   | GET   | /api/fornecedores                        | Listar fornecedores                 |
| Produtos       | GET   | /api/produtos                            | Listar produtos                     |
| Entradas       | POST  | /api/entradas                            | Cadastrar entrada                   |
| Saídas         | POST  | /api/saidas                               | Cadastrar saída                     |
| Estoque Atual  | GET   | /api/relatorio/estoque-atual             | Ver estoque atual                   |
| Relatório Entradas | GET | /api/relatorio/entradas?dataInicio=dd/MM/yyyy&dataFim=dd/MM/yyyy | Entradas por período |
| Relatório Saídas | GET | /api/relatorio/saidas?dataInicio=dd/MM/yyyy&dataFim=dd/MM/yyyy | Saídas por período |
| Dashboard      | GET   | /api/relatorio/dashboard                 | Resumo geral                        |
| PDF Dashboard  | GET   | /api/relatorio/dashboard/pdf             | Exportar dashboard em PDF           |

## 📑 Exportação de PDF

✔️ Endpoint `/api/relatorio/dashboard/pdf` gera um PDF formatado com o resumo do dashboard.

## 🎯 Próximos passos (em desenvolvimento ou sugestão):

- 🔐 Implementar autenticação via JWT
- 🐳 Dockerização da API
- ☁️ Deploy na nuvem (Azure, Railway, Render)
- 📦 Implementar testes unitários
- 📊 Gerar PDFs para outros relatórios (entradas, saídas, estoque atual)
- 💻 Desenvolver frontend em Blazor, React ou Vue

## 👨‍💻 Desenvolvedor

**Rafael Arantes da Silva**  
📍 Uberlândia - MG - Brasil  
📧 [rafael.imu@gmail.com](mailto:rafael.imu@gmail.com)  
📱 (34) 99713-2663  
🔗 [LinkedIn](https://www.linkedin.com/in/rafael-arantes)  
🔗 [GitHub](https://github.com/365rafael)

## 🏆 Licença

Projeto de código aberto — Licença MIT.
