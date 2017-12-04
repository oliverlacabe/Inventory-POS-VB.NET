-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 22, 2014 at 04:05 PM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `godblesspos`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE IF NOT EXISTS `account` (
  `emp_ID` varchar(20) DEFAULT NULL,
  `emp_uNAme` mediumtext,
  `emp_Pass` mediumtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`emp_ID`, `emp_uNAme`, `emp_Pass`) VALUES
('L042014OP', 'Hÿo®oG2´WõùŠ„c', '‚w\rˆÀ©æ¢¯´B+'),
('L042014OP', 'Hÿo®oG2´WõùŠ„c', '‚w\rˆÀ©æ¢¯´B+'),
('M092014KG', 'ŠñctZê®o½,ÄxOê', 'gXE­Èuh*‰/‚y—*™É'),
('2014-G0904CT', 'xºÎÛ7D÷H#K¬¤Ð', '†V®æÐ‹UúUÿÃG°J');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `cat_ID` int(11) NOT NULL AUTO_INCREMENT,
  `cat_name` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`cat_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`cat_ID`, `cat_name`) VALUES
(1, 'Food and Beverage'),
(2, 'Can goods'),
(3, 'Appliances'),
(4, 'Dairy Products');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE IF NOT EXISTS `employees` (
  `emp_id` varchar(20) NOT NULL,
  `emp_Fname` varchar(20) DEFAULT NULL,
  `emp_Mname` varchar(20) DEFAULT NULL,
  `emp_Lname` varchar(20) DEFAULT NULL,
  `emp_Bdate` varchar(20) DEFAULT NULL,
  `emp_DateHire` varchar(20) DEFAULT NULL,
  `emp_Address` varchar(100) DEFAULT NULL,
  `emp_PosID` int(11) DEFAULT NULL,
  `emp_pic` varchar(20) DEFAULT NULL,
  `emp_Gender` varchar(6) DEFAULT NULL,
  PRIMARY KEY (`emp_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`emp_id`, `emp_Fname`, `emp_Mname`, `emp_Lname`, `emp_Bdate`, `emp_DateHire`, `emp_Address`, `emp_PosID`, `emp_pic`, `emp_Gender`) VALUES
('2014-G0904CT', 'CRISTINE', 'TUALLA', 'GAYAS', '9/4/1994', '3/21/2014', 'JARO', 1, '2014-G0904CT.jpg', 'Female'),
('L042014OP', 'OLIVER', 'PELENIO', 'LACABE', '4/25/1991', '3/21/2014', 'SAN MIGUEL', 1, 'L042014OP.jpg', 'Male'),
('M092014KG', 'KIMBERLY', 'GOBANGCO', 'MORENO', '9/6/1991', '3/21/2014', 'DULAG', 2, 'M092014KG.jpg', 'Female');

-- --------------------------------------------------------

--
-- Table structure for table `emppos`
--

CREATE TABLE IF NOT EXISTS `emppos` (
  `PosID` int(11) NOT NULL AUTO_INCREMENT,
  `PosName` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`PosID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `emppos`
--

INSERT INTO `emppos` (`PosID`, `PosName`) VALUES
(1, 'Administrator'),
(2, 'Cashier');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `prod_code` varchar(20) DEFAULT NULL,
  `prod_cat` varchar(30) DEFAULT NULL,
  `prod_name` varchar(30) DEFAULT NULL,
  `prod_price` decimal(10,2) DEFAULT NULL,
  `prod_stock` int(11) DEFAULT NULL,
  PRIMARY KEY (`PID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`PID`, `prod_code`, `prod_cat`, `prod_name`, `prod_price`, `prod_stock`) VALUES
(1, '6666666666666', '1', 'Red Horse', 65.50, 100),
(2, '3333333333333', '3', 'Karaoke', 1999.95, 30),
(3, '7777777777777', '2', 'Youngs Town Sardines', 18.00, 200),
(4, '4444444444444', '2', 'Lucky 777', 13.00, 50),
(5, '2222222222222', '3', 'DVD', 500.00, 20),
(6, '5555555555555', '1', 'Lucky Me Instant Noodles', 7.00, 200),
(7, '1111111111111', '2', 'Argentina Corned Beef', 20.95, 40),
(8, '8888888888888', '4', 'Eden Cheese', 50.50, 200),
(9, '2625462546235', '3', 'TV', 1000.00, 5),
(10, '6725426472424', '4', 'Bear Brand', 20.00, 120);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
