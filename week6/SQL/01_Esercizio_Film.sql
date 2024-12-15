CREATE DATABASE Hollywood;
USE Hollywood;

CREATE TABLE Film(
	id INT PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(100),
	genere VARCHAR(200),
	durata INT,
	paese_produzione VARCHAR(200),
	oscar BIT
);

INSERT INTO Film 
(titolo, genere, durata, paese_produzione, oscar)
VALUES
('Panama Papers', 'Commedia', 96, 'USA', 0),
('La Grande Bellezza', 'Drammatico', 146, 'ITA', 1),
('Pirati dei Caraibi: 1', 'Azione', 141, 'USA', 0),
('Interstellar', 'Sci-Fi', 169, 'USA', 1),
('Parasite', 'Thriller', 132, 'KOR', 1),
('C''era una volta in America', 'Drammatico', 251, 'ITA-USA', 0),
('Spy Kids', 'Azione', 90, 'USA', 0),
('Blow', 'Biografico-Drammatico-Giallo', 124, 'USA', 0);

CREATE TABLE Attori(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	cognome VARCHAR(100),
	dob DATE,
	nazionalita VARCHAR(200),
	premi BIT,
	stipendio FLOAT
);

INSERT INTO Attori 
(nome, cognome, dob, nazionalita, premi, stipendio)
VALUES
('Antonio', 'Banderas', '1960-08-10', 'SPA', 1, 20),
('Tony', 'Servillo', '1959-01-25', 'ITA', 1, 2),
('Keira', 'Knightley', '1985-03-26', 'UK', 1, 15),
('Matt','Damon','1970-10-08','USA',0,30),
('Son Kang','Ho','1967-01-17','KOR',0,5.5),
('Jhonny','Deep','1963-06-09','USA',0,100.1);

SELECT * FROM Film;
SELECT * FROM Attori;

CREATE TABLE Associativa(
	id INT PRIMARY KEY IDENTITY(1,1),
	idFilm INT,
	idAttore INT,
	data_inizio_riprese DATE,
	data_fine_riprese DATE

	FOREIGN KEY (idFilm) REFERENCES Film(id)
	ON UPDATE CASCADE ON DELETE SET NULL,

	FOREIGN KEY (idAttore) REFERENCES Attori(id)
	ON UPDATE CASCADE ON DELETE SET NULL
);

INSERT INTO Associativa
(idFilm, idAttore, data_inizio_riprese, data_fine_riprese)
VALUES
(1,1,'2005-04-02', '2005-09-29'),
(2,2,'2012-08-09', '2012-12-24'),
(3,3,'2002-10-28', '2003-03-07'),
(3,6,'2002-10-28', '2003-03-07'),
(4,4,'2013-08-12', NULL),
(7,1,'2000-05-21', '2000-06-30'),
(8,6,'2000-02-01','2000-05-20');

SELECT * FROM Associativa;

--voglio vedere tutti gli attori che hanno recitato in almeno 1 film
SELECT DISTINCT CONCAT(Attori.nome, ' ',Attori.cognome) AS Nominativo
FROM Attori INNER JOIN Associativa
ON Attori.id = Associativa.idAttore;

--voglio vedere tutti i film in cui ci sono almeno 2 attori
SELECT * 
FROM Film INNER JOIN Associativa
ON Film.id = Associativa.idFilm;

-- voglio vedere quale nazione ha prodotto più film, mostra solo il paese con il numero massimo di film
SELECT paese_produzione, COUNT(*) AS numero_film
FROM Film
GROUP BY paese_produzione
HAVING COUNT(*) = (
	SELECT MAX(numero_film)
	FROM (
		SELECT paese_produzione, COUNT(*) AS numero_film
		FROM Film
		GROUP BY paese_produzione
	) AS subquery
);

-- voglio vedere quale nazione ha prodotto più film usa view, mostra solo il paese con il numero massimo di film. CREA la view e mostra il risultato in una sola query
GO
DROP VIEW IF EXISTS FilmPerPaese;
GO
CREATE VIEW FilmPerPaese AS
SELECT paese_produzione, COUNT(*) AS numero_film
FROM Film
GROUP BY paese_produzione;
GO

SELECT *
FROM FilmPerPaese
WHERE numero_film = (
	SELECT MAX(numero_film)
	FROM FilmPerPaese
);

-- quale nazione ha prodotto più film con attori autoctoni, mostra solo il paese con il numero massimo di film
SELECT paese_produzione, COUNT(*) AS numero_film
FROM Film f
JOIN Associativa a ON f.id = a.idFilm
JOIN Attori att ON a.idAttore = att.id
WHERE f.paese_produzione = att.nazionalita
GROUP BY paese_produzione
HAVING COUNT(*) = (
    SELECT MAX(numero_film)
    FROM (
        SELECT paese_produzione, COUNT(*) AS numero_film
        FROM Film f
        JOIN Associativa a ON f.id = a.idFilm
        JOIN Attori att ON a.idAttore = att.id
        WHERE f.paese_produzione = att.nazionalita
        GROUP BY paese_produzione
    ) AS subquery
);

-- quale nazione ha prodotto più film con attori autoctoni usa view, mostra solo il paese con il numero massimo di film. CREA la view e mostra il risultato in una sola query
GO
DROP VIEW IF EXISTS FilmPerPaeseConAttoriAutoctoni;
GO
CREATE VIEW FilmPerPaeseConAttoriAutoctoni AS
SELECT paese_produzione, COUNT(*) AS numero_film
FROM Film f
JOIN Associativa a ON f.id = a.idFilm
JOIN Attori att ON a.idAttore = att.id
WHERE f.paese_produzione = att.nazionalita
GROUP BY paese_produzione;
GO

SELECT *
FROM FilmPerPaeseConAttoriAutoctoni
WHERE numero_film = (
	SELECT MAX(numero_film)
	FROM FilmPerPaeseConAttoriAutoctoni
);