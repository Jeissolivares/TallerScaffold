IF OBJECT_ID('Transito') IS NOT NULL
DROP DATABASE Transito

GO

CREATE DATABASE Transito

GO

USE Transito

GO

IF OBJECT_ID('Matriculas') IS NOT NULL
DROP TABLE Matriculas

GO

Create Table Matriculas(
Id int identity(1,1) primary key NOT NULL,
Numero varchar(20) NOT NULL,
FechaExpedicion date NOT NULL,
ValidaHasta date NOT NULL,
Activo bit NULL
)

GO

IF OBJECT_ID('Conductores') IS NOT NULL
DROP TABLE Conductores

GO

Create Table Conductores(
Id int identity(1,1) primary key,
Identificacion varchar(15) NOT NULL,
Nombre varchar(20) NOT NULL,
Apellidos varchar(20) NOT NULL,
Direccion varchar(30) NOT NULL,
Telefono varchar(15) NOT NULL,
Email varchar(30) NULL,
Fecha_nacimiento date NOT NULL,
Activo bit NULL,
MatriculaId int
CONSTRAINT fk_Matricula FOREIGN KEY 
REFERENCES Matriculas(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
)

GO

IF OBJECT_ID('Sanciones') IS NOT NULL
DROP TABLE Sanciones

GO

CREATE TABLE Sanciones(
Id int identity(1,1) primary key,
FechaActual date NOT NULL,
Sancion varchar(100) NOT NULL,
Observacion varchar(Max) NULL,
Valor decimal(10,2) NOT NULL,
ConductoresId int NOT NULL
CONSTRAINT fk_Conductor FOREIGN KEY
REFERENCES Conductores(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
)