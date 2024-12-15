USE Negozio;

SELECT * FROM Prodotti;

SELECT TOP 1 CONCAT(titolo, ' - ', autore, ' - ', prezzo) AS "Libro piu economico" FROM Libri ORDER BY prezzo;