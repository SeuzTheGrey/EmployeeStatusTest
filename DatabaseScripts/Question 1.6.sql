create procedure Question1point6 @StaffID int
as
select Nickname, 
(select InOutStatus.Description from StaffInOutHistory inner join InOutStatus on StaffInOutHistory.InOutStatusIDOld = InOutStatus.InOutStatusID  where StaffInOutHistory.StaffID = @StaffID ) 'Status before change' ,
(select InOutStatus.Description from StaffInOutHistory inner join InOutStatus on StaffInOutHistory.InOutStatusIDNew = InOutStatus.InOutStatusID  where StaffInOutHistory.StaffID = @StaffID ) 'status after change',
StaffInOutHistory.DateChanged,
(Select Staff.Nickname from Staff inner join StaffInOutHistory on  Staff.StaffID = StaffInOutHistory.StaffID where StaffInOutHistory.ChangedByStaffID = @StaffID) 'Status change by' 
from Staff
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.StaffID
where Staff.StaffID = @StaffID


exec Question1point6 1