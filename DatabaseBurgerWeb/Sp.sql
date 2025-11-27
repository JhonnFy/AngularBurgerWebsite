
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
-- ===================================================
-- Sp(PutOrderAbout)
-- ===================================================
CREATE PROCEDURE PutOrderAbout
	@id BIGINT,
	@quantity BIGINT,
	@total_price DECIMAL,
	@status VARCHAR(100)
AS
BEGIN
	UPDATE order_about
	SET  quantity=@quantity,total_price=@total_price,status=@status
	WHERE id = @id
END
GO

-- ===================================================
-- Sp(GetContact)
-- ===================================================
CREATE PROCEDURE GetContact
AS
BEGIN
	SELECT id, name, address, phone FROM contact
END
GO

-- ===================================================
-- Sp(GetContactId)
-- ===================================================
CREATE PROCEDURE GetContactId
	@id BIGINT
AS
BEGIN
	SELECT id, name, address, phone FROM contact
	WHERE id = @id
END
GO

-- ===================================================
-- Sp(PostContact)
-- ===================================================
CREATE PROCEDURE PostContact
	@id BIGINT,
	@name VARCHAR(100),
	@address VARCHAR(100),
	@phone BIGINT
AS
BEGIN
	INSERT INTO contact (id,name,address,phone)
	VALUES
	(@id,@name,@address,@phone)
END
GO

-- ===================================================
-- Sp(PutContact)
-- ===================================================
CREATE PROCEDURE PutContact
	@id BIGINT,
	@name VARCHAR(100),
	@address VARCHAR(100),
	@phone BIGINT
AS
BEGIN
	UPDATE contact
	SET name = @name, address = @address, phone = @phone
	WHERE id = @id
END
GO
-- ===================================================
-- Sp(DeleteContact)
-- ===================================================
CREATE PROCEDURE DeleteContact
	@id BIGINT
AS
BEGIN
	DELETE contact 
	WHERE id = @id
END
GO
-- ===================================================
-- Sp(GetMenuHamburger)
-- ===================================================
CREATE PROCEDURE GetMenuHamburger
AS
BEGIN
	SELECT id, name FROM menuHamburger
END
GO
-- ===================================================
-- Sp(GetMenuHamburgerId)
-- ===================================================
CREATE PROCEDURE GetMenuHamburgerId
	@id BIGINT
AS
BEGIN
	SELECT id, name FROM menuHamburger
	WHERE id = @id
END
GO
-- ===================================================
-- Sp(PostMenuHamburger)
-- ===================================================
CREATE PROCEDURE PostMenuHamburger
	@id BIGINT,
	@name VARCHAR(100)
AS
BEGIN
	INSERT INTO MenuHamburger (id, name) 
	VALUES
	(@id,@name)
END
GO
-- ===================================================
-- Sp(PutmenuHamburger)
-- ===================================================
CREATE PROCEDURE PutmenuHamburger
	@id BIGINT,
	@name VARCHAR(100)
AS
BEGIN
	UPDATE menuHamburger
	SET name = @name
	WHERE id = @id
END
GO
-- ===================================================
-- Sp(DeleteMenuHamburger)
-- ===================================================
CREATE PROCEDURE DeleteMenuHamburger 
	@id BIGINT
AS
BEGIN
	DELETE FROM MenuHamburger
	WHERE id = @id
END
GO
-- ===================================================
-- Sp(GetMenuHamburger)
-- ===================================================
CREATE PROCEDURE GetaboutHamburger
AS
BEGIN
	SELECT id,name FROM aboutHamburger
END
GO
-- ===================================================
-- Sp(GetMenuHamburgerId)
-- ===================================================
CREATE PROCEDURE GetaboutHamburgerId
	@id BIGINT
AS
BEGIN
	SELECT id,name FROM aboutHamburger
	WHERE id = @id
END
GO




Execute.GetClients
Execute.GetClientsId @cc=1;
EXECUTE.PutClients @Accion = 'PutClientsName', @name = 'Sql Update', @cc =7;
EXECUTE.PutClients @Accion = 'PutAllClients', @cc=1,
@name = 'Update Name', @address = 'Update Address', @phone1 = 1, @phone2 = 2, 
@reference = 'Update Reference', @payment_method = 'Method Update';
EXECUTE GetOrderAbout
