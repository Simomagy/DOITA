-- Creare il database Losco
CREATE DATABASE Losco;
USE Losco;
-- Creare la tabella criminali che avr� id PK, nome, cognome, alias, dob, gruppo
CREATE TABLE Criminali
(
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100),
    cognome VARCHAR(100),
    alias VARCHAR(100),
    dob DATE,
    gruppo VARCHAR(100)
);
-- Creare la tabella armi che avr� id PK, nome, caricatore, calibro, automatica(1-0), colore, id_criminale FK
CREATE TABLE Armi
(
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100),
    caricatore INT,
    calibro VARCHAR(100),
    automatica BIT,
    colore VARCHAR(100),
    id_Criminale INT,
    FOREIGN KEY(id_Criminale) REFERENCES Criminali(id)
);
-- Inserite almeno 3 criminali e 5 armi
INSERT INTO Criminali
(nome, cognome, alias, dob, gruppo)
VALUES
('Piero','Ettore','Achille','1998-11-26','Escapar'),
('Pino','Pane','Baguette','1978-09-03','ChioscoNostro'),
('Franco','Franchi','Don','2000-09-29','ChioscoNostro'),
('Carla','Cracci','Ciclope','1989-12-07','Camoscio D''oro'),
('Giada','Furla','Biancaneve','1997-10-31','Escapar');

INSERT INTO Armi
(nome,caricatore,calibro,automatica,colore,id_Criminale)
VALUES
('Pulisci Tutto',30,'10mm',1,'Nero',3),
('Multipla',113,'MM54',1,'Verde Bosco',3),
('Beretta',12,'9mm',0,'Grigio',null),
('Desert Eagle',20,'12mm',1,'Oro',1),
('Beretta',12,'9mm',0,'Grigio',2),
('Revolver',6,'6mm',0,'Argento',4);

-- visualizzare:
-- Per ogni criminale, il suo alias e la sua eta'
SELECT alias, DATEDIFF(YEAR,dob,GETDATE()) AS eta FROM Criminali;
-- Per ogni criminale il numero di armi che possiede
SELECT c.alias, COUNT(a.id) AS numero_armi FROM Criminali c
LEFT JOIN Armi a ON c.id = a.id_Criminale
GROUP BY c.alias;
-- i criminali che non possiedono armi 
SELECT c.alias FROM Criminali c
LEFT JOIN Armi a ON c.id = a.id_Criminale
WHERE a.id IS NULL;
-- L'alias della persona/e che possiede/ono l'arma con il caricatore maggiore
SELECT c.alias FROM Criminali c
JOIN Armi a ON c.id = a.id_Criminale
WHERE a.caricatore = (SELECT MAX(caricatore) FROM Armi);
-- Il numero di armi automatiche e non(-- e se ho delle armi che hanno automatica=null?)
SELECT COUNT(id) AS numero_armi_automatiche FROM Armi WHERE automatica = 1;
-- i criminali armati
SELECT COUNT(DISTINCT id_Criminale) AS numero_criminali_armati FROM Armi;
-- Il numero di criminali armati(devono possedere almeno un arma) per ogni gruppo
SELECT c.gruppo, COUNT(DISTINCT c.id) AS numero_criminali_armati 
FROM Criminali c
GROUP BY c.gruppo;
-- La media dei colpi dei caricatori per le armi automatiche
SELECT AVG(caricatore) AS media_colpi FROM Armi WHERE automatica = 1;
-- Il numero di colpi totali per ogni criminale
SELECT c.alias, SUM(a.caricatore) AS colpi_totali FROM Criminali c
JOIN Armi a ON c.id = a.id_Criminale
GROUP BY c.alias;
-- La/e persona/e pi� anziana senza armi in suo possesso
SELECT c.alias FROM Criminali c
LEFT JOIN Armi a ON c.id = a.id_Criminale
WHERE a.id IS NULL
ORDER BY dob ASC;