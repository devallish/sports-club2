USE DevallishRFC

SELECT A.Id, A.Title, S.Id, S.Name
FROM Articles A
INNER JOIN SquadArticle SA ON SA.ArticleId = A.Id
INNER JOIN Squads S ON S.Id = SA.SquadId
WHERE A.Id = 4

SELECT *
FROM ClubArticle
WHERE ArticleId = 4

SELECT * FROM Squads

DELETE FROM SquadArticle WHERE ArticleId = 4
DELETE FROM ClubArticle WHERE ArticleId = 4



SELECT * FROM sys.tables

SELECT * FROM Clubs

UPDATE Clubs SET BrowserTitle = 'Burp RFC'

INSERT INTO Clubs (BrowserTitle, CreatedBy, CreatedDate, Name, Summary)
VALUES ('Andover RFC', 1, GETDATE(), 'Andover Rugby Club', 'This is the Andover RFC Summary')

SELECT * FROM Articles WHERE ID = 4
UPDATE Articles SET PublishDate = GETDATE(), RemoveDate = DATEADD(YEAR, 10, GETDATE()) WHERE ID = 4
UPDATE Articles SET Content1 = 'Something Else' WHERE ID = 4
INSERT INTO Articles (Title, ArticleDate, AuthorId, Content1, Summary, Keywords )
VALUES ('U16 Hit the Top', GETDATE(), 1, 'This conntent 1', 'A convincing win for U15', 'Match Report,U15,Trojans')


INSERT INTO Persons (Forenames, Surname, CreatedBy, CreatedDate)
VALUES ('Dave', 'Gregory', 1, GETDATE())

SELECT * FROM ClubArticle
INSERT INTO ClubArticle (ClubId, ArticleId)
VALUES (1,4), (1,5),(1,6),(1,7)

SELECT A.Title, A.Summary
FROM Clubs C
INNER JOIN ClubArticle CS ON CS.ClubId = C.Id
INNER JOIN Articles A ON A.Id = CS.ArticleId
INNER JOIN Persons P ON P.Id = A.AuthorId


SELECT *
FROM Sponsors

INSERT INTO Sponsors(CreatedBy, CreatedDate, ImageUrl, LinkUrl, Name, Summary)
VALUES (1, GETDATE(), 'Assets\Sponsors\Image01.jpg','http:\\bbc.co.uk','Devallish Technology', 'Summary for Devalllish Technology' ),
(1, GETDATE(), 'Assets\Sponsors\Image02.jpg','http:\\facebook.co.uk','Bob Technology', 'Summary for Bob Technology' ),
(1, GETDATE(), 'Assets\Sponsors\Image03.jpg','http:\\google.co.uk','Cat Technology', 'Summary for Cat Technology' ),
(1, GETDATE(), 'Assets\Sponsors\Image04.jpg','http:\\arfcya.co.uk','Cheese Technology', 'Summary for Chese Technology' )

SELECT * FROM ClubSponsor
 
SELECT * FROM Squads
INSERT INTO Squads (CreatedBy, CreatedDate,Name, Summary, Information)
VALUES(1, GETDATE(), 'Under 10', 'Under 10 Summary', 'Under 10 information'),
(1, GETDATE(), 'Under 11', 'Under 11 Summary', 'Under 11 information'),
(1, GETDATE(), 'Under 12', 'Under 12 Summary', 'Under 12 information'),
(1, GETDATE(), 'Under 13', 'Under 13 Summary', 'Under 13 information'),
(1, GETDATE(), 'Under 14', 'Under 14 Summary', 'Under 14 information')

INSERT INTO SquadArticle (SquadId, ArticleId)
VALUES(1,4), (4,4)