CREATE DATABASE Azienda;
USE Azienda;

CREATE TABLE Persone(
	id	INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(150),
	cognome VARCHAR(150),
	residenza VARCHAR(150),
	dob DATE
);

INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Ive', 'Crowhurst', '1946-08-04', 'Mbinga');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Sven', 'Springtorp', '1975-07-16', 'Libertad');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Inge', 'Bedford', '1984-07-08', 'Zitong');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Joel', 'Yeoland', '1940-04-12', 'Jastrebarsko');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Liza', 'Garlette', '1914-10-12', 'Guam Government House');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Carmella', 'Aizikov', '1947-11-14', 'Changgucheng');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Tammy', 'Guidera', '1934-01-22', 'Jiebu');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Sibel', 'Symonds', '1986-12-07', 'Uppsala');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Ansell', 'Dorin', '1945-11-05', 'Orong');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Tabbie', 'Tootin', '1921-04-07', 'Derbur');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Worth', 'Ivanets', '1955-06-14', 'São Miguel do Rio Torto');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Chalmers', 'Orrocks', '1929-07-24', 'Kabo');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Essy', 'Folker', '1996-05-15', 'Černovice');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Charmian', 'Rainbird', '1961-12-07', 'San Diego');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Pascal', 'Shakespeare', '1904-10-08', 'Xinning');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Brynn', 'Balnaves', '1938-04-05', 'Donabate');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Britni', 'Bullerwell', '1986-01-16', 'Aguada de Pasajeros');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Henriette', 'Fannon', '1966-07-30', 'Kujama');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Giles', 'Weatherall', '1941-03-26', 'Thessalon');
INSERT INTO Persone (nome, cognome, dob, residenza) VALUES ('Barbara', 'Maddinon', '1932-09-01', 'Ciherang');

SELECT * FROM Persone;

CREATE TABLE DIPENDENTI(
	id INT PRIMARY KEY,
	ufficio VARCHAR(250),
	numero_oreG INT,
	pagaOraria float,
	mensilita INT,
	FOREIGN KEY(id) REFERENCES Persone(id)
);

INSERT INTO Dipendenti
(id,ufficio,numero_oreG,pagaOraria,mensilita)
VALUES
(1,'Vendite',8,9.05,13),
(3,'Vendite',8,9,14),
(4,'Vendite',12,5,6),
(14,'Risorse Umane',10,10,12);

--visualizzare le persone e i loro dati come dipendenti
SELECT *
FROM Persone JOIN Dipendenti
ON Persone.id = Dipendenti.id;

-- vedere il nominativo delle persone, la loro eta e quanto guadagnano in un anno se lavorano
SELECT nome, cognome, DATEDIFF(YEAR,dob,GETDATE()) AS eta, pagaOraria*numero_oreG*30*12 AS guadagno_annuo
FROM Persone JOIN Dipendenti
ON Persone.id = Dipendenti.id;

-- contare il numero di dipendendi per ufficio
SELECT ufficio, COUNT(id) AS numero_dipendenti
FROM Dipendenti
GROUP BY ufficio;