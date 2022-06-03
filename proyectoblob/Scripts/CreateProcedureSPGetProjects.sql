CREATE PROCEDURE dbo.SPGetProjects
AS
BEGIN
SELECT [Id]
      ,[Name]
      ,[Origin]
  FROM [dbo].[Project]
END

