CREATE TABLE Prodotti (
    id INT PRIMARY KEY IDENTITY(1,1),
    categoria VARCHAR(255),
    marca VARCHAR(255),
    modello VARCHAR(255),
    affittabile BIT,
    annoImmatricolazione INT,
    consumoMedioAKM INT,
    capienzaSerbatoio INT
);

CREATE TABLE Automobili (
    id INT PRIMARY KEY IDENTITY(1,1),
    cilindrata INT,
    velocitaMax INT,
    postiAuto INT,
    prodotto_id INT,
    FOREIGN KEY (prodotto_id) REFERENCES Prodotti(id)
    ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE Moto (
    id INT PRIMARY KEY IDENTITY(1,1),
    passeggeri BIT,
    prodotto_id INT,
    FOREIGN KEY (prodotto_id) REFERENCES Prodotti(id)
    ON UPDATE CASCADE ON DELETE SET NULL
);
INSERT INTO Prodotti (categoria, marca, modello, affittabile, annoImmatricolazione, consumoMedioAKM, capienzaSerbatoio)
VALUES 
('Automobile', 'Toyota', 'Corolla', 1, 2019, 6, 50),
('Automobile', 'BMW', 'Serie 3', 0, 2021, 8, 60),
('Automobile', 'Audi', 'A4', 1, 2020, 7, 55),
('Automobile', 'Mercedes', 'C-Class', 1, 2018, 7, 50),
('Automobile', 'Volkswagen', 'Golf', 1, 2017, 5, 45),
('Moto', 'Yamaha', 'MT-09', 1, 2020, 4, 14),
('Moto', 'Ducati', 'Monster', 1, 2018, 5, 15),
('Moto', 'Honda', 'CBR600RR', 1, 2019, 4, 16),
('Moto', 'Kawasaki', 'Ninja 650', 0, 2021, 4, 15),
('Moto', 'Suzuki', 'GSX-R750', 1, 2020, 4, 16),
('Automobile', 'Ford', 'Focus', 1, 2018, 6, 48),
('Automobile', 'Chevrolet', 'Malibu', 0, 2019, 8, 60),
('Automobile', 'Hyundai', 'Elantra', 1, 2021, 6, 50),
('Automobile', 'Mazda', 'Mazda3', 1, 2020, 7, 50),
('Automobile', 'Tesla', 'Model 3', 1, 2021, 5, 75),
('Moto', 'BMW', 'R1250', 1, 2020, 5, 17),
('Moto', 'KTM', 'Duke 390', 1, 2019, 4, 13),
('Moto', 'Triumph', 'Street Triple', 1, 2018, 5, 16),
('Moto', 'Harley-Davidson', 'Sportster', 0, 2021, 6, 12),
('Moto', 'Indian', 'Scout', 1, 2020, 6, 14);

INSERT INTO Automobili (cilindrata, velocitaMax, postiAuto, prodotto_id)
VALUES 
(1600, 180, 5, 1),  
(2000, 240, 5, 2), 
(1800, 220, 5, 3),  
(2200, 250, 5, 4), 
(1400, 200, 5, 5), 
(1600, 210, 5, 11),
(2500, 240, 5, 12), 
(2000, 230, 5, 13), 
(2000, 220, 5, 14), 
(1500, 250, 5, 15);    

INSERT INTO Moto (passeggeri, prodotto_id)
VALUES 
(1, 6), 
(1, 7),  
(1, 8),  
(1, 9),  
(1, 10), 
(1, 16), 
(1, 17), 
(1, 18), 
(1, 19), 
(1, 20); 