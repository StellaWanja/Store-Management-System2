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
-- Description:	Create procedure to help execute insert statements into stores table
-- =============================================
CREATE PROCEDURE INSERTINTOSTORESTABLE
	-- Add the parameters for the stored procedure here
	@storeName VARCHAR(120), @storeNumber VARCHAR(120), @storeType VARCHAR(120), @products INT, @userId INT
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO Stores VALUES(@storeName, @storeNumber, @storeType, @products, @userId);
END
GO
