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
	IsFeatured bit not null,
	IsSold bit not null,
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
	('Buy 3 Tires and get the 4th for $1', 'For a limited time when you buy 3 tires you can get the 4th for only $1. Restrictions apply. See dealer for details. Offer valid only on OEM, OEA, and WIN replacement tires.'),
	('Windshield Wipers from $26.99', 'Toyota OE - $26.99. Toyota OE Beam - $39.99. Restrictions apply. Offer valid until November 7, 2019. Total discount amount cannot exceed $20.')

insert into BodyTypes (Name) values
	('New'),
	('Used')

insert into BodyStyles (Name) values
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
	('Automatic'),
	('Manual')

insert into Roles (Name) values
	('Admin'),
	('Sales'),
	('Disabled')

insert into Users (RoleId, FirstName, LastName, Email, Password) values
	(1, 'Thomas', 'Juranek', 'admin@minneapolismachines.com', 'AIi2YyoLDjvQl4camiOeqa0gNGYfPr3LY4f2bwmn6ERFgVtJA0vQ+SS189hn91Wjqg=='),
	(2, 'Elle', 'Juranek', 'sales@minneapolismachines.com', 'ANH1MvrkMEYyABKMjDgiCvSg5d6efeulLGl53DPXdTEg/kBARVg04sb0UwXRYHTidA==')

insert into Makes (Name, DateCreated, UserId) values
	('Jeep', GETDATE(), 1),
	('Ford', GETDATE(), 1),
	('GMC', GETDATE(), 1)

insert into Models (Name, DateCreated, UserId, MakeId) values
	('Grand Cherokee', GETDATE(), 1, 1),
	('Rubicon', GETDATE(), 1, 1),
	('Explorer', GETDATE(), 1, 2),
	('Expedition', GETDATE(), 1, 2),
	('Yukon', GETDATE(), 1, 3)

insert into Vehicles (ModelId, BodyTypeId, BodyStyleId, ExteriorColorId, InteriorColorId, TransmissionTypeId, ReleaseYear, VIN, Mileage, MSRP, SalesPrice, Description, ImageUrl, IsSold, IsFeatured) values
	(1, 2, 2, 4, 5, 1, 2006, 'JH4DA3450KS009535', 156282, 8000, 6500, 'This Jeep is a great value with decent mileage.', 'https://drop.ndtv.com/albums/AUTO/porsche-taycan-turbo/6401200x900_1_640x480.jpg', 0, 1),
	(1, 2, 2, 3, 1, 2, 2003, 'JH4KA7660PC001313', 198232, 4000, 2300, 'Great first vehicle for your new driver.', 'https://drop.ndtv.com/albums/AUTO/porsche-taycan-turbo/6401200x900_1_640x480.jpg', 0, 0),
	(2, 2, 2, 4, 5, 1, 2013, 'JH4DB1550NS000306', 156282, 14000, 12995, 'One owner, clean past. Great value.', 'https://drop.ndtv.com/albums/AUTO/porsche-taycan-turbo/6401200x900_1_640x480.jpg', 0, 0),
	(2, 1, 2, 6, 1, 1, 2018, '1FTYR14U2XPC03940', 127, 45000, 41575, 'A brand new Jeep Rubicon, come take a test drive!', 'https://drop.ndtv.com/albums/AUTO/porsche-taycan-turbo/6401200x900_1_640x480.jpg', 0, 1)


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

create procedure CreateVehicle (@ModelId int, @BodyTypeId int, @BodyStyleId int, @ExteriorColorId int, @InteriorColorId int, @TransmissionTypeId int, @ReleaseYear int, @VIN nvarchar(32), @Mileage int, @MSRP decimal(10,2), @SalesPrice decimal(10, 2), @Description nvarchar(MAX), @ImageUrl nvarchar(MAX), @IsFeatured bit)
as
	insert into Vehicles (ModelId, BodyTypeId, BodyStyleId, ExteriorColorId, InteriorColorId, TransmissionTypeId, ReleaseYear, VIN, Mileage, MSRP, SalesPrice, Description, ImageUrl, IsFeatured, IsSold) values
		(@ModelId, @BodyTypeId, @BodyStyleId, @ExteriorColorId, @InteriorColorId, @TransmissionTypeId, @ReleaseYear, @VIN, @Mileage, @MSRP, @SalesPrice, @Description, @ImageUrl, @IsFeatured, 0)
go

create procedure GetVehicles
as
	select * from Vehicles
go

create procedure GetFeaturedVehicles
as
	select * from Vehicles
	where IsFeatured = 1
go

create procedure CreateContact (@Name nvarchar(128), @Email nvarchar(128), @Phone int, @Message nvarchar(MAX))
as
	insert into Contacts (Name, Email, Phone, Message) values
		(@Name, @Email, @Phone, @Message)
go

create procedure GetContacts 
as
	select * from Contacts
go

create procedure CreateMake (@Name nvarchar(32), @DateCreated date, @UserId int)
as
	insert into Makes (Name, DateCreated, UserId) values
		(@Name, @DateCreated, @UserId)
go


create procedure CreateModel (@Name nvarchar(32), @DateCreated date, @UserId int, @MakeId int)
as
	insert into Models (Name, DateCreated, UserId, MakeId) values
		(@Name, @DateCreated, @UserId, @MakeId)
go