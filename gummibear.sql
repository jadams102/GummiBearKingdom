-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Apr 22, 2018 at 02:25 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gummibear`
--

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductId` int(11) NOT NULL,
  `Description` longtext,
  `Price` longtext,
  `Name` longtext,
  `imageUrl` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductId`, `Description`, `Price`, `Name`, `imageUrl`) VALUES
(3, 'They\'re gummy eggs! The perfect breakfast candy!', '$0.29 / oz', 'Gummy Eggs!', 'https://i.imgur.com/636AIik.jpg'),
(5, 'You asked for them (okay no you didn\'t), its our least popular product ever!', '$0.18 / oz', 'Gummy Chicken Feet!', 'https://i.imgur.com/6xwumCy.jpg'),
(7, 'The one that started it all!', '$0.13 / oz', 'Gummy Bears!', 'https://i.imgur.com/UtyQhK8.jpg'),
(8, 'The original* youth-themed sour gummy candy!', '$0.26 / oz', 'Gummy Children!', 'https://i.imgur.com/GKRs71B.jpg'),
(9, 'Ever wanted a gummy approximation of shark fin soup? No? Well we made it anyway!', '$0.16 /oz', 'Gummy Sharks!', 'https://i.imgur.com/D30dGDb.jpg'),
(10, 'A perfect gummy recreation of the skull of one of Jeremy the intern, may he rest in peace!', '$0.29 / oz', 'Gummy Skulls!', 'https://i.imgur.com/32E6h8O.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20180420164740_initial', '1.1.5'),
('20180420173147_AddNameAndPrice', '1.1.5'),
('20180422012621_AddImgUrl', '1.1.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
