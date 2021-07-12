/*
Это пример создания таблиц с первичными и внешними ключами, с ограничениями (constraints) для примера из презентации
*/


--Отношение Departs (отделы):

create table IF NOT exists departs (
d_id varchar(12) primary key,
d_name varchar(100) not null);

--Отношение Rooms (комнаты):

create table IF NOT exists rooms (
d_depart varchar(12) references departs(d_id),
r_room numeric(4) not null,
r_phone varchar(20),
primary key(r_room, r_phone));


--Отношение Posts (должности):

create table IF NOT exists posts (
p_post varchar(30) primary key,
p_salary numeric(8,2) not null check (p_salary >= 4500));

--Отношение Employees (сотрудники):

create table IF NOT exists employees (
e_id numeric(4) primary key,
e_fname varchar(25) not null,
e_lname varchar(30) not null,
e_born date not null,
e_gender char(1) check (e_gender in ('ж','м')),
e_date date not null,
e_depart varchar(12) references departs,
e_post varchar(30) references posts,
e_room numeric(4) not null,
e_phone varchar(20) not null,
foreign key(e_room,e_phone) references rooms (r_room, r_phone));

--Отношение Projects (проекты):

create table IF NOT exists projects (
p_id numeric(6) not null unique,
p_name varchar(100) not null,
p_short_name char(10) primary key,
p_depart varchar(12) references departs,
p_boss numeric(4) references employees,
p_begin date not null,
p_end date not null,
p_finish date,
p_cost numeric(10) not null check(p_cost>0),
check (p_end>p_begin), check (p_finish is null or p_finish>p_begin));


--Отношение Job (участие):

create table IF NOT exists job (
j_pro char(10) references projects,
j_emp numeric(2) references employees,
j_role varchar(20) not null,
j_bonus numeric(2) not null,
check(j_bonus>0), check (j_role in ('исполнитель', 'консультант')));