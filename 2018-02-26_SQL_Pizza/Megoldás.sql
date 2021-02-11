SELECT f.futar_nev FROM futar AS f;

SELECT p.pizza_nev, p.pizza_ar FROM pizza AS p;

SELECT AVG(p.pizza_ar) FROM pizza AS p;

SELECT p.pizza_nev FROM pizza AS p
  WHERE p.pizza_ar < 1000;

SELECT f.futar_nev FROM futar AS f
  INNER JOIN rendeles AS r ON f.futar_id = r.futar_id
  WHERE r.rendeles_id = 1;

SELECT v.vevo_nev FROM vevo AS v
  INNER JOIN rendeles AS r ON v.vevo_id = r.vevo_id
  WHERE r.ido < "12,00";

SELECT p.pizza_nev FROM pizza AS p
  INNER JOIN tetelek AS t ON p.pizza_id = t.pizza_id
   INNER JOIN rendeles AS r ON r.rendeles_id = t.rendeles_id
  INNER JOIN vevo AS v ON v.vevo_id = r.vevo_id 
  WHERE v.vevo_nev = "Szundi"
GROUP BY p.pizza_nev;

SELECT f.futar_nev FROM futar AS f
  INNER JOIN rendeles AS r ON f.futar_id = r.futar_id
  INNER JOIN vevo AS v ON r.vevo_id = v.vevo_id
  WHERE v.vevo_nev = "Tudor";

SELECT r.rendeles_id, f.futar_nev, v.vevo_nev FROM rendeles AS r
  INNER JOIN futar AS f ON r.futar_id = f.futar_id
  INNER JOIN vevo AS v ON r.vevo_id = v.vevo_id;

SELECT SUM(p.pizza_ar * t.db) FROM pizza AS p
  INNER JOIN tetelek AS t ON p.pizza_id = t.pizza_id
  INNER JOIN rendeles r ON t.rendeles_id = r.rendeles_id
  INNER JOIN vevo v ON r.vevo_id = v.vevo_id
  WHERE v.vevo_nev = "Morgó";

SELECT COUNT(p.pizza_id) FROM pizza AS p
  INNER JOIN tetelek AS t ON p.pizza_id = t.pizza_id
  INNER JOIN rendeles AS r ON t.rendeles_id = r.rendeles_id
  INNER JOIN vevo AS v ON r.vevo_id = v.vevo_id
  WHERE p.pizza_nev = "Sorrento" AND v.vevo_nev = "Vidor";

SELECT SUM(t.db) FROM tetelek AS t
  INNER JOIN rendeles r ON t.rendeles_id = r.rendeles_id
  INNER JOIN vevo v ON r.vevo_id = v.vevo_id
  WHERE v.vevo_nev = "Hapci";

SELECT COUNT(r.rendeles_id) FROM rendeles AS r
  INNER JOIN vevo AS v ON r.vevo_id = v.vevo_id
  WHERE v.vevo_nev = "Szende";

SELECT SUM(t.db) FROM tetelek AS t
  INNER JOIN pizza AS p ON t.pizza_id = p.pizza_id
 WHERE p.pizza_nev LIKE "Hawaii";

SELECT v.vevo_nev, SUM(p.pizza_ar * t.db) FROM vevo AS v
  INNER JOIN rendeles AS r ON v.vevo_id = r.vevo_id
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  INNER JOIN pizza AS p ON t.pizza_id = p.pizza_id
  GROUP BY v.vevo_nev;

SELECT p.pizza_nev, v.vevo_nev, SUM(t.db) FROM pizza AS p
  LEFT JOIN tetelek AS t ON p.pizza_id = t.pizza_id
  LEFT JOIN rendeles AS r ON t.rendeles_id = r.rendeles_id
  LEFT JOIN vevo AS v ON r.vevo_id = v.vevo_id
  GROUP BY v.vevo_nev;

SELECT f.futar_nev, SUM(t.db) FROM futar AS f
  INNER JOIN rendeles AS r ON f.futar_id = r.futar_id
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY f.futar_nev;

SELECT r.datum, SUM(p.pizza_ar * t.db) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  INNER JOIN pizza AS p ON t.pizza_id = p.pizza_id
  GROUP BY r.datum;

SELECT r.datum, SUM(t.db) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY r.datum;

SELECT r.datum, SUM(t.db) / COUNT(DISTINCT t.rendeles_id) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY r.datum;

SELECT SUM(t.db) / COUNT(DISTINCT t.rendeles_id) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id;

SELECT f.futar_nev, COUNT(r.rendeles_id) FROM futar AS f
  INNER JOIN rendeles AS r ON f.futar_id = r.futar_id
  GROUP BY f.futar_nev;

SELECT p.pizza_nev, SUM(t.db) FROM pizza AS p
  INNER JOIN tetelek AS t ON p.pizza_id = t.pizza_id
  GROUP BY p.pizza_nev
  ORDER BY SUM(t.db) DESC;

SELECT v.vevo_nev, SUM(p.pizza_ar * t.db) FROM vevo AS v
  INNER JOIN rendeles AS r ON v.vevo_id = r.vevo_id
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  INNER JOIN pizza AS p ON t.pizza_id = p.pizza_id
  GROUP BY v.vevo_nev
  ORDER BY SUM(p.pizza_ar * t.db) DESC;

SELECT p.pizza_nev FROM pizza AS p
  ORDER BY p.pizza_ar DESC
  LIMIT 1;

SELECT f.futar_nev, SUM(t.db) FROM futar AS f
  INNER JOIN rendeles AS r ON f.futar_id = r.futar_id
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY f.futar_nev
  ORDER BY SUM(t.db) DESC
  LIMIT 1;

SELECT v.vevo_nev, SUM(t.db) FROM vevo AS v
  INNER JOIN rendeles AS r ON v.vevo_id = r.vevo_id
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY v.vevo_nev
  ORDER BY SUM(t.db) DESC
  LIMIT 1;

SELECT r.datum, SUM(t.db) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY r.datum
  ORDER BY SUM(t.db) DESC
  LIMIT 1;

SELECT r.datum, SUM(t.db) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  INNER JOIN pizza AS p ON t.pizza_id = p.pizza_id
  WHERE p.pizza_nev = "Hawaii"
  GROUP BY r.datum
  ORDER BY SUM(t.db) DESC
  LIMIT 1;

SELECT r.datum, SUM(t.db) FROM rendeles AS r
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  GROUP BY r.datum
  ORDER BY COUNT(r.rendeles_id) DESC
  LIMIT 1;

SELECT r.datum, SUM(p.pizza_ar * t.db) FROM rendeles AS r
  INNER JOIN tetelek t ON r.rendeles_id = t.rendeles_id
  INNER JOIN pizza p ON t.pizza_id = p.pizza_id
  GROUP BY r.datum
  ORDER BY SUM(p.pizza_ar * t.db) DESC
  LIMIT 1;

SELECT p.pizza_nev FROM pizza AS p
  INNER JOIN tetelek AS t ON p.pizza_id = t.pizza_id
  INNER JOIN rendeles AS r ON t.rendeles_id = r.rendeles_id
  INNER JOIN vevo AS v ON r.vevo_id = v.vevo_id
  WHERE v.vevo_nev = "Szundi"
  GROUP BY p.pizza_nev
  ORDER BY SUM(t.db) DESC
  LIMIT 1;

SELECT v.vevo_nev FROM vevo AS v
  INNER JOIN rendeles r ON v.vevo_id = r.vevo_id
  WHERE r.datum = "2010.10.01";

SELECT p.pizza_nev FROM pizza p
  WHERE p.pizza_ar < (SELECT p1.pizza_ar FROM pizza p1
  WHERE p1.pizza_nev = "Capricciosa"
  );

SELECT p.pizza_nev FROM pizza AS p
  WHERE p.pizza_ar > (SELECT AVG(p1.pizza_ar) FROM pizza p1
  );

SELECT p.pizza_nev FROM pizza AS p
  GROUP BY p.pizza_nev
  ORDER BY ABS((SELECT AVG(p1.pizza_ar) FROM pizza p1) - p.pizza_ar)
  LIMIT 1;

SELECT f.futar_nev FROM futar f
  INNER JOIN rendeles r ON f.futar_id = r.futar_id
  GROUP BY r.futar_id
  HAVING COUNT(r.rendeles_id) > (SELECT AVG(db) FROM (SELECT COUNT(rendeles_id) AS db FROM rendeles GROUP BY futar_id) AS darab);

SELECT v.vevo_nev FROM vevo AS v
  INNER JOIN rendeles AS r ON v.vevo_id = r.vevo_id
  INNER JOIN tetelek AS t ON r.rendeles_id = t.rendeles_id
  WHERE SUM(t.db) > (SELECT AVG(t1.db) FROM tetelek t1) * 3
  GROUP BY v.vevo_nev;
