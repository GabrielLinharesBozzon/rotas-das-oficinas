# Inicialização do Banco de Dados

Este diretório contém os scripts SQL necessários para inicializar o banco de dados com dados de exemplo.

## Ordem de Execução

1. `01_CreateRoles.sql` - Cria os roles iniciais
2. `02_CreateUsers.sql` - Cria os usuários iniciais e associa aos roles
3. `03_CreateData.sql` - Cria dados de exemplo (produtos, clientes, vendas)

## Usuários Padrão

- Admin
  - Email: admin@test.com
  - Senha: Admin123!

- Gerente
  - Email: manager@test.com
  - Senha: Manager123!

## Executando os Scripts

1. Certifique-se de que o banco de dados está criado:
```bash
dotnet ef database update
```

2. Execute os scripts na ordem correta:
```bash
psql -U postgres -d rota_devtest -f 01_CreateRoles.sql
psql -U postgres -d rota_devtest -f 02_CreateUsers.sql
psql -U postgres -d rota_devtest -f 03_CreateData.sql
```

Ou usando o pgAdmin:
1. Conecte-se ao banco de dados
2. Abra a ferramenta Query Tool
3. Cole e execute cada script na ordem correta 