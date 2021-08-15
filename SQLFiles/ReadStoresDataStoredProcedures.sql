-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stella Njoroge
-- Create date: 13/8/2021
-- Description:	Create procedure to help read statements from stores table
-- =============================================
CREATE PROCEDURE READDATAFROMSTORESTABLE
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * FROM Stores;
END
GO

