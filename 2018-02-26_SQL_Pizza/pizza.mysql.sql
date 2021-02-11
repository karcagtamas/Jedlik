-- 
-- Tábla szerkezet: `vevo`
-- 

CREATE TABLE `vevo` (
  `vevo_id` int(6) NOT NULL default '0',
  `vevo_nev` varchar(30) collate utf8_hungarian_ci NOT NULL default '',
  `vevo_cim` varchar(30) collate utf8_hungarian_ci NOT NULL default '',
  PRIMARY KEY  (`vevo_id`)
) ENGINE=InnoDb DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- 
-- Tábla adatok: `vevo`
-- 

INSERT INTO `vevo` VALUES (1, 'Hapci', '');
INSERT INTO `vevo` VALUES (2, 'Vidor', '');
INSERT INTO `vevo` VALUES (3, 'Tudor', '');
INSERT INTO `vevo` VALUES (4, 'Kuka', '');
INSERT INTO `vevo` VALUES (5, 'Szende', '');
INSERT INTO `vevo` VALUES (6, 'Szundi', '');
INSERT INTO `vevo` VALUES (7, 'Morgó', '');

-- 
-- Tábla szerkezet: `futar`
-- 

CREATE TABLE `futar` (
  `futar_id` int(3) NOT NULL default '0',
  `futar_nev` varchar(25) collate utf8_hungarian_ci NOT NULL default '',
  `futar_telefon` varchar(12) collate utf8_hungarian_ci NOT NULL default '',
  PRIMARY KEY  (`futar_id`)
) ENGINE=InnoDb DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- 
-- Tábla adatok: `pizza_futar`
-- 

INSERT INTO `futar` VALUES (1, 'Hurrikán', '123456');
INSERT INTO `futar` VALUES (2, 'Gyalogkakukk', '666666');
INSERT INTO `futar` VALUES (3, 'Gömbvillám', '888888');
INSERT INTO `futar` VALUES (4, 'Szélvész', '258369');
INSERT INTO `futar` VALUES (5, 'Imperial', '987654');

-- --------------------------------------------------------

-- 
-- Tábla szerkezet: `pizza`
-- 

CREATE TABLE `pizza` (
  `pizza_id` int(3) NOT NULL default '0',
  `pizza_nev` varchar(15) collate utf8_hungarian_ci NOT NULL default '',
  `pizza_ar` int(4) NOT NULL default '0',
  PRIMARY KEY  (`pizza_id`)
) ENGINE=InnoDb DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- 
-- Tábla adatok: `pizza`
-- 

INSERT INTO `pizza` VALUES (1, 'Capricciosa', 900);
INSERT INTO `pizza` VALUES (2, 'Frutti di Mare', 1100);
INSERT INTO `pizza` VALUES (3, 'Hawaii', 780);
INSERT INTO `pizza` VALUES (4, 'Vesuvio', 890);
INSERT INTO `pizza` VALUES (5, 'Sorrento', 990);

-- --------------------------------------------------------

-- 
-- Tábla szerkezet: `rendeles`
-- 

CREATE TABLE `rendeles` (
  `rendeles_id` int(8) NOT NULL default '0',
  `vevo_id` int(6) NOT NULL default '0',
  `futar_id` int(3) NOT NULL default '0',
  `datum` date NOT NULL default '0000-00-00',
  `ido` float NOT NULL default '0',
  PRIMARY KEY  (`rendeles_id`),
  INDEX(vevo_id),
  INDEX(futar_id),
  FOREIGN KEY (vevo_id) REFERENCES vevo(vevo_id) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY (futar_id) REFERENCES futar(futar_id) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDb DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- 
-- Tábla adatok: `rendeles`
-- 

INSERT INTO `rendeles` VALUES ( 1, 4, 2, '2010-10-01', 13.15);
INSERT INTO `rendeles` VALUES ( 2, 7, 2, '2010-10-01', 14.17);
INSERT INTO `rendeles` VALUES ( 3, 1, 1, '2010-10-02', 11.07);
INSERT INTO `rendeles` VALUES ( 4, 5, 2, '2010-10-02', 14.55);
INSERT INTO `rendeles` VALUES ( 5, 2, 3, '2010-10-02', 15.27);
INSERT INTO `rendeles` VALUES ( 6, 4, 2, '2010-10-03', 15.58);
INSERT INTO `rendeles` VALUES ( 7, 6, 2, '2010-10-04', 11.44);
INSERT INTO `rendeles` VALUES ( 8, 7, 4, '2010-10-04', 12.11);
INSERT INTO `rendeles` VALUES ( 9, 1, 5, '2010-10-04', 14.33);
INSERT INTO `rendeles` VALUES (10, 3, 5, '2010-10-04', 18.04);
INSERT INTO `rendeles` VALUES (11, 2, 1, '2010-10-05', 16.38);
INSERT INTO `rendeles` VALUES (12, 5, 2, '2010-10-05', 17.02);
INSERT INTO `rendeles` VALUES (13, 6, 2, '2010-10-06', 12.17);
INSERT INTO `rendeles` VALUES (14, 4, 3, '2010-10-06', 13.21);
INSERT INTO `rendeles` VALUES (15, 1, 4, '2010-10-06', 15.05);
INSERT INTO `rendeles` VALUES (16, 2, 5, '2010-10-06', 15.59);
INSERT INTO `rendeles` VALUES (17, 7, 2, '2010-10-06', 18.44);
INSERT INTO `rendeles` VALUES (18, 3, 2, '2010-10-07', 12.01);
INSERT INTO `rendeles` VALUES (19, 4, 5, '2010-10-07', 13.44);
INSERT INTO `rendeles` VALUES (20, 1, 1, '2010-10-07', 17.25);
INSERT INTO `rendeles` VALUES (21, 5, 3, '2010-10-08', 14.29);

-- --------------------------------------------------------

-- 
-- Tábla szerkezet: `tetelek`
-- 

CREATE TABLE `tetelek` (
  `rendeles_id` int(8) NOT NULL default '0',
  `pizza_id` int(3) NOT NULL default '0',
  `db` int(3) NOT NULL default '0',
  PRIMARY KEY  (`rendeles_id`, `pizza_id`),
  INDEX(rendeles_id),
  INDEX(pizza_id),
  FOREIGN KEY (rendeles_id) REFERENCES rendeles(rendeles_id) ON DELETE CASCADE ON UPDATE CASCADE ,
  FOREIGN KEY (pizza_id) REFERENCES pizza(pizza_id) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDb DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- 
-- Tábla adatok: `tetelek`
-- 

INSERT INTO `tetelek` VALUES ( 1, 1, 2);
INSERT INTO `tetelek` VALUES ( 1, 4, 3);
INSERT INTO `tetelek` VALUES ( 2, 2, 1);
INSERT INTO `tetelek` VALUES ( 3, 1, 2);
INSERT INTO `tetelek` VALUES ( 4, 1, 1);
INSERT INTO `tetelek` VALUES ( 4, 4, 1);
INSERT INTO `tetelek` VALUES ( 5, 2, 4);
INSERT INTO `tetelek` VALUES ( 6, 1, 1);
INSERT INTO `tetelek` VALUES ( 6, 4, 1);
INSERT INTO `tetelek` VALUES ( 6, 5, 1);
INSERT INTO `tetelek` VALUES ( 7, 5, 5);
INSERT INTO `tetelek` VALUES ( 8, 4, 3);
INSERT INTO `tetelek` VALUES ( 9, 2, 1);
INSERT INTO `tetelek` VALUES (10, 1, 1);
INSERT INTO `tetelek` VALUES (10, 4, 1);
INSERT INTO `tetelek` VALUES (11, 1, 1);
INSERT INTO `tetelek` VALUES (12, 2, 2);
INSERT INTO `tetelek` VALUES (12, 4, 2);
INSERT INTO `tetelek` VALUES (13, 4, 1);
INSERT INTO `tetelek` VALUES (13, 5, 1);
INSERT INTO `tetelek` VALUES (13, 2, 1);
INSERT INTO `tetelek` VALUES (14, 2, 2);
INSERT INTO `tetelek` VALUES (15, 1, 1);
INSERT INTO `tetelek` VALUES (16, 2, 1);
INSERT INTO `tetelek` VALUES (16, 4, 1);
INSERT INTO `tetelek` VALUES (16, 5, 1);
INSERT INTO `tetelek` VALUES (17, 1, 2);
INSERT INTO `tetelek` VALUES (17, 2, 3);
INSERT INTO `tetelek` VALUES (18, 1, 4);
INSERT INTO `tetelek` VALUES (18, 5, 1);
INSERT INTO `tetelek` VALUES (19, 1, 1);
INSERT INTO `tetelek` VALUES (19, 2, 1);
INSERT INTO `tetelek` VALUES (19, 4, 1);
INSERT INTO `tetelek` VALUES (19, 5, 1);
INSERT INTO `tetelek` VALUES (20, 5, 3);
INSERT INTO `tetelek` VALUES (21, 2, 2);
INSERT INTO `tetelek` VALUES (21, 4, 1);

-- --------------------------------------------------------        