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
('������','������ ��������)'),
('����������','������ ��������)'),
('�������','������ ��������)'),
('������������','������ ��������)'),
('�������','������ ��������)'),
('���','������ ��������)'),
('�����','������ ��������)'),
('������','������ ��������)'),
('�����������','�������� �-�����'),
('��-������� �������','�������� �-�����'),
('���� �������','�������� �-�����'),
('�����','�������� �-�����'),
('��� ����?','� ���� ��� �������, � �� ���)'),
('����� �����','��� �� �� ������');
go

select [Answer] from [Message] where Lower([message]) like '%�����%' 
go
drop table [Message]