1. feladat:

CREATE DATABASE eurofoci2017
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

3. feladat:

ALTER TABLE bajnokság
  ADD PRIMARY KEY (id);

ALTER TABLE csapatok
  ADD PRIMARY KEY (id);

ALTER TABLE játékosok
  ADD PRIMARY KEY (id);

ALTER TABLE stadionok
  ADD PRIMARY KEY (id);

ALTER TABLE csapatok
  ADD CONSTRAINT FK_csapatok_bajnokság_id FOREIGN KEY (bajnokságid)
    REFERENCES bajnokság(id) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE csapatok
  ADD CONSTRAINT FK_csapatok_stadionok_id FOREIGN KEY (stadionid)
    REFERENCES stadionok(id) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE játékosok
  ADD CONSTRAINT FK_jatekosok_csapatok_id FOREIGN KEY (csapatid)
    REFERENCES csapatok(id) ON DELETE RESTRICT ON UPDATE RESTRICT;

4. feladat:

SELECT s.stadion, s.néző_szám FROM stadionok s
  GROUP BY s.stadion
  ORDER BY s.néző_szám DESC;

5. feladat:

SELECT j.név, j.érték FROM játékosok j
  INNER JOIN csapatok c ON c.id = j.csapatid
  WHERE c.klub LIKE "Liverpool FC"
  ORDER BY j.név;

6. feladat: 

SELECT b.bajnokságnév, b.klub_szám FROM bajnokság b
  GROUP BY b.bajnokságnév;

7. feladat: 

SELECT COUNT(j.id) FROM játékosok j
  WHERE j.szerződés IS NULL;

8. feladat:

SELECT s.stadion, s.város, s.épült FROM stadionok s
  ORDER BY s.épült
  LIMIT 1;

9. feladat:

SELECT b.ország, COUNT(j.láb) FROM bajnokság b
  INNER JOIN csapatok c ON b.id = c.bajnokságid
  INNER JOIN játékosok j ON c.id = j.csapatid
  WHERE j.láb = "left"
  GROUP BY b.ország
  HAVING COUNT(j.láb) > 40
  ORDER BY COUNT(j.láb) DESC;


