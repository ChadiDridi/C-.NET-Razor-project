alter PROC [dbo].[GetAllEmployees]
as 
BEGIN
 select * from Employees
end


--drop table Employerh
drop table Employerh

alter proc [dbo].[GetAllMissions]
as
begin
select * from Missions
end


alter proc [dbo].[GetAllMission]
as
begin
select * from Missions
end


alter proc [dbo].[DeleteMission]
@id int
as
begin
delete from Missions where IdMission=@id
end


select * from Employerh
insert into [dbo].[Mission] values(1,'Mission1','2019-01-01','2019-01-02','2019-01-01',1,6)
insert into [dbo].[Mission] values(2,'Mission2','2019-01-01','2019-01-02','2019-01-01',1,6)


alter proc [dbo].[GetAllProviders] as 
begin
select * from providers
end


create proc GetAllHardwares
as
begin
select * from Hardware
end