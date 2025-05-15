# 🏍️ API de Gestão de Movimentação de Motos

---

## 🔍 Descrição

Esta é uma API RESTful desenvolvida para gerenciar a movimentação de motos em estacionamentos.  
O sistema permite o controle eficiente de vagas, operadores, sensores e histórico de movimentações, facilitando a administração e automatizando processos.

Com esta API você pode:  
- Registrar entrada e saída de motos  
- Gerenciar sensores vinculados às motos  
- Consultar movimentações por operador  
- Controlar vagas de estacionamento  

---

## 🛠️ Tecnologias Utilizadas

- .NET 7 / C#  
- ASP.NET Core Web API  
- Entity Framework Core  
- Oracle sql
- Swagger (OpenAPI) para documentação interativa  

---

## 🚀 Rotas Principais da API

### Movimentação

| Método | Rota                                         | Descrição                           |
|--------|----------------------------------------------|-----------------------------------|
| GET    | `/api/Movimentacao`                          | Lista todas movimentações          |
| POST   | `/api/Movimentacao`                          | Cria nova movimentação             |
| GET    | `/api/Movimentacao/{id}`                     | Busca movimentação por ID          |
| PUT    | `/api/Movimentacao/{id}`                     | Atualiza movimentação por ID       |
| DELETE | `/api/Movimentacao/{id}`                     | Deleta movimentação por ID         |
| GET    | `/api/Movimentacao/por-operador/{idOperador}` | Lista movimentações por operador   |

### Sensor

| Método | Rota                     | Descrição               |
|--------|--------------------------|-------------------------|
| GET    | `/api/Sensor`            | Lista todos sensores     |
| POST   | `/api/Sensor`            | Cria novo sensor         |
| GET    | `/api/Sensor/{id}`       | Busca sensor por ID      |
| PUT    | `/api/Sensor/{id}`       | Atualiza sensor por ID   |
| DELETE | `/api/Sensor/{id}`       | Deleta sensor por ID     |

*Outras entidades como Moto, Operador e Vaga possuem rotas CRUD similares.*

---

## ⚙️ Instalação

### Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
- Oracle sql  
- Visual Studio 2022 / VS Code  

### Passos para rodar o projeto localmente

1. Clone o repositório  
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

2.Configure a connection string no appsettings.json com seu banco de dados.

3. Rode as migrations para criar o banco:
dotnet ef database update

4. Execute o projeto:
dotnet run

5. Acesse a documentação Swagger em:
https://localhost:5000/swagger/index.html
