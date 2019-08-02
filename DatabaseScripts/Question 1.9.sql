create procedure GetEmployeeList
as
select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
order by InOutStatus.Description asc

go

create procedure GetEmployeeStatus @StaffID int
as
select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
where Staff.StaffID = @StaffID

go

create procedure GetEmployeeHistory @StaffID int
as
select Nickname, 
(select InOutStatus.Description from StaffInOutHistory inner join InOutStatus on StaffInOutHistory.InOutStatusIDOld = InOutStatus.InOutStatusID  where StaffInOutHistory.StaffID = @StaffID ) 'Status before change' ,
(select InOutStatus.Description from StaffInOutHistory inner join InOutStatus on StaffInOutHistory.InOutStatusIDNew = InOutStatus.InOutStatusID  where StaffInOutHistory.StaffID = @StaffID ) 'status after change',
StaffInOutHistory.DateChanged,
(Select Staff.Nickname from Staff inner join StaffInOutHistory on  Staff.StaffID = StaffInOutHistory.StaffID where StaffInOutHistory.ChangedByStaffID = @StaffID) 'Status change by' 
from Staff
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.StaffID
where Staff.StaffID = @StaffID
