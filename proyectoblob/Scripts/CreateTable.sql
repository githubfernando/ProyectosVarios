CREATE TABLE dbo.Project(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(300) NOT NULL,
Origin VARCHAR(200) NOT NULL
)


INSERT INTO [dbo].[Project]
           ([Name]
           ,[Origin])
     VALUES
           ('Nueva EPS'
           ,'PRED')

INSERT INTO [dbo].[Project]
           ([Name]
           ,[Origin])
     VALUES
           ('Sanitas'
           ,'FLASH')



INSERT INTO [dbo].[Project]
           ([Name]
           ,[Origin])
     VALUES
           ('PPL'
           ,'FLASH')



INSERT INTO [dbo].[Project]
           ([Name]
           ,[Origin])
     VALUES
           ('Mundial'
           ,'IQDOC')


CREATE TABLE dbo.ImageRouting(
Id INT PRIMARY KEY IDENTITY(1,1),
Route VARCHAR(300) NOT NULL,
Active BIT NOT NULL,
Id_Project INT FOREIGN KEY REFERENCES Project(Id)
)


INSERT INTO [dbo].[ImageRouting]
           ([Route]
           ,[Active]
           ,[Id_Project])
     VALUES
           ('C:\Users\OmarCC\Documents\TestImage'
           ,1
           ,1)

INSERT INTO [dbo].[ImageRouting]
           ([Route]
           ,[Active]
           ,[Id_Project])
     VALUES
           ('C:\Users\OmarCC\Documents\TestImage'
           ,1
           ,2)

INSERT INTO [dbo].[ImageRouting]
           ([Route]
           ,[Active]
           ,[Id_Project])
     VALUES
           ('C:\Users\OmarCC\Documents\TestImage'
           ,1
           ,3)

INSERT INTO [dbo].[ImageRouting]
           ([Route]
           ,[Active]
           ,[Id_Project])
     VALUES
           ('C:\Users\OmarCC\Documents\TestImage'
           ,1
           ,4)
