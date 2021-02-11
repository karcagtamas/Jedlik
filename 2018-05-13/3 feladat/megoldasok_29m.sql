A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!


1. feladat:

CREATE DATABASE fogado
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;


3. feladat:

ALTER TABLE vendegek ADD INDEX(vnev);

4. feladat:

ALTER TABLE foglalasok
  ADD CONSTRAINT FK_foglalasok_vendegek_vsorsz FOREIGN KEY (vendeg)
    REFERENCES vendegek(vsorsz) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE foglalasok
  ADD CONSTRAINT FK_foglalasok_szobak_szazon FOREIGN KEY (szoba)
    REFERENCES szobak(szazon) ON DELETE RESTRICT ON UPDATE RESTRICT;

5. feladat:

INSERT foglalasok
SET fsorsz = 281,
    vendeg = 100,
    szoba = 2,
    erk = "2016.06.28.",
    tav = "2016.06.30.",
    fo = 5;

6. feladat:

UPDATE szobak
  SET agy = 3
WHERE szobak.sznev LIKE "Vidor" ;

7. feladat:

SELECT COUNT(vnev) AS venegszam FROM vendegek v
  WHERE v.irsz >= 3400 AND v.irsz <= 3999;

8. feladat:

SELECT s.sznev, SUM(f.fo) AS vendegek, SUM(f.tav - f.erk) AS vendegejszakak FROM szobak s
  INNER JOIN foglalasok f ON s.szazon = f.szoba
  GROUP BY s.sznev
  ORDER BY vendegejszakak, vendegek;

9. feladat:

SELECT v.vnev, COUNT(f.vendeg) AS alkalmak FROM vendegek v
  INNER JOIN foglalasok f ON f.vendeg = v.vsorsz
  GROUP BY v.vnev
  HAVING COUNT(f.vendeg) > 1
  ORDER BY v.vnev;


