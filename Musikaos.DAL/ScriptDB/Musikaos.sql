--CREATE DATABASE MusikaosDB;

USE MusikaosDB;

CREATE TABLE [dbo].[TpUsuario]
(
    [IdTpUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DescricaoTpUsuario] NVARCHAR(13) NOT NULL 

);

INSERT INTO [TpUsuario] VALUES('Administrador');
INSERT INTO [TpUsuario] VALUES('Outros');
-----------------------------------------------------


-----------------------------------------------------

CREATE TABLE [dbo].Usuario
(
    IdUsuario INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    NomeUsuario NVARCHAR(50) NOT NULL, 
    SenhaUsuario NVARCHAR(6) NOT NULL,
    EmailUsuario NVARCHAR(50) NOT NULL,
    FKTpUsuario INT NOT NULL,
    
    FOREIGN KEY (FKTpUsuario) REFERENCES [TpUsuario](IdTpUsuario)
   
);

INSERT INTO Usuario VALUES('Cerjio','111111','cerjio@musicaos.com',1);
INSERT INTO Usuario VALUES('Marsia','222222','marcia@musicaos.com',2);

SELECT * FROM Genero;
-----------------------------------------------------

CREATE TABLE [dbo].Genero
(
    [IdGenero] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NomeGenero] NVARCHAR(50) NOT NULL 

);

INSERT INTO Genero VALUES('Pop');
INSERT INTO Genero VALUES('Rock');
INSERT INTO Genero VALUES('Punk');
INSERT INTO Genero VALUES('Eletrônico');
INSERT INTO Genero VALUES('R&B');
INSERT INTO Genero VALUES('Clássico');
INSERT INTO Genero VALUES('Sertanejo');


CREATE TABLE [dbo].Album
(
    [IdAlbum] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NomeAlbum] NVARCHAR(50) NOT NULL,
    [ArtistaAlbum] NVARCHAR(50) NOT NULL,
    [SeloAlbum] NVARCHAR(50) NOT NULL,
    [UrlImagemAlbum] NVARCHAR (MAX) NOT NULL,
    [FKGeneroAlbum] INT NOT NULL,

    FOREIGN KEY (FKGeneroAlbum) REFERENCES Genero(IdGenero)
);

INSERT INTO Album VALUES('Lets Dance','Varukers','EMI','C:\Images\varukers.jpg',1);
INSERT INTO Album VALUES('Power slave','Iron Maiden','Sony','C:\Images\varukers.jpg',2);
INSERT INTO Album VALUES('Ramones','Ramones','Independente','C:\Images\varukers.jpg',2);
INSERT INTO Album VALUES('Waiting for the Sun','The Doors','Sony','C:\Images\varukers.jpg',2);

SELECT * FROM Album;
-----------------------------------------------------



SELECT * FROM GENERO

SELECT * FROM ALBUM


update Album 
set urlImagemAlbum = 'david-bowie-aladdin-sane-e1561828527172.jpg' 
where idAlbum = 1

update Album 
set urlImagemAlbum = 'pink-floyd-the-wall.jpg' 
where idAlbum = 2

update Album 
set urlImagemAlbum = 'sepultura-roots-1010x1024.jpg' 
where idAlbum = 3