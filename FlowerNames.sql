DECLARE @Flowers TABLE(Name nvarchar(20))
INSERT INTO @Flowers
VALUES ('Rose'),
('Tulip'),
('Daisy'),
('Forget-me-not'),
('Lilac'),
('Narcissus'),
('Camomile'),
('Lily of the valley');

WITH DATA_RESULT AS 
(
	SELECT f1.Name Name1, f2.Name Name2, f3.Name Name3, f4.Name Name4, f5.Name Name5
	FROM @Flowers f1
	INNER JOIN @Flowers f2 ON f1.Name > f2.Name
	INNER JOIN @Flowers f3 ON f2.Name > f3.Name
	INNER JOIN @Flowers f4 ON f3.Name > f4.Name
	INNER JOIN @Flowers f5 ON f4.Name > f5.Name
)
SELECT Name1 as 'Name 1', Name2 as 'Name 2', Name3 as 'Name 3', Name4 as 'Name 4', Name5 as 'Name 5' FROM DATA_RESULT