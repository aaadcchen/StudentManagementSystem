/*
Navicat MySQL Data Transfer

Source Server         : Student
Source Server Version : 80028
Source Host           : localhost:3306
Source Database       : studentstatusmanagement

Target Server Type    : MYSQL
Target Server Version : 80028
File Encoding         : 65001

Date: 2022-05-29 20:37:56
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for class
-- ----------------------------
DROP TABLE IF EXISTS `class`;
CREATE TABLE `class` (
  `classId` char(10) NOT NULL,
  `className` char(10) DEFAULT NULL,
  `classCount` char(10) DEFAULT NULL,
  `classExplain` char(30) DEFAULT NULL,
  `teacher` char(10) DEFAULT NULL,
  `majorId` char(10) DEFAULT NULL,
  PRIMARY KEY (`classId`),
  KEY `majorId` (`majorId`),
  CONSTRAINT `class_ibfk_1` FOREIGN KEY (`majorId`) REFERENCES `major` (`majorId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of class
-- ----------------------------

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course` (
  `courseId` char(10) NOT NULL,
  `courseGrade` char(10) DEFAULT NULL,
  `courseName` char(10) DEFAULT NULL,
  `courseExplain` char(30) DEFAULT NULL,
  PRIMARY KEY (`courseId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of course
-- ----------------------------

-- ----------------------------
-- Table structure for major
-- ----------------------------
DROP TABLE IF EXISTS `major`;
CREATE TABLE `major` (
  `majorId` char(10) NOT NULL,
  `majorName` char(10) DEFAULT NULL,
  `majorExplain` char(30) DEFAULT NULL,
  PRIMARY KEY (`majorId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of major
-- ----------------------------

-- ----------------------------
-- Table structure for student
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student` (
  `studentId` char(10) NOT NULL,
  `studentName` char(10) DEFAULT NULL,
  `sex` char(10) DEFAULT NULL,
  `age` char(10) DEFAULT NULL,
  `studentExplain` char(30) DEFAULT NULL,
  `classId` char(10) DEFAULT NULL,
  PRIMARY KEY (`studentId`),
  KEY `classId` (`classId`),
  CONSTRAINT `student_ibfk_1` FOREIGN KEY (`classId`) REFERENCES `class` (`classId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of student
-- ----------------------------
INSERT INTO `student` VALUES ('01', '01', '男', '18', '131321', null);
INSERT INTO `student` VALUES ('02', '02', '女', '17', '13321', null);
INSERT INTO `student` VALUES ('03', '03', '男', '16', '53434', null);

-- ----------------------------
-- Table structure for studenttest
-- ----------------------------
DROP TABLE IF EXISTS `studenttest`;
CREATE TABLE `studenttest` (
  `studentId` char(10) NOT NULL,
  `studentName` char(15) DEFAULT NULL,
  `class` char(15) DEFAULT NULL,
  `birthday` char(15) DEFAULT NULL,
  `address` char(50) DEFAULT NULL,
  PRIMARY KEY (`studentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of studenttest
-- ----------------------------
INSERT INTO `studenttest` VALUES ('001', '张三', '1', '2313', '231');
INSERT INTO `studenttest` VALUES ('002', '陈斌', '232', '321', '');
INSERT INTO `studenttest` VALUES ('003', '王五', '2', '2001.01.01', '');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `userId` int NOT NULL AUTO_INCREMENT,
  `userName` char(20) DEFAULT NULL,
  `userPassword` char(20) DEFAULT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', '213', '123456');
INSERT INTO `user` VALUES ('2', '陈斌', '123456');
INSERT INTO `user` VALUES ('3', '123', '123');
