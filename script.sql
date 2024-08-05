CREATE DATABASE Hotel;
GO

-- Usar o banco de dados Hotel
USE Hotel;
GO

-- Criação da tabela Clientes
CREATE TABLE Clientes (
                          ClienteId INT IDENTITY(1,1) PRIMARY KEY,
                          Nome NVARCHAR(100) NOT NULL,
                          Email NVARCHAR(100) NOT NULL,
                          Telefone NVARCHAR(20) NULL
);
GO

-- Criação da tabela Quartos
CREATE TABLE Quartos (
                         QuartoId INT IDENTITY(1,1) PRIMARY KEY,
                         Numero NVARCHAR(10) NOT NULL,
                         Tipo NVARCHAR(50) NOT NULL,
                         Preco DECIMAL(10, 2) NOT NULL
);
GO

-- Criação da tabela ReservaStatus
CREATE TABLE ReservaStatus (
                               ReservaStatusId INT IDENTITY(1,1) PRIMARY KEY,
                               Descricao NVARCHAR(50) NOT NULL
);
GO

-- Criação da tabela Reservas
CREATE TABLE Reservas (
                          ReservaId INT IDENTITY(1,1) PRIMARY KEY,
                          ClienteId INT NOT NULL,
                          QuartoId INT NOT NULL,
                          ReservaStatusId INT NOT NULL,
                          DataEntrada DATE NOT NULL,
                          DataSaida DATE NOT NULL,
                          FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
                          FOREIGN KEY (QuartoId) REFERENCES Quartos(QuartoId),
                          FOREIGN KEY (ReservaStatusId) REFERENCES ReservaStatus(ReservaStatusId)
);
GO

-- Inserção de dados iniciais na tabela ReservaStatus
INSERT INTO ReservaStatus (Descricao) VALUES 
('Reservado'), 
('Confirmado'), 
('Cancelado');
GO

-- Inserir dados na tabela Clientes
INSERT INTO Clientes (Nome, Email, Telefone) VALUES 
('João Silva', 'joao.silva@example.com', '123456789'),
('Maria Oliveira', 'maria.oliveira@example.com', '987654321'),
('Carlos Santos', 'carlos.santos@example.com', '555555555');
GO

-- Inserir dados na tabela Quartos
INSERT INTO Quartos (Numero, Tipo, Preco) VALUES 
('101', 'Standard', 100.00),
('102', 'Deluxe', 150.00),
('201', 'Suite', 200.00);
GO

-- Inserir dados na tabela Reservas
INSERT INTO Reservas (ClienteId, QuartoId, ReservaStatusId, DataEntrada, DataSaida) VALUES 
(1, 1, 1, '2023-08-01', '2023-08-05'),
(2, 2, 2, '2023-08-10', '2023-08-15'),
(3, 3, 3, '2023-08-20', '2023-08-25');
GO