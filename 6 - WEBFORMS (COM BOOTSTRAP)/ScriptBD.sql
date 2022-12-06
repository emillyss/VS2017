CREATE DATABASE DadosCadastroVendaGenericoNovo;
USE DadosCadastroVendaGenericoNovo;

CREATE TABLE clientes
(
  id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  nome varchar(200),
  ativo boolean
);
 
CREATE TABLE produtos
( 
  id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  descricao varchar(200),
  estoque int,
  valor float
);

CREATE TABLE vendas 
( 
  id int PRIMARY KEY AUTO_INCREMENT NOT NULL, 
  datahora datetime NOT NULL,
  id_cliente int NOT NULL,
  FOREIGN KEY(id_cliente) REFERENCES clientes(id)
);

CREATE TABLE itens_venda
( 
  id int PRIMARY KEY AUTO_INCREMENT NOT NULL, 
  qtd int NOT NULL,
  valor float NOT NULL, 
  id_venda int NOT NULL,
  FOREIGN KEY(id_venda) REFERENCES vendas(id),
  id_produto int NOT NULL,
  FOREIGN KEY(id_produto) REFERENCES produtos(id)
);

INSERT INTO clientes (nome, ativo) VALUES ('Fulano',1), ('Beltrano',0), ('Sicrano',1), ('Beltrão',0);
INSERT INTO produtos (descricao, estoque, valor) VALUES ('Arroz',100, 8.9), ('Feijão',50, 7.6), ('Salada',40, 1.3), ('Macarrão',30, 4.4);
