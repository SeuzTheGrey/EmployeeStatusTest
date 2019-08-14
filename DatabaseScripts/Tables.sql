create table InOutStatus(
InOutStatusID int not null primary key,
Description nvarchar(255) not null
)

create table Staff(

StaffID int not null primary key identity,
Lastname nvarchar(80) not null,
Firstname nvarchar(80) not null,
Nickname nvarchar(80) not null,
Username nvarchar(255) not null,
InOutStatusID int not null foreign key references InOutStatus(InOutStatusID),
TelephoneExtension nvarchar(50) not null,
FlagDeleted bit not null,
ManagerID int null foreign key references Staff(StaffID)
)

create table StaffInOutHistory(
StaffInOutHistoryID int  not null primary key identity,
StaffID int not null foreign key references Staff(StaffID),
InOutStatusIDOld int not null foreign key references InOutStatus(InOutStatusID),
InOutStatusIDNew int not null foreign key references InOutStatus(InOutStatusID),
DateChanged datetime not null,
ChangedByStaffID int not null foreign key references Staff(StaffID)
)