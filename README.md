# Rotas das Oficinas - E-commerce API

API de e-commerce desenvolvida como parte do teste técnico para a Rotas das Oficinas.

## 🚀 Tecnologias

- .NET 8.0
- PostgreSQL
- Docker
- JWT Authentication
- Entity Framework Core
- Clean Architecture
- CQRS Pattern
- Identity Framework

## 📋 Funcionalidades

- Controle de clientes, vendas e produtos (CRUD)
- Autenticação e autorização com JWT
- Sistema de roles (Admin, Manager, Sales, Customer)
- Paginação, filtragem e ordenação
- Análise de vendas por período
- Testes unitários
- Frontend em React
- Dockerização completa

## 🛠️ Instalação

### Usando Docker

1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/rotas-das-oficinas.git
```

2. Execute com Docker Compose
```bash
docker-compose up -d
```

A API estará disponível em `http://localhost:5000`

### Desenvolvimento local

1. Requisitos
   - .NET 8.0 SDK
   - PostgreSQL
   - Node.js (para o frontend)

2. Configure a string de conexão em `appsettings.json`

3. Execute as migrações
```bash
dotnet ef database update
```

4. Execute a API
```bash
dotnet run --project RO.DevTest.WebApi
```

## 🧪 Testes

Execute os testes unitários:
```bash
dotnet test
```

## 📦 Estrutura do Projeto

- `RO.DevTest.WebApi`: API REST e configurações
- `RO.DevTest.Application`: Casos de uso e DTOs
- `RO.DevTest.Domain`: Entidades e regras de negócio
- `RO.DevTest.Infrastructure`: Implementações de serviços
- `RO.DevTest.Persistence`: Acesso a dados e migrações
- `RO.DevTest.Tests`: Testes unitários e de integração

## 🔐 Autenticação

A API usa JWT para autenticação. Os tokens podem ser obtidos através do endpoint `/api/auth/login`.

## 👥 Roles

- `Admin`: Acesso total ao sistema
- `Manager`: Gerenciamento de vendas e relatórios
- `Sales`: Operações de vendas
- `Customer`: Acesso básico e compras

## 📝 Licença

Este projeto está sob a licença MIT.

