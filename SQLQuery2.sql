--Read all employees from DB 
alter PROC [dbo].[GetAllEmployees]
as 
BEGIN
 select * from Employees
 end
 select * from [Order]

 --Get employee by id

alter PROC [dbo].[GetEmployeeById] (@IdEmployer int)
as 
BEGIN
 select * from Employees where IdEmployer = @IdEmployer
 end

 --Insert new employee

alter PROC [dbo].[InsertEmployee] (@NomEmployer nvarchar(50), @PrenomEmployer nvarchar(50), @EmailEmployer nvarchar(50),@PasswordEmployer nvarchar(50), @PosteEmployer nvarchar(50), @TelephoneEmployer nvarchar(50), @Services nvarchar(50))
as
BEGIN
 insert into Employees (NomEmployer, PrenomEmployer, EmailEmployer,PasswordEmployer, PosteEmployer, TelephoneEmployer, Services) values (@NomEmployer, @PrenomEmployer, @EmailEmployer,@PasswordEmployer, @PosteEmployer, @TelephoneEmployer, @Services)
 end

 --Update employee
 alter proc UpdateEmployee (@NomEmployer nvarchar(50), @PrenomEmployer nvarchar(50), @EmailEmployer nvarchar(50),@PasswordEmployer nvarchar(50), @PosteEmployer nvarchar(50), @TelephoneEmployer nvarchar(50), @Services nvarchar(50))
 as 
begin
update Employees set NomEmployer = @NomEmployer, PrenomEmployer = @PrenomEmployer, EmailEmployer = @EmailEmployer,PasswordEmployer = @PasswordEmployer, PosteEmployer = @PosteEmployer, TelephoneEmployer = @TelephoneEmployer, Services = @Services
where EmailEmployer = @EmailEmployer 
end

 --Delete employee
 alter PROC [dbo].[DeleteEmployee] (@IdEmployer int)
end


--Update Provider 
alter proc UpdateFournisseur (@NameProvider nvarchar(50), @RaisonSocialProvider nvarchar(50), @AdresseProvider nvarchar(50),@PaysProvider nvarchar(50), @MailProvider nvarchar(50), @PrincipalProvider nvarchar(50), @ActifProvider nvarchar(50),@PhoneProvider nvarchar(50),@Phone2Provider nvarchar(50))
as
begin
update providers set NameProvider = @NameProvider, RaisonSocialProvider = @RaisonSocialProvider, AdresseProvider = @AdresseProvider, PaysProvider = @PaysProvider, MailProvider = @MailProvider,PrincipalProvider = @PrincipalProvider,ActifProvider = @ActifProvider,PhoneProvider = @PhoneProvider,Phone2Provider = @Phone2Provider
end

--get provider by ID 
create proc GetProviderById (@IdProvider int)
as
begin
select * from providers where IdProvider = @IdProvider
end

 --Delete employee
 alter PROC [dbo].[DeleteEmployee] (@IdEmployer int)
as
BEGIN
 delete from Employees where IdEmployer = @IdEmployer
 end

 alter proc [dbo].[DeleteMission] (@IdMission int)
as
begin
delete from Missions where IdMission = @IdMission
end


 alter TABLE [dbo].[Missions] (
    [IdMission]          INT           IDENTITY (1, 1) NOT NULL,
    [DateReturnMission]  NVARCHAR (50) NULL,
    [DescriptionMission] NVARCHAR (50) NULL,
    [EmplacementMission] NVARCHAR (50) NULL,
    [MvMission]          NVARCHAR (50) NULL,
    [InsMission]         NVARCHAR (50) NULL,
    [IdEmployer]         INT           NULL,
    [IdHardware]         INT           NULL,
    PRIMARY KEY CLUSTERED ([IdMission] ASC),
    FOREIGN KEY ([IdEmployer]) REFERENCES [dbo].[Employees]([IdEmployer]),
    FOREIGN KEY ([IdHardware]) REFERENCES [dbo].[Hardware]([IdHardware])
);
drop table Missions

insert into Missions (DateReturnMission, DescriptionMission, EmplacementMission, MvMission, InsMission, IdEmployer, IdHardware) values ('2020-12-12', 'Mission 1', 'Tunis', 'Mv1', 'Ins1', 1,7)
insert 	into Missions (DateReturnMission, DescriptionMission, EmplacementMission, MvMission, InsMission, IdEmployer, IdHardware) values ('2020-12-12', 'Mission 2', 'Tunis', 'Mv2', 'Ins2', 1, 7)                   
insert into    Missions (DateReturnMission, DescriptionMission, EmplacementMission, MvMission, InsMission, IdEmployer, IdHardware) values ('2020-12-12', 'Mission 3', 'Tunis', 'Mv3', 'Ins3', 1, 6)



--procedure to AddEmployer

create proc AddEmployer(@NomEmployer nvarchar(50), @PrenomEmployer nvarchar(50), @EmailEmployer nvarchar(50),@PasswordEmployer nvarchar(50), @PosteEmployer nvarchar(50), @TelephoneEmployer nvarchar(50), @Services nvarchar(50))
as
begin
insert into Employerh (NomEmployer, PrenomEmployer, EmailEmployer,PasswordEmployer, PosteEmployer, TelephoneEmployer, Services) 
values (@NomEmployer, @PrenomEmployer, @EmailEmployer,@PasswordEmployer, @PosteEmployer, @TelephoneEmployer, @Services)
end




create proc AddProvider(@NameProvider nvarchar(50), @RaisonSocialProvider nvarchar(50), @AdresseProvider nvarchar(50),@PaysProvider nvarchar(50), @MailProvider nvarchar(50), @PrincipalProvider nvarchar(50), @ActifProvider nvarchar(50),@PhoneProvider nvarchar(50),@Phone2Provider nvarchar(50))
as
begin
insert into Provider (NameProvider, RaisonSocialProvider, AdresseProvider, PaysProvider, MailProvider,PrincipalProvider,ActifProvider,PhoneProvider,Phone2Provider)
values (@NameProvider, @RaisonSocialProvider, @AdresseProvider, @PaysProvider, @MailProvider,@PrincipalProvider,@ActifProvider,@PhoneProvider,@Phone2Provider)
end




create proc AddMission(@DateReturnMission nvarchar(50), @DescriptionMission nvarchar(50), @EmplacementMission nvarchar(50),@MvMission nvarchar(50), @InsMission nvarchar(50), @IdEmployer int, @IdHardware int)
as
begin
insert into Missions (DateReturnMission, DescriptionMission, EmplacementMission, MvMission, InsMission, IdEmployer, IdHardware)
values (@DateReturnMission, @DescriptionMission, @EmplacementMission, @MvMission, @InsMission, @IdEmployer, @IdHardware)
end




alter proc DeleteProvider(@IdProvider int)
as
begin
delete from providers where IdProvider = @IdProvider
end


create proc [dbo].[GetAllProviders]  as 
begin
select * from providers
end


create proc DeleteHardware (@IdHardware int)
as
begin
delete from Hardware where IdHardware = @IdHardware
end



create proc AddHardware(@SnHardware nvarchar(50), @DateHardware nvarchar(50),@DateCreateHardware nvarchar(20), 
@TypeHardware nvarchar(50),@EtatHardware nvarchar(50),@ModelHardware nvarchar(50), 
@AvailableHardware nvarchar(50), @GrantieHardware nvarchar(50), @ConsommableHardware nvarchar(50),
@LoginHardware nvarchar(50),@IdOrder int)
as 
begin 
insert into Hardware (SnHardware, DateHardware,DateCreateHardware, TypeHardware, EtatHardware,ModelHardware, AvailableHardware,
GrantieHardware, IdOrder)
values (@SnHardware, @DateHardware, @DateCreateHardware,@TypeHardware, @AvailableHardware, @GrantieHardware, @ConsommableHardware,@LoginHardware,@IdOrder)
end

ALTER PROCEDURE [dbo].[UpdateEmployee] 
    @IdEmployer INT,
    @NomEmployer NVARCHAR(50),
    @PrenomEmployer NVARCHAR(50),
    @EmailEmployer NVARCHAR(50),
    @PasswordEmployer NVARCHAR(50),
    @PosteEmployer NVARCHAR(50),
    @TelephoneEmployer NVARCHAR(50),
    @Services NVARCHAR(50)
AS
BEGIN
    UPDATE Employees
    SET 
        NomEmployer = @NomEmployer,
        PrenomEmployer = @PrenomEmployer,
        EmailEmployer = @EmailEmployer,
        PasswordEmployer = @PasswordEmployer,
        PosteEmployer = @PosteEmployer,
        TelephoneEmployer = @TelephoneEmployer,
        Services = @Services
    WHERE IdEmployer = @IdEmployer;
END;



create proc [dbo].[GetAllOrders] as 
begin
select * from BonAchats
end


create proc [dbo].[DeleteOrder] (@IdOrder int)
as
begin
delete from BonAchats where IdOrder = @IdOrder
end


drop table BonAchats


create table BonAchats (
	IdOrder int identity(1,1) primary key,
	DesignationOrder nvarchar(50),
	ReferenceOrder nvarchar(50),
	QuantiteOrder int ,
	QtsOrder int,
	SnOrder nvarchar(50),
	InsOrder nvarchar(50),
	IdProvider int,
	FOREIGN KEY (IdProvider) REFERENCES providers(IdProvider),
	)


 create proc GetAllDisponibles as
begin
select * from Hardware where AvailableHardware !=0 
end



create proc DeleteDisponible(@IdHardware int)
as
begin
 update Hardware set AvailableHardware = 0 where IdHardware = @IdHardware
end
