create procedure getEmployeeDetails @staffID int
as
select * from Staff
where StaffID = @staffID

go

create procedure UpdateEmployeeDetails @staffID int ,@Lastname varchar ,@firstname varchar ,@nickname varchar, @telephoneExtension varchar, @flagDeleted bit
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

create procedure insertEmployee @staffid int, @lastname varchar,@firstname varchar ,@nickname varchar,@username varchar, @inoutstatusID int, @extension varchar,@flagDeleted bit, @managerid int
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