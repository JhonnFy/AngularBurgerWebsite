-- ===================================================
-- INSERT DE DATOS INICIALES
-- ===================================================
-- Tiendas
INSERT INTO contact (id, name, address, phone) VALUES
(1, 'Hamburger Sur', 'Calle Sur 123', '3101234567'),
(2, 'Hamburger Chapinero', 'Calle Chapinero 456', '3102345678'),
(3, 'Hamburger Chico', 'Calle Chico 789', '3103456789');

-- Hamburguesas físicas
INSERT INTO menuHamburger (id, name) VALUES
(1, 'Cheese Hamburger'),
(2, 'BBQ Hamburger'),
(3, 'Hawaiian Burger');

-- Hamburguesas domicilio
INSERT INTO aboutHamburger (id, name) VALUES
(1, 'The Classics About Burger');


