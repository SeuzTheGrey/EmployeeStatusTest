create procedure UpdateEmployeeStatus @staffId int, @changedby int, @description varchar(255)
as
begin
declare @StatusID int
update InOutStatus
set Description = @description, @StatusID = InOutStatusID
update StaffInOutHistory
set InOutStatusIDOld = InOutStatusIDNew, InOutStatusIDNew = @StatusID , StaffID = @staffId, DateChanged = GETDATE(),ChangedByStaffID = @staffId
where StaffID = @staffId
end