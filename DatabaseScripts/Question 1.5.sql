select YEAR(DateChanged)'year',MONTH(DateChanged) 'month',Count(StaffInOutHistoryID) 'amount'
from StaffInOutHistory
group by DateChanged