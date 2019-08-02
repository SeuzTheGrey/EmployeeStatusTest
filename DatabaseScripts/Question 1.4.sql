select Staff.StaffID, FirstName, LastName, COUNT(StaffInOutHistory.StaffInOutHistoryID) 'Number Of Status changes' from staff
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.ChangedByStaffID
group by Staff.StaffID,FirstName, LastName