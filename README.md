# Guestbook
A way to do guestbook by using c# in CRUD

## Database Design
```
 -- 留言板数据库SQL设计
 CREATE DATABASE `book` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
 USE book;
 -- 数据表及其字段
 CREATE TABLE message_book(
 	id int not null auto_increment,
 	time datetime not null DEFAULT NOW(),
 	name char(4) not null,
 	email char(15) not null,
 	content varchar(200) not null,
 	PRIMARY KEY(id)
 );
 -- 插入初始数据
 INSERT INTO message_book(name,email,content) VALUES("熊小飞","980382256@qq.com","Hello World！！！");
 -- 查询测试
 SELECT * FROM message_book;
```

## Architecture Design
> the project wpf1 is useless
> 
> the Page1 in wpf2 is useless
> 
* *MainWindow* is the program entrance
* *Window1* function is that  add record in database
Thanks for watching!
