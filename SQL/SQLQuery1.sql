select * from __EFMigrationsHistory
select * from Categoria_Noticias
select * from Categoria_Videos
select * from Categorias_Noticias
select * from Categorias_Videos
select * from Comentario_Postagem
select * from Eventos
select * from Forum_Postagem
select * from Noticias
select * from Permissao
select * from Postagem_Tags
select * from Restaurantes
select * from Tags_Forum
select * from Unidades_Sesi
select * from Usuario
select * from Nutricionista
select * from Usuario_Permissao
select * from Videos

--Excluindo Usuarios
DELETE Permissoes WHERE Id >=3

--Inserindo Permissao(Populando)
insert into Permissao (Descricao) values ('Usuario')

--Retorna Nome, Ativo e Permissao
SELECT U.Nome,U.Email,U.Senha,U.Ativo,P.Descricao
FROM Usuario AS U
JOIN Permissao AS P ON U.Permissao = P.ID

--Definindo um valor padrão
ALTER TABLE Usuario ADD Ativo INT NOT NULL DEFAULT 1 

--Excluindo coluna de tabela
ALTER TABLE usuario DROP COLUMN Ativo