
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
-- ===================================================
-- Sp(PutClients)
-- ===================================================
CREATE PROCEDURE PutClients
	@Accion VARCHAR(100),
	@cc BIGINT,
	@name VARCHAR(100),
	@address VARCHAR(100) = NULL,
	@phone1 BIGINT = NULL,
	@phone2 BIGINT = NULL,
	@reference VARCHAR(100) = NULL,
	@payment_method varchar(100) = NULL
AS
BEGIN
SET NOCOUNT ON;
	
	
	IF @Accion = 'PutClientsName'
	BEGIN 
		UPDATE clients
		SET name = @name
		WHERE cc = @cc
	END

	ELSE IF @Accion = 'PutAllClients'
	BEGIN
		UPDATE clients
		SET name=@name, 
		address=@address,
		phone1=@phone1,
		phone2=@phone2,
		reference=@reference,
		payment_method = @payment_method
		WHERE cc = @cc
	END
END
GO
-- ===================================================
-- Sp(DeleteClients)
-- ===================================================
CREATE PROCEDURE DeleteClients
	@Cc BIGINT
AS
BEGIN
	DELETE FROM clients
	WHERE cc = @Cc
END
GO

-- ===================================================
-- Sp(GetOrderAbout)
-- ===================================================
CREATE PROCEDURE GetOrderAbout
AS
BEGIN
	SELECT id, client_cc, hamburger_id, quantity, total_price, status, store_id, created_at FROM order_about
END
GO
-- ===================================================
-- Sp(GetOrderAboutId)
-- ===================================================
CREATE PROCEDURE GetOrderAboutId
	@id BIGINT
AS
BEGIN
	SELECT id, client_cc, hamburger_id, quantity, total_price, status, store_id, created_at FROM order_about
	WHERE id = @id
END
GO
-- ===================================================
-- Sp(PostOrderAbout)
-- ===================================================
CREATE PROCEDURE PostOrderAbout
	@id BIGINT,
	@client_cc BIGINT,
	@hamburger_id BIGINT,
	@quantity BIGINT,
	@total_price DECIMAL,
	@status VARCHAR(100),
	@store_id BIGINT
AS
BEGIN
	INSERT INTO order_about 
	(id,client_cc,hamburger_id,quantity,total_price,status,store_id,created_at) VALUES
	(@id,@client_cc,@hamburger_id,@quantity,@total_price,@status,@store_id,GETDATE())
END
GO

Execute.GetClients
Execute.GetClientsId @cc=1;
EXECUTE.PutClients @Accion = 'PutClientsName', @name = 'Sql Update', @cc =7;
EXECUTE.PutClients @Accion = 'PutAllClients', @cc=1,
@name = 'Update Name', @address = 'Update Address', @phone1 = 1, @phone2 = 2, 
@reference = 'Update Reference', @payment_method = 'Method Update';


EXECUTE GetOrderAbout
