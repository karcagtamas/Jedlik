SELECT o.főváros FROM országok AS o
  WHERE o.név = "Madagaszkár";

SELECT o.név FROM országok AS o
  WHERE o.főváros = "OUAGADOUGOU";

SELECT o.név FROM országok AS o
  WHERE o.autójel = "TT";

SELECT o.név FROM országok AS o
  WHERE o.pénzjel = "SGD";

SELECT o.név FROM országok AS o
  WHERE o.telefon = 61;

SELECT o.terület FROM országok AS o
  WHERE o.név = "Monaco";

SELECT o.népesség * 1000 FROM országok AS o
  WHERE o.név = "Málta";

SELECT o.népesség / o.terület * 1000 FROM országok AS o
  WHERE o.név = "Japán";

SELECT o.név FROM országok AS o
  WHERE o.népesség / o.terület * 1000 > 500;

SELECT o.név FROM országok AS o
  WHERE o.földrajzi_hely LIKE "%szigetország%";

SELECT o.név FROM országok AS o
  ORDER BY o.terület DESC
  LIMIT 6;

SELECT o.név FROM országok AS o
  ORDER BY o.terület
  LIMIT 3;

SELECT o.név FROM országok AS o
  ORDER BY o.terület
  LIMIT 39,1;

SELECT o.név FROM országok AS o
  ORDER BY o.népesség
  LIMIT 14, 1;

SELECT o.név FROM országok AS o
  ORDER BY o.népesség / o.terület DESC
  LIMIT 60, 1;

SELECT SUM(o.népesség) * 1000 FROM országok AS o;

SELECT SUM(o.népesség) / SUM(o.terület) * 1000 FROM országok AS o;

SELECT COUNT(o.terület) FROM országok AS o
  WHERE o.terület > 1000000;

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.terület > 50000 AND o.terület < 150000;

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.népesség < 1000;

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.terület < 10000 OR o.népesség < 1000;

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.pénznem = "kelet-karib dollár";

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.név LIKE "%ország%";

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.földrajzi_hely LIKE "%afrika%";

SELECT SUM(o.népesség * 1000) FROM országok AS o
  WHERE o.földrajzi_hely LIKE "%afrika%";

SELECT SUM(o.terület) FROM országok AS o
  WHERE o.földrajzi_hely LIKE "%európa%";

SELECT SUM(o.népesség) / SUM(o.terület) * 1000 FROM országok AS o
  WHERE o.földrajzi_hely LIKE "%európa%";

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.autójel = "";

SELECT COUNT(o.név) FROM országok AS o
  WHERE o.váltópénz <> 100;

SELECT COUNT(o.név) FROM országok AS o,
  (
    SELECT o1.terület FROM országok AS o1
      WHERE o1.név = "Magyarország"
  ) AS ko
WHERE o.terület < ko.terület;

SELECT ko.nép / SUM(o.népesség) * 100 FROM országok AS o, (
  SELECT SUM(o1.népesség) AS nép FROM országok AS o1
  WHERE o1.földrajzi_hely LIKE "%afrika%"
  ) AS ko;

SELECT ko.nép / SUM(o.népesség) *100 FROM országok AS o, (
  SELECT SUM(o1.népesség) AS nép FROM országok AS o1
  WHERE o1.pénznem = "peso"
  ) AS ko;




