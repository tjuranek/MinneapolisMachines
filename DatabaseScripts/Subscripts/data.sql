-------------------------
-- START SUBSCRIPT DATA
-------------------------
use MinneapolisMachines
go

insert into Roles (Name) values
	('Admin'),
	('Sales'),
	('Disabled')

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

