
USE BurgerWeb

-- ==============================
-- TRIGGERS SQL SERVER
-- ==============================

-- Trigger para insertar en blogs al registrar order_menu
CREATE TRIGGER trg_order_menu_insert
ON order_menu
AFTER INSERT
AS
BEGIN
    INSERT INTO blogs (order_type, order_id, client_name, client_cc, store_name, product_name, quantity, total_price, status, created_at)
    SELECT 
        'menu',
        i.id,
        c.name,
        i.client_cc,
        s.name,
        m.name,
        i.quantity,
        i.total_price,
        i.status,
        i.created_at
    FROM inserted i
    JOIN clients c ON c.cc = i.client_cc
    JOIN stores s ON s.id = i.store_id
    JOIN menu m ON m.id = i.menu_id
END;
GO

-- Trigger para insertar en blogs al registrar order_about
CREATE TRIGGER trg_order_about_insert
ON order_about
AFTER INSERT
AS
BEGIN
    INSERT INTO blogs (order_type, order_id, client_name, client_cc, store_name, product_name, quantity, total_price, status, created_at)
    SELECT 
        'about',
        i.id,
        c.name,
        i.client_cc,
        s.name,
        a.product_name,
        i.quantity,
        i.total_price,
        i.status,
        i.created_at
    FROM inserted i
    JOIN clients c ON c.cc = i.client_cc
    JOIN stores s ON s.id = i.store_id
    JOIN about a ON a.id = i.about_id
END;
GO

-- Trigger para actualizar status en blogs cuando cambia order_menu
CREATE TRIGGER trg_order_menu_update
ON order_menu
AFTER UPDATE
AS
BEGIN
    UPDATE b
    SET b.status = i.status
    FROM blogs b
    JOIN inserted i ON b.order_type = 'menu' AND b.order_id = i.id
END;
GO

-- Trigger para actualizar status en blogs cuando cambia order_about
CREATE TRIGGER trg_order_about_update
ON order_about
AFTER UPDATE
AS
BEGIN
    UPDATE b
    SET b.status = i.status
    FROM blogs b
    JOIN inserted i ON b.order_type = 'about' AND b.order_id = i.id
END;
GO

-- Trigger para reviews
CREATE TRIGGER trg_review_insert
ON reviews
AFTER INSERT
AS
BEGIN
    UPDATE om
    SET om.status = 'delivered'
    FROM order_menu om
    JOIN inserted i ON i.order_type = 'menu' AND i.order_id = om.id

    UPDATE oa
    SET oa.status = 'delivered'
    FROM order_about oa
    JOIN inserted i ON i.order_type = 'about' AND i.order_id = oa.id
END;
GO
