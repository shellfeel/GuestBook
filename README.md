# Guestbook
A way to do guestbook by using c# in CRUD

## Database Design
```
 -- GuestbookSQL design
 CREATE DATABASE `book` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
 USE book;
 -- table and the column
 CREATE TABLE message_book(
 	id int not null auto_increment,
 	time datetime not null DEFAULT NOW(),
 	name char(4) not null,
 	email char(15) not null,
 	content varchar(200) not null,
 	PRIMARY KEY(id)
 );
 -- insert the init data
 INSERT INTO message_book(name,email,content) VALUES("熊小飞","980382256@qq.com","Hello World！！！");
 -- query test
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
