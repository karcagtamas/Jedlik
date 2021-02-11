/* ----------------------------------------------------- */
/* név, osztály, dátum, gépszám ------------------------ */
/* ----------------------------------------------------- */

/*1. feladat: */

  CREATE DATABASE futóverseny
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;


/*2. feladat: nem kell ----------- */

/*3. feladat: nem kell ----------- */ 

/*4. feladat: */

  ALTER TABLE eredmény
  ADD PRIMARY KEY (helyezés);

  ALTER TABLE kategória
  ADD PRIMARY KEY (kategóriaid);

  ALTER TABLE ország
  ADD PRIMARY KEY (országid);

ALTER TABLE kategória
  ADD UNIQUE INDEX UK_kategória_kategóriaid (kategóriaid);

ALTER TABLE eredmény
  ADD CONSTRAINT FK_eredmény_kategória_kategóriaid FOREIGN KEY (kategóriaid)
    REFERENCES kategória(kategóriaid) ON DELETE RESTRICT ON UPDATE RESTRICT;

  ALTER TABLE eredmény
  ADD CONSTRAINT FK_eredmény_ország_országid FOREIGN KEY (országid)
    REFERENCES ország(országid) ON DELETE RESTRICT ON UPDATE RESTRICT;

/*5. feladat: */

  SELECT (YEAR(NOW()) - e.születési_év) AS n FROM eredmény e
    ORDER BY n DESC
    LIMIT 1;

/*6. feladat: */

  SELECT e.helyezés, e.rajtszám, e.település FROM eredmény e
    WHERE e.település <> "Budapest" AND e.nem = "Nő"
    ORDER BY e.helyezés;

/*7. feladat: */

  SELECT e.rajtszám FROM eredmény e
    INNER JOIN ország o ON o.országid = e.országid
    WHERE o.név = "Magyarország" AND e.település = "";

/*8. feladat: */

  SELECT o.név, COUNT(e.helyezés) FROM ország o
    INNER JOIN eredmény e ON o.országid = e.országid
    GROUP BY o.név
    ORDER BY COUNT(e.helyezés) DESC;

/*9. feladat: */

  SELECT k.név, COUNT(e.helyezés) FROM kategória k
    INNER JOIN eredmény e ON k.kategóriaid = e.kategóriaid
    WHERE e.idő > (SELECT AVG(e1.idő) FROM eredmény e1)
    GROUP BY k.név;
    

/*10. feladat: */

  ALTER TABLE eredmény
    ADD COLUMN név varchar(255) DEFAULT NULL AFTER idő;

/*11. feladat: nem kell ----------- */

/*12. feladat: */

  UPDATE eredmény e SET e.név


/*13. feladat: */
