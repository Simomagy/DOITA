CREATE DATABASE Concessionaria;

Use Concessionaria

CREATE TABLE Prodotti
(
		Id INT PRIMARY KEY IDENTITY(1,1),
		Categoria VARCHAR (255),
		Marca VARCHAR (255),
		Modello VARCHAR (255),
		Affittabile BIT,
		AnnoImmatricolazione INT,
		ConsumoMedioAKM FLOAT,
		CapienzaSerbatoio INT);


CREATE TABLE Automobili
(
		Id INT PRIMARY KEY,
		Cilindrata INT,
		VelocitaMax INT,
		PostiAuto INT,
		FOREIGN KEY (Id) REFERENCES Prodotti(Id)
		);

DROP TABLE Automobili

CREATE TABLE Moto
(
		Id INT PRIMARY KEY,
		Passeggeri BIT,
		FOREIGN KEY (Id) REFERENCES Prodotti(Id)
		);

DROP TABLE Moto

INSERT INTO Prodotti
(Categoria, Marca, Modello, Affittabile, AnnoImmatricolazione, ConsumoMedioAKM, CapienzaSerbatoio)
VALUES
('Automobile','Ferrari','Testarossa',1,2014,0.3,30),
('Automobile', 'Rolls Royce','Riccanza',0,2020,0.2,60),
('Automobile','FIAT','Panda',1,1998,0.6,35),
('Automobile','Ferrari','Monoposto',1,2022,0.1,25),
('Moto','Kawasaki','Ninja',0,2013,0.3,15),
('Moto','Ducati','Streetfighter',1,2024,0.1,17),
('Moto','Vespa','Paperino',1,1946,0.5,6),
('Carro Armato','H&S','Tiger',1,1942,2,540),
('Papamobile','Mercedes','Alleluia',0,2007,0.2,35);

SELECT * FROM Prodotti

DROP TABLE PRODOTTI

INSERT INTO Automobili
(Id, Cilindrata, VelocitaMax, PostiAuto)
VALUES
(1,4943,314,2),
(2,6749,250,5),
(3,1100,150,4),
(4,1600,350,1);

INSERT INTO Moto
(Id, Passeggeri)
VALUES
(5,0),
(6,1),
(7,1);

SELECT * FROM Prodotti
LEFT JOIN Automobili
ON Prodotti.Id = Automobili.Id
LEFT JOIN Moto
ON Prodotti.Id = Moto.Id
