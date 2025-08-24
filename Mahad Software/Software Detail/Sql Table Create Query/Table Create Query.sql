create database MA_Solution
use  ma_solution

create  table pay_emp_info
(
ID int primary key identity (1,1),
code varchar(10),
_name varchar(25),
f_name varchar(25),
email varchar(50),
dob datetime,
cnic varchar(15),
gander Nvarchar(15),
doj datetime ,
address varchar(max),
phone varchar(13),
Depart_ID int ,
foreign key (Depart_ID) references pay_emp_department(ID) ,
Desig_ID int ,
foreign key (Desig_ID) references pay_emp_designation(ID) ,
Country_ID int ,
foreign key (Country_ID) references _Country(ID) ,
City_ID int ,
foreign key (City_ID) references _Country(ID) ,
Emp_Type_ID int ,
foreign key (Emp_Type_ID) references _Country(ID) ,
Shift_ID int ,
foreign key (Shift_ID) references pay_emp_shift(ID) ,
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)
create table pay_emp_department
(
ID int primary key identity(1,1),
Depat_code varchar(10),
Depart_Desc varchar(50),
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)

insert into pay_emp_department(Depat_code , Depart_Desc) values ('0001' , 'Nothing')
insert into pay_emp_designation(Desig_code , Desig_desc) values ('0001' , 'Nothing')
insert into pay_emp_type(type_code , type_desc) values ('0001' , 'Permanent')
insert into pay_emp_type(type_code , type_desc) values ('0002' , 'Non Permanent')
insert into _Country(Country_code , Country_desc) values ('0001' , 'Pakistan')
insert into _City(City_code , City_desc) values ('0001' , 'Karachi')
insert into pay_emp_shift(Shift_code , Shift_desc) values ('0001' , 'morning Shift (09am to 9pm)')

truncate table pay_emp_type

create table pay_emp_designation
(
ID int primary key identity (1,1),
Desig_code varchar(10),
Desig_desc varchar(50),
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)


create table _Country
(
ID int primary key identity (1,1),
Country_code varchar(10),
Country_desc varchar(50),
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)


create table _City
(
ID int primary key identity (1,1),
City_code varchar(10),
City_desc varchar(50),
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)


create table pay_emp_type
(
ID int primary key identity (1,1),
type_code varchar(10),
type_desc varchar(50),
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)






create table pay_emp_shift
(
ID int primary key identity (1,1),
Shift_code varchar(10),
Shift_desc varchar(50),
CrBy varchar(45),
CrWhen datetime,
MoBy varchar(45),
MoWhen datetime
)
