
-- ===================================================
-- Sp(GetClients)
-- ===================================================
CREATE PROCEDURE GetClients
AS
BEGIN 
SELECT cc,name,address,phone1,phone2,reference,payment_method FROM clients  
END 
GO

-- ===================================================
-- Sp(GetClientsId)
-- ===================================================
CREATE PROCEDURE GetClientsId
	@cc BIGINT
AS
BEGIN
	SELECT cc, name, address,phone1,phone2,reference,payment_method FROM clients
	WHERE cc = @cc
END
GO

-- ===================================================
-- Sp(PostClients)
-- ===================================================
CREATE PROCEDURE PostClients
	@cc BIGINT, @name VARCHAR(100), @address VARCHAR(100), @phone1 BIGINT, @phone2 BIGINT,
	@reference VARCHAR(100), @payment_method varchar(100)
AS
BEGIN
	INSERT INTO clients (cc, name,address,phone1,phone2,reference,payment_method)
	VALUES
	(@cc,@name,@address,@phone1,@phone2,@reference,@payment_method);
END
GO

Execute.GetClients
Execute.GetClientsId @cc = 4;
EXECUTE PostClients 
	@cc=1, @name=Cliente1,@address=Address1,@phone1=1,
	@phone2=1,@reference=Addres1,@payment_method=Credit1
