SELECT ü.név FROM ügyfelek AS ü
  ORDER BY ü.név;

SELECT ü.név FROM ügyfelek AS ü
  WHERE ü.országkód = "H"
  ORDER BY ü.születési_év DESC;

SELECT ü.név FROM ügyfelek AS ü
  WHERE ü.irányítószám LIKE "2%";

SELECT SUM(b.összeg) AS "Összes befizetés" FROM befizetések AS b;

SELECT AVG(b.összeg) AS "Átlag befizetés" FROM befizetések AS b;

SELECT MAX(b.összeg), MIN(b.összeg) FROM befizetések AS b;

SELECT COUNT(b.összeg) FROM befizetések AS b;

SELECT b.összeg, b.dátum FROM befizetések AS b
  INNER JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  WHERE ü.név = "Török Bálint";

SELECT SUM(b.összeg) FROM befizetések AS b
  INNER JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  WHERE ü.név = "Nagy Károly";

SELECT SUM(b.összeg) FROM befizetések AS b
  INNER JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  WHERE ü.országkód <> "H";

SELECT ü.név, SUM(b.összeg) FROM befizetések AS b
  RIGHT JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  GROUP BY ü.név;

SELECT ü.név, SUM(b.összeg) AS össz FROM befizetések AS b
  INNER JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  GROUP BY ü.név
  ORDER BY össz DESC
  LIMIT 3;

SELECT MONTH(b.dátum) AS hónap, SUM(b.összeg) FROM befizetések AS b
  GROUP BY hónap;

SELECT DATE(b.dátum) AS dátumka FROM befizetések AS b
  GROUP BY dátumka
  HAVING COUNT(b.összeg) > 1;

SELECT ü.név, b.dátum, b.összeg FROM befizetések AS b
  INNER JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  WHERE DATE(b.dátum) < "2010.06.01";

SELECT ü.név, b.összeg FROM befizetések AS b
  INNER JOIN ügyfelek AS ü ON b.azonosító = ü.azonosító
  WHERE MONTH(b.dátum) = 6;

SELECT ü.név FROM ügyfelek AS ü
  ORDER BY ü.születési_év
  LIMIT 1;

SELECT ü.név FROM ügyfelek AS ü
  INNER JOIN befizetések AS b ON ü.azonosító = b.azonosító
  ORDER BY b.összeg
  LIMIT 1;

SELECT ü.név FROM ügyfelek AS ü
  INNER JOIN befizetések AS b ON ü.azonosító = b.azonosító
  GROUP BY ü.név
  ORDER BY SUM(b.összeg)
  LIMIT 1;

SELECT ü.név FROM ügyfelek AS ü
  INNER JOIN befizetések AS b ON ü.azonosító = b.azonosító
  GROUP BY ü.név
  HAVING SUM(b.összeg) > (
    SELECT AVG(al.v) FROM (
      SELECT SUM(b2.összeg) AS v
      FROM ügyfelek AS ü2
      INNER JOIN befizetések AS b2 ON ü2.azonosító = b2.azonosító
      GROUP BY ü2.név) AS al
      );

SELECT ü.név FROM ügyfelek AS ü
  LEFT JOIN befizetések AS b ON ü.azonosító = b.azonosító
  GROUP BY ü.név
  HAVING SUM(b.összeg) IS NULL;

SELECT MONTH(b.dátum) FROM befizetések AS b
  GROUP BY MONTH(b.dátum)
  HAVING SUM(b.összeg) IS NULL;






