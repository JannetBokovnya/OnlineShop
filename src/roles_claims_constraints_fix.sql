use [OnlineShop.Users]
Go

Alter table [dbo].[AspNetRoleClaims] ADD Id_new int IDENTITY(1,1)
Go
Alter table [dbo].[AspNetRoleClaims] Drop constraint [Pk_AspNetRoleClaims] With (Online=off)
Go
Alter table [dbo].[AspNetRoleClaims] Drop column Id
Go
Exec sp_rename 'AspNetRoleClaims.Id_new', 'Id', 'Column';
Alter table [dbo].[AspNetRoleClaims] Add Primary key (Id)
Go


Alter table [dbo].[AspNetUserClaims] add Id_new Int Identity(1,1)
Go
Alter table [dbo].[AspNetUserClaims] drop constraint [Pk_AspNetUserClaims] with (online=off)
Go
Alter table [dbo].[AspNetUserClaims] drop column Id
Go
Exec sp_rename 'AspNetUserClaims.Id_new', 'Id', 'Column';
Alter table [dbo].[AspNetUserClaims] add primary key(Id)
Go