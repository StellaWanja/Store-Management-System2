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
-- Description:	Create procedure to help execute insert statements into users table
-- =============================================
CREATE PROCEDURE INSERTINTOUSERSTABLE
	-- Add the parameters for the stored procedure here
	@firstName VARCHAR(120), @lastName VARCHAR(120), @email VARCHAR(120), @userPassword VARCHAR(20)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO Users VALUES(@firstName, @lastName, @email, @userPassword);
END
GO
