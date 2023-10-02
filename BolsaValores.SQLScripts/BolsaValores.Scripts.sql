CREATE DATABASE bolsaValoresTest;

USE bolsaValoresTest;

CREATE TABLE Accion (
    idAccion varchar(50) NOT NULL PRIMARY KEY,
	codigo varchar(25) NOT NULL,
    fecha datetime NOT NULL,
	hora datetime NOT NULL,
    abre decimal NOT NULL,
	cierra decimal NOT NULL,
	alta decimal NOT NULL,
	baja decimal NOT NULL,
);

CREATE TABLE Usuario (
    correo varchar(255) NOT NULL PRIMARY KEY,
	contrasena varchar(255) NOT NULL,
);

CREATE TABLE BitacoraHistorial (
    idBitacoraHistorial varchar(255) NOT NULL PRIMARY KEY,
	idAccion varchar(50) NOT NULL FOREIGN KEY REFERENCES Accion(idAccion),
	correo varchar(255) NOT NULL FOREIGN KEY REFERENCES Usuario(correo)
);

CREATE TABLE BitacoraErrores (
    idBitacoraErrores varchar(255) NOT NULL PRIMARY KEY,
	fecha datetime NOT NULL,
	descripcion varchar(max) NOT NULL
);


SELECT * FROM [dbo].[BitacoraHistorial] a 
INNER JOIN [dbo].[Accion] b ON b.idAccion = a.idAccion
WHERE a.correo = 'usuario@bolsa.com'
