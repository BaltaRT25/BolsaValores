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
	correo varchar(255) NOT NULL FOREIGN KEY REFERENCES Usuario(correo),
	fecha datetime NOT NULL
);

CREATE TABLE BitacoraErrores (
    idBitacoraErrores varchar(255) NOT NULL PRIMARY KEY,
	fecha datetime NOT NULL,
	descripcion varchar(max) NOT NULL
);


CREATE PROCEDURE SPCalcularTotalHistorialPorUsuario @correoUsuario varchar(255)
AS
SELECT COUNT(a.idBitacoraHistorial) FROM [dbo].[BitacoraHistorial] a 
INNER JOIN [dbo].[Accion] b ON b.idAccion = a.idAccion
WHERE a.correo = @correoUsuario


CREATE PROCEDURE SPObtenerHistorial  @correoUsuario varchar(255), @Saltar int, @Tomar int
AS
SELECT a.fecha as fechaConsulta,b.codigo,b.fecha,b.hora,b.abre,b.cierra,b.alta,b.baja FROM [dbo].[BitacoraHistorial] a 
INNER JOIN [dbo].[Accion] b ON b.idAccion = a.idAccion
WHERE a.correo = @correoUsuario ORDER BY a.fecha DESC
OFFSET (@Saltar) ROWS FETCH NEXT (@Tomar) ROWS ONLY

