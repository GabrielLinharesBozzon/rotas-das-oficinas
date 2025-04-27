-- Criar produtos
INSERT INTO "Produtos" ("Id", "Nome", "Descricao", "Preco", "QuantidadeEstoque", "Codigo")
VALUES 
(1, 'Produto 1', 'Descrição do Produto 1', 99.99, 100, 'PROD001'),
(2, 'Produto 2', 'Descrição do Produto 2', 149.99, 50, 'PROD002'),
(3, 'Produto 3', 'Descrição do Produto 3', 199.99, 75, 'PROD003');

-- Criar clientes
INSERT INTO "Clientes" ("Id", "Nome", "Email", "Telefone", "Endereco", "CPF")
VALUES 
(1, 'Cliente 1', 'cliente1@test.com', '11999999999', 'Endereço 1', '12345678901'),
(2, 'Cliente 2', 'cliente2@test.com', '11988888888', 'Endereço 2', '98765432109');

-- Criar vendas
INSERT INTO "Vendas" ("Id", "DataVenda", "ValorTotal", "Status", "ClienteId", "UsuarioId")
VALUES 
(1, CURRENT_TIMESTAMP, 249.98, 0, 1, '1'),
(2, CURRENT_TIMESTAMP, 199.99, 0, 2, '2');

-- Criar itens de venda
INSERT INTO "ItensVenda" ("Id", "Quantidade", "PrecoUnitario", "Subtotal", "ProdutoId", "VendaId")
VALUES 
(1, 2, 99.99, 199.98, 1, 1),
(2, 1, 149.99, 149.99, 2, 1),
(3, 1, 199.99, 199.99, 3, 2); 