CREATE PROCEDURE dbo.SPGetRoutes
(
@IdProject INT 
)
AS
BEGIN
SELECT [Id],
	   [Route],
	   [Active],
	   [Id_Project]
  FROM [dbo].[ImageRouting] WHERE [Id_Project] = @IdProject
END

