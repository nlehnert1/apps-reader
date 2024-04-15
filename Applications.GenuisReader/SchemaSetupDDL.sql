-- Comment out the below to have the table availabe for the Test endpoint in the WeatherForecast controller. You will still have to seed data yourself
--create table TestTable (
--TestId int IDENTITY(1,1) PRIMARY KEY,
--Contents NVARCHAR(100),
--);

-- Clear out existing schema
drop table AuthorWorks;
drop table Series;
drop table Author;

-- Re-create schema
Create table Author(
	AuthorId int identity(1,1) primary key,
	FirstName nvarchar(100),
	LastName nvarchar(100) not null
);

create table Series (
	SeriesId int IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(1024) not null
);

create table AuthorWorks (
	SeriesId int not null,
	AuthorId int not null,
	constraint author_work_pk primary key (SeriesId, AuthorId),
	constraint FK_Author
		Foreign key (AuthorId) References Author(AuthorId),
	constraint FK_Series
		Foreign Key (SeriesId) References Series(SeriesId)
);
