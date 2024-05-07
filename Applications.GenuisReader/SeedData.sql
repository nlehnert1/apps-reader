-- Populate authors
Insert into Author(FirstName, LastName) values
('Nio', 'Nakatani'),
('Kon', 'Fukaumi'),
('Hitoma', 'Iruma'),
(null, 'Kashikaze'),
(null, 'Hijiki');

-- Populate series
Insert into Series (Name, StartDate, EndDate) values
('Bloom Into You', '2015-04-27', '2019-09-27'),
('Riko & Haru & Irukawa Hot Springs', '2013-04-17', '2018-01-13'),
('Can''t Defy The Lonely Girl', '2019-12-04', '2023-01-18'),
('A Love Yet To Bloom', '2022-09-23', null),
('Contract Sisters', '2022-04-17', null),
('Our Yuri Started With Me Getting Rejected In A Dream', '2022-04-24', null),
('Adachi and Shimamura (Light Novel)', '2019-04-17', null);

Insert into Chapter(ChapterTitle) values 
('Chapter 1: I Can''t Reach the Stars'),				-- 1
('Chapter 2: Fever'),
('Chapter 3: First Love Application'),
('Chapter 4: Still Within the Atmosphere'),
('Chapter 5: The Girl Who Loves Me'),					-- 5
('Volume 1 Extras'),
('Chapter 6: A Kiss is Just a Kiss'),
('Chapter 7: No Actor'),
('Chapter 8: Multiple Choice'),
('Chapter 9: Multiple Choice Questions, Part Two'),		-- 10
('Interlude: Before Daybreak'),
('Chapter 10: Imprisoned by a Word'),
('Volume 2 Extras'),
('Chapter 1: Riko and Haru and Open Air Bath'),
('Chapter 2: Opening Ceremony and Iruka'),				-- 15
('Chapter 3: Twin Sisters and Cabbage Field'),
('Chapter 4: Club Activities and Flower Viewing'),
('Chapter 5: Hot Springs Photo Shoot and the Landlady'),
('Chapter 6: Anmitsu and Postcard and Iruka'),
('Chapter 1'),			-- 20
('Chapter 2'),
('Chapter 3'),
('Chapter 4'),
('Chapter 5'),
('Valentines Day'),		-- 25
('Chapter 6'),
('Animate Bonus'),
('Melonbooks Bonus'),
('Volume 1 Extras')

Insert into SeriesChapter (SeriesId, ChapterId, ChapterOrder) values
(1,1,1),
(1,2,2),
(1,3,3),
(1,4,4),
(1,5,5),
(1,6,6),
(1,7,7),
(1,8,8),
(1,9,9),
(1,10,10),
(1,11,11),
(1,12,12),
(1,13,13),
(2,14,1),
(2,15,2),
(2,16,3),
(2,17,4),
(2,18,5),
(2,19,6),
(3,20,1),
(3,21,2),
(3,22,3),
(3,23,4),
(3,24,5),
(3,25,6),
(3,26,7),
(3,27,8),
(3,28,9),
(3,29,10)

Insert into Tag(Label, Description) values
('4-koma', 'Layout largely follows a vertical four-panel design, usually with two "strips" to a page.'),
('Adult life', 'To be used in works that feature adult characters. These works are generally (but not always) centered more around working life than school.'),
('Anime', 'This work has gotten, or has been announced to soon have, an anime adaptation.'),
('Aro/Ace', 'This work prominently features a character who is aromantic and/or asexual.'),
('Bath', 'There is a focus on a bath, either private or shared, inside or open-air.'),
('Blackmail', 'A character manipulates another into doing what they want by threatening to expose secrets.'),
('Childhood friends', 'Story features two people who have been friends since childhood.'),
('College life', 'To be used when the work centers around college/university students, staff, or faculty. If characters are college-aged but are working, consider using (or adding) the "Adult Life" tag.'),
('Comedy', 'Genre tag for works where jokes and other comedic actions drive the plot'),
('Drama', 'Genre tag for works where emotionally charged plot actions and/or intense conflict drive the narrative.'),
('Ecchi', 'Also known as "Not quite NSFW". Suggestive, often include elements such as panty or clevage shots, but no nudity is found.'),
('Hot spring', 'Story takes place at or features an onsen.'),
('Insane amounts of sex', 'Most, if not all, of the pages depict sex. If work is < 10 pages, consider using "Lots of sex" tag.'),
('Lots of sex', 'Roughly half of the pages depict sex.'),
('Moderate amounts of sex', 'Roughly a quarter of the pages depict sex.'),
('Nosebleed', 'Features a character getting a nosebleed.'),
('NSFW', 'Indicates that this work contains nudity. Be forewarned that not everything that could qualify as "not safe for work" will be tagged NSFW; Only works containing nudity will be.'),
('Romance', 'Genre tag for works where discovering, building, and/or accepting feelings of romantic love drive the narrative.'),
('School life', 'To be used when school is a prominent element of the story. Can apply to stories where the characters are attending primary, junior high, or high school, or stories about adults who work at such a school if it is plot-significant. Should not be used for students in college (see the "College life" tag) unless the college students spend a lot of time at a primary/secondary/high school.'),
('Slice of life', 'Stories not particularly concerned with an overall plot, and moreso the daily lives of the characters within'),
('Student council', 'One or more characters serves on the Student Council and that fact is relevant in the work.'),
('Subtext', 'There are things done and/or said that could easily be interpreted as Yuri, but the characters never quite make it explicit. In general, if a work has two women who are extremely important to each other but are not dating, and neither of them is aro/ace coded, it probably qualifies as Subtext.'),
('Twins', 'Story features twins in some capacity. See also the "Telling twins apart" tag.'),
('Wholesome', 'Story makes you come away with a warm fuzzy feeling. Often involves characters enthusiastically supporting each other through difficult times or significant insecurities.'),
('Yuri', 'The story features main characters who identify as women and are attracted to other women. The attraction may or may not be sexual or romantic. Generally (but not always) involves two or more women confessing and/or dating.');

Insert into SeriesTag (SeriesId, TagId) values
(1, (select TagId from Tag where Label = 'Anime')),
(1, (select TagId from Tag where Label = 'Drama')),
(1, (select TagId from Tag where Label = 'Romance')),
(1, (select TagId from Tag where Label = 'School life')),
(1, (select TagId from Tag where Label = 'Student council')),
(1, (select TagId from Tag where Label = 'Yuri')),
(2, (select TagId from Tag where Label = 'Yuri')),
(2, (select TagId from Tag where Label = 'Bath')),
(2, (select TagId from Tag where Label = 'Childhood friends')),
(2, (select TagId from Tag where Label = 'Comedy')),
(2, (select TagId from Tag where Label = 'Ecchi')),
(2, (select TagId from Tag where Label = 'Hot spring')),
(2, (select TagId from Tag where Label = 'Slice of life')),
(2, (select TagId from Tag where Label = 'Twins'))

Insert into ChapterTag (ChapterId, TagId) values
(8, (select TagId from Tag where Label = 'Aro/Ace')),
(14, (select TagId from Tag where Label = 'Nosebleed'))

-- Populate Author<-->Series join table
Insert into AuthorWorks (SeriesId, AuthorId) values
(1,1),
(1,3),
(2,5),
(3,4),
(4,2),
(5,5),
(6,5),
(7,3);

