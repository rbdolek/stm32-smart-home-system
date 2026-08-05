USE arayuz;
GO

INSERT INTO dbo.kayit_tbl
(user_name,password,name,last_name,mail)

VALUES
('admin','123456','Rabia','Dölek','rabia@example.com');

INSERT INTO dbo.Temperature_tbl
(Room,Temperature)

VALUES
('Living Room',24.8),
('Kitchen',25.3),
('Bedroom',23.7),
('Children Room',24.1);