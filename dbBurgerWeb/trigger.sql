
USE WebBurger
GO

--=======================
--TRIGGER 1 – Insertar en Blogs cuando se crea un pedido
--=======================
CREATE TRIGGER trg_order_insert_blog
ON Orders
AFTER INSERT
AS
BEGIN
    INSERT INTO Blogs (order_id, estado, total, cliente_nombre, tienda_nombre, metodo_pago)
    SELECT 
        i.order_id,
        i.estado,
        (
            SELECT SUM(oi.cantidad * oi.precio_unitario)
            FROM OrderItems oi
            WHERE oi.order_id = i.order_id
        ) AS total,
        c.nombre,
        t.nombre,
        c.metodo_pago
    FROM inserted i
    INNER JOIN Clientes c ON i.cliente_id = c.cliente_id
    INNER JOIN Tiendas t ON i.tienda_id = t.tienda_id;
END;
GO

--=======================
--TRIGGER 2 – Actualizar Blogs cuando cambia el ESTADO
--=======================
CREATE TRIGGER trg_order_update_blog
ON Orders
AFTER UPDATE
AS
BEGIN
    IF UPDATE(estado)
    BEGIN
        UPDATE Blogs
        SET estado = i.estado
        FROM Blogs b
        INNER JOIN inserted i ON b.order_id = i.order_id;
    END
END;
GO

--=======================
--TRIGGER 3 – Cuando un cliente deja un Review → marcar pedido como ENTREGADO
--=======================
CREATE TRIGGER trg_review_entregado
ON Reviews
AFTER INSERT
AS
BEGIN
    UPDATE Orders
    SET estado = 'delivered'
    WHERE order_id IN (SELECT order_id FROM inserted)
      AND estado <> 'delivered';
END;
GO

--=======================
--TRIGGER 4 – Recalcular total en Blogs cuando cambian items
--=======================
CREATE TRIGGER trg_orderitems_update_total
ON OrderItems
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE Blogs
    SET total = (
        SELECT SUM(oi.cantidad * oi.precio_unitario)
        FROM OrderItems oi
        WHERE oi.order_id = b.order_id
    )
    FROM Blogs b
    INNER JOIN Orders o ON b.order_id = o.order_id;
END;
GO

--=======================
--TRIGGER 5 – Insertar automáticamente en Blogs cuando se agregan items
--=======================
CREATE TRIGGER trg_orderitems_insert_blog
ON OrderItems
AFTER INSERT
AS
BEGIN
    UPDATE Blogs
    SET total = (
        SELECT SUM(oi.cantidad * oi.precio_unitario)
        FROM OrderItems oi
        WHERE oi.order_id = b.order_id
    )
    FROM Blogs b
    INNER JOIN inserted i ON b.order_id = i.order_id;
END;
GO


