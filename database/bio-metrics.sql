-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.36 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for ht_iris
CREATE DATABASE IF NOT EXISTS `ht_iris` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ht_iris`;

-- Dumping structure for table ht_iris.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `suffixname` varchar(45) DEFAULT NULL,
  `dateofbirth` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `municipality` varchar(1000) DEFAULT NULL,
  `barangay` varchar(1000) DEFAULT NULL,
  `zipcode` varchar(45) DEFAULT NULL,
  `filefingerprintleft` varchar(1000) DEFAULT NULL,
  `filefingerprintright` varchar(1000) DEFAULT NULL,
  `filethumbprintleft` varchar(1000) DEFAULT NULL,
  `filethumbprintright` varchar(1000) DEFAULT NULL,
  `fileirisleft` varchar(1000) DEFAULT NULL,
  `fileirisright` varchar(1000) DEFAULT NULL,
  `filedocument` varchar(1000) DEFAULT NULL,
  `fileidpicture` varchar(1000) DEFAULT NULL,
  `filesignature` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table ht_iris.users: ~2 rows (approximately)
DELETE FROM `users`;
INSERT INTO `users` (`id`, `firstname`, `middlename`, `lastname`, `suffixname`, `dateofbirth`, `sex`, `address`, `municipality`, `barangay`, `zipcode`, `filefingerprintleft`, `filefingerprintright`, `filethumbprintleft`, `filethumbprintright`, `fileirisleft`, `fileirisright`, `filedocument`, `fileidpicture`, `filesignature`) VALUES
	(1, 'Jeron', 'Jeron', 'Jeron', '', '2020/06/10', 'Male', 'Gagag', 'Gagaga', 'Gagag', '---233', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\FingerPrints\\JeronJeron - LEFTFINGER.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\FingerPrints\\JeronJeron - RIGHTFINGER.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\FingerPrints\\JeronJeron - LEFTTHUMB.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\FingerPrints\\JeronJeron - RIGHTTHUMB.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\Iris\\JeronJeron - LEFTYEYE.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\Iris\\JeronJeron - RIGHTEYE.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\JeronJeron - DOCUMENT.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\JeronJeron - ID.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Jeron - Jeron - NBI\\JeronJeron - SIGNATURE.jfif'),
	(2, 'Ceron', 'Ceron', 'Ceron', '-', '2000/02/02', 'Male', 'Sdadasd', 'Dasdadw', 'Asdad', '-24411', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\FingerPrints\\CeronCeron - LEFTFINGER.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\FingerPrints\\CeronCeron - RIGHTFINGER.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\FingerPrints\\CeronCeron - LEFTTHUMB.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\FingerPrints\\CeronCeron - RIGHTTHUMB.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\Iris\\CeronCeron - LEFTYEYE.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\Iris\\CeronCeron - RIGHTEYE.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\CeronCeron - DOCUMENT.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\CeronCeron - ID.jfif', 'C:\\Users\\Ceron Calsena\\Desktop\\NBI\\Sir  - Ceron - Ceron - NBI\\CeronCeron - SIGNATURE.jfif');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
