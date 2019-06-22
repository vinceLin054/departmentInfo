/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50725
Source Host           : localhost:3306
Source Database       : departmental_manage_system

Target Server Type    : MYSQL
Target Server Version : 50725
File Encoding         : 65001

Date: 2019-06-22 09:41:22
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for department
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `admin` varchar(20) NOT NULL,
  `admin_id` varchar(20) DEFAULT NULL,
  `activated` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `department_ibfk_1` (`admin_id`),
  CONSTRAINT `department_ibfk_1` FOREIGN KEY (`admin_id`) REFERENCES `user` (`username`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of department
-- ----------------------------
INSERT INTO `department` VALUES ('2', '信息部', '小红', 'lisi', '1');
INSERT INTO `department` VALUES ('3', '艺术部', '小绿', 'lisi', '1');
INSERT INTO `department` VALUES ('7', '生活部', '张三', 'linhao', '1');
INSERT INTO `department` VALUES ('8', '财务部', '李四', 'linhao', '1');
INSERT INTO `department` VALUES ('11', '生活部', '李四', 'lisi', '0');

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `sex` varchar(2) NOT NULL,
  `position` varchar(20) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `department_id` int(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `department_id` (`department_id`),
  CONSTRAINT `member_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `department` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of member
-- ----------------------------
INSERT INTO `member` VALUES ('8', '张四', '男', '干事', '13123123123', '3');
INSERT INTO `member` VALUES ('9', '张五', '男', '副部长', '1321321321321', '3');
INSERT INTO `member` VALUES ('10', '张六', '男', '干事', '1321321313213', '3');
INSERT INTO `member` VALUES ('11', '张七', '男', '干事', '1321321313213', '3');
INSERT INTO `member` VALUES ('12', '张八', '男', '干事', '1321321313213', '3');
INSERT INTO `member` VALUES ('14', '李一', '男', '干事', '13123123123', '2');
INSERT INTO `member` VALUES ('15', '李二', '女', '副部长', '1321321321321', '2');
INSERT INTO `member` VALUES ('16', '李三', '女', '干事', '1321321313213', '2');
INSERT INTO `member` VALUES ('17', '李五', '女', '干事', '1321321313213', '2');
INSERT INTO `member` VALUES ('18', '李六', '男', '干事', '1321321313213', '2');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `username` varchar(20) NOT NULL,
  `password` varchar(16) NOT NULL,
  `authority` varchar(2) NOT NULL,
  `activated` varchar(1) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('linhao', '123', '1', '1');
INSERT INTO `user` VALUES ('lisi', '123', '1', '1');
INSERT INTO `user` VALUES ('root', '123', '0', '1');
INSERT INTO `user` VALUES ('wangwu', '123', '1', '0');
