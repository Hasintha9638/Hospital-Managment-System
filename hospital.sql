-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 23, 2019 at 06:04 AM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospital`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` varchar(30) NOT NULL,
  `first_name` varchar(30) DEFAULT NULL,
  `last_name` varchar(30) DEFAULT NULL,
  `date_of_appointment` date DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `contact_no` varchar(20) DEFAULT NULL,
  `password` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `first_name`, `last_name`, `date_of_appointment`, `address`, `contact_no`, `password`) VALUES
('', '', '', '2019-09-21', '', '', ''),
('admin01', 'hasintha', 'ranaweera', '2019-09-23', 'Pullayara Junction;\r\nA track\r\nPadaviya', '0773143831', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `id` int(20) NOT NULL,
  `std_id` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `note` varchar(500) DEFAULT NULL,
  `completed` varchar(10) DEFAULT 'no'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`id`, `std_id`, `date`, `time`, `note`, `completed`) VALUES
(27, 'gdfgdf', '2019-09-21', '02:15:00', 'fdgdfg', 'yes'),
(29, 'fdgfdg', '2019-09-21', '23:55:00', 'fdgdfg', 'yes'),
(30, '13213', '2019-09-21', '00:00:00', '213213213', 'yes'),
(34, 'cvcxv', '2019-09-22', '00:20:00', 'cxvxzzzzzzzzzzzzzzzzzzzzzzzz', 'yes'),
(35, 'gtfhgf', '2019-09-23', '04:15:00', 'gfhf', 'yes'),
(36, 'hgjghj', '2019-09-23', '01:15:00', 'hgggggggggggggggj', 'yes'),
(37, 'fghg', '2019-09-23', '01:15:00', 'gfdhg', 'yes'),
(38, 'sadd', '2019-09-23', '12:30:00', 'asddd', 'yes'),
(39, 'sd?d', '2019-09-23', '12:30:00', 'sd?d', 'yes'),
(40, 'sa', '2019-09-23', '12:30:00', 'ds', 'yes'),
(41, 'fxbcvcb', '2019-09-23', '03:15:00', 'vcccccccccccb', 'yes'),
(42, 'vcb', '2019-09-23', '03:15:00', 'cvvvvvvvvvb', 'yes'),
(43, 'vb', '2019-09-23', '03:15:00', 'vvvvxxb', 'yes'),
(44, 'vxcbxc', '2019-09-23', '03:15:00', 'vcxxxxxxxxxxxxx', 'yes');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `id` varchar(20) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `date_of_appointment` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `contact_no` varchar(20) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`id`, `first_name`, `last_name`, `date_of_appointment`, `address`, `contact_no`, `password`) VALUES
('', '', '', '2019-09-21', '', '', ''),
('d1095', 'prasad', 'siriwardana', '2016-06-07', 'no 21,kadawatha road,colombo 3', '0754297456', ''),
('d1234', 'kamal', 'subasinha', '1981-06-06', 'no 56 gampaha road, colombo 2', '077724674', ''),
('d5410', 'kapila', 'nirmal', '2017-06-07', 'no 23,kiribathgoda road,colombo 3', '0754294635', ''),
('d5687', 'nihal', 'gamage', '2018-06-07', 'no 36,trincomalle road,haputhale', '0776345297', ''),
('d6715', 'charitha', 'dissanayake', '2017-06-05', 'no 03,gampaha road,colombo 3', '0706745230', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `drug`
--

CREATE TABLE `drug` (
  `id` int(20) NOT NULL,
  `item_id` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `exp` date NOT NULL,
  `qty` int(10) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drug`
--

INSERT INTO `drug` (`id`, `item_id`, `name`, `exp`, `qty`) VALUES
(27, 'DV001', 'A vitamin', '2020-09-20', 950),
(28, 'DV002', 'B-Vitamin', '2020-09-22', 975),
(29, 'DV003', 'C-vitamin', '2020-09-20', 980),
(30, 'DV004', 'D-vitamin', '2020-09-20', 930),
(31, 'DV005', 'E-vitamin', '2020-09-20', 940),
(32, 'DP001', 'Panadol', '2019-08-01', 425);

-- --------------------------------------------------------

--
-- Table structure for table `drug_issue`
--

CREATE TABLE `drug_issue` (
  `order_id` int(11) NOT NULL,
  `std_id` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `drugs` varchar(800) NOT NULL,
  `no_of_days` varchar(50) DEFAULT '3 days',
  `drug_issued` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drug_issue`
--

INSERT INTO `drug_issue` (`order_id`, `std_id`, `date`, `drugs`, `no_of_days`, `drug_issued`) VALUES
(34, 'cvcxv', '2019-09-22', 'A vitamin,5,B-Vitamin,5,', '28 Days', 'yes'),
(35, 'cvcxv', '2019-09-22', 'B-Vitamin,5,', '26 Days', 'no'),
(36, 'cvcxv', '2019-09-22', 'D-vitamin,5,', '28 Days', 'no'),
(37, 'cvcxv', '2019-09-22', 'B-Vitamin,5,C-vitamin,5,', '28 Days', 'no'),
(38, 'gtfhgf', '2019-09-23', 'C-vitamin,5,D-vitamin,5,', '27 Days', 'yes'),
(39, 'hgjghj', '2019-09-23', 'D-vitamin,5,Panadol,5,', '28 Days', 'yes'),
(40, 'fghg', '2019-09-23', 'Panadol,5,E-vitamin,5,', '02 Days', 'yes'),
(41, 'sadd', '2019-09-23', 'B-Vitamin,5,C-vitamin,5,', '25 Days', 'yes'),
(42, 'sd?d', '2019-09-23', 'D-vitamin,55,', '03 Days', 'yes'),
(43, 'sa', '2019-09-23', 'B-Vitamin,5,Panadol,5,', '', 'yes'),
(44, 'fxbcvcb', '2019-09-23', 'C-vitamin,5,Panadol,5,', '27 Days', 'yes'),
(45, 'vcb', '2019-09-23', 'E-vitamin,55,', '', 'yes'),
(46, 'vb', '2019-09-23', 'Panadol,555,', '', 'yes'),
(47, 'vxcbxc', '2019-09-23', '', '', 'yes');

-- --------------------------------------------------------

--
-- Table structure for table `feedback`
--

CREATE TABLE `feedback` (
  `id` int(11) NOT NULL,
  `std_id` varchar(30) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `message` varchar(500) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `medical_history`
--

CREATE TABLE `medical_history` (
  `id` int(11) NOT NULL,
  `std_id` varchar(30) NOT NULL,
  `diagnostic` varchar(500) NOT NULL,
  `drug` varchar(800) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `medical_history`
--

INSERT INTO `medical_history` (`id`, `std_id`, `diagnostic`, `drug`, `date`) VALUES
(29, 'gtfhgf', 'gfhf', 'C-vitamin,5,D-vitamin,5,', '2019-09-23'),
(30, 'hgjghj', 'hgggggggggggggggj', 'D-vitamin,5,Panadol,5,', '2019-09-23'),
(31, 'fghg', 'gfdhg', 'Panadol,5,E-vitamin,5,', '2019-09-23'),
(32, 'sadd', 'asddd', 'B-Vitamin,5,C-vitamin,5,', '2019-09-23'),
(33, 'sd?d', '', 'D-vitamin,55,', '2019-09-23'),
(34, 'sa', 'ds', 'B-Vitamin,5,Panadol,5,', '2019-09-23'),
(35, 'fxbcvcb', 'vcccccccccccb', 'C-vitamin,5,Panadol,5,', '2019-09-23'),
(37, 'vb', '', 'Panadol,555,', '2019-09-23');

-- --------------------------------------------------------

--
-- Table structure for table `pharmasist`
--

CREATE TABLE `pharmasist` (
  `id` varchar(30) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `date_of_appointment` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `contact_no` varchar(20) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pharmasist`
--

INSERT INTO `pharmasist` (`id`, `first_name`, `last_name`, `date_of_appointment`, `address`, `contact_no`, `password`) VALUES
('', '', '', '2019-09-21', '', '', ''),
('p7855', 'anushka', 'gamage', '1999-06-07', 'no 4,haldaduwana road,colombo 4', '0754874523', '0'),
('p9753', 'chathura', 'galapatha', '1998-06-07', 'no 98,hambanthota, kandy', '0754329875', '0'),
('p9988', 'gihani', 'sammani', '1997-06-07', 'no 56,dabulla road, kandy', '0786345234', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `id` varchar(20) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `date_of_birth` date NOT NULL,
  `address` varchar(200) NOT NULL,
  `contact_no` varchar(20) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `first_name`, `last_name`, `date_of_birth`, `address`, `contact_no`, `password`) VALUES
('', '', '', '2019-09-21', '', '', ''),
('s2345', 'chamath', 'lakmuthu', '1996-06-07', 'no 56,meegamu road, halawatha.', '0762396436', ''),
('s2876', 'saman', 'kumara', '1994-06-07', 'no 34,ballapana road,kurunegala', '0786543297', ''),
('s2996', 'lakmal', 'kumara', '1996-06-07', 'no 36,kdawatha road,kiribathgoda', '0756563297', ''),
('s3356', 'darshana', 'nadeera', '1995-06-07', 'no 9,dambulla road,trincomalee', '0712356893', ''),
('s3456', 'nisith', 'heshan', '2019-06-10', 'gampaha', '0876543216', ''),
('s5056', 'nisith', 'heshan', '1995-06-29', '80/6 ,veyangoda road,naiwala', '0718136893', '1234');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `drug`
--
ALTER TABLE `drug`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `drug_issue`
--
ALTER TABLE `drug_issue`
  ADD PRIMARY KEY (`order_id`);

--
-- Indexes for table `feedback`
--
ALTER TABLE `feedback`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `medical_history`
--
ALTER TABLE `medical_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pharmasist`
--
ALTER TABLE `pharmasist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointment`
--
ALTER TABLE `appointment`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;
--
-- AUTO_INCREMENT for table `drug`
--
ALTER TABLE `drug`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;
--
-- AUTO_INCREMENT for table `drug_issue`
--
ALTER TABLE `drug_issue`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;
--
-- AUTO_INCREMENT for table `feedback`
--
ALTER TABLE `feedback`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `medical_history`
--
ALTER TABLE `medical_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
