```
author: 陈斌
date: 2022-05-30 23:16:12

```

C#大作业学生管理系统，Mysql数据库

数据库采用Mysql，数据库文件已放在文件目录 studentstatusmanagement.sql

文件运行请点击WinFormsApp1.sln文件，窗体中，不足的是连接数据库配置文件，在区域注释中（正确的做法是添加一个配置文件类，其他窗体调用配置文件），代码里折叠起来了，可展开

```
			#region 连接数据库
            //定义连接字符串
            string connStr = "Database=StudentStatusManagement;Data Source=127.0.0.1;port=3306;User Id=root;Password=password;";
            MySqlConnection conn = new MySqlConnection(connStr);//创建Connection对象
            conn.Open();//打开数据库
            #endregion  
```

数据库的地址密码不一样时，可Ctrl+F查找替换全部

本大作业只做了学生部分，其他身份并没有用



文件名解释

登录页面：login

登录等待页面：Index1

管理系统首页：Index

新建学生信息页面：Student

编辑学生信息页面：Iditstu

删除信息页面：Deletestu

在系统首页中有一个全局变量 public static string[] array = new string[100]非常重要注意理解其中意义，起到传值作用

编辑学生信息页面中也有个全局变量，并带有set方法，涉及到了页面之间的传值（传的学号id）



数据库表只用到了StudentTest表和User表

其他表可做延伸

建库代码，部分省略

```
CREATE TABLE IF NOT EXISTS StudentTest(
	studentId char(10) NOT NULL PRIMARY KEY,
	studentName char(15), 
	class char(15),
	birthday char(15),
	address char(50)	
)
#建用户表
CREATE TABLE IF NOT EXISTS USER(
	userId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	userName CHAR(20),
	userPassword CHAR(20)
)
```

