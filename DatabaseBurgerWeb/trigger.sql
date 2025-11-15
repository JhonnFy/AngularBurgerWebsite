

USE BurgerWeb
GO

-- ===================================================
-- TRIGGER PARA PEDIDOS DE VENTA FÍSICA (order_menu)
-- ===================================================
CREATE TRIGGER trg_order_menu_insert
ON order_menu
AFTER INSERT
AS
BEGIN
    INSERT INTO blogs (
        order_id,
        order_type,
        client_cc,
        hamburger_name,
        quantity,
        total_price,
        payment_method,
        store_name,
        status,
        created_at
    )
    SELECT 
        i.id,
        'menu',                           -- tipo de pedido
        c.cc,
        m.name,
        i.quantity,
        i.total_price,
        c.payment_method,
        s.name,
        i.status,
        i.created_at
    FROM inserted i
    INNER JOIN clients c ON i.client_cc = c.cc
    INNER JOIN menuHamburger m ON i.hamburger_id = m.id
    INNER JOIN contact s ON i.store_id = s.id;
END;
GO

-- ===================================================
-- TRIGGER PARA PEDIDOS DE VENTA A DOMICILIO (order_about)
-- ===================================================
CREATE TRIGGER trg_order_about_insert
ON order_about
AFTER INSERT
AS
BEGIN
    INSERT INTO blogs (
        order_id,
        order_type,
        client_cc,
        hamburger_name,
        quantity,
        total_price,
        payment_method,
        store_name,
        status,
        created_at
    )
    SELECT 
        i.id,
        'about',                          -- tipo de pedido
        c.cc,
        m.name,
        i.quantity,
        i.total_price,
        c.payment_method,
        s.name,
        i.status,
        i.created_at
    FROM inserted i
    INNER JOIN clients c ON i.client_cc = c.cc
    INNER JOIN aboutHamburger m ON i.hamburger_id = m.id
    INNER JOIN contact s ON i.store_id = s.id;
END;
GO
