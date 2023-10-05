CREATE TABLE [dbo].[Employerh] (
    [IdEmployer]        INT           IDENTITY (1, 1) NOT NULL,
    [NomEmployer]       NVARCHAR (20) NULL,
    [PrenomEmployer]    NVARCHAR (20) NULL,
    [EmailEmployer]    NVARCHAR (20) NULL,
    [PosteEmployer]     NVARCHAR (20) NULL,
    [TelephoneEmployer] NVARCHAR (20) NULL,
    [Services]          NVARCHAR (20) NULL
);


alter proc [dbo].[AddEmployer]
@NomEmployer nvarchar(20),
@PrenomEmployer nvarchar(20),
@EmailEmployer nvarchar(20),
@PosteEmployer nvarchar(20),
@TelephoneEmployer nvarchar(20),
@Services nvarchar(20)
as
begin
insert into Employerh(NomEmployer,PrenomEmployer,EmailEmployer,PosteEmployer,TelephoneEmployer,Services) values(@NomEmployer,@PrenomEmployer,@EmailEmployer,@PosteEmployer,@TelephoneEmployer,@Services)
end

insert into [dbo].[Missions] ( IdEmployer,IdHardware,DescriptionMission,InsMission, DateReturnMission,EmplacementMission,MvMission) values (1,6,'Description1','Ins1,2019-01-01','2019-01-01','Emplacement1','Mv1')
insert into [dbo].[Missions] ( IdEmployer,IdHardware,DescriptionMission,InsMission, DateReturnMission,EmplacementMission,MvMission) values (1,7,'Description1','Ins1','2019-01-01','Emplacement1','Mv1')