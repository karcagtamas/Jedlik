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
UPDATE diakok
  SET kpmagy = 43
  WHERE oktazon = "0143302";


5. feladat:
SELECT
  diakok.nev
FROM diakok
WHERE kpmagy = 50 AND kpmat = 50 AND hozott >= 40;


6. feladat:

SELECT
  tagozatok.agazat,
  COUNT(jelentkezesek.tag) AS jelentkezoszam,
  MAX(diakok.hozott) - MIN(diakok.hozott) AS terjedelem
FROM jelentkezesek
  INNER JOIN diakok
    ON jelentkezesek.diak = diakok.oktazon
  INNER JOIN tagozatok
    ON jelentkezesek.tag = tagozatok.akod
WHERE tagozatok.nyek = 1
AND jelentkezesek.hely = 1
GROUP BY tagozatok.agazat


7. feladat:

SELECT
  diakok.nev,
  tagozatok.agazat,
  tagozatok.nyek,
  jelentkezesek.hely,
  diakok.kpmagy + diakok.kpmat + diakok.hozott * 2 AS osszpont
FROM jelentkezesek
  INNER JOIN diakok
    ON jelentkezesek.diak = diakok.oktazon
  INNER JOIN tagozatok
    ON jelentkezesek.tag = tagozatok.akod
ORDER BY tagozatok.agazat, osszpont DESC, jelentkezesek.hely


