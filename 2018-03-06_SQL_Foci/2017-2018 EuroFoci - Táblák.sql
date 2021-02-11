CREATE TABLE bajnokság (
  id int(11) NOT NULL,
  bajnokságnév varchar(50) DEFAULT NULL,
  ország varchar(50) DEFAULT NULL,
  klub_szám int(11) DEFAULT NULL,
  játékos_szám int(11) DEFAULT NULL,
  kor_átlag double DEFAULT NULL,
  külföldi_arány double DEFAULT NULL,
  euro_érték double DEFAULT NULL
);

CREATE TABLE stadionok (
  id int(11) NOT NULL,
  stadion varchar(100) DEFAULT NULL,
  néző_szám int(11) DEFAULT NULL,
  város varchar(50) DEFAULT NULL,
  ország varchar(50) DEFAULT NULL,
  épült int(11) DEFAULT NULL,
  csapat1 varchar(50) DEFAULT NULL,
  csapat2 varchar(50) DEFAULT NULL
);

CREATE TABLE csapatok (
  id int(11) NOT NULL,
  klub varchar(50) DEFAULT NULL,
  keret int(11) DEFAULT NULL,
  külföldi int(11) DEFAULT NULL,
  euro_érték int(11) DEFAULT NULL,
  manager varchar(50) DEFAULT NULL,
  bajnokságid int(11) DEFAULT NULL,
  stadionid int(11) DEFAULT NULL
);

CREATE TABLE játékosok (
  id int(11) NOT NULL,
  mez_szám varchar(50) DEFAULT NULL,
  név varchar(50) DEFAULT NULL,
  poszt varchar(50) DEFAULT NULL,
  születés varchar(50) DEFAULT NULL,
  magasság varchar(50) DEFAULT NULL,
  láb varchar(50) DEFAULT NULL,
  szerződés varchar(50) DEFAULT NULL,
  érték int(11) DEFAULT NULL,
  csapatid int(11) DEFAULT NULL
);