use MinneapolisMachines
go

-- customers from vehicle purchases
create table Customers(
	CustomerId int primary key identity(1, 1),
	FirstName nvarchar(64) not null,
	LastName nvarchar(64) not null,
	Street1 nvarchar(128) not null,
	Street2 nvarchar(128) null,
	City nvarchar(64) not null,
	Zip int not null
);

-- contact form submissions, basically sales leads
create table Contacts(
	ContactId int primary key identity(1, 1),
	Name nvarchar(128) not null,
	Email nvarchar(128) null,
	Phone int null,
	Message nvarchar(MAX) not null
);

-- roles for user permissions
create table Roles(
	RoleId int primary key identity(1, 1),
	Name nvarchar(16) not null,
);

-- users table for logins
create table Users(
	UserId int primary key identity(1, 1),
	RoleId int not null,
	FirstName nvarchar(64) not null,
	LastName nvarchar(64) not null,
	Email nvarchar(128) not null,
	Password nvarchar(MAX) not null,
	constraint fk_Users_Roles foreign key (RoleId) references Roles(RoleId)
);

-- special deals
create table Specials(
	SpecialId int primary key identity(1, 1),
	Title nvarchar(256) not null,
	Description nvarchar(MAX) not null
);

-- vehicle make	
create table Makes(
	MakeId int primary key identity(1, 1),
	UserId int not null,
	Name nvarchar(32) not null,
	DateCreated Date not null,
	constraint fk_Makes_Users foreign key (UserId) references Users(UserId)
);

-- vehicle model
create table Models(
	ModelId int primary key identity(1, 1),
	MakeId int not null,
	UserId int not null,
	Name nvarchar(32) not null,
	DateCreate Date not null,
	constraint fk_Models_Makes foreign key (MakeId) references Makes(MakeId),
	constraint fk_Modles_Users foreign key (UserId) references Users(UserId)
);

-- vehicle body type
create table BodyTypes(
	BodyTypeId int primary key identity(1, 1),
	Name nvarchar(32)
);

-- vehicle interior color
create table InteriorColors(
	InteriorColorId int primary key identity(1, 1),
	Name nvarchar(32)
);

-- vehicle exterior color
create table ExteriorColors(
	ExteriorColorId int primary key identity(1, 1),
	Name nvarchar(32)
);

-- vehicle transmission type
create table TransmissionTypes(
	TransmissionTypeId int primary key identity(1, 1),
	Name nvarchar(32)
);

-- vehicle
create table Vehicles(
	VehicleId int primary key identity(1, 1),
	ModelId int not null,
	BodyTypeId int not null,
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
	constraint fk_Vehicles_ExteriorColors foreign key (ExteriorColorId) references ExteriorColors(ExteriorColorId),
	constraint fk_Vehicles_InteriorColors foreign key (InteriorColorId) references InteriorColors(InteriorColorId),
	constraint fk_Vehicles_Transmissions foreign key (TransmissionTypeId) references TransmissionTypes(TransmissionTypeId)
);