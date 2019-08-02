select Nickname, 
(select InOutStatus.Description from StaffInOutHistory inner join InOutStatus on StaffInOutHistory.InOutStatusIDOld = InOutStatus.InOutStatusID) 'Status before change' , 
(select InOutStatus.Description from StaffInOutHistory inner join InOutStatus on StaffInOutHistory.InOutStatusIDNew = InOutStatus.InOutStatusID) 'status after change',
StaffInOutHistory.DateChanged,(Select Staff.Nickname from Staff inner join StaffInOutHistory on  Staff.StaffID = StaffInOutHistory.StaffID )
'Status change by' from Staff 
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.StaffID
where DATEPART(hour, StaffInOutHistory.DateChanged) <= '20'