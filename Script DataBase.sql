Create Database Oscar

go

Use Oscar

go

Create table Studios
(
  Id int identity(1,1) constraint PK_Id_Studios primary key(Id),
  Name varchar(50)
)

go

Create table Movies
(
  Id int identity(1,1) constraint PK_Id_Movies primary key(Id),
  Title varchar(50) not null,
  Release_Date date,
  Id_Studio int constraint FK_Id_Studios Foreign Key References Studios(Id)
)