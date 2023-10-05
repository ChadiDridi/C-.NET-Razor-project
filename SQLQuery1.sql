create table [dbo].[Employerh](
[IdEmployer] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[NomEmployer] [nvarchar](50) NULL,
[PrenomEmployer] [nvarchar](50) NULL,
[EmailEmployer] [nvarchar](50) NULL,
[PasswordEmployer] [nvarchar](50) NULL,
[PosteEmployer] [nvarchar](50) NULL,
[TelephoneEmployer] [nvarchar](50) NULL,
[Services] [nvarchar](50) NULL
) ON [PRIMARY]

drop table [dbo].[Employerh]
select * from [dbo].[Hardware]


create table [dbo].[Employees](
[IdEmployer] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[NomEmployer] [nvarchar](50) NULL,
[PrenomEmployer] [nvarchar](50) NULL,
[EmailEmployer] [nvarchar](50) NULL,
[PasswordEmployer] [nvarchar](50) NULL,
[PosteEmployer] [nvarchar](50) NULL,
[TelephoneEmployer] [nvarchar](50) NULL,
[Services] [nvarchar](50) NULL
) ON [PRIMARY]



insert into [dbo].[Employees] (NomEmployer, PrenomEmployer, EmailEmployer,PasswordEmployer, PosteEmployer, TelephoneEmployer, Services) values ('Kilani', 'Timoui', 'k@gmail.com','c', 'c', '5', 'c')
insert into [dbo].[Employees] (NomEmployer, PrenomEmployer, EmailEmployer,PasswordEmployer, PosteEmployer, TelephoneEmployer, Services) values ('chadi', 'chadi', 'c@gmail.com','c', 'c', '5', 'c')

--Insertion 
insert into [dbo].[Employerh] (NomEmployer, PrenomEmployer, EmailEmployer,PasswordEmployer, PosteEmployer, TelephoneEmployer, Services) values ('Kilani', 'Timoui', 'k@gmail.com','c', 'c', '5', 'c')
insert into [dbo].[Employerh] (NomEmployer, PrenomEmployer, EmailEmployer,PasswordEmployer, PosteEmployer, TelephoneEmployer, Services) values ('chadi', 'chadi', 'c@gmail.com','c', 'c', '5', 'c')


--table affectation 
create table [dbo].[Affectation](
[IdAffectation] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[IdEmployer] [int] NULL, --must exist in table Employerh
[IdProjet] [int] NULL,
[DateDebut] [date] NULL,
[DateFin] [date] NULL,
[Etat] [nvarchar](50) NULL
) ON [PRIMARY]

--table MIssion

create table [dbo].[Mission](
[IdMission] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[DateReturnMission] [nvarchar](50)	,
[DescriptionMission] [nvarchar](50)	,
[EmplacementMission] [nvarchar](50)	,
[MvMission] [nvarchar](50)	,
[InsMission] [nvarchar](50)	,
[IdEmployer] [int] NULL,
[IdHardware] [int] NULL,
foreign key (IdEmployer) references Employees([IdEmployer]),
foreign key (IdHardware) references Hardware([IdHardware])
) ON [PRIMARY]




--table Hardware
create table [dbo].[Hardware](
[IdHardware] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[SnHardware] [nvarchar](50) NULL,
[DateHardware] [nvarchar](50) NULL,
[DatecreateHardware] [nvarchar](50) NULL,
[TypeHardware] [nvarchar](50) NULL,
[MarqueHardware] [nvarchar](50) NULL,
[EtatHardware] [nvarchar](50) NULL,
[ModelHardware] [nvarchar](50) NULL,
[AvailableHardware] int NULL,
[GrantieHardware] [nvarchar](50) NULL,
[ConsommableHardware] [nvarchar](50) NULL,
[LoginHardware] [nvarchar](50) NULL,
[IdOrder] int NULL,
foreign key (IdOrder) references [Order](IdOrder)
) ON [PRIMARY]


--table Order

create table [dbo].[Order](
[IdOrder] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[DesignationOrder] [nvarchar](50) NULL,
[ReferenceOrder] [nvarchar](50) NULL,
[QuantiteOrder] int NULL,
[QtsOrder] int NULL,
[SnOrder] [nvarchar](50) NULL,
[InsOrder] [nvarchar](50) NULL,
[IdProvider] int NULL,
foreign key (IdProvider) references Provider(IdProvider)
) ON [PRIMARY]

--table Provider

create table [dbo].[Provider](
[IdProvider] [int] IDENTITY(1,1) NOT NULL,
[RaisonSocialProvider] [nvarchar](50) NULL,
[NameProvider] [nvarchar](50) NULL,
[MailProvider] [nvarchar](50) NULL,
[TelephoneProvider] [nvarchar](50) NULL,
[PaysProvider] [nvarchar](50) NULL,
[PrincipalProvider] [nvarchar](50) NULL,
[AdresseProvider] [nvarchar](50) NULL,
[ActifProvider] [nvarchar](50) NULL,
[PhoneProvider] [nvarchar](50) NULL,
[Phone2Provider] [nvarchar](50) NULL
PRIMARY KEY ([IdProvider])) ON [PRIMARY]

drop table [dbo].[Provider]


create table [dbo].[providers](
[IdProvider] [int] IDENTITY(1,1) NOT NULL,
[RaisonSocialProvider] [nvarchar](50) NULL,
[NameProvider] [nvarchar](50) NULL,
[MailProvider] [nvarchar](50) NULL,
[TelephoneProvider] [nvarchar](50) NULL,
[PaysProvider] [nvarchar](50) NULL,
[PrincipalProvider] [nvarchar](50) NULL,
[AdresseProvider] [nvarchar](50) NULL,
[ActifProvider] [nvarchar](50) NULL,
[PhoneProvider] [nvarchar](50) NULL,
[Phone2Provider] [nvarchar](50) NULL
PRIMARY KEY ([IdProvider])) ON [PRIMARY]

insert into providers values ('c', 'c', 'c@c', '5', 'c', 'c', 'c', 'c', 'c', 'c')
insert into providers values ('d', 'c', 'c@c', '5', 'c', 'c', 'c', 'c', 'c', 'c')

-- insert values to tables 

insert into [dbo].[Provider] (RaisonSocialProvider, NameProvider, MailProvider, TelephoneProvider, PaysProvider, PrincipalProvider, AdresseProvider, ActifProvider, PhoneProvider, Phone2Provider) values ('c', 'c', 'c@c', '5', 'c', 'c', 'c', 'c', 'c', 'c')
insert into [dbo].[Provider] (RaisonSocialProvider, NameProvider, MailProvider, TelephoneProvider, PaysProvider, PrincipalProvider, AdresseProvider, ActifProvider, PhoneProvider, Phone2Provider) values ('d', 'c', 'c@c', '5', 'c', 'c', 'c', 'c', 'c', 'c')


insert into [dbo].[Order] (DesignationOrder, ReferenceOrder, QuantiteOrder, QtsOrder, SnOrder, InsOrder, IdProvider) values ('c', 'c', 5, '5', 'c', 'c', '1')
insert into [dbo].[Order] (DesignationOrder, ReferenceOrder, QuantiteOrder, QtsOrder, SnOrder, InsOrder, IdProvider) values ('c', 'c', 5, '5', 'c', 'c', '1')



insert into [dbo].[Hardware] (SnHardware, DateHardware, DatecreateHardware, TypeHardware, MarqueHardware, EtatHardware, ModelHardware, AvailableHardware, GrantieHardware, ConsommableHardware, LoginHardware, IdOrder) values ('c', 'c', 'c', 'c', 'c', 'c', 'c', '5', 'c', 'c', 'c', '1')
insert into [dbo].[Hardware] (SnHardware, DateHardware, DatecreateHardware, TypeHardware, MarqueHardware, EtatHardware, ModelHardware, AvailableHardware, GrantieHardware, ConsommableHardware, LoginHardware, IdOrder) values ('c', 'c', 'c', 'c', 'c', 'c', 'c', '5', 'c', 'c', 'c', '1')


insert into [dbo].[Mission] (DateReturnMission, DescriptionMission, EmplacementMission, MvMission, InsMission, IdEmployer, IdHardware) values ('10/10/2023', 'c', 'c', 'c', 'c', '2', '1')
insert into [dbo].[Mission] (DateReturnMission, DescriptionMission, EmplacementMission, MvMission, InsMission, IdEmployer, IdHardware) values ('10/11/2020', 'c', 'c', 'c', 'c', '2', '1')


insert into [dbo].[Affectation] (IdEmployer, IdProjet, DateDebut, DateFin, Etat) values ('1', '1', '11/11/2020', '12/11/2020', 'c')
insert into [dbo].[Affectation] (IdEmployer, IdProjet, DateDebut, DateFin, Etat) values ('1', '1', '11/11/2020', '12/11/2020', 'c')



insert into [dbo].[Hardware] (SnHardware, DateHardware, DatecreateHardware, TypeHardware, MarqueHardware, EtatHardware, ModelHardware, AvailableHardware, GrantieHardware, ConsommableHardware, LoginHardware, IdOrder) values ('c', 'c', 'c', 'c', 'c', 'c', 'c', '5', 'c', 'c', 'c', '1')
insert into [dbo].[Hardware] (SnHardware, DateHardware, DatecreateHardware, TypeHardware, MarqueHardware, EtatHardware, ModelHardware, AvailableHardware, GrantieHardware, ConsommableHardware, LoginHardware, IdOrder) values ('c', 'c', 'c', 'c', 'c', 'c', 'c', '5', 'c', 'c', 'c', '1')
