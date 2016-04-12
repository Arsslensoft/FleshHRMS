-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Mar 12 Avril 2016 à 11:32
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `fhrms`
--

-- --------------------------------------------------------

--
-- Structure de la table `employees`
--

CREATE TABLE IF NOT EXISTS `employees` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Department` int(11) NOT NULL DEFAULT '0',
  `Title` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Status` int(11) NOT NULL DEFAULT '0',
  `HireDate` datetime DEFAULT '0000-00-00 00:00:00',
  `PersonalProfile` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `FirstName` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Prefix` int(11) NOT NULL DEFAULT '0',
  `HomePhone` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `MobilePhone` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Email` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Skype` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `BirthDate` datetime DEFAULT '0000-00-00 00:00:00',
  `PictureId` int(11) DEFAULT '0',
  `Address_Line` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `Address_City` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `Address_State` int(11) NOT NULL DEFAULT '0',
  `Address_ZipCode` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `Role` int(2) NOT NULL DEFAULT '0',
  `CIN` varchar(8) NOT NULL,
  `LeaveCredit` int(8) NOT NULL DEFAULT '0',
  `LateCredit` int(11) NOT NULL DEFAULT '0',
  `Salary` float NOT NULL DEFAULT '0',
  `Credential_PasswordHash` varchar(64) NOT NULL,
  `Credential_Username` varchar(20) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `employees`
--

INSERT INTO `employees` (`Id`, `Department`, `Title`, `Status`, `HireDate`, `PersonalProfile`, `FirstName`, `LastName`, `Prefix`, `HomePhone`, `MobilePhone`, `Email`, `Skype`, `BirthDate`, `PictureId`, `Address_Line`, `Address_City`, `Address_State`, `Address_ZipCode`, `Role`, `CIN`, `LeaveCredit`, `LateCredit`, `Salary`, `Credential_PasswordHash`, `Credential_Username`) VALUES
(1, 4, 'Engineering Student', 0, '2016-03-18 00:00:00', 'EA', 'Arsslen', 'Idadi', 0, '+216 53299093', '+216 53299093', 'arsslens021@gmail.com', NULL, '1995-11-24 00:00:00', 0, '07 Rue Yogoslavie', 'La Marsa', 22, '2070', 2, '15002060', 365, 0, 756, '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'arsslen'),
(2, 0, 'Engineer', 4, NULL, NULL, 'Laouini', 'Ahmed', 0, NULL, '+216 55555555', 'a@aa.aaa', NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, '00000000', 0, 0, 0, '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'ahmed'),
(3, 7, 'ENGINEER', 1, '2016-03-20 00:00:00', NULL, 'Troudi', 'Amine', 0, NULL, '+216 53333333', 'a@aaa.dsz', NULL, '1995-03-20 00:00:00', NULL, '', NULL, 22, '1027', 1, '15000000', 78, 0, 6589, '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'amine'),
(4, 6, 'Egineer', 3, '2015-03-19 00:00:00', NULL, 'Ferjani', 'Khaled', 0, NULL, '+216 55555555', 'aa@aa.aez', NULL, '1995-02-20 00:00:00', NULL, NULL, NULL, 12, '7777', 0, '15444444', 12, 0, 4578, '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'khaled');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
