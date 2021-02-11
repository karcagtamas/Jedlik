# 1. feladat:
CREATE DATABASE futoverseny12A
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

# 3. feladat:


# 4. feladat:

ALTER TABLE sportoló
  ADD CONSTRAINT FK_sportoló_egyesület_egyesületId FOREIGN KEY (EgyesületId)
    REFERENCES egyesület(egyesületId) ON DELETE RESTRICT ON UPDATE RESTRICT;
	
	ALTER TABLE indulás
  ADD CONSTRAINT FK_sportoló_sportolóId FOREIGN KEY (SportolóId)
    REFERENCES sportoló(SportolóId) ON DELETE RESTRICT ON UPDATE RESTRICT;
	
	ALTER TABLE indulás
  ADD CONSTRAINT FK_sportoló_VersenyId FOREIGN KEY (VersenyId)
    REFERENCES verseny(VersenyId) ON DELETE RESTRICT ON UPDATE RESTRICT;

# 5. feladat
INSERT INTO egyesület (egyesületId, név, alapításÉve)
  VALUES (DEFAULT, 'Győri Dózsa', 1937)

# 6. feladat
SELECT
  egyesület.név,
  COUNT(indulás.SportolóId) AS expr1
FROM sportoló
  INNER JOIN egyesület
    ON sportoló.EgyesületId = egyesület.egyesületId
  INNER JOIN indulás
    ON indulás.SportolóId = sportoló.SportolóId
GROUP BY egyesület.név


# 7. feladat


# 8. feladat
SELECT
  sportoló.SzületésiÉv
FROM sportoló
  WHERE Vezetéknév = "Felcser" AND Keresztnév = "Anett";


# 9. feladat
SELECT
  sportoló.Vezetéknév,
  sportoló.Keresztnév
FROM sportoló
WHERE sportoló.SzületésiÉv <= 1977
AND sportoló.Nem = "nő"


# 10. feladat
SELECT
  AVG(YEAR(NOW()) - sportoló.SzületésiÉv ) AS expr1
FROM sportoló
WHERE sportoló.Nem = "férfi"

# 11. feladat
SELECT
  COUNT(sportoló.SzületésiÉv) AS expr1
FROM sportoló
  INNER JOIN egyesület
    ON sportoló.EgyesületId = egyesület.egyesületId
WHERE YEAR(NOW()) - sportoló.SzületésiÉv < 18 AND név = "PSE";

# 12. feladat
SELECT
  COUNT(sportoló.SportolóId) AS expr1
FROM sportoló
  INNER JOIN egyesület
    ON sportoló.EgyesületId = egyesület.egyesületId
  INNER JOIN indulás
    ON indulás.SportolóId = sportoló.SportolóId
  INNER JOIN verseny
    ON indulás.VersenyId = verseny.VersenyId
WHERE verseny.Név = "Föld alatti futás" AND indulás.Befutott = 1;

# 13.1 feladat
SELECT
  verseny.Név
FROM indulás
  INNER JOIN verseny
    ON indulás.VersenyId = verseny.VersenyId
GROUP BY verseny.Név
ORDER BY COUNT(indulás.IndulóId)
  LIMIT 1;

# 13.2 feladat
SELECT
  sportoló.Vezetéknév,
  sportoló.Keresztnév,
  SUM(verseny.Távolság) AS Tábolságok
FROM indulás
  INNER JOIN verseny
    ON indulás.VersenyId = verseny.VersenyId
  INNER JOIN sportoló
    ON indulás.SportolóId = sportoló.SportolóId
GROUP BY sportoló.Vezetéknév,
         sportoló.Keresztnév
ORDER BY Tábolságok DESC

# 13.3 feladat

