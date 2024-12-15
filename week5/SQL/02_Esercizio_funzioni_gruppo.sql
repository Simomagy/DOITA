-- Creare un DB Negozi
-- creare una tabella Prodotti
-- ogni prodotto avr�:
-- id,nome,tipo,prezzoBase,iva,quantita,dataCambio
-- inserire almeno 15 prodotti

-- Impostare l'iva a 4 per il tipo 'alimentari', a 10 per 'casalinghi' e a 20 per tutti gli altri casi
-- Creare una nuova colonna, prezzoFinale float
-- Inserire il valore di prezzoFinale, che sar� dato dal prezzoBase + il valore dell'IVA
-- ROUND() Funzione scalare che vuole 2 parametri: il numero da arrotondare e il numero di decimali che vogliamo tenere
-- FLOOR() Funzione scalare che toglie la parte decimale del numero messo tra le tonde
-- Voglio vedere l'elenco dei Prodotti da cambiare (devono avere quantit� = 1 e dataCambio entro 10 giorni da oggi)
-- Voglio vedere l'elenco dei Prodotti di elettronica che si stanno esaurendo (quantita < 5)
-- Voglio vedere il prezzoBase medio dei Prodotti per la casa
-- Voglio vedere il prezzoFinale pi� alto tra i Prodotti alimentari
-- Voglio vedere l'elenco dei Prodotti con il valore di IVA maggiore
-- Eliminate tutti i Prodotti che hanno una quantit� inferiore a 5
-- Modificate mettendo l'iva = 4 a tutti i Prodotti che prima l'avevano al 10
-- Voglio vedere il numero dei Prodotti raggruppati per tipo
-- Voglio vedere il numero dei Prodotti raggruppati per tipo a condizione che il numero dei Prodotti sia maggiore di 2
-- Voglio vedere l'elenco dei Prodotti che devono essere cambiati a Maggio
-- Voglio vedere l'elenco dei Prodotti che NON devono essere cambiati di Luned�
-- Voglio vedere il prezzoFinale medio dei Prodotti per ogni categoria
-- Voglio vedere il guadagno totale nel negozio nel caso si venda ogni pezzo presente nella tabella

CREATE DATABASE Negozio;
USE Negozio;

-- Creare una tabella Prodotti
CREATE TABLE Prodotti (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100),
    tipo VARCHAR(100),
    prezzoBase FLOAT,
    iva FLOAT,
    quantita INT,
    dataCambio DATE,
);

SELECT * FROM Prodotti;

-- Inserire almeno 15 prodotti
INSERT INTO "Prodotti"
("nome", "tipo", "prezzoBase", "quantita", "dataCambio")
VALUES 
('Laptop', 'elettronica', 1200.50, 5, NULL),
('Arance', 'alimentari', 1.2, 30, '2023-08-15'),
('Latte', 'alimentari', 1.5, 25, '2023-07-20'),
('Zucchero', 'alimentari', 2.0, 10, '2024-01-10'),
('Sapone', 'casalinghi', 3.99, 15, '2025-09-14'),
('Jeans', 'vestiario', 45.99, 8, '2023-07-01'),
('Monitor', 'elettronica', 250.75, 3, NULL),
('Tastiera', 'elettronica', 75.99, 2, NULL),
('Giacca', 'vestiario', 89.99, 5, NULL),
('Shampoo', 'igiene personale', 6.99, 12, '2023-08-05'),
('Biscotti', 'alimentari', 2.5, 50, '2023-07-25'),
('Caffè', 'alimentari', 5.0, 20, '2023-07-30'),
('Detergente', 'casalinghi', 8.99, 18, '2024-12-01'),
('Scarpe', 'vestiario', 60.00, 7, '2023-06-15'),
('Tablet', 'elettronica', 350.99, 4, NULL);

-- Impostare l'iva a 4 per il tipo 'alimentari', a 10 per 'casalinghi' e a 20 per tutti gli altri casi
UPDATE Prodotti SET iva = 4 WHERE tipo = 'alimentari';
UPDATE Prodotti SET iva = 10 WHERE tipo = 'casalinghi';
UPDATE Prodotti SET iva = 20 WHERE tipo NOT IN ('alimentari', 'casalinghi');

-- Creare una nuova colonna, prezzoFinale float
ALTER TABLE Prodotti ADD prezzoFinale FLOAT;

-- Inserire il valore di prezzoFinale, che sar� dato dal prezzoBase + il valore dell'IVA
UPDATE Prodotti SET prezzoFinale = prezzoBase + prezzoBase * iva / 100;

-- Voglio vedere l'elenco dei Prodotti da cambiare (devono avere quantit� = 1 e dataCambio entro 10 giorni da oggi)
SELECT * FROM Prodotti WHERE quantita = 1 AND dataCambio <= DATEADD(DAY, 10, GETDATE());

-- Voglio vedere l'elenco dei Prodotti di elettronica che si stanno esaurendo (quantita < 5)
SELECT * FROM Prodotti WHERE tipo = 'elettronica' AND quantita < 5;

-- Voglio vedere il prezzoBase medio dei Prodotti per la casa
SELECT AVG(prezzoBase) FROM Prodotti WHERE tipo = 'casalinghi';

-- Voglio vedere il prezzoFinale pi� alto tra i Prodotti alimentari
SELECT MAX(prezzoFinale) FROM Prodotti WHERE tipo = 'alimentari';

-- Voglio vedere l'elenco dei Prodotti con il valore di IVA maggiore
SELECT * FROM Prodotti WHERE iva = (SELECT MAX(iva) FROM Prodotti);

-- Eliminate tutti i Prodotti che hanno una quantit� inferiore a 5
DELETE FROM Prodotti WHERE quantita < 5;

-- Modificate mettendo l'iva = 4 a tutti i Prodotti che prima l'avevano al 10
UPDATE Prodotti SET iva = 4 WHERE iva = 10;

-- Voglio vedere il numero dei Prodotti raggruppati per tipo
SELECT tipo, COUNT(*) FROM Prodotti GROUP BY tipo;

-- Voglio vedere il numero dei Prodotti raggruppati per tipo a condizione che il numero dei Prodotti sia maggiore di 2
SELECT tipo, COUNT(*) FROM Prodotti GROUP BY tipo HAVING COUNT(*) > 2;

-- Voglio vedere l'elenco dei Prodotti che devono essere cambiati a Maggio
SELECT * FROM Prodotti WHERE MONTH(dataCambio) = 5;

-- Voglio vedere l'elenco dei Prodotti che NON devono essere cambiati di Luned�
SELECT * FROM Prodotti WHERE DATENAME(WEEKDAY, dataCambio) != 'Monday';

-- Voglio vedere il prezzoFinale medio dei Prodotti per ogni categoria
SELECT tipo, AVG(prezzoFinale) FROM Prodotti GROUP BY tipo;

-- Voglio vedere il guadagno totale nel negozio nel caso si venda ogni pezzo presente nella tabella
SELECT SUM(prezzoFinale * quantita) FROM Prodotti;


