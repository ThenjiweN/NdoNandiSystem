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

create table ProductType (
TypeID int identity (1,1) primary key,
[Name] varchar (50) not null
);

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

create table InventoryItem (
ID int identity (1,1) primary key,
[Name] varchar (50) not null,
[Description] varchar (100),
Quantity int,
TypeID int,
foreign key (TypeID) references InventoryItemType(TypeID)
);


create table BlogEntry (
ID int identity (1,1) primary key,
Title varchar (50) not null,
Content varchar (255) not null,
[Date] datetime not null
);

create table Package (
ID int identity (1,1) primary key,
[Name] varchar (50) not null,
[Description] varchar (255) not null,
Duration varchar (50) not null,
Price decimal not null
);

create table ReturnReason (
ID int identity (1,1) primary key,
[Name] varchar (50)
);

create table Province (
ProvinceID int identity (1,1) primary key,
[Name] varchar (50)
);



create table City (
CityID int identity (1,1) primary key,
[Name] varchar (50)
);


create table Subhurb (
SubhurbID int identity (1,1) primary key
);

create table [Address] (
ID int identity (1,1) primary key,
FirstName varchar (50) not null,
LastName varchar (50) not null,
Street varchar (100) not null,
ZipCode int,
ProvinceID int,
CityID int,
SubhurbID int,
foreign key (ProvinceID) references Province(ProvinceID),
foreign key (CityID) references City(CityID),
foreign key (SubhurbID) references Subhurb(SubhurbID)
);

