use StaffStatus

select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
order by InOutStatus.Description asc
