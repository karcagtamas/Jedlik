A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!

1. feladat:

CREATE DATABASE ostermelo
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

3. feladat:

SELECT p.telepules FROM partnerek AS p 
  GROUP BY p.telepules
ORDER BY p.telepules;

4. feladat:

SELECT COUNT(k.datum) AS alkalmak FROM kiszallitasok AS k
  INNER JOIN partnerek p ON k.partnerid = p.id
  WHERE p.telepules LIKE "Vác";

5. feladat:

SELECT MAX(k.karton) AS legtobb FROM kiszallitasok AS k
WHERE YEAR(k.datum) = "2016" AND MONTH(k.datum) = "05";

6. feladat:

SELECT p.telepules FROM partnerek AS p
  GROUP BY p.telepules
  HAVING COUNT(p.telepules) > 1;

7. feladat:

SELECT gy.gynev AS ital, SUM(k.karton) * 6 AS doboz FROM gyumolcslevek AS gy
  INNER JOIN kiszallitasok k ON gy.id = k.gyumleid
  GROUP BY gy.gynev
  ORDER BY doboz DESC
  LIMIT 3;

