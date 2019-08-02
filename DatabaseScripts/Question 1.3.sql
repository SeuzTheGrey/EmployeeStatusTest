create procedure Question1point3 @StaffID int
as
select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
where Staff.StaffID = @StaffID


exec Question1point3 1