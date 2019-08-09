create procedure getEmployeeDetails @staffID int
as
select * from Staff
where StaffID = @staffID

go

create procedure UpdateEmployeeDetails @staffID int ,@Lastname varchar(80) ,@firstname varchar(80) ,@nickname varchar(80), @telephoneExtension varchar(80), @flagDeleted bit
as
update Staff
set Lastname = @Lastname, Firstname = @firstname, Nickname = @nickname, TelephoneExtension = @telephoneExtension, FlagDeleted = @flagDeleted
where StaffID = @staffID

go

create procedure DeleteEmployee @staffID int
as
delete Staff
where StaffID = @staffID

go 

create procedure insertEmployee @staffid int, @lastname varchar(80),@firstname varchar(80) ,@nickname varchar(80),@username varchar(80), @inoutstatusID int, @extension varchar(80),@flagDeleted bit, @managerid int
as
INSERT INTO Staff
           ([StaffID]
           ,[Lastname]
           ,[Firstname]
           ,[Nickname]
           ,[Username]
           ,[InOutStatusID]
           ,[TelephoneExtension]
           ,[FlagDeleted]
           ,[ManagerID])
     VALUES
           (@staffid
           ,@lastname
           ,@firstname
           ,@nickname
           ,@username
           ,@inoutstatusID
           ,@extension
           ,@flagDeleted
           ,@managerid)