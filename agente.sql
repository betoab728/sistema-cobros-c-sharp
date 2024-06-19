-- MySQL dump 10.13  Distrib 5.7.23, for Win32 (AMD64)
--
-- Host: localhost    Database: miguel2
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.22-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bancos`
--

DROP TABLE IF EXISTS `bancos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bancos` (
  `idbanco` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `estado` int(11) DEFAULT 1,
  PRIMARY KEY (`idbanco`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bancos`
--

LOCK TABLES `bancos` WRITE;
/*!40000 ALTER TABLE `bancos` DISABLE KEYS */;
INSERT INTO `bancos` VALUES (1,'BCP- BANCO DE CREDITO',1),(2,'BBVA - BANCO CONTINENTAL',1);
/*!40000 ALTER TABLE `bancos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cajachica`
--

DROP TABLE IF EXISTS `cajachica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cajachica` (
  `idcajachica` int(11) NOT NULL AUTO_INCREMENT,
  `fechaapertura` datetime NOT NULL,
  `fechacierre` datetime DEFAULT NULL,
  `montoapertura` decimal(10,2) NOT NULL,
  `efectivo` decimal(10,2) DEFAULT NULL,
  `estado` int(11) NOT NULL DEFAULT 1,
  `idcajero` int(11) NOT NULL,
  `observacion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idcajachica`),
  KEY `idcajero_idx` (`idcajero`),
  CONSTRAINT `idcajero` FOREIGN KEY (`idcajero`) REFERENCES `cajeros` (`idcajero`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cajachica`
--

LOCK TABLES `cajachica` WRITE;
/*!40000 ALTER TABLE `cajachica` DISABLE KEYS */;
INSERT INTO `cajachica` VALUES (1,'2021-08-09 00:00:00','2021-08-16 17:21:31',65.00,7907.00,0,1,'NADAAAA'),(2,'2021-08-16 00:00:00','2021-08-16 17:50:49',111.00,7907.00,0,1,'');
/*!40000 ALTER TABLE `cajachica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cajeros`
--

DROP TABLE IF EXISTS `cajeros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cajeros` (
  `idcajero` int(11) NOT NULL AUTO_INCREMENT,
  `dni` varchar(45) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `contraseña` varchar(45) NOT NULL,
  `estado` int(11) DEFAULT 1,
  PRIMARY KEY (`idcajero`),
  UNIQUE KEY `dni_UNIQUE` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cajeros`
--

LOCK TABLES `cajeros` WRITE;
/*!40000 ALTER TABLE `cajeros` DISABLE KEYS */;
INSERT INTO `cajeros` VALUES (1,'45568554','elias-prueb','45568554',1),(3,'7777','prueba2','7777',1);
/*!40000 ALTER TABLE `cajeros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria` (
  `idcategoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `estado` int(11) DEFAULT 1,
  PRIMARY KEY (`idcategoria`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'LUZ',1),(2,'MUNICIPALIDADES-SAT',1),(3,'OPERADOR PORTUARIO',1),(4,'OTRAS FINANCIERAS',1),(5,'OTROS',1),(6,'PAGOS VARIOS',1),(7,'PRENDAS DE VESTIR',1),(8,'PRODUCTOS DE BELLEZA',1),(9,'SEGURIDAD',1),(10,'SEGUROS Y CLINICAS',1),(11,'SERVICIOS',1),(12,'SIDERURGICOS',1),(13,'TARJETAS OTRAS ENTIDADES',1),(14,'TAXIS',1),(15,'TECNOLOGIA E INFORMACION',1),(16,'TELECOMUNICACIONES',1),(17,'TELEFONIA',1),(18,'TEXTILES',1),(19,'TRANSPORTES Y ENVIOS',1),(20,'TRIBUTOS-IMPUESTOS',1),(21,'UNIVERSIDAD',1),(22,'UNIVERSIDADES',1),(23,'VENTA DIRECTA',1),(24,'VENTAS TEXTILES',1),(25,'PRUEBA',0),(27,'PRUEBA2',0),(28,'CAT3',0),(29,'DEPOSITO',1),(30,'PAGO DE TARJETA DE CREDITO',1),(31,'GIROS',1);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mediospago`
--

DROP TABLE IF EXISTS `mediospago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mediospago` (
  `idmedio` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmedio`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mediospago`
--

LOCK TABLES `mediospago` WRITE;
/*!40000 ALTER TABLE `mediospago` DISABLE KEYS */;
INSERT INTO `mediospago` VALUES (1,'EFECTIVO'),(2,'VISA DEBITO'),(3,'VISA CREDITO'),(4,'MASTER CARD DEBITO');
/*!40000 ALTER TABLE `mediospago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operaciones`
--

DROP TABLE IF EXISTS `operaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operaciones` (
  `idoperacion` int(11) NOT NULL AUTO_INCREMENT,
  `numero_operacion` varchar(45) DEFAULT NULL,
  `cuenta_origen` varchar(45) DEFAULT NULL,
  `cuenta_destino` varchar(45) DEFAULT NULL,
  `nombre_destino` varchar(45) DEFAULT NULL,
  `monto` decimal(10,2) DEFAULT NULL,
  `idcategoria` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `registro` datetime DEFAULT NULL,
  `estado` int(11) DEFAULT 1,
  `idbanco` int(11) DEFAULT NULL,
  `tipo` int(11) DEFAULT NULL,
  `idcajachica` int(11) NOT NULL,
  `idmedio` int(11) DEFAULT NULL,
  `descripcionpago` varchar(200) DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `titular` varchar(200) DEFAULT NULL,
  `tarjetadestino` varchar(200) DEFAULT NULL,
  `tarjetacredito` varchar(200) DEFAULT NULL,
  `montotarjeta` decimal(10,2) DEFAULT NULL,
  `pagosempresa` varchar(200) DEFAULT NULL,
  `pagoscategoria` varchar(200) DEFAULT NULL,
  `pagosservicio` varchar(200) DEFAULT NULL,
  `pagoscodigo` varchar(50) DEFAULT NULL,
  `giromonto` decimal(10,2) DEFAULT NULL,
  `girocomision` decimal(10,2) DEFAULT NULL,
  `girodocumento` varchar(200) DEFAULT NULL,
  `girobeneficiario` varchar(200) DEFAULT NULL,
  `giroclave` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idoperacion`),
  KEY `idcategor_idx` (`idcategoria`),
  KEY `idbanco_idx` (`idbanco`),
  KEY `idcajachica_idx` (`idcajachica`),
  KEY `idmedio_idx` (`idmedio`),
  CONSTRAINT `idbanco` FOREIGN KEY (`idbanco`) REFERENCES `bancos` (`idbanco`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idcajachica` FOREIGN KEY (`idcajachica`) REFERENCES `cajachica` (`idcajachica`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idcategor` FOREIGN KEY (`idcategoria`) REFERENCES `categoria` (`idcategoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idmedio` FOREIGN KEY (`idmedio`) REFERENCES `mediospago` (`idmedio`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1 COMMENT='							';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operaciones`
--

LOCK TABLES `operaciones` WRITE;
/*!40000 ALTER TABLE `operaciones` DISABLE KEYS */;
INSERT INTO `operaciones` VALUES (1,'6464','432432','234234','ELIAS ALEGRE',100.00,22,'2021-08-06','2021-08-06 22:00:25',1,2,1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'99999','43423','23423432','MIGUEL SANCHEZ',200.00,7,'2021-08-06','2021-08-06 22:22:10',1,1,2,1,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,'99999','43423','23423432','MIGUEL SANCHEZ',200.00,7,'2021-08-06','2021-08-06 22:22:20',1,2,1,1,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,'6465','646','3165616','IHUIU',888.00,1,'2021-08-06','2021-08-06 22:24:05',1,2,2,1,4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(5,'6456546','979789','879797','MIGUEL SANCHEZ',300.00,16,'2021-08-06','2021-08-06 22:25:54',1,2,1,1,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(6,'987979','694969','987949','MIGUEL SANCHEZ',200.00,1,'2021-08-06','2021-08-06 22:27:35',1,2,2,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(7,'98946','64646','16461869','MIGUEL SANCHEZ',200.00,10,'2021-08-06','2021-08-06 22:28:48',1,1,1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(8,'79794','5784542','313232','MIGUEL SANCHEZ',299.00,6,'2021-08-06','2021-08-06 22:31:19',1,2,2,1,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(9,'125635','4646546','CUENTA AHORRO 16351656','MIGUEL SANCHEZ',199.00,1,'2021-08-06','2021-08-06 22:32:26',1,2,2,1,4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(10,'6256+','64654656','616516','pago celular 935185330',50.00,17,'2021-08-09','2021-08-09 14:20:20',1,1,1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(11,'6166','dwqd','dwqd','dwqdqwd',87.00,4,'2021-08-09','2021-08-09 22:01:28',0,2,2,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(13,'6465','64646','1656546','UGYUGYU',56.00,14,'2021-08-10','2021-08-10 23:36:09',0,2,1,1,4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(14,'8979','','','ELIAS ALEGRE',50.00,17,'2021-08-11','2021-08-11 22:42:01',1,2,1,1,4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(15,'65646','','','ELIAS ALEGRE',30.00,17,'2021-08-11','2021-08-11 22:51:46',1,1,1,1,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(16,'984694','','','ELIAS ALEGRE',300.00,21,'2021-08-11','2021-08-11 22:55:43',1,1,1,1,1,'pago utp',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(17,'548897494','','','ELIAS ALEGRE',50.00,21,'2021-08-11','2021-08-11 23:00:17',1,1,1,1,1,'PAGO UTP - ALUMNO U20203340',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(18,'','','','CLENDENES PURIZACA',56.00,6,'2021-08-14','2021-08-14 12:57:08',1,1,1,1,1,'LINEA DE CREDITO EN SOLES TARJETA DE CREDITO VISA 4634-0105-3889-0018',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(20,'654321','beto','papa',NULL,101.00,29,'2021-08-16','2021-08-16 15:18:26',1,1,NULL,1,1,NULL,'15:18:26','beto beto',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(21,'ertretre',NULL,NULL,NULL,534.00,2,'2021-08-16','2021-08-16 15:28:25',1,2,NULL,1,1,NULL,'15:28:25','',NULL,NULL,NULL,'fdggfd','fgdfg','dfgdfg','dfgdfg',NULL,NULL,NULL,NULL,NULL),(22,'987',NULL,NULL,NULL,987.00,21,'2021-08-16','2021-08-16 15:29:09',1,2,NULL,1,1,NULL,'15:29:09','',NULL,NULL,NULL,'utp','csac','ascas','wrewr',NULL,NULL,NULL,NULL,NULL),(23,'5646',NULL,NULL,NULL,44.00,31,'2021-08-16','2021-08-16 15:39:02',1,1,NULL,1,2,NULL,'15:39:02',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,56.00,546.00,'64564','',NULL),(24,'ope 1608 ','beto','papa',NULL,123.00,29,'2021-08-16','2021-08-16 15:47:59',1,1,NULL,1,1,NULL,'15:47:59','beto beto',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(25,'1608-2 ope','beto','papa',NULL,123.00,29,'2021-08-16','2021-08-16 15:50:56',1,2,NULL,1,1,NULL,'15:50:56','elia alegre',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(26,'1608-3 ope','beto','papa',NULL,321.00,29,'2021-08-16','2021-08-16 15:52:42',1,2,NULL,1,1,NULL,'15:52:42','elias alegre',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(27,'9879','oouo','44656',NULL,999.00,29,'2021-08-16','2021-08-16 15:56:45',1,2,NULL,1,1,NULL,'15:56:45','elias laegre',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(28,'98799- 1608',NULL,NULL,NULL,43.00,21,'2021-08-16','2021-08-16 16:08:16',1,1,NULL,1,2,NULL,'16:08:16','',NULL,NULL,NULL,'UTP','PENSION','CSC','20203340',NULL,NULL,NULL,NULL,NULL),(29,'89 1608 ope',NULL,NULL,NULL,98.00,21,'2021-08-16','2021-08-16 16:11:59',1,2,NULL,1,1,NULL,'16:11:59','',NULL,NULL,NULL,'UTP','wdwd','ddd','20203340',NULL,NULL,NULL,NULL,NULL),(30,'cdc',NULL,NULL,NULL,33.00,21,'2021-08-16','2021-08-16 16:14:28',1,2,NULL,1,1,NULL,'16:14:28','',NULL,NULL,NULL,'FDF','dsdf','sdf','sdf',NULL,NULL,NULL,NULL,NULL),(31,'9798',NULL,NULL,NULL,987.00,21,'2021-08-16','2021-08-16 16:18:24',1,1,NULL,1,1,NULL,'16:18:24','ELIAS ALEGRE',NULL,NULL,NULL,'UCV','hjkj','kjhkl','20203340',NULL,NULL,NULL,NULL,NULL),(32,'9798',NULL,NULL,NULL,199.00,30,'2021-08-16','2021-08-16 16:27:30',1,2,NULL,1,1,NULL,'16:27:30','TITULAR TARJETA',NULL,NULL,NULL,'','','','',NULL,NULL,NULL,NULL,NULL),(33,'445',NULL,NULL,NULL,34.00,30,'2021-08-16','2021-08-16 16:28:36',1,2,NULL,1,1,NULL,'16:28:36','RGREGREG',NULL,NULL,NULL,'','','','',NULL,NULL,NULL,NULL,NULL),(34,'rewrwr',NULL,NULL,NULL,333.00,30,'2021-08-16','2021-08-16 16:31:30',1,1,NULL,1,1,NULL,'16:31:30','FEFEWF',NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(35,'7546546',NULL,NULL,NULL,16.00,30,'2021-08-16','2021-08-16 16:38:30',1,1,NULL,1,1,NULL,'16:38:30','LJLJKLK','drs','615646546',654.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(36,'94989',NULL,NULL,NULL,999.00,30,'2021-08-16','2021-08-16 16:42:07',1,2,NULL,1,1,NULL,'16:42:07','GFGF','iihuihi','rgreg',887.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(37,'efefewfe',NULL,NULL,NULL,987.00,31,'2021-08-16','2021-08-16 16:54:53',1,2,NULL,1,1,NULL,'16:54:53',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,789.00,3435.00,'gbfdbfd','',NULL),(38,'sfsdfsaf',NULL,NULL,NULL,55.00,31,'2021-08-16','2021-08-16 17:00:00',1,2,NULL,1,1,NULL,'17:00:00',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,887.00,3342.00,'fsfsf','dfsdfsfdsfsdf','6666'),(39,'979','dfdsf','sdfdsfd',NULL,444.00,29,'2021-08-16','2021-08-16 17:45:30',0,2,NULL,2,1,NULL,'17:45:30','DSFDSFDSF',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(40,'ffdsfd','dsfdsfdf','dsfsdfsdf',NULL,545.00,29,'2021-08-16','2021-08-16 17:47:56',0,2,NULL,2,1,NULL,'17:47:56','DSDSFDSF',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(41,'ggrgrgr',NULL,NULL,NULL,434.00,21,'2021-08-16','2021-08-16 17:48:25',0,1,NULL,2,1,NULL,'17:48:25','GSDG',NULL,NULL,NULL,'GGDSG','GSD','SDGSDG','gsdgsdg',NULL,NULL,NULL,NULL,NULL),(42,'teetret',NULL,NULL,NULL,444.00,31,'2021-08-16','2021-08-16 17:48:57',0,2,NULL,2,1,NULL,'17:48:57',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,4535.00,34534.00,'retertre','GFDGFDGDFGFD','t4543t');
/*!40000 ALTER TABLE `operaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `idusuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `pass` varchar(45) NOT NULL,
  PRIMARY KEY (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'OPERADOR','123'),(2,'ADMINISTRADOR','123456');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'miguel2'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_anularbanco` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_anularbanco`(pidbanco int)
BEGIN
update bancos set estado='0' where idbanco=pidbanco;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_anularcajero` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_anularcajero`(pidcajero int)
BEGIN
update cajeros set estado='0' where idcajero=pidcajero;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_anularcategoria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_anularcategoria`(pidcat int)
BEGIN
update categoria set estado='0' where idcategoria=pidcat;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_anularoperacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_anularoperacion`(pidope int)
BEGIN
update operaciones set estado='0' where idoperacion=pidope;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_buscarcajaactiva` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_buscarcajaactiva`()
BEGIN
select * from cajachica where estado='1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_buscarcajero` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_buscarcajero`(pclave varchar(20),pdni varchar(8))
BEGIN
select * from cajeros where dni=pdni and contraseña=pclave and estado='1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Buscaroperacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Buscaroperacion`(ptipo int, pfecha datetime,pnumop varchar(50),pbanco varchar(50))
BEGIN
declare pidcaja int;

if( ptipo=1 )then #cierre
set pidcaja=(select idcajachica from cajachica where estado='1');
select o.idoperacion, fecha FECHA , numero_operacion OPERACION,c.nombre CATEGORIA, cuenta_origen CUENTA_ORIGEN ,
cuenta_destino CUENTA_DESTINO,nombre_destino NOMBRE
,b.nombre BANCO , registro REGISTRO, c.idcategoria

from operaciones o 
inner join bancos b on o.idbanco=b.idbanco
inner join mediospago m on o.idmedio=m.idmedio
inner join categoria c on o.idcategoria=c.idcategoria
WHERE o.idcajachica=pidcaja and o.estado='1';

end if;

if( ptipo=2 )then #fecha
    select o.idoperacion, fecha FECHA , numero_operacion OPERACION,c.nombre CATEGORIA, cuenta_origen CUENTA_ORIGEN ,
cuenta_destino CUENTA_DESTINO,nombre_destino NOMBRE
,b.nombre BANCO , registro REGISTRO ,  c.idcategoria

from operaciones o 
inner join bancos b on o.idbanco=b.idbanco
inner join mediospago m on o.idmedio=m.idmedio
inner join categoria c on o.idcategoria=c.idcategoria
WHERE o.fecha=pfecha and o.estado='1';
end if;
 
if( ptipo=3 )then  #n operacion
    select o.idoperacion, fecha FECHA , numero_operacion OPERACION,c.nombre CATEGORIA, cuenta_origen CUENTA_ORIGEN ,
cuenta_destino CUENTA_DESTINO,nombre_destino NOMBRE
,b.nombre BANCO , registro REGISTRO ,  c.idcategoria

from operaciones o 
inner join bancos b on o.idbanco=b.idbanco
inner join mediospago m on o.idmedio=m.idmedio
inner join categoria c on o.idcategoria=c.idcategoria
WHERE o.numero_operacion=pnumop and o.estado='1'; 

end if;
if( ptipo=4 )then  #banco
    select o.idoperacion, fecha FECHA , numero_operacion OPERACION,c.nombre CATEGORIA, cuenta_origen CUENTA_ORIGEN ,
cuenta_destino CUENTA_DESTINO,nombre_destino NOMBRE
,b.nombre BANCO , registro REGISTRO,  c.idcategoria

from operaciones o 
inner join bancos b on o.idbanco=b.idbanco
inner join mediospago m on o.idmedio=m.idmedio
inner join categoria c on o.idcategoria=c.idcategoria
WHERE b.nombre like CONCAT('%',pbanco,'%') and o.estado='1';  
end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Buscarusuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Buscarusuario`( pidusuario int, ppasss varchar(50))
BEGIN
select * from usuarios where idusuario=pidusuario and pass=ppasss;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Cierrecaja` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Cierrecaja`(INOUT pidcaja int, pobservacion varchar(200),pefectivo decimal(10,2))
BEGIN

set pidcaja=(select idcajachica from cajachica where estado='1');
update  cajachica set efectivo=pefectivo,fechacierre=now(),estado='0',observacion=pobservacion
where idcajachica=pidcaja;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_cierrepormedios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cierrepormedios`()
BEGIN
declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');

SELECT m.nombre MEDIO_PAGO, sum(o.monto) TOTAL
FROM agente.operaciones o inner join mediospago m on o.idmedio=m.idmedio
where o.idcajachica=pidcaja
group by o.idmedio ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_editarbanco` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_editarbanco`(pidbanco int, pnombre varchar(100))
BEGIN
update bancos set nombre=pnombre where idbanco=pidbanco;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_editarcajero` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_editarcajero`(pidcajero int, pdni varchar(8),pnombre varchar(100),pcontraseña varchar(100))
BEGIN
update cajeros set nombre=pnombre , dni=pdni,contraseña= pcontraseña where idcajero=pidcajero;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_editarcategoria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_editarcategoria`(pidcat int, pnombre varchar(100))
BEGIN
update categoria set nombre=pnombre where idcategoria=pidcat;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_editarmedio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_editarmedio`(pidmedio int, pnombre varchar(50))
BEGIN
update mediospago set nombre=pnombre where idmedio=pidmedio;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_imprimircierre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_imprimircierre`(pidcaja int)
BEGIN

SELECT c.fechaapertura apertura,c.fechacierre cierre,c.efectivo,c.montoapertura,( c.montoapertura+c.efectivo) efectivocierre,c.efectivo saldo,b.nombre banco,ca.nombre categoria,o.monto
,o.numero_operacion operacion,m.nombre medio , if(c.estado='1','ABIERTO','CERRADO') estado,caj.nombre cajero
  FROM 
cajachica c
inner join operaciones o on c.idcajachica=o.idcajachica
inner join bancos b on o.idbanco=b.idbanco
inner join categoria ca on o.idcategoria=ca.idcategoria
inner join mediospago m on o.idmedio=m.idmedio
inner join cajeros caj on c.idcajero=caj.idcajero
WHERE c.idcajachica=pidcaja;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_imprimirgiros` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_imprimirgiros`(pidope int)
BEGIN
select o.idoperacion,o.numero_operacion, o.monto,DATE_FORMAT(o.fecha,'%d/%m/%Y') fecha,b.nombre banco,o.hora,girocomision comision,girodocumento documento,girobeneficiario beneficiario
,giroclave clave
 from operaciones o
 inner join bancos b on o.idbanco=b.idbanco
where o.idoperacion=pidope;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ImprimirPago` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ImprimirPago`(pidope int)
BEGIN
select o.idoperacion,o.numero_operacion,o.monto,o.descripcionpago descripcion, o.nombre_destino, c.nombre categoria ,DATE_FORMAT(o.fecha,'%d/%m/%Y') fecha,b.nombre banco,
o.hora,o.titular nombre_destino
from operaciones o
inner join categoria c on o.idcategoria=c.idcategoria
inner join bancos b on o.idbanco=b.idbanco
where o.idoperacion=pidope;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_imprimirpagostarjeta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_imprimirpagostarjeta`(pidope int)
BEGIN
select o.idoperacion,o.numero_operacion,tarjetadestino destino,titular,tarjetacredito , o.monto,DATE_FORMAT(o.fecha,'%d/%m/%Y') fecha,b.nombre banco,o.hora
 from operaciones o
 inner join bancos b on o.idbanco=b.idbanco
where o.idoperacion=pidope;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_imprimirticket` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_imprimirticket`(pidope int)
BEGIN

select o.idoperacion,o.numero_operacion,o.cuenta_destino,o.monto,DATE_FORMAT(o.fecha,'%d/%m/%Y') fecha,b.nombre banco,o.hora,o.titular nombre_destino
 from operaciones o
 inner join bancos b on o.idbanco=b.idbanco

where o.idoperacion=pidope;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ImprmirPagos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ImprmirPagos`(pidope int)
BEGIN
select o.idoperacion,o.numero_operacion,o.pagosempresa empresa,pagoscategoria categoria,pagosservicio servicio,
pagoscodigo codigo,o.titular, o.monto,DATE_FORMAT(o.fecha,'%d/%m/%Y') fecha,b.nombre banco,o.hora
 from operaciones o
 inner join bancos b on o.idbanco=b.idbanco

where o.idoperacion=pidope;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Listarbancos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Listarbancos`()
BEGIN
select idbanco ,nombre NOMBRE from bancos;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ListarCajeros` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ListarCajeros`()
BEGIN
select idcajero ,dni DNI,nombre NOMBRE,contraseña CONTRASENIA from cajeros where estado='1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ListarCategorias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ListarCategorias`()
BEGIN
select idcategoria,nombre NOMBRE from categoria  where estado='1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_listarmedios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarmedios`()
BEGIN
select * from mediospago;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ListarUsuarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ListarUsuarios`()
BEGIN
select * from usuarios;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_operacionescierre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_operacionescierre`()
BEGIN

declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');

select b.nombre BANCO ,  fecha FECHA ,if (tipo='1','PAGO','DEPOSITO') TIPO, numero_operacion OPERACION,c.nombre CATEGORIA, cuenta_origen CUENTA_ORIGEN ,
cuenta_destino CUENTA_DESTINO,nombre_destino NOMBRE,o.descripcionpago DESCRIPCION


from operaciones o 
inner join bancos b on o.idbanco=b.idbanco
inner join mediospago m on o.idmedio=m.idmedio
inner join categoria c on o.idcategoria=c.idcategoria
WHERE o.idcajachica=pidcaja and o.estado='1' ORDER BY o.idbanco;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarbanco` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarbanco`(pnombre varchar(100))
BEGIN
insert into bancos (nombre) values (pnombre);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarcajachica` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarcajachica`(pfecha datetime,pmonto decimal(10,2),pidcajero int, inout idcaja int)
BEGIN
insert into cajachica(fechaapertura,montoapertura,idcajero) values (pfecha,pmonto,pidcajero);
set idcaja=LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarcajero` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarcajero`( pdni varchar(100),pnombre varchar(100),pclave varchar(100))
BEGIN
insert into cajeros (dni,nombre,contraseña) values (pdni,pnombre,pclave);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarcategoria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarcategoria`(pnombre varchar(100))
BEGIN
insert into categoria (nombre) values (pnombre);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrargiros` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrargiros`(INOUT pidope int,pnumero varchar(50),pmonto decimal(10,2)
,pidcat int,pidbanco int,pfecha date,pidmedio int,pgiromonto decimal(10,2),pgirocomision decimal(10,2),pgirodocumento varchar(200),pgirobeneficiario varchar(200)
,pgiroclave varchar(50))
BEGIN
declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');
insert into operaciones (numero_operacion,monto,idcategoria,idbanco,fecha,registro,idcajachica,idmedio,hora,giromonto,girocomision,girodocumento,
girobeneficiario,giroclave)
values (pnumero,pmonto,pidcat,pidbanco,pfecha,now(),pidcaja,pidmedio,curtime(),pgiromonto,pgirocomision,pgirodocumento,pgirobeneficiario,pgiroclave);
set pidope=LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarmedio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarmedio`(pnombre varchar(50))
BEGIN
insert into mediospago(nombre) values (pnombre);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarpagos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarpagos`(INOUT pidope int,pnumero varchar(50),pmonto decimal(10,2)
,pidcat int,pidbanco int,pfecha date,pidmedio int,pempresa varchar(200),pcategoria varchar(200),pservicio varchar(200),pcodigo varchar(50),ptitular varchar(200))
BEGIN
declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');
insert into operaciones (numero_operacion,titular,monto,idcategoria,idbanco,fecha,registro,idcajachica,idmedio,hora,pagosempresa,pagoscategoria,pagosservicio,pagoscodigo)
values (pnumero,ptitular,pmonto,pidcat,pidbanco,pfecha,now(),pidcaja,pidmedio,curtime(),pempresa,pcategoria,pservicio,pcodigo);
set pidope=LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_registrarpagotarjeta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_registrarpagotarjeta`(INOUT pidope int,pnumero varchar(50),pmonto decimal(10,2)
,pidcat int,pidbanco int,pfecha date,pidmedio int,pdestino varchar(200),ptitular varchar(200),ptarjeta varchar(200),pmontotarjeta decimal(10,2))
BEGIN
declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');
insert into operaciones (numero_operacion,titular,monto,idcategoria,idbanco,fecha,registro,idcajachica,idmedio,hora,tarjetadestino,tarjetacredito,montotarjeta)
values (pnumero,ptitular,pmonto,pidcat,pidbanco,pfecha,now(),pidcaja,pidmedio,curtime(),pdestino,ptarjeta,pmontotarjeta);
set pidope=LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_resgistardeposito` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_resgistardeposito`(INOUT pidope int,pnumero varchar(50),porigen varchar(50),pdestino varchar(50)
,pnombre varchar(100),pmonto decimal(10,2)
,pidcat int,pidbanco int,pfecha date,pidmedio int)
BEGIN
declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');
insert into operaciones (numero_operacion,cuenta_origen,cuenta_destino,titular,monto,idcategoria,idbanco,fecha,registro,idcajachica,idmedio,hora)
values (pnumero,porigen,pdestino,pnombre,pmonto,pidcat,pidbanco,pfecha,now(),pidcaja,pidmedio,curtime());
set pidope=LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_rgistraroperacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_rgistraroperacion`(INOUT pidope int,pnumero varchar(50),porigen varchar(50),pdestino varchar(50)
,pnombre varchar(100),pmonto decimal(10,2)
,pidcat int,pidbanco int,pfecha date,ptipo int,pidmedio int,pdescripcion varchar(200))
BEGIN
declare pidcaja int;
set pidcaja=(select idcajachica from cajachica where estado='1');
insert into operaciones (numero_operacion,cuenta_origen,cuenta_destino,nombre_destino,monto,idcategoria,idbanco,fecha,registro,tipo,idcajachica,idmedio,descripcionpago)
values (pnumero,porigen,pdestino,pnombre,pmonto,pidcat,pidbanco,pfecha,now(),ptipo,pidcaja,pidmedio,pdescripcion);
set pidope=LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_saldocierre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_saldocierre`()
BEGIN
SELECT c.idcajachica,c.montoapertura,t.efectivo, (t.efectivo- c.montoapertura) saldo

from cajachica c 

inner join (select o.idcajachica, sum(o.monto) efectivo from operaciones o where o.idmedio='1' 
and idcajachica='1' and o.estado='1' ) as t

on c.idcajachica=t.idcajachica;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-19 17:57:15
