---------------------------
-- START SUBSCRIPT DATABASE
---------------------------
use master
go

if exists (select * from sys.databases where name = N'MinneapolisMachines')
begin
	exec msdb.dbo.sp_delete_database_backuphistory @database_name = N'MinneapolisMachines';
	alter database MinneapolisMachines set single_user with rollback immediate;
	drop database MinneapolisMachines;
end

create database MinneapolisMachines
go

-------------------------
-- START SUBSCRIPT TABLES
-------------------------
use MinneapolisMachines
go

create table Roles(
	RoleId int primary key identity(1, 1),
	Name nvarchar(16) not null,
);

create table Users(
	UserId int primary key identity(1, 1),
	RoleId int not null,
	FirstName nvarchar(64) not null,
	LastName nvarchar(64) not null,
	Email nvarchar(128) not null,
	Password nvarchar(MAX) not null,
	constraint fk_Users_Roles foreign key (RoleId) references Roles(RoleId)
);

create table Customers(
	CustomerId int primary key identity(1, 1),
	FirstName nvarchar(64) not null,
	LastName nvarchar(64) not null,
	Street1 nvarchar(128) not null,
	Street2 nvarchar(128) null,
	City nvarchar(64) not null,
	Zip int not null
);

create table Contacts(
	ContactId int primary key identity(1, 1),
	Name nvarchar(128) not null,
	Email nvarchar(128) null,
	Phone int null,
	Message nvarchar(MAX) not null
);

create table Specials(
	SpecialId int primary key identity(1, 1),
	Title nvarchar(256) not null,
	Description nvarchar(MAX) not null
);

create table Makes(
	MakeId int primary key identity(1, 1),
	UserId int not null,
	Name nvarchar(32) not null,
	DateCreated Date not null,
	constraint fk_Makes_Users foreign key (UserId) references Users(UserId)
);

create table Models(
	ModelId int primary key identity(1, 1),
	MakeId int not null,
	UserId int not null,
	Name nvarchar(32) not null,
	DateCreated Date not null,
	constraint fk_Models_Makes foreign key (MakeId) references Makes(MakeId),
	constraint fk_Models_User foreign key (UserId) references Users(UserId)
);

create table BodyTypes(
	BodyTypeId int primary key identity(1, 1),
	Name nvarchar(32)
);

create table BodyStyles(
	BodyStyleId int primary key identity(1, 1),
	Name nvarchar(32)
);

create table InteriorColors(
	InteriorColorId int primary key identity(1, 1),
	Name nvarchar(32)
);

create table ExteriorColors(
	ExteriorColorId int primary key identity(1, 1),
	Name nvarchar(32)
);

create table TransmissionTypes(
	TransmissionTypeId int primary key identity(1, 1),
	Name nvarchar(32)
);

create table Vehicles(
	VehicleId int primary key identity(1, 1),
	ModelId int not null,
	BodyTypeId int not null,
	BodyStyleId int not null,
	ExteriorColorId int not null,
	InteriorColorId int not null,
	TransmissionTypeId int not null,
	ReleaseYear int not null,
	VIN nvarchar(32) not null,
	Mileage int not null,
	MSRP decimal(10, 2) not null,
	SalesPrice decimal(10, 2) not null,
	Description nvarchar(MAX) not null,
	ImageUrl nvarchar(MAX) not null
	constraint fk_Vehicles_Models foreign key (ModelId) references Models(ModelId),
	constraint fk_Vehicles_BodyTypes foreign key (BodyTypeId) references BodyTypes(BodyTypeId),
	constraint fk_Vehicles_BodyStyles foreign key (BodyStyleId) references BodyStyles(BodyStyleId),
	constraint fk_Vehicles_ExteriorColors foreign key (ExteriorColorId) references ExteriorColors(ExteriorColorId),
	constraint fk_Vehicles_InteriorColors foreign key (InteriorColorId) references InteriorColors(InteriorColorId),
	constraint fk_Vehicles_Transmissions foreign key (TransmissionTypeId) references TransmissionTypes(TransmissionTypeId)
);

------------------------
-- START SUBSCRIPT DATA
------------------------
use MinneapolisMachines
go

insert into Specials (Title, Description) values
	('Evening Service Special', '10% off service and repairs from 4pm to 9pm, Monday-Thursday. Tires are not eligible for discount. Total discount amount cannot exceed $50.'),
	('Buy 3 Tires and get the 4th for $1', 'For a limited time when you buy 3 tires you can get the 4th for only $1. Restrictions apply. See dealer for details. Offer valid only on OEM, OEA, and WIN on-program replacement tires purchased through the Toyota Coplete Maintenance Care website.'),
	('Windshield Wipers from $26.99', 'Toyota OE - $26.99. Toyota OE Beam - $39.99. Restrictions apply. Offer valid until November 7, 2019. Total discount amount cannot exceed $20.')

insert into BodyTypes (Name) values
	('Car'),
	('SUV'),
	('Truck'),
	('Van')

insert into InteriorColors (Name) values
	('Black'),
	('Brown'),
	('Gray'),
	('Tan'),
	('Silver')

insert into ExteriorColors (Name) values
	('Black'),
	('Metallic'),
	('Gray'),
	('Silver'),
	('Blue'),
	('Red'),
	('Orange'),
	('Dark Green'),
	('Tan'),
	('White')

insert into TransmissionTypes (Name) values
	('Manual'),
	('Automatic')

insert into Roles (Name) values
	('Admin'),
	('Sales'),
	('Disabled')

------------------------------
-- START SUBSCRIPT PROCEDURES
------------------------------
use MinneapolisMachines
go

create procedure CreateSpecial (@Title nvarchar(256), @Description nvarchar(MAX))
as
	insert into Specials (Title, Description) values
		(@Title, @Description)
go

create procedure DeleteSpecial (@Id int)
as
	delete from Specials
	where SpecialId = @Id
go

create procedure GetSpecials 
as
	select * from Specials
go

create procedure GetMakes
as
	select * from Makes
go

create procedure GetModels
as
	select * from Models
go

create procedure GetInteriorColors
as
	select * from InteriorColors
go

create procedure GetExteriorColors
as
	select * from ExteriorColors
go

create procedure GetBodyTypes
as
	select * from BodyTypes
go

create procedure GetBodyStyles
as
	select * from BodyStyles
go

create procedure GetTransmissionTypes
as
	select * from TransmissionTypes
go



