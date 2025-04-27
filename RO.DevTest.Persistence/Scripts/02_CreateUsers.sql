-- Criar usuários
INSERT INTO "AspNetUsers" (
    "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", 
    "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", 
    "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", 
    "LockoutEnabled", "AccessFailedCount", "Nome", "Role", "Ativo"
)
VALUES 
(
    '1', 'admin@test.com', 'ADMIN@TEST.COM', 'admin@test.com', 'ADMIN@TEST.COM',
    true, 'AQAAAAIAAYagAAAAEPvIBGPTyZbTwgQw9Ls4RQv+fNWxrqh7APkrHXG+aqH1UPbP4wZYfkrHXG+aqH1UPbP4w==',
    'STAMP1', '1', NULL, false, false, NULL, true, 0, 'Administrador', 0, true
),
(
    '2', 'manager@test.com', 'MANAGER@TEST.COM', 'manager@test.com', 'MANAGER@TEST.COM',
    true, 'AQAAAAIAAYagAAAAEPvIBGPTyZbTwgQw9Ls4RQv+fNWxrqh7APkrHXG+aqH1UPbP4wZYfkrHXG+aqH1UPbP4w==',
    'STAMP2', '2', NULL, false, false, NULL, true, 0, 'Gerente', 1, true
);

-- Associar usuários aos roles
INSERT INTO "AspNetUserRoles" ("UserId", "RoleId")
VALUES 
('1', '1'), -- Admin
('2', '2'); -- Manager 