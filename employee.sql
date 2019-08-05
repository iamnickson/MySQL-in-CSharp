-- phpMyAdmin SQL Dump
-- version 4.5.0.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 05, 2019 at 07:04 AM
-- Server version: 10.0.17-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `employee`
--

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ProductId` varchar(10) NOT NULL DEFAULT '',
  `ProductName` varchar(30) DEFAULT NULL,
  `UnitPrice` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ProductId`, `ProductName`, `UnitPrice`) VALUES
('445555', 'llllllllllllllll', 111111111111),
('P001', 'HP-PC', 150000),
('P002', 'External H', 15000),
('P003', 'Dell-M', 800),
('P004', 'Keyboard', 1000),
('P005', 'Parinter', 26000),
('P006', 'Mouse', 250),
('P007', 'Mouse Pad', 155),
('P008', 'Mouse pad version 2', 550),
('P009', 'Key', 15),
('P010', 'Keys', 75),
('P011', 'System Covering', 175),
('P012', 'CPU 5', 45005),
('P013', 'CPU 2', 37500),
('P014', 'Pen', 200),
('P015', 'Paper', 12);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(10) DEFAULT NULL,
  `password` varchar(10) NOT NULL,
  `userid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`, `userid`) VALUES
('user1', '1111', 1),
('user2', '2222', 2),
('user3', '3333', 3),
('user6', '6666', 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ProductId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
