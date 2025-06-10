-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 10, 2025 at 10:37 AM
-- Server version: 5.7.24
-- PHP Version: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `unityaccess`
--

-- --------------------------------------------------------

--
-- Table structure for table `profesori`
--

CREATE TABLE `profesori` (
  `id_profesor` int(11) NOT NULL,
  `ime` varchar(16) NOT NULL,
  `prezime` varchar(16) NOT NULL,
  `predmet` varchar(64) NOT NULL,
  `mail` varchar(64) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `kod_predmeta` varchar(16) DEFAULT NULL,
  `verifikacija` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesori`
--

INSERT INTO `profesori` (`id_profesor`, `ime`, `prezime`, `predmet`, `mail`, `hash`, `salt`, `kod_predmeta`, `verifikacija`) VALUES
(6, 'Profa', 'Profic', 'Matematika', 'profa@gmail.com', '$5$rounds=5000$idegasprofa@gmai$OiGjGkA1zkiMQ7WZNcP6SvmnnK35XpB0C1IRTsiQjOB', '$5$rounds=5000$idegasprofa@gmail.com$', NULL, 1),
(7, 'Profa', 'Proff', 'Matematika', 'profa2@gmail.com', '$5$rounds=5000$idegasprofa2@gma$2fpNCsuEXdOe4eGichhASR6L7vtCzS2yclv.X5i2Cj7', '$5$rounds=5000$idegasprofa2@gmail.com$', 'm', 1),
(8, 'Slavko', 'Radovanovic', 'matematika', 'slavko@gmail.com', '$5$rounds=5000$idegasslavko@gma$Rzr4oDsUjVMX6bmBHUP/Rz41KBTOOi3vN/eSBxQtf.7', '$5$rounds=5000$idegasslavko@gmail.com$', 'm', 1),
(9, 'Profesor', 'Prezime', 'Matematika', 'profesor@gmail.com', '$5$rounds=5000$idegasprofesor@g$hqkGzy9mOFMmyabFc.O3ezmic/sJXB4eJk5EgH97pB1', '$5$rounds=5000$idegasprofesor@gmail.com$', 'm', 1),
(10, 'Debilcina', 'Retardirana', 'ProMaks', 'stankovic.mata@gmail.com', '$5$rounds=5000$idegasstankovic.$uBcZCI6UGiRZJLuiTO9LKSLFWifKjHUWjBeOKx7s5o4', '$5$rounds=5000$idegasstankovic.mata@gmail.com$', 'm', 1);

-- --------------------------------------------------------

--
-- Table structure for table `profesor_odeljenje`
--

CREATE TABLE `profesor_odeljenje` (
  `id_profesor` int(11) NOT NULL,
  `razred` int(11) NOT NULL,
  `odeljenje` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesor_odeljenje`
--

INSERT INTO `profesor_odeljenje` (`id_profesor`, `razred`, `odeljenje`) VALUES
(7, 4, 4),
(7, 1, 9),
(7, 1, 1),
(8, 4, 6),
(9, 2, 5),
(10, 4, 4),
(10, 4, 6);

-- --------------------------------------------------------

--
-- Table structure for table `ucenici`
--

CREATE TABLE `ucenici` (
  `jmbg` varchar(15) NOT NULL,
  `ime` varchar(16) NOT NULL,
  `prezime` varchar(16) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `razred` varchar(2) DEFAULT NULL,
  `odeljenje` varchar(2) DEFAULT NULL,
  `ocene` varchar(512) DEFAULT '',
  `verifikacija` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ucenici`
--

INSERT INTO `ucenici` (`jmbg`, `ime`, `prezime`, `hash`, `salt`, `razred`, `odeljenje`, `ocene`, `verifikacija`) VALUES
('', '', '', '$5$rounds=5000$idegas$mRo.NPOVLIvxoOsfZDz2a6KsVFTkyXyUxwAnaAs4Ps9', '$5$rounds=5000$idegas$', '1', '1', '', 0),
('1', 'sdasdasd', 'sasdadasd', '$5$rounds=5000$idegassdasdasd$uv/XyaFpFZpO1vgqtQY60dFPOIRpYTrPIwI9LRoDpR8', '$5$rounds=5000$idegassdasdasd$', '1', '1', 'm4(2025-05-31)m4(2025-05-31)', 0),
('1231232131231', 'MIlan', 'Djordjevic', '$5$rounds=5000$idegasMIlan$MSHNvXXg6orZvowkJ.1s/Cg9vaRUIngf9OEb0BdID/B', '$5$rounds=5000$idegasMIlan$', '4', '6', 'm5(2025-05-31)m3(2025-05-31)m1(2025-05-31)', 1),
('2200010100483', 'Ucenik', 'Ucenik', '$5$rounds=5000$idegasUcenik$anFPdMj9R5UdSsxQfy/3/bi1GKtNN2QXWshfb/GGD54', '$5$rounds=5000$idegasUcenik$', '2', '5', 'm4', 1),
('A', 'A', 'A', '123', '123', '1', '9', '1m4m3', 1);

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_obaveza`
--

CREATE TABLE `ucenik_obaveza` (
  `id_ucenik` varchar(64) NOT NULL,
  `predmet` varchar(32) NOT NULL,
  `tekst` varchar(512) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ucenik_obaveza`
--

INSERT INTO `ucenik_obaveza` (`id_ucenik`, `predmet`, `tekst`) VALUES
('1231232131231', 'Математика', 'Уради домаћи - 21. 22. 34. 45. задатак'),
('1231232131231', 'Физика', 'Тест - Нуклеарне реакције (26-05-2025)');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `profesori`
--
ALTER TABLE `profesori`
  ADD PRIMARY KEY (`id_profesor`);

--
-- Indexes for table `profesor_odeljenje`
--
ALTER TABLE `profesor_odeljenje`
  ADD KEY `id_profesor` (`id_profesor`);

--
-- Indexes for table `ucenici`
--
ALTER TABLE `ucenici`
  ADD PRIMARY KEY (`jmbg`);

--
-- Indexes for table `ucenik_obaveza`
--
ALTER TABLE `ucenik_obaveza`
  ADD KEY `id_ucenik` (`id_ucenik`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `profesori`
--
ALTER TABLE `profesori`
  MODIFY `id_profesor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `profesor_odeljenje`
--
ALTER TABLE `profesor_odeljenje`
  ADD CONSTRAINT `profesor_odeljenje_ibfk_1` FOREIGN KEY (`id_profesor`) REFERENCES `profesori` (`id_profesor`);

--
-- Constraints for table `ucenik_obaveza`
--
ALTER TABLE `ucenik_obaveza`
  ADD CONSTRAINT `id_ucenik` FOREIGN KEY (`id_ucenik`) REFERENCES `ucenici` (`jmbg`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
