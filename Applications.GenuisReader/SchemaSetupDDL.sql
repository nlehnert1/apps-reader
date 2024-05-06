-- Comment out the below to have the table availabe for the Test endpoint in the WeatherForecast controller. You will still have to seed data yourself
--create table TestTable (
--TestId int IDENTITY(1,1) PRIMARY KEY,
--Contents NVARCHAR(100),
--);

-- Clear out existing schema
drop table if exists AuthorWorks;
drop table if exists SeriesTag;
drop table if exists ChapterTag;
drop table if exists SeriesChapter;
drop table if exists Series;
drop table if exists Author;
drop table if exists Chapter;
drop table if exists Tag;

-- Re-create schema
Create table Author(
	AuthorId int identity(1,1) primary key,
	FirstName nvarchar(100),
	LastName nvarchar(100) not null
);

create table Series (
	SeriesId int IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(1024) not null,
	StartDate Date not null,
	EndDate Date
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

create table Chapter (
	ChapterId int identity(1,1) primary key,
	ChapterTitle nvarchar(500)
);

create table SeriesChapter (
	SeriesId int not null,
	ChapterId int not null,
	ChapterOrder smallint not null,
	constraint series_chapter_pk primary key (SeriesId,ChapterId),
	constraint FK_SeriesChapter_Series
		Foreign key (SeriesId) references Series(SeriesId),
	constraint FK_SeriesChapter_Chapter
		foreign key (ChapterId) references Chapter(ChapterId)
);

create table Tag (
	TagId int identity(1,1) primary key,
	Label nvarchar(50) not null,
	Description nvarchar(1000)
);

create table SeriesTag (
	SeriesId int not null,
	TagId int not null,
	constraint series_tag_pk primary key (SeriesId, TagId),
	constraint FK_SeriesTag_Series
		foreign key (SeriesId) references Series(SeriesId),
	constraint FK_SeriesTag_Tag
		foreign key (TagId) references Tag(TagId)
);

create table ChapterTag (
	ChapterId int not null,
	TagId int not null,
	constraint chapter_tag_pk primary key (ChapterId, TagId),
	constraint FK_ChapterTag_Chapter
		foreign key (ChapterId) references Chapter(ChapterId),
	constraint FK_ChapterTag_Tag
		foreign key (TagId) references Tag(TagId)
);
