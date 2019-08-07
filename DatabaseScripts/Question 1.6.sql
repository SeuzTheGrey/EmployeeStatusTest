create procedure Question1point6 @StaffID int
as
select Nickname, 
s1.Description 'Status before change' ,
s2.Description 'status after change',
StaffInOutHistory.DateChanged,
StaffInOutHistory.ChangedByStaffID 'Status change by' 
from Staff
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.StaffID
inner join InOutStatus s1 on StaffInOutHistory.InOutStatusIDOld = s1.InOutStatusID
inner join InOutStatus s2 on StaffInOutHistory.InOutStatusIDNew = s2.InOutStatusID
where Staff.StaffID = @StaffID



exec Question1point6 1