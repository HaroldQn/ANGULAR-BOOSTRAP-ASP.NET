CREATE DATABASE BD_CRUD;
use BD_CRUD;
go

create table raza(
	idraza int primary key identity(1,1),
	nombre_raza varchar(50) not null
)
go

insert into raza(nombre_raza)values('Chiwawa'),('Pedigri'),('Pitbull')
go

CREATE TABLE Mascota(
	idmascota int primary key identity(1,1),
	idraza int,
	nombre_mascota varchar(50) not null
	foreign key (idraza) references raza(idraza)
)
go
insert into Mascota(idraza,nombre_mascota)values(1,'Barbas'),(2,'Duki')
go

create proc sp_getMascotaAll
as
begin
	select * from Mascota
end
go

exec sp_getMascotaAll
GO

create proc sp_addMascota(
	@idraza int,
	@nombre_mascota varchar(50)
)
as
begin
	insert into Mascota(idraza,nombre_mascota)values(@idraza,@nombre_mascota)
end
go

create proc sp_updateMascota(
	@idmascota int,
	@idraza int,
	@nombre_mascota varchar(50)
)
as
begin
	update Mascota
	set 
	idraza = @idraza,
	nombre_mascota = @nombre_mascota
	where idmascota = @idmascota
end
go

create proc sp_deleteMascota(
	@idmascota int
)
as
begin
	delete from Mascota where idmascota = @idmascota
end
go



