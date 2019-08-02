use StaffStatus

select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
where InOutStatus.Description = 'In'
order by InOutStatus.Description asc


select * from Staff
order by FirstName asc

