-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: locacar
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20230702010541_Migração Inicial','7.0.8');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `anos`
--

DROP TABLE IF EXISTS `anos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anos` (
  `id_ano` int NOT NULL AUTO_INCREMENT,
  `codigo_ano` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nome_ano` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `last_update_amd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_ano`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anos`
--

LOCK TABLES `anos` WRITE;
/*!40000 ALTER TABLE `anos` DISABLE KEYS */;
INSERT INTO `anos` VALUES (1,'1992-1','1992 Gasolina','2023-07-05 14:19:43'),(2,'1991-1','1991 Gasolina','2023-07-05 14:19:43'),(3,'1998-1','1998 Gasolina','2023-07-05 14:19:44'),(4,'1997-1','1997 Gasolina','2023-07-05 14:19:44'),(5,'1996-1','1996 Gasolina','2023-07-05 14:19:44'),(6,'1995-1','1995 Gasolina','2023-07-05 14:19:44'),(7,'1994-1','1994 Gasolina','2023-07-05 14:19:44'),(8,'1993-1','1993 Gasolina','2023-07-05 14:19:44');
/*!40000 ALTER TABLE `anos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `anos_modelos`
--

DROP TABLE IF EXISTS `anos_modelos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anos_modelos` (
  `idAno_amd` int NOT NULL,
  `idModelo_amd` int NOT NULL,
  `last_update_amd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idAno_amd`,`idModelo_amd`),
  KEY `IX_anos_modelos_idModelo_amd` (`idModelo_amd`),
  CONSTRAINT `FK_anos_modelos_anos_idAno_amd` FOREIGN KEY (`idAno_amd`) REFERENCES `anos` (`id_ano`) ON DELETE CASCADE,
  CONSTRAINT `FK_anos_modelos_modelos_idModelo_amd` FOREIGN KEY (`idModelo_amd`) REFERENCES `modelos` (`id_mod`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anos_modelos`
--

LOCK TABLES `anos_modelos` WRITE;
/*!40000 ALTER TABLE `anos_modelos` DISABLE KEYS */;
INSERT INTO `anos_modelos` VALUES (1,1,'2023-07-05 14:19:43'),(1,2,'2023-07-05 14:19:44'),(1,3,'2023-07-05 14:19:44'),(2,1,'2023-07-05 14:19:43'),(2,2,'2023-07-05 14:19:44'),(2,3,'2023-07-05 14:19:44'),(3,2,'2023-07-05 14:19:44'),(4,2,'2023-07-05 14:19:44'),(5,2,'2023-07-05 14:19:44'),(6,2,'2023-07-05 14:19:44'),(6,3,'2023-07-05 14:19:44'),(7,2,'2023-07-05 14:19:44'),(7,3,'2023-07-05 14:19:44'),(8,2,'2023-07-05 14:19:44'),(8,3,'2023-07-05 14:19:44');
/*!40000 ALTER TABLE `anos_modelos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carros`
--

DROP TABLE IF EXISTS `carros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carros` (
  `id_car` int NOT NULL AUTO_INCREMENT,
  `marca_car` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `modelo_car` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ano_car` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `cor_car` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tipoCorpo_car` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `motor_car` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `transmissao_car` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `quilometragem_car` decimal(18,2) NOT NULL,
  `preco_car` decimal(18,2) NOT NULL,
  `numeroPortas_car` int NOT NULL,
  `capacidadePassageiros_car` int NOT NULL,
  `descricao_car` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `last_update_amd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_car`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carros`
--

LOCK TABLES `carros` WRITE;
/*!40000 ALTER TABLE `carros` DISABLE KEYS */;
INSERT INTO `carros` VALUES (1,'Volkswagen','Golf','2022','Prata','Hatchback','1.4L','Automática',5000.20,35000.50,4,5,'O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada.','2023-07-05 14:19:40'),(2,'Ford','Mustang','2021','Vermelho','Cupê','5.0L','Manual',8000.80,40000.75,2,4,'O Ford Mustang 2021 é um cupê icônico que combina potência e estilo em um único veículo.','2023-07-05 14:19:40'),(3,'Toyota','Corolla','2020','Branco','Sedan','2.0L','Automática',10000.50,25000.00,4,5,'O Toyota Corolla 2020 é um sedan confiável, econômico e confortável, com tecnologia de ponta e um design elegante.','2023-07-05 14:19:40'),(4,'Chevrolet','Camaro','2019','Amarelo','Cupê','6.2L','Manual',3000.30,50000.25,2,2,'O Chevrolet Camaro 2019 é um cupê esportivo de alto desempenho, com um motor potente e um design impressionante.','2023-07-05 14:19:40'),(5,'Honda','Civic','2022','Preto','Sedan','1.5L','Automática',7000.70,30000.50,4,5,'O Honda Civic 2022 é um sedan confiável e eficiente, com uma reputação de durabilidade e conforto.','2023-07-05 14:19:40'),(6,'BMW','X5','2021','Prata','SUV','3.0L','Automática',15000.90,45000.75,4,7,'O BMW X5 2021 é um SUV de luxo que combina elegância, desempenho e tecnologia avançada em um veículo espaçoso e confortável.','2023-07-05 14:19:40'),(7,'Mercedes-Benz','Classe C','2020','Azul','Sedan','2.0L','Automática',12000.60,40000.00,4,5,'A Mercedes-Benz Classe C 2020 é um sedan de luxo com um interior sofisticado, tecnologia avançada e um desempenho impressionante.','2023-07-05 14:19:40'),(8,'Audi','A4','2019','Branco','Sedan','2.0L','Automática',9000.40,35000.25,4,5,'O Audi A4 2019 é um sedan elegante e esportivo, com um interior luxuoso, tecnologia de ponta e um desempenho excepcional.','2023-07-05 14:19:40'),(9,'Hyundai','HB20','2022','Vermelho','Hatchback','1.6L','Manual',6000.20,25000.50,4,5,'O Hyundai HB20 2022 é um hatchback moderno e versátil, com um design arrojado e recursos avançados de segurança e conectividade.','2023-07-05 14:19:40'),(10,'Kia','Sportage','2021','Prata','SUV','2.0L','Automática',10000.80,35000.75,4,5,'O Kia Sportage 2021 é um SUV elegante e espaçoso, com um interior confortável, tecnologia intuitiva e um desempenho confiável.','2023-07-05 14:19:40'),(11,'Fiat','Uno','2020','Branco','Hatchback','1.0L','Manual',8000.50,20000.00,2,4,'O Fiat Uno 2020 é um hatchback compacto e econômico, ideal para a cidade, com um design moderno e recursos práticos.','2023-07-05 14:19:40'),(12,'Renault','Sandero','2019','Azul','Hatchback','1.6L','Manual',9000.30,25000.25,4,5,'O Renault Sandero 2019 é um hatchback espaçoso e confortável, com um design atraente e uma excelente relação custo-benefício.','2023-07-05 14:19:40'),(13,'Nissan','Versa','2022','Cinza','Sedan','1.6L','Manual',7500.70,28000.50,4,5,'O Nissan Versa 2022 é um sedan versátil e eficiente, com um interior espaçoso, tecnologia avançada e um bom desempenho.','2023-07-05 14:19:40'),(14,'Volvo','XC60','2021','Preto','SUV','2.0L','Automática',11000.90,45000.75,4,5,'O Volvo XC60 2021 é um SUV de luxo com um design elegante, conforto excepcional e tecnologia inovadora para uma experiência de condução premium.','2023-07-05 14:19:40'),(15,'Mazda','CX-5','2020','Vermelho','SUV','2.5L','Automática',8500.60,38000.00,4,5,'O Mazda CX-5 2020 é um SUV sofisticado e esportivo, com um interior requintado, desempenho emocionante e recursos avançados de segurança.','2023-07-05 14:19:40'),(16,'Subaru','Impreza','2019','Prata','Hatchback','2.0L','Manual',7000.40,32000.25,4,5,'O Subaru Impreza 2019 é um hatchback ágil e confiável, com tração nas quatro rodas, tecnologia intuitiva e um design distinto.','2023-07-05 14:19:40'),(17,'Lexus','RX','2022','Branco','SUV','3.5L','Automática',12000.80,50000.75,4,5,'O Lexus RX 2022 é um SUV de luxo com um interior refinado, desempenho suave e uma ampla gama de recursos de conforto e segurança.','2023-07-05 14:19:40'),(18,'Land Rover','Range Rover Evoque','2021','Preto','SUV','2.0L','Automática',10000.50,45000.00,4,5,'O Land Rover Range Rover Evoque 2021 é um SUV sofisticado e robusto, com um design icônico, capacidades off-road impressionantes e um interior luxuoso.','2023-07-05 14:19:40'),(19,'Jeep','Compass','2020','Vermelho','SUV','2.0L','Automática',9000.30,40000.25,4,5,'O Jeep Compass 2020 é um SUV versátil e resistente, com um design atraente, conforto refinado e capacidade off-road.','2023-07-05 14:19:40'),(20,'Porsche','911','2019','Amarelo','Cupê','3.0L','Automática',6000.20,70000.50,2,4,'O Porsche 911 2019 é um cupê esportivo lendário, com um desempenho excepcional, tecnologia avançada e um design atemporal.','2023-07-05 14:19:40'),(21,'Jaguar','F-Pace','2022','Azul','SUV','2.0L','Automática',8000.80,55000.75,4,5,'O Jaguar F-Pace 2022 é um SUV de luxo com um design elegante, dinâmica de condução empolgante e um interior requintado com tecnologia de ponta.','2023-07-05 14:19:40'),(22,'Tesla','Model S','2021','Branco','Sedan','Elétrico','Automática',5000.70,90000.50,4,5,'O Tesla Model S 2021 é um sedan elétrico de alto desempenho, com aceleração impressionante, autonomia excepcional e recursos de segurança avançados.','2023-07-05 14:19:40'),(23,'Alfa Romeo','Giulia','2020','Vermelho','Sedan','2.0L','Automática',7000.50,60000.00,4,5,'O Alfa Romeo Giulia 2020 é um sedan esportivo e elegante, com um design italiano icônico, um motor potente e uma experiência de condução emocionante.','2023-07-05 14:19:40'),(24,'Maserati','Ghibli','2019','Preto','Sedan','3.0L','Automática',9000.30,75000.25,4,5,'O Maserati Ghibli 2019 é um sedan de luxo com um design sofisticado, desempenho poderoso e um interior luxuoso com detalhes artesanais.','2023-07-05 14:19:40'),(25,'Mini','Cooper','2022','Branco','Hatchback','1.5L','Automática',6000.20,35000.50,2,4,'O Mini Cooper 2022 é um hatchback compacto e estiloso, com um caráter divertido, desempenho ágil e um interior cheio de personalidade.','2023-07-05 14:19:40'),(26,'Acura','TLX','2021','Prata','Sedan','2.0L','Automática',8000.80,40000.75,4,5,'O Acura TLX 2021 é um sedan de luxo com um design elegante, desempenho esportivo e tecnologia avançada para uma experiência de condução refinada.','2023-07-05 14:19:40'),(27,'Infiniti','Q50','2020','Azul','Sedan','3.0L','Automática',10000.50,45000.00,4,5,'O Infiniti Q50 2020 é um sedan sofisticado e confortável, com um motor potente, tecnologia inovadora e um design atraente.','2023-07-05 14:19:40'),(28,'Lamborghini','Huracán','2019','Amarelo','Cupê','5.2L','Automática',3000.30,500000.25,2,2,'O Lamborghini Huracán 2019 é um cupê de alto desempenho, com um motor poderoso, aerodinâmica avançada e um design exótico.','2023-07-05 14:19:40'),(29,'Bentley','Continental GT','2022','Prata','Cupê','4.0L','Automática',15000.90,550000.75,2,4,'O Bentley Continental GT 2022 é um cupê de luxo com um design elegante, interior refinado e um desempenho excepcional.','2023-07-05 14:19:40'),(30,'Rolls-Royce','Phantom','2021','Preto','Sedan','6.8L','Automática',2000.60,1000000.00,4,5,'O Rolls-Royce Phantom 2021 é um sedan de luxo supremo, com um interior opulento, tecnologia de última geração e uma presença imponente.','2023-07-05 14:19:40'),(31,'Ferrari','488 GTB','2020','Vermelho','Cupê','3.9L','Automática',5000.40,800000.25,2,2,'O Ferrari 488 GTB 2020 é um cupê esportivo de alto desempenho, com um motor turbo V8, aerodinâmica avançada e um design icônico.','2023-07-05 14:19:40'),(32,'Porsche','Panamera','2019','Branco','Sedan','3.0L','Automática',9000.70,60000.50,4,5,'O Porsche Panamera 2019 é um sedan de luxo versátil, com um desempenho emocionante, tecnologia avançada e espaço para toda a família.','2023-07-05 14:19:40'),(33,'Lexus','ES','2022','Azul','Sedan','2.5L','Automática',8000.50,55000.00,4,5,'O Lexus ES 2022 é um sedan de luxo com um design elegante, conforto excepcional e um conjunto abrangente de recursos de segurança e tecnologia.','2023-07-05 14:19:40'),(34,'Audi','Q5','2021','Prata','SUV','2.0L','Automática',12000.90,50000.75,4,5,'O Audi Q5 2021 é um SUV premium com um design moderno, desempenho esportivo e uma cabine espaçosa e luxuosa.','2023-07-05 14:19:40'),(35,'BMW','X5','2020','Preto','SUV','3.0L','Automática',10000.60,60000.00,4,5,'O BMW X5 2020 é um SUV de luxo com um equilíbrio perfeito entre desempenho, conforto e tecnologia, oferecendo uma experiência de condução emocionante.','2023-07-05 14:19:40'),(36,'Mercedes-Benz','E-Class','2019','Cinza','Sedan','2.0L','Automática',9000.40,55000.25,4,5,'O Mercedes-Benz E-Class 2019 é um sedan elegante e sofisticado, com um interior luxuoso, tecnologia avançada e um desempenho suave.','2023-07-05 14:19:40'),(37,'Jaguar','XE','2022','Branco','Sedan','2.0L','Automática',7000.20,45000.50,4,5,'O Jaguar XE 2022 é um sedan de luxo com um design arrojado, dinâmica de condução esportiva e uma cabine refinada com tecnologia de ponta.','2023-07-05 14:19:40'),(38,'Cadillac','CT5','2021','Prata','Sedan','2.0L','Automática',8000.80,50000.75,4,5,'O Cadillac CT5 2021 é um sedan sofisticado e elegante, com um interior espaçoso, tecnologia avançada e um desempenho poderoso.','2023-07-05 14:19:40'),(39,'Chevrolet','Camaro','2020','Vermelho','Cupê','6.2L','Automática',6000.70,60000.50,2,4,'O Chevrolet Camaro 2020 é um cupê esportivo icônico, com um design agressivo, motor V8 potente e um desempenho emocionante.','2023-07-05 14:19:40'),(40,'Dodge','Challenger','2019','Preto','Cupê','5.7L','Automática',5000.50,55000.00,2,4,'O Dodge Challenger 2019 é um cupê musculoso e poderoso, com um estilo retrô, desempenho de alta potência e um interior moderno.','2023-07-05 14:19:40'),(41,'Ford','Mustang','2022','Azul','Cupê','5.0L','Automática',7000.90,65000.75,2,4,'O Ford Mustang 2022 é um cupê lendário, com um design icônico, motor V8 emocionante e uma experiência de condução emocionante.','2023-07-05 14:19:40'),(42,'Nissan','GT-R','2021','Prata','Cupê','3.8L','Automática',6000.60,80000.00,2,2,'O Nissan GT-R 2021 é um cupê de alto desempenho, com um motor turbo V6, tecnologia avançada e um design aerodinâmico.','2023-07-05 14:19:40'),(43,'Toyota','Supra','2020','Vermelho','Cupê','3.0L','Automática',5000.40,70000.25,2,2,'O Toyota Supra 2020 é um cupê esportivo emocionante, com um design elegante, desempenho ágil e uma experiência de condução envolvente.','2023-07-05 14:19:40'),(44,'Mazda','MX-5 Miata','2019','Branco','Conversível','2.0L','Automática',4000.20,45000.50,2,2,'O Mazda MX-5 Miata 2019 é um conversível clássico, com um design esportivo, leveza e agilidade, e uma condução pura e divertida.','2023-07-05 14:19:40'),(45,'Subaru','WRX STI','2022','Azul','Sedan','2.5L','Manual',3000.70,40000.75,4,5,'O Subaru WRX STI 2022 é um sedan esportivo com tração nas quatro rodas, um motor turbocharged, estilo agressivo e uma condução empolgante.','2023-07-05 14:19:40'),(46,'Volkswagen','Golf GTI','2021','Cinza','Hatchback','2.0L','Automática',5000.50,35000.00,2,4,'O Volkswagen Golf GTI 2021 é um hatchback esportivo e versátil, com um desempenho emocionante, manuseio preciso e um interior confortável.','2023-07-05 14:19:40'),(47,'Hyundai','Veloster','2020','Amarelo','Hatchback','1.6L','Automática',6000.90,30000.25,3,4,'O Hyundai Veloster 2020 é um hatchback único e esportivo, com um design assimétrico, recursos avançados e uma condução divertida.','2023-07-05 14:19:40'),(48,'Kia','Stinger','2019','Vermelho','Sedan','3.3L','Automática',7000.60,40000.50,4,5,'O Kia Stinger 2019 é um sedan de alto desempenho, com um design arrojado, um motor turbo V6 potente e uma cabine luxuosa.','2023-07-05 14:19:40'),(49,'Volvo','XC90','2022','Preto','SUV','2.0L','Automática',9000.40,55000.25,4,7,'O Volvo XC90 2022 é um SUV de luxo com um design escandinavo elegante, tecnologia avançada de segurança e um interior espaçoso e confortável.','2023-07-05 14:19:40'),(50,'Mitsubishi','Outlander','2021','Branco','SUV','2.5L','Automática',8000.20,45000.50,4,7,'O Mitsubishi Outlander 2021 é um SUV versátil e confiável, com um design moderno, espaço para toda a família e tecnologia conveniente.','2023-07-05 14:19:40');
/*!40000 ALTER TABLE `carros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marcas`
--

DROP TABLE IF EXISTS `marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marcas` (
  `id_mar` int NOT NULL AUTO_INCREMENT,
  `codigo_mar` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nome_mar` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `last_update_amd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_mar`)
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marcas`
--

LOCK TABLES `marcas` WRITE;
/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES (1,'1','Acura','2023-07-05 14:19:41'),(2,'2','Agrale','2023-07-05 14:19:41'),(3,'3','Alfa Romeo','2023-07-05 14:19:41'),(4,'4','AM Gen','2023-07-05 14:19:41'),(5,'5','Asia Motors','2023-07-05 14:19:41'),(6,'189','ASTON MARTIN','2023-07-05 14:19:41'),(7,'6','Audi','2023-07-05 14:19:41'),(8,'207','Baby','2023-07-05 14:19:41'),(9,'7','BMW','2023-07-05 14:19:41'),(10,'8','BRM','2023-07-05 14:19:41'),(11,'123','Bugre','2023-07-05 14:19:41'),(12,'238','BYD','2023-07-05 14:19:41'),(13,'236','CAB Motors','2023-07-05 14:19:41'),(14,'10','Cadillac','2023-07-05 14:19:41'),(15,'161','Caoa Chery','2023-07-05 14:19:41'),(16,'11','CBT Jipe','2023-07-05 14:19:41'),(17,'136','CHANA','2023-07-05 14:19:41'),(18,'182','CHANGAN','2023-07-05 14:19:41'),(19,'12','Chrysler','2023-07-05 14:19:41'),(20,'13','Citroën','2023-07-05 14:19:41'),(21,'14','Cross Lander','2023-07-05 14:19:41'),(22,'241','D2D ','2023-07-05 14:19:41'),(23,'15','Daewoo','2023-07-05 14:19:41'),(24,'16','Daihatsu','2023-07-05 14:19:41'),(25,'17','Dodge','2023-07-05 14:19:41'),(26,'147','EFFA','2023-07-05 14:19:41'),(27,'18','Engesa','2023-07-05 14:19:41'),(28,'19','Envemo','2023-07-05 14:19:41'),(29,'20','Ferrari','2023-07-05 14:19:41'),(30,'21','Fiat','2023-07-05 14:19:41'),(31,'149','Fibravan','2023-07-05 14:19:41'),(32,'22','Ford','2023-07-05 14:19:41'),(33,'190','FOTON','2023-07-05 14:19:41'),(34,'170','Fyber','2023-07-05 14:19:41'),(35,'199','GEELY','2023-07-05 14:19:41'),(36,'23','GM - Chevrolet','2023-07-05 14:19:41'),(37,'153','GREAT WALL','2023-07-05 14:19:41'),(38,'24','Gurgel','2023-07-05 14:19:41'),(39,'240','GWM','2023-07-05 14:19:41'),(40,'152','HAFEI','2023-07-05 14:19:41'),(41,'214','HITECH ELECTRIC','2023-07-05 14:19:41'),(42,'25','Honda','2023-07-05 14:19:41'),(43,'26','Hyundai','2023-07-05 14:19:41'),(44,'27','Isuzu','2023-07-05 14:19:41'),(45,'208','IVECO','2023-07-05 14:19:41'),(46,'177','JAC','2023-07-05 14:19:41'),(47,'28','Jaguar','2023-07-05 14:19:41'),(48,'29','Jeep','2023-07-05 14:19:41'),(49,'154','JINBEI','2023-07-05 14:19:41'),(50,'30','JPX','2023-07-05 14:19:41'),(51,'31','Kia Motors','2023-07-05 14:19:41'),(52,'32','Lada','2023-07-05 14:19:41'),(53,'171','LAMBORGHINI','2023-07-05 14:19:41'),(54,'33','Land Rover','2023-07-05 14:19:41'),(55,'34','Lexus','2023-07-05 14:19:41'),(56,'168','LIFAN','2023-07-05 14:19:41'),(57,'127','LOBINI','2023-07-05 14:19:41'),(58,'35','Lotus','2023-07-05 14:19:41'),(59,'140','Mahindra','2023-07-05 14:19:41'),(60,'36','Maserati','2023-07-05 14:19:41'),(61,'37','Matra','2023-07-05 14:19:41'),(62,'38','Mazda','2023-07-05 14:19:41'),(63,'211','Mclaren','2023-07-05 14:19:41'),(64,'39','Mercedes-Benz','2023-07-05 14:19:41'),(65,'40','Mercury','2023-07-05 14:19:41'),(66,'167','MG','2023-07-05 14:19:41'),(67,'156','MINI','2023-07-05 14:19:41'),(68,'41','Mitsubishi','2023-07-05 14:19:41'),(69,'42','Miura','2023-07-05 14:19:41'),(70,'43','Nissan','2023-07-05 14:19:41'),(71,'44','Peugeot','2023-07-05 14:19:41'),(72,'45','Plymouth','2023-07-05 14:19:41'),(73,'46','Pontiac','2023-07-05 14:19:41'),(74,'47','Porsche','2023-07-05 14:19:41'),(75,'185','RAM','2023-07-05 14:19:41'),(76,'186','RELY','2023-07-05 14:19:41'),(77,'48','Renault','2023-07-05 14:19:41'),(78,'195','Rolls-Royce','2023-07-05 14:19:41'),(79,'49','Rover','2023-07-05 14:19:41'),(80,'50','Saab','2023-07-05 14:19:41'),(81,'51','Saturn','2023-07-05 14:19:41'),(82,'52','Seat','2023-07-05 14:19:41'),(83,'183','SHINERAY','2023-07-05 14:19:41'),(84,'157','smart','2023-07-05 14:19:41'),(85,'125','SSANGYONG','2023-07-05 14:19:41'),(86,'54','Subaru','2023-07-05 14:19:41'),(87,'55','Suzuki','2023-07-05 14:19:41'),(88,'165','TAC','2023-07-05 14:19:41'),(89,'56','Toyota','2023-07-05 14:19:41'),(90,'57','Troller','2023-07-05 14:19:41'),(91,'58','Volvo','2023-07-05 14:19:41'),(92,'59','VW - VolksWagen','2023-07-05 14:19:41'),(93,'163','Wake','2023-07-05 14:19:41'),(94,'120','Walk','2023-07-05 14:19:41');
/*!40000 ALTER TABLE `marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modelos`
--

DROP TABLE IF EXISTS `modelos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modelos` (
  `id_mod` int NOT NULL AUTO_INCREMENT,
  `codigo_mod` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nome_mod` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `idMarca_mod` int NOT NULL,
  `last_update_amd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_mod`),
  KEY `IX_modelos_idMarca_mod` (`idMarca_mod`),
  CONSTRAINT `FK_modelos_marcas_idMarca_mod` FOREIGN KEY (`idMarca_mod`) REFERENCES `marcas` (`id_mar`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modelos`
--

LOCK TABLES `modelos` WRITE;
/*!40000 ALTER TABLE `modelos` DISABLE KEYS */;
INSERT INTO `modelos` VALUES (1,'1','Integra GS 1.8',1,'2023-07-05 14:19:43'),(2,'2','Legend 3.2/3.5',1,'2023-07-05 14:19:43'),(3,'3','NSX 3.0',1,'2023-07-05 14:19:43');
/*!40000 ALTER TABLE `modelos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-05 11:22:31
