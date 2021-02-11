A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!

1. feladat:
CREATE DATABASE varosok
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;
3. feladat:
SELECT
  varos.vnev
FROM varos
WHERE varos.vnev LIKE '%vásár%'

4. feladat:
SELECT
  varos.vnev,
  varos.nepesseg,
  varos.terulet
FROM varos
  WHERE terulet > 400
  ORDER BY nepesseg DESC;

5. feladat:
SELECT
  varos.vnev,
  varos.nepesseg
FROM varos
  INNER JOIN megye
    ON varos.megyeid = megye.id
WHERE varos.nepesseg > 15000 AND mnev = 'Fejér';


6. feladat:
SELECT
  varostipus.vtip AS `Varos Típusa`,
  COUNT(varos.id) AS `Városok száma`,
  SUM(varos.nepesseg) AS Népesség
FROM varos
  INNER JOIN megye
    ON varos.megyeid = megye.id
  INNER JOIN varostipus
    ON varos.vtipid = varostipus.id
  WHERE vtip != 'főváros'
GROUP BY varostipus.vtip

7. feladat:
SELECT
  megye.mnev,
  COUNT(varos.id) AS 'db'
FROM varos
  INNER JOIN megye
    ON varos.megyeid = megye.id
WHERE varos.kisterseg <> varos.jaras
GROUP BY megye.mnev
HAVING COUNT(varos.id) > 8
  ORDER BY db DESC
