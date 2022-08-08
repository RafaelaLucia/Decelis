
USE DECELIS2RP;
GO

-- select all tables
SELECT * FROM class
SELECT * FROM skillLevel
SELECT * FROM statusType
SELECT * FROM timeClass
SELECT * FROM userInfo
SELECT * FROM userType

--select class
SELECT idClass, nameClass, periodTime, skillLevel FROM class C
inner join timeClass T on C.idTime = T.idTime
inner join skillLevel S on C.idLevel = S.idLevel

--select user
SELECT idUser, nameUser as Name, email, passwordUser as Password, titleUserType as Type, activeStatus as Status, nameClass as Class, periodTime as Time FROM userInfo U
inner join userType T on U.idUserType = T.idUserType
inner join statusType S on U.idStatus = S.idStatus
inner join class C on U.idClass = C.idClass
inner join timeClass on timeClass.idTime = C.idTime

-- show the numbers of users
select COUNT (idUser) AS users from userInfo;

