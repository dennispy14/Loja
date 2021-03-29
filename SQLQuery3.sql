USE Loja;
UPDATE Cliente
SET datacadastro = convert(datetime,'18-06-12 10:34:09 AM', 5)
WHERE codigo = 1;