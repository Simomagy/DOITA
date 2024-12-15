CREATE DATABASE Aon;
USE Aon;

CREATE TABLE Assicurazioni(
    id INT PRIMARY KEY IDENTITY(1,1),
    tipo VARCHAR(255),
    costoAnnuo FLOAT,
);

INSERT INTO Assicurazioni
(tipo,costoAnnuo) VALUES
('Auto',500),
('Moto',300),
('Casa',1000),
('Vita',2000),
('Viaggio',100);

SELECT * FROM Assicurazioni;

CREATE TABLE Persone(
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255),
    cognome VARCHAR(255),
    residenza VARCHAR(500),
    dob DATE,
    nuovoCliente BIT
)

INSERT INTO Persone 
(nome,cognome,residenza,dob,nuovoCliente)
VALUES
('Ive','Crowhurst','Napoli','1946-08-04',1),
('Sven','Springtorp','Roma','1975-07-16',0),
('Inge','Bedford','Milano','1984-07-08',1),
('Joel','Yeoland','Napoli','1940-04-12',0),
('Liza','Garlette','Roma','1914-10-12',1),
('Carmella','Aizikov','Milano','1947-11-14',1),
('Tammy','Guidera','Napoli','1934-01-22',1),
('Sibel','Symonds','Milano','1986-12-07',1),
('Ansell','Dorin','Milano','1945-11-05',0),
('Barbara','Maddinon','Milano','1932-09-01',0);

SELECT * FROM Persone;

-- Tabella associativa che contiene due FOREIGN KEY colleganti le tabelle Persone e Assicurazioni
-- FK 1 -> Persone --> collega idPersona all'id di una persona nella tabella Persone
-- FK 2 -> Assicurazioni --> collega idAssicurazione all'id di una assicurazione nella tabella Assicurazioni

CREATE TABLE Polizze(
    id INT PRIMARY KEY IDENTITY(1,1),
    dataInizio DATE,
    dataFine DATE,
    tassoInteresse FLOAT,
    idPersona INT,
    idAssicurazione INT,
    FOREIGN KEY(idPersona) REFERENCES Persone(id)
    ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY(idAssicurazione) REFERENCES Assicurazioni(id)
    ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Polizze (dataInizio,dataFine,tassoInteresse,idPersona,idAssicurazione)
VALUES
('2024-01-01','2024-12-31',3.5,4,2),
('2024-08-01','2025-05-01',2.8,7,1);

SELECT * FROM Polizze;

-- visualizzare il nominativo delle persone e il tipo di assicurazione che hanno sottoscritto e la data di fine della polizza
-- Visualizzo il nome, cognome, tipo di assicurazione e la data di fine della polizza
SELECT p.nome AS Nome, p.cognome AS Cognome, a.tipo AS Assicurazione, po.dataFine AS DataFine
-- Seleziono la prima tabella Persone(alias p)
FROM Persone p
-- Collego la tabella Persone(p) con la tabella Polizze(alias po) tramite la chiave esterna idPersona
INNER JOIN Polizze po 
ON p.id = po.idPersona
-- Collego la tabella Polizze(po) con la tabella Assicurazioni(alias a) tramite la chiave esterna idAssicurazione
INNER JOIN Assicurazioni a
ON po.idAssicurazione = a.id;

-- aggiungere altre 10 Polizze con date di inizio e fine diverse meta attive e meta scadute
INSERT INTO Polizze (dataInizio, dataFine, tassoInteresse, idPersona, idAssicurazione)
VALUES
('2020-01-01', '2021-12-31', 3.5, 1, 2),
('2024-08-01', '2025-05-01', 2.8, 2, 1),
('2024-01-01', '2024-12-31', 3.5, 3, 2),
('2024-08-01', '2025-05-01', 2.8, 4, 1),
('1980-01-01', '1999-12-31', 3.5, 5, 2),
('2024-08-01', '2025-05-01', 2.8, 6, 1),
('2024-01-01', '2024-12-31', 3.5, 7, 2),
('1700-08-01', '1750-05-01', 2.8, 8, 1),
('2024-01-01', '2024-12-31', 3.5, 9, 2),
('2024-08-01', '2025-05-01', 2.8, 10, 1);

SELECT id FROM Persone;

-- vedere le polizze ancora attive
SELECT p.nome AS Nome, p.cognome AS
Cognome, a.tipo AS Assicurazione, po.dataFine AS DataFine
FROM Persone p
INNER JOIN Polizze po
ON p.id = po.idPersona
INNER JOIN Assicurazioni a
ON po.idAssicurazione = a.id
WHERE po.dataFine > GETDATE();

-- vedere le polizze scadute
SELECT p.nome AS Nome, p.cognome AS
Cognome, a.tipo AS Assicurazione, po.dataFine AS DataFine
FROM Persone p
INNER JOIN Polizze po
ON p.id = po.idPersona
INNER JOIN Assicurazioni a
ON po.idAssicurazione = a.id
WHERE po.dataFine < GETDATE();

-- vedere quante assicurazione a vita per citta
SELECT p.residenza AS Citta, COUNT(po.idAssicurazione) AS NumeroAssicurazioniVita
FROM Persone p
INNER JOIN Polizze po
ON p.id = po.idPersona
INNER JOIN Assicurazioni a
ON po.idAssicurazione = a.id
WHERE a.tipo = 'Vita'
GROUP BY p.residenza;

-- vedere il costo annuo totale di ogni persona,considerando che possa aver stipulato più assicurazioni
SELECT p.nome AS Nome, p.cognome AS Cognome, IIF(SUM(a.costoAnnuo) > 0, SUM(a.costoAnnuo), 0) AS CostoAnnuoTotale
FROM Persone p
LEFT JOIN Polizze po
ON p.id = po.idPersona
LEFT JOIN Assicurazioni a
ON po.idAssicurazione = a.id
GROUP BY p.nome, p.cognome;

-- le persone che hanno un'assicurazione e i giorni mancati alla scadenza
SELECT p.nome AS Nome, p.cognome AS Cognome, IIF(DATEDIFF(DAY,GETDATE(),po.dataFine) > 0, DATEDIFF(DAY,GETDATE(),po.dataFine), 0) AS GiorniMancanti
FROM Persone p
INNER JOIN Polizze po
ON p.id = po.idPersona;

-- la città di residenza col maggior numero di persone che hanno stipulato una polizza
SELECT p.residenza AS Citta, COUNT(po.idPersona) AS NumeroPersone
FROM Persone p
INNER JOIN Polizze po
ON p.id = po.idPersona
GROUP BY p.residenza
ORDER BY COUNT(po.idPersona) DESC;