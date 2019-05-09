-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 10, 2018 at 04:04 AM
-- Server version: 10.1.35-MariaDB
-- PHP Version: 7.2.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project2`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `First_Name` varchar(25) NOT NULL,
  `Last_Name` varchar(25) NOT NULL,
  `Email` varchar(30) NOT NULL,
  `Phone_Number` varchar(15) NOT NULL,
  `Password` varchar(25) NOT NULL,
  `RegID` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`First_Name`, `Last_Name`, `Email`, `Phone_Number`, `Password`, `RegID`) VALUES
('Ashraf', 'Patel', '4shr4f@live.co.uk', '905111111111', 'admin', '4shr4f5c09849d611f3'),
('admin', 'admin', 'admin@admin.com', 'admin', 'admin', 'admin123'),
('Ashraf', 'Patel', 'derdsgs', 'gsgtsgds', 'sgdsgfsdgdes', 'derdsgs5c0c13bd0e028'),
('Harpreet', 'Gill', 'hgill@gmail.com', 'dfsgdfsg', 'hgill', 'fhdhddsgf'),
('yhubvehbuvh', 'dfdfgd', 'sgsgsdg', 'gsgddsdfs', 'gssdgsdgsdg', 'gdgdf'),
('sdfgdfsgfdsf', 'fsdgfsdgfsd', 'gsdfgfsddg', 'gsfddgfsdg', 'sgdsdfgfdsfgfd', 'gdsfgfdsgsdfgds'),
('dgsfdsgfsdfgd', 'gsdfgsdfgf', 'gdsfgfsdgfs', 'gfdsfgffdsfg', 'sgdfdsdfgfgf', 'gdsgdfsgfsdgf'),
('sdgsdgdsggdssd', 'gsdgsdgsg', 'sdgsdgsgdg', 'sdgdsgsdgds', 'gsdgsdgdsgd', 'gsdgsdgsdgsd'),
('dgssddsggdssd', 'sdgsdsddsgds', 'sdfdsfsddfs', 'dsfdssdfsdf', 'sfddssdfsdf', 'sdgsdfsgdsd'),
('sdgsdg', 'sdgsdgsdsgdd', 'sdgdssdgdssdg', 'sgdsdgdsg', 'sdggdsgsdgsd', 'sgsdgsdg'),
('yjtyjyt', 'jtjtyjy', 'tjtyjtjtyjt', 'yjtyjtyjtyj', 'tjtjtyyjtj', 'yktykytt');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`RegID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
