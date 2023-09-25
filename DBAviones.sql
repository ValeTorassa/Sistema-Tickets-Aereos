USE MASTER
GO
DROP DATABASE DBAviones

GO
CREATE DATABASE DBAviones

GO
USE DBAviones

--#REGION (TABLAS)

-- AVIONES
CREATE TABLE AVIONES (
  ID int NOT NULL IDENTITY PRIMARY KEY,
  MATRICULA nvarchar(25) NOT NULL UNIQUE,
  MARCA nvarchar(100) NOT NULL,
  MODELO nvarchar(100) NOT NULL,
  CAPACIDADMAXIMA INT NOT NULL,
  ESTADO BIT NULL
);

--PASAJEROS
CREATE TABLE PASAJEROS (
  ID int NOT NULL IDENTITY PRIMARY KEY,
  NUMERODEPASAPORTE nvarchar(25) NOT NULL UNIQUE,
  NOMBREAPELLIDO nvarchar(100) NOT NULL,
  NACIONALIDAD nvarchar(25) NOT NULL UNIQUE,
  FECHADENACIMIENTO DATE NOT NULL,
  ESTADO BIT NULL
);

--TICKETAVION
CREATE TABLE TICKETSAEREOS (
  ID int NOT NULL IDENTITY PRIMARY KEY,
  NUMEROTICKET int NOT NULL UNIQUE,
  ORIGEN nvarchar(25) NOT NULL,
  DESTINO nvarchar(25) NOT NULL,
  ID_PASAJERO INT NOT NULL FOREIGN KEY REFERENCES PASAJEROS(ID),
  ID_AVION INT NOT NULL FOREIGN KEY REFERENCES AVIONES(ID),
  FECHAVUELO DATE NOT NULL,
  ESTADO BIT NULL
);

--#ENDREGION




--#REGION (AVIONES)

--SPs de AVIONES (SIN RELACIONES)

--RECUPERAR AVIONES

GO  -- DEVULVE TODAS LAS COLUMNAS DE AVIONES MENOS LAS NO HABILITADAS
CREATE PROCEDURE SP_RECUPERARAVIONES
AS BEGIN
    SELECT * FROM AVIONES WHERE ESTADO IS NULL
END;


--AGREGAR AVIONES (RECUPERAR DE BAJA LOGICA TAMBIEN)

GO 
CREATE PROCEDURE SP_AGREGARAVION @Matricula nvarchar(25), @Marca nvarchar(50), @Modelo nvarchar(50), @CapacidadMaxima int
AS BEGIN
    DECLARE @ID_AVIONES INT
    SET @ID_AVIONES = (SELECT ID FROM AVIONES WHERE MATRICULA = @Matricula)
    IF(@ID_AVIONES IS NULL)
    BEGIN 
        INSERT INTO AVIONES VALUES (@Matricula, @Marca, @Modelo, @CapacidadMaxima, NULL) 
    END
    ELSE
    BEGIN
        UPDATE AVIONES SET ESTADO = NULL, Matricula = @Matricula, MODELO = @Modelo, CAPACIDADMAXIMA = @CapacidadMaxima WHERE (MATRICULA = @Matricula)
    END
END;
    

--ELIMINAR AVIONES BAJA LOGICA

GO
CREATE PROCEDURE SP_ELIMINARAVIONES @Matricula nvarchar(25) 
AS BEGIN
    UPDATE AVIONES SET ESTADO = 'True' where MATRICULA = @Matricula
END;


--MODIFICAR AVIONES

GO
CREATE PROCEDURE SP_MODIFICARAVIONES @Matricula nvarchar(25), @Marca nvarchar(50), @Modelo nvarchar(50), @CapacidadMaxima int
AS BEGIN
    UPDATE AVIONES SET MARCA = @Marca, MODELO = @Modelo, CAPACIDADMAXIMA = @CapacidadMaxima WHERE (MATRICULA = @Matricula)
END;


--RECUPERAR LOS AVIONES ELIMINADOS

GO
CREATE PROCEDURE SP_RECUPERARAVIONESELIMINADOS
AS BEGIN
    SELECT * FROM AVIONES WHERE NOT ESTADO IS NULL 
END;

--#ENDREGION



--#REGION (PASAJEROS)

--SPs de PASAJEROS 

-- SP_AGREGARPASAJERO
GO
CREATE PROCEDURE SP_AGREGARPASAJERO @NumeroPasaporte nvarchar(25), @NombreApellido nvarchar(100), @Nacionalidad nvarchar(25), @FechaDeNacimiento DATE
AS BEGIN
    DECLARE @ID_PASAJEROS INT
    SET @ID_PASAJEROS = (SELECT ID FROM PASAJEROS WHERE NUMERODEPASAPORTE = @NumeroPasaporte)
    IF(@ID_PASAJEROS IS NULL)
    BEGIN 
        INSERT INTO PASAJEROS (NUMERODEPASAPORTE, NOMBREAPELLIDO, NACIONALIDAD, FECHADENACIMIENTO, ESTADO)
        VALUES (@NumeroPasaporte, @NombreApellido, @Nacionalidad, @FechaDeNacimiento, NULL)  
    END
    ELSE
    BEGIN
        UPDATE PASAJEROS
        SET NOMBREAPELLIDO = @NombreApellido, NACIONALIDAD = @Nacionalidad, FECHADENACIMIENTO = @FechaDeNacimiento, ESTADO = NULL
        WHERE (NUMERODEPASAPORTE = @NumeroPasaporte)
    END
END;

-- SP_MODIFICARPASAJEROS
GO
CREATE PROCEDURE SP_MODIFICARPASAJERO @NumeroPasaporte nvarchar(25), @NombreApellido nvarchar(100), @Nacionalidad nvarchar(25), @FechaDeNacimiento DATE
AS BEGIN
    UPDATE PASAJEROS
    SET NOMBREAPELLIDO = @NombreApellido, NACIONALIDAD = @Nacionalidad, FECHADENACIMIENTO = @FechaDeNacimiento
    WHERE NUMERODEPASAPORTE = @NumeroPasaporte
END;

-- SP_ELIMINARPASAJEROS
GO
CREATE PROCEDURE SP_ELIMINARPASAJERO @NumeroPasaporte nvarchar(25) 
AS BEGIN
    UPDATE PASAJEROS
    SET ESTADO = 1 -- True para indicar eliminación lógica
    WHERE NUMERODEPASAPORTE = @NumeroPasaporte
END;
--RECUPERAR PASAJEROS
GO
CREATE PROCEDURE SP_RECUPERARPASAJEROS
AS BEGIN
SELECT * FROM PASAJEROS WHERE ESTADO IS NULL
END;


--#ENDREGION




--#REGION (TicketAereo)

--SPs de TICKETAEREO


--AGREGAR TICKETAEREO
-- SP_AGREGARTICKETAEREO
GO
CREATE PROCEDURE SP_AGREGARTICKETAEREO @NumeroTicket int, @Origen nvarchar(25), @Destino nvarchar(25),  @NumPasaportePasajero nvarchar(25), @MatriculaAvion nvarchar(25), @FechaVuelo DATE
AS BEGIN
    DECLARE @ID_TICKETAEREO INT
    SET @ID_TICKETAEREO = (SELECT ID FROM TICKETSAEREOS WHERE NUMEROTICKET = @NumeroTicket)
    IF (@ID_TICKETAEREO IS NULL)
    BEGIN
        INSERT INTO TICKETSAEREOS (NUMEROTICKET, ORIGEN, DESTINO, ID_PASAJERO, ID_AVION, FECHAVUELO, ESTADO)
        VALUES (@NumeroTicket, @Origen, @Destino, (SELECT ID FROM PASAJEROS WHERE NUMERODEPASAPORTE = @NumPasaportePasajero), (SELECT ID FROM AVIONES WHERE MATRICULA = @MatriculaAvion), @FechaVuelo, NULL) 
    END
    ELSE
    BEGIN
        UPDATE TICKETSAEREOS
        SET ORIGEN = @Origen, DESTINO = @Destino, ID_PASAJERO = (SELECT ID FROM PASAJEROS WHERE NUMERODEPASAPORTE = @NumPasaportePasajero), ID_AVION = (SELECT ID FROM AVIONES WHERE MATRICULA = @MatriculaAvion), FECHAVUELO = @FechaVuelo, ESTADO = NULL
        WHERE (NUMEROTICKET = @NumeroTicket)
    END
END;

-- SP_RECUPERARTICKETAEREO
GO
CREATE PROCEDURE SP_RECUPERARTICKETAEREO 
AS BEGIN
    SELECT 
        TA.NUMEROTICKET,
        TA.ORIGEN,
        TA.DESTINO,
        P.NUMERODEPASAPORTE AS NUMEROPASAPORTE,
        A.MATRICULA AS MATRICULA,
        TA.FECHAVUELO
    FROM TICKETSAEREOS AS TA
    INNER JOIN PASAJEROS AS P ON TA.ID_PASAJERO = P.ID
    INNER JOIN AVIONES AS A ON TA.ID_AVION = A.ID
    WHERE TA.ESTADO IS NULL
END;


-- SP_ELIMINARTICKETAEREO
GO
CREATE PROCEDURE SP_ELIMINARTICKETAEREO @NumeroTicket int 
AS BEGIN
    UPDATE TICKETSAEREOS
    SET ESTADO = 'True'
    WHERE NUMEROTICKET = @NumeroTicket
END;

-- SP_MODIFICARTICKETAEREO
GO
CREATE PROCEDURE SP_MODIFICARTICKETAEREO @NumeroTicket int, @Origen nvarchar(25), @Destino nvarchar(25), @NumPasaportePasajero nvarchar(25), @MatriculaAvion nvarchar(25), @FechaVuelo DATE
AS BEGIN
    UPDATE TICKETSAEREOS
    SET ORIGEN = @Origen, DESTINO = @Destino, ID_PASAJERO = (SELECT ID FROM PASAJEROS WHERE NUMERODEPASAPORTE = @NumPasaportePasajero), ID_AVION = (SELECT ID FROM AVIONES WHERE MATRICULA = @MatriculaAvion), FECHAVUELO = @FechaVuelo
    WHERE NUMEROTICKET = @NumeroTicket AND ESTADO IS NULL
END;

--#ENDREGION


-- #REGION (PRUEBAS)
-----------------------------------------------------------------------------------
-- Región AVIONES
-- Recuperar Todos los Aviones
SELECT * FROM AVIONES;
-- Recuperar Aviones (incluyendo los deshabilitados)
EXEC SP_RECUPERARAVIONES;
-- Agregar un Avión
EXEC SP_AGREGARAVION 'MAT123', 'Boeing', '747', 300;
EXEC SP_AGREGARAVION 'MAT456', 'Airbus', 'A320', 200;
-- Eliminar un Avión (Baja lógica)
EXEC SP_ELIMINARAVIONES 'MAT123';
-- Modificar un Avión
EXEC SP_MODIFICARAVIONES 'MAT456', 'Airbus', 'A321', 220;
-- Recuperar los Aviones eliminados
EXEC SP_RECUPERARAVIONESELIMINADOS;
-- #ENDRegion AVIONES
-------------------------------------------------------------------------------------

-- #REGION PASAJEROS
-- Recuperar Todos los Pasajeros
SELECT * FROM PASAJEROS;
-- Recuperar Pasajeros (eliminación lógica)
EXEC SP_RECUPERARPASAJEROS;
-- Agregar un Pasajero
EXEC SP_AGREGARPASAJERO '440912', 'John Romero', 'Argentina', '1980-05-01';
EXEC SP_AGREGARPASAJERO '423452', 'Jane Smith', 'Canadá', '1990-03-20';
-- Modificar un Pasajero
EXEC SP_MODIFICARPASAJEROS 'PAS001', 'John Doe', 'Reino Unido', '1980-01-15';
-- Eliminar un Pasajero (eliminación lógica)
EXEC SP_ELIMINARPASAJEROS 'PAS001';
-- #ENDREGION PASAJEROS


-----------------------------------------------------------------------------


-- #REGION TICKETSAEREOS
-- Recuperar Todos los Tickets Aéreos
SELECT * FROM TICKETSAEREOS;
-- Recuperar Tickets Aéreos
EXEC SP_RECUPERARTICKETAEREO;
-- Agregar un Ticket Aéreo
EXEC SP_AGREGARTICKETAEREO 1, 'Ciudad A', 'Ciudad B', '440912', 'MAT123', '2023-09-14';
EXEC SP_AGREGARTICKETAEREO 2, 'Ciudad C', 'Ciudad D', '423452', 'MAT456', '2023-09-14';
-- Eliminar un Ticket Aéreo (opción 1, baja lógica)
EXEC SP_ELIMINARTICKETAEREO 1;
-- Modificar un Ticket Aéreo
EXEC SP_MODIFICARTICKETAEREO 2, 'Nueva Ciudad A', 'Nueva Ciudad B', 3, 3, '2023-09-14';
-- #ENDREGION TICKETSAEREOS
-----------------------------------------------------------------------------------

-- #REGION DROP
DROP PROCEDURE SP_AGREGARTICKETAEREO
DROP PROCEDURE SP_MODIFICARTICKETAEREO
DROP PROCEDURE SP_RECUPERARTICKETAEREO 
-- #ENDREGION DROP

-- LIMPIAR LA BASE DE DATOS
DELETE FROM AVIONES;
DELETE FROM PASAJEROS;
DELETE FROM TICKETSAEREOS;
-- #ENDREGION DROP
