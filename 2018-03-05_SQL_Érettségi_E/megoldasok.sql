A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!


1. feladat:

CREATE DATABASE beiskolazas
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

3. feladat:

ALTER TABLE jelentkezesek
  ADD CONSTRAINT FK_jelentkezesek_diakok_oktazon FOREIGN KEY (diak)
    REFERENCES diakok(oktazon) ON DELETE RESTRICT ON UPDATE RESTRICT;
ALTER TABLE jelentkezesek
  ADD CONSTRAINT FK_jelentkezesek_tagozatok_akod FOREIGN KEY (tag)
    REFERENCES tagozatok(akod) ON DELETE RESTRICT ON UPDATE RESTRICT;


4. feladat:

UPDATE diakok d
SET d.kpmagy = 43
WHERE d.nev = "Nagy Vince";

5. feladat:

SELECT d.nev FROM diakok d
  WHERE d.kpmagy = 50 AND d.kpmat = 50 AND d.hozott >= 40
  ORDER BY d.nev;

6. feladat:

SELECT t.agazat AS agazat, COUNT(d.oktazon) AS jelentkezoszam, MAX(d.hozott) - MIN(d.hozott) AS terjedelem FROM tagozatok t
  INNER JOIN jelentkezesek j ON t.akod = j.tag
  INNER JOIN diakok d ON d.oktazon = j.diak
  WHERE t.nyek = 1 AND j.hely = 1
  GROUP BY t.agazat
  ORDER BY jelentkezoszam DESC;


7. feladat:

SELECT d.nev AS nev,   FROM diakok AS d
  INNER JOIN jelentkezesek j ON d.oktazon = j.diak
  INNER JOIN tagozatok t ON t.akod = j.tag


