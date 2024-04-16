-- Populate authors
Insert into Author(FirstName, LastName) values
('Nio', 'Nakatani'),
('Kon', 'Fukaumi'),
('Hitoma', 'Iruma');
Insert into Author(LastName) values
('Kashikaze'), ('Hijiki');

-- Populate series
Insert into Series (Name, IsOngoing, StartDate, EndDate) values
('Bloom Into You', 0, '2015-04-27', '2019-09-27'),
('Riko & Haru & Irukawa Hot Springs', 0, '2013-04-17', '2018-01-13'),
('Can''t Defy The Lonely Girl', 0, '2019-12-04', '2023-01-18');
Insert into Series(Name, IsOngoing, StartDate) values
('A Love Yet To Bloom', 1, '2022-09-23'),
('Contract Sisters', 1, '2022-04-17'),
('Our Yuri Started With Me Getting Rejected In A Dream', 1, '2022-04-24'),
('Adachi and Shimamura (Light Novel)', 1, '2019-04-17');

-- Populate Author<-->Series join table
Insert into AuthorWorks (SeriesId, AuthorId) values
(1,1),
(2,5),
(3,4),
(4,2),
(5,5),
(6,5),
(7,3)