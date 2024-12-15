-- creare un database per un aeroporto
CREATE DATABASE Aeroporto;
USE Aeroporto;
-- un areoporto dovra' gestire i propri aerei e i passeggeri che li utilizzano
-- Di ogni aereo si sa:
-- id, tipologia,destinazione,nPersonale,nPosti
CREATE TABLE aerei
(
    id INT PRIMARY KEY IDENTITY(1,1),
    tipologia VARCHAR(100),
    destinazione VARCHAR(100),
    nPersonale INT,
    nPosti INT
);

INSERT INTO aerei
(tipologia,destinazione,nPersonale,nPosti)
VALUES
('Passeggeri','Londra',4,150),
('Merci','Tokio',2,0),
('Passeggeri','Sidney',8,300),
('Militare','New York',2,80),
('Passeggeri','New York',8,300),
('Merci','Los Angeles',2,0),
('Passeggeri','Reykjavik',4,100),
('Militare','Pratica di Mare',2,80),
('Passeggeri','Cuba',6,200),
('Passeggeri','Lima',4,100),
('Passeggeri','Lamezia Terme',3,220),
('Merci','Milano',2,0),
('Militare','Cape Town',2,100),
('Merci','Oslo',2,0);

-- i dati dei passeggeri sono:
-- id, nominativo,genere,prezzoBiglietto,riferimento all'aereo da prendere
CREATE TABLE passeggeri
(
    id INT PRIMARY KEY IDENTITY(1,1),
    nominativo VARCHAR(100),
    genere CHAR(1),
    prezzoBiglietto FLOAT,
    idAereo INT
);

INSERT INTO passeggeri
(nominativo,genere, prezzoBiglietto,idAereo)
VALUES
('Buzz Lightyear','M',100,1),
('Betty Boop','F',300,3),
('Mike Ross','M',500,5),
('Michael Jordan','M',1500,5),
('Michelle Obama','F',2000,5),
('Ted Mosby','M',250,5),
('Peter Parker','M',300,5),
('Jack Ripper','M',100,1),
('Dorian Gray','M',200,1),
('Jack Sparrow','M',350,9),
('Enzo Ferrari','M',1000,11),
('Bruce Wayne','M',3000,9),
('Anthony Stark','M',2000,3),
('Daesy Duke','F',250,9),
('Niky Lauda','M',500,10),
('Jessica Rabbit','F',250,1),
('Mina Murray','F',100,1),
('Black Widow','F',300,7),
('Virginia Pepper Potts','F',3000,7),
('Clark Kent','M',100,3),
('Willy l''Orbo','M',50,9);

-- visualizzare il numero di passeggeri per ogni destinazione 
SELECT a.destinazione, COUNT(p.id) AS numero_passeggeri
FROM aerei a
LEFT JOIN passeggeri p ON a.id = p.idAereo
GROUP BY a.destinazione;

-- visualizzare gli aerei che non hanno ancora passeggeri
SELECT a.*
FROM aerei a
LEFT JOIN passeggeri p ON a.id = p.idAereo
WHERE p.id IS NULL;

-- il numero dei passeggeri e il numero del personale e la destinazione di tutti gli aerei
SELECT a.destinazione, COUNT(p.id) AS numero_passeggeri, a.nPersonale
FROM aerei a
LEFT JOIN passeggeri p ON a.id = p.idAereo
GROUP BY a.destinazione, a.nPersonale;

