CREATE DATABASE GestionProductosDB;
GO
USE GestionProductosDB;
GO

CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(250) NULL
);

CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    IdCategoria INT NOT NULL,
    CONSTRAINT FK_Productos_Categorias
        FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);
GO

-- Datos de prueba
INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Computación', 'Equipos y componentes'),
('Accesorios', 'Periféricos y complementos'),
('Impresión', 'Impresoras y suministros'),
('Redes', 'Cables y equipos de red');

INSERT INTO Productos (Nombre, Precio, Stock, FechaRegistro, IdCategoria) VALUES
('Teclado', 12500.00, 20, GETDATE(), 2),
('Mouse', 8000.00, 35, GETDATE(), 2),
('Monitor', 95000.00, 8, GETDATE(), 1),
('Impresora', 120000.00, 5, GETDATE(), 3),
('Cable de red', 3500.00, 50, GETDATE(), 4);
GO
