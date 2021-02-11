CREATE TABLE kategória (
  kategóriaid INT(11),
  név VARCHAR(50) DEFAULT NULL
);

CREATE TABLE eredmény (
  helyezés INT(11),
  rajtszám INT(11) DEFAULT NULL,
  születési_év INT(11) DEFAULT NULL,
  település VARCHAR(50) DEFAULT NULL,
  országid VARCHAR(50) DEFAULT NULL,
  kategóriaid INT(11) DEFAULT NULL,
  kategóriánkénti_helyezés INT(11) DEFAULT NULL,
  nem VARCHAR(50) DEFAULT NULL,
  nemenkénti_helyezés INT(11) DEFAULT NULL,
  idő TIME DEFAULT NULL
);