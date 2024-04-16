-- Populate authors
Insert into Author(FirstName, LastName) values
('Nio', 'Nakatani'),
('Kon', 'Fukaumi'),
('Hitoma', 'Iruma');
Insert into Author(LastName) values
('Kashikaze'), ('Hijiki');

-- Populate series
Insert into Series (Name) values
('Bloom Into You'),
('Bluer than Love'),
('Contract Sisters'),
('Our Yuri Started With Me Getting Rejected In A Dream'),
('Riko & Haru & Irukawa Hot Springs'),
('Can''t Defy The Lonely Girl'),
('Adachi and Shimamura');

-- Populate Author<-->Series join table
Insert into AuthorWorks (SeriesId, AuthorId) values
(1,1),
(2,2),
(7,3),
(3,5),
(4,5),
(5,5),
(6,4)