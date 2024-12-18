CREATE DATABASE Mercato;
USE Mercato;

CREATE TABLE Merci (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100),
    quantitaMagazzino INT,
    dataCambio DATE,
    dataScadenza DATE,
    categoria VARCHAR(50),
    prezzo DECIMAL(10, 2)
);

INSERT INTO Merci (nome, quantitaMagazzino, dataCambio, dataScadenza, categoria, prezzo) VALUES
('Pane', 50, '2024-12-15', '2024-12-20', 'Alimentari', 1.50),
('Latte', 30, '2024-12-14', '2024-12-19', 'Alimentari', 0.90),
('Formaggio', 20, '2024-12-10', '2024-12-25', 'Alimentari', 3.00),
('Yogurt', 25, '2024-12-12', '2024-12-18', 'Alimentari', 1.20),
('Rivista di Moda', 15, '2024-12-01', NULL, 'Riviste', 5.00),
('Rivista di Tecnologia', 10, '2024-12-05', NULL, 'Riviste', 6.00),
('Smartphone', 5, NULL, NULL, 'Tecnologia', 699.99),
('Laptop', 8, NULL, NULL, 'Tecnologia', 999.99),
('Biscotti', 40, '2024-12-10', '2024-12-22', 'Alimentari', 2.50),
('Cereali', 35, '2024-12-11', '2024-12-21', 'Alimentari', 3.50),
('Rivista di Cucina', 20, '2024-12-02', NULL, 'Riviste', 4.00),
('Tablet', 7, NULL, NULL, 'Tecnologia', 299.99),
('Succo di Frutta', 15, '2024-12-13', '2024-12-19', 'Alimentari', 1.80),
('Cuffie Bluetooth', 12, NULL, NULL, 'Tecnologia', 49.99),
('Pasta', 60, '2024-12-10', '2024-12-30', 'Alimentari', 1.00),
('Olio d''Oliva', 20, '2024-12-12', '2024-12-29', 'Alimentari', 5.50),
('Rivista di Viaggi', 18, '2024-12-03', NULL, 'Riviste', 5.50),
('Carne', 10, '2024-12-14', '2024-12-17', 'Alimentari', 10.00),
('Pesce', 8, '2024-12-15', '2024-12-18', 'Alimentari', 12.00),
('Snack Salati', 25, '2024-12-11', '2024-12-20', 'Alimentari', 2.00);


Select * FROM Merci


CREATE TABLE Clienti (
    id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(100),
    dataIscrizione DATE,
    maggiorenne BIT
);

INSERT INTO Clienti (username, dataIscrizione, maggiorenne) VALUES
('Mario Rossi', '2024-01-10', 1),
('Giulia Bianchi', '2024-02-15', 1),
('Luca Verdi', '2024-03-20', 1),
('Anna Neri', '2024-04-25', 1),
('Marco Gialli', '2024-05-30', 0),
('Sofia Blu', '2024-06-05', 1),
('Francesco Grigi', '2024-07-10', 1),
('Elena Fucsia', '2024-08-15', 1),
('Alessandro Arancio', '2024-09-20', 1),
('Chiara Viola', '2024-10-25', 1);

CREATE TABLE Carrello (
    cliente_id INT,
    merce_id INT,
    quantita INT,
    PRIMARY KEY (cliente_id, merce_id),
    FOREIGN KEY (cliente_id) REFERENCES Clienti(id),
    FOREIGN KEY (merce_id) REFERENCES Merci(id)
);

-- Inserimento dati casuali nella tabella Carrello
INSERT INTO Carrello (cliente_id, merce_id, quantita) VALUES
(1, 1, 2),
(1, 3, 1),
(1, 4, 3),
(2, 2, 1),
(2, 5, 2),
(3, 4, 3),
(3, 6, 1),
(3, 7, 2),
(4, 8, 1),
(4, 9, 2),
(5, 10, 1),
(5, 11, 3),
(5, 12, 2),
(6, 13, 1),
(6, 14, 4),
(7, 15, 2),
(7, 16, 1),
(8, 17, 3),
(8, 18, 2),
(9, 19, 1),
(9, 20, 5),
(10, 1, 2),
(10, 2, 1);

SELECT 
    *
FROM 
    Carrello ca
INNER JOIN 
    Clienti c ON ca.cliente_id = c.id
INNER JOIN 
    Merci m ON ca.merce_id = m.id;


	SELECT 
    c.username AS NomeCliente,
    m.nome AS NomeMerce,
    ca.quantita AS QuantitaAcquistata
FROM 
    Carrello ca
INNER JOIN 
    Clienti c ON ca.cliente_id = c.id
INNER JOIN 
    Merci m ON ca.merce_id = m.id;