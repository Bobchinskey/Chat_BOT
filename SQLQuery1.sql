Create DataBase Chat_Bot
go
Use Chat_Bot
go

Create Table [Message]
(
[id_message] int NOT NULL IDENTITY(1,1),
[message] varchar(255) NOT NULL,
[Answer] varchar(255) NOT NULL,
primary key([id_message])
);
go

Insert into [Message]
values
('Привет','Привет солнышко)'),
('Здравствуй','Привет солнышко)'),
('Здорова','Привет солнышко)'),
('Здравствуйте','Привет солнышко)'),
('Здарова','Привет солнышко)'),
('Хай','Привет солнышко)'),
('Шалом','Привет солнышко)'),
('Превет','Привет солнышко)'),
('асамалейкум','Аляйкуму с-салям'),
('Ас-саляяму алейкум','Аляйкуму с-салям'),
('Асам Алейкум','Аляйкуму с-салям'),
('Салам','Аляйкуму с-салям'),
('Как дела?','У меня все отлично, я же бот)'),
('Пошла нахуй','Мда ну ты попуск');
go

select [Answer] from [Message] where Lower([message]) like '%салам%' 
go
drop table [Message]