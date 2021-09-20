Use Master
Go

 drop database NdoNandiDB
 go

Create Database NdoNandiDB
Go

USE NdoNandiDB
GO

create table HairCondition (
ID int identity(1,1) primary key,
[Name] varchar (100) not null,
);

INSERT INTO [dbo].HairCondition VALUES ('My hair could use a bit of detangling')
INSERT INTO [dbo].HairCondition VALUES ('My hair is very tangled')
INSERT INTO [dbo].HairCondition VALUES ('I just took out braids and have not detangled')
INSERT INTO [dbo].HairCondition VALUES ('I have not detangled my hair for some time and it’s forming unplanned locs')

create table HairDensity (
ID int identity(1,1) primary key,
[Name] varchar (100) not null,
);

INSERT INTO [dbo].HairDensity VALUES ('I have a lot of hair and its thick')
INSERT INTO [dbo].HairDensity VALUES ('I don’t have a lot of hair and its fine/thin')
INSERT INTO [dbo].HairDensity VALUES ('Not sure')

create table HairLength (
ID int identity(1,1) primary key,
[Name] varchar (100) not null,
);

INSERT INTO [dbo].HairLength VALUES ('Ear Length')
INSERT INTO [dbo].HairLength VALUES ('Neck Length')
INSERT INTO [dbo].HairLength VALUES ('Shoulder Length')
INSERT INTO [dbo].HairLength VALUES ('Armpit Length')
INSERT INTO [dbo].HairLength VALUES ('Bra-Strap Length')
INSERT INTO [dbo].HairLength VALUES ('Mid Back Length')
INSERT INTO [dbo].HairLength VALUES ('Waist Length ')

create table Allergen (
ID int identity (1,1) primary key,
[Name] varchar (50) not null
);

INSERT INTO [dbo].Allergen VALUES ('Shea Butter')


create table ProductType (
TypeID int identity (1,1) primary key,
[Name] varchar (50) not null
);

INSERT INTO [dbo].ProductType VALUES ('Hair Oil')
INSERT INTO [dbo].ProductType VALUES ('Hair Butter')

create table Product (
ID int identity (1,1) primary key,
ProductName varchar (100) not null,
ProductDescription varchar (255) not null,
ProductPrice decimal not null,
Quantity int,
TypeID int,
PictureUrl varchar (50) not null,
foreign key (TypeID) references ProductType(TypeID)
);


create table InventoryItemType (
TypeID int identity (1,1) primary key,
[Name] varchar (50) not null
);

INSERT INTO [dbo].InventoryItemType VALUES ('Oil')
INSERT INTO [dbo].InventoryItemType VALUES ('Beads')
INSERT INTO [dbo].InventoryItemType VALUES ('Butter')

create table InventoryItem (
ID int identity (1,1) primary key,
[Name] varchar (50) not null,
[Description] varchar (100),
Quantity int,
TypeID int,
foreign key (TypeID) references InventoryItemType(TypeID)
);

INSERT INTO [dbo].InventoryItem VALUES ('Ndose and Scalp Oil','50ml','20',1)
INSERT INTO [dbo].InventoryItem VALUES ('Vitamin E Oil','30ml','20',1)
INSERT INTO [dbo].InventoryItem VALUES ('Rosemary','250ml','22',1)
INSERT INTO [dbo].InventoryItem VALUES ('Grey Land','10ml','50',2)
INSERT INTO [dbo].InventoryItem VALUES ('Moringa Butter','50ml','15',3)
INSERT INTO [dbo].InventoryItem VALUES ('Shea Butter','50ml','18',3)


create table BlogEntry (
ID int identity (1,1) primary key,
Title varchar (50) not null,
Content varchar (255) not null,
[Date] datetime not null,
PictureUrl varchar (50) not null,
);

create table Package (
ID int identity (1,1) primary key,
[Name] varchar (50) not null,
[Description] varchar (255) not null,
Duration varchar (50) not null,
Price decimal not null
);

create table Country (
CountryID int identity(1,1) primary key,
CountryName varchar (30) not null
);

INSERT INTO [dbo].Country VALUES ('South Africa')


create table Province (
ProvinceID int identity (1,1) primary key,
[Name] varchar (50) not null,
);

INSERT INTO [dbo].Province VALUES ('Gauteng',1)
INSERT INTO [dbo].Province VALUES ('Western Cape',1)
INSERT INTO [dbo].Province VALUES ('Northern Cape',1)
INSERT INTO [dbo].Province VALUES ('Eastern Cape',1)
INSERT INTO [dbo].Province VALUES ('KwaZulu-Natal',1)
INSERT INTO [dbo].Province VALUES ('Free State',1)
INSERT INTO [dbo].Province VALUES ('Mpumalanga',1)
INSERT INTO [dbo].Province VALUES ('North West',1)
INSERT INTO [dbo].Province VALUES ('Limpopo',1)

create table City (
CityID int identity(1,1) primary key,
[Name] varchar (30) not null,
ProvinceID int null,
foreign key (ProvinceID) references Province(ProvinceID)
);

INSERT INTO [dbo].City VALUES ('Pretoria',1)
INSERT INTO [dbo].City VALUES ('Johannesburg',1)
INSERT INTO [dbo].City VALUES ('Cape Town',2)
INSERT INTO [dbo].City VALUES ('Stellenbosch',2)
INSERT INTO [dbo].City VALUES ('Knysna',2)
INSERT INTO [dbo].City VALUES ('Kimberly',3)
INSERT INTO [dbo].City VALUES ('Upington',3)
INSERT INTO [dbo].City VALUES ('Springbok',3)
INSERT INTO [dbo].City VALUES ('Port Elizabeth',4)
INSERT INTO [dbo].City VALUES ('East London',4)
INSERT INTO [dbo].City VALUES ('Mthatha',4)
INSERT INTO [dbo].City VALUES ('Durban',5)
INSERT INTO [dbo].City VALUES ('Richards Bay',5)
INSERT INTO [dbo].City VALUES ('Umhlanga',5)
INSERT INTO [dbo].City VALUES ('pietermaritzburg',5)
INSERT INTO [dbo].City VALUES ('Bloemfontein',6)
INSERT INTO [dbo].City VALUES ('Sasolburg',6)
INSERT INTO [dbo].City VALUES ('Welkom',6)
INSERT INTO [dbo].City VALUES ('Nelspruit',7)
INSERT INTO [dbo].City VALUES ('Barberton',7)
INSERT INTO [dbo].City VALUES ('Standerton',7)
INSERT INTO [dbo].City VALUES ('Midrand',1)
INSERT INTO [dbo].City VALUES ('Roodepoort',1)
INSERT INTO [dbo].City VALUES ('Sandton',1)
INSERT INTO [dbo].City VALUES ('Soweto',1)
INSERT INTO [dbo].City VALUES ('Orange Farm',1)
INSERT INTO [dbo].City VALUES ('Alberton',1)
INSERT INTO [dbo].City VALUES ('Germiston',1)
INSERT INTO [dbo].City VALUES ('Polokwane',9)
INSERT INTO [dbo].City VALUES ('Louis Trichardt',9)
INSERT INTO [dbo].City VALUES ('Tzaneen',9)
INSERT INTO [dbo].City VALUES ('Modimolle',9)
INSERT INTO [dbo].City VALUES ('Potchefstroom',8)
INSERT INTO [dbo].City VALUES ('Mafikeng',8)
INSERT INTO [dbo].City VALUES ('Lichtenburg',8)

create table Suburb (
SuburbID int identity(1,1) primary key,
[Name] varchar (30) not null,
CityID int null,
foreign key (CityID) references City(CityID)
);

INSERT INTO [dbo].Suburb VALUES ('Hatfield',1)
INSERT INTO [dbo].Suburb VALUES ('Brooklyn',1)

create table [Address] (
ID int identity (1,1) primary key,
FirstName varchar (50) not null,
LastName varchar (50) not null,
Street varchar (100) not null,
ZipCode int,
ProvinceID int,
CityID int,
SuburbID int,
foreign key (ProvinceID) references Province(ProvinceID),
foreign key (CityID) references City(CityID),
foreign key (SuburbID) references Suburb(SuburbID)
);

