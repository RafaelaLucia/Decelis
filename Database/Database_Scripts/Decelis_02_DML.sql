
USE DECELIS2RP;
GO

INSERT INTO userType (titleUserType)
values ('Geral'),('Admin'),('Root');
GO

INSERT INTO timeClass (periodTime)
values ('Manhã'),('Tarde'),('Noite');
GO

INSERT INTO statusType (activeStatus)
values (0),(1);
GO

INSERT INTO skillLevel (skillLevel)
values ('Baby Class'),('Básico'),('Intermediário'),('Avançado');
GO

INSERT INTO class (idLevel, idTime, nameClass)
values (2,2,'Basic-A1'),(3,1,'Middle-C3'),(4,3,'Advanced-B4'),(1,2,'Baby-D9');
GO

INSERT INTO userInfo (idUserType,idStatus,idClass,nameUser,email,passwordUser)
values (2,5,3,'Jéssica','jessica@gmail.com','jessica123')
GO

select * from userType
select * from statusType
select * from class
select * from userInfo