
CREATE DATABASE BurgerWeb
GO

USE BurgerWeb
GO

-- ===================================================
-- TABLA DE CLIENTES
-- ===================================================
CREATE TABLE clients (
    cc VARCHAR(20) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(200),
    phone1 VARCHAR(20),
    phone2 VARCHAR(20),
    reference VARCHAR(200),
    payment_method VARCHAR(50)
);

-- ===================================================
-- TABLA DE TIENDAS (Contact)
-- ===================================================
CREATE TABLE contact (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    address VARCHAR(200),
    phone VARCHAR(20)
);

-- ===================================================
-- HAMBURGUESAS POR CANAL
-- ===================================================
-- Ventas físicas
CREATE TABLE menuHamburger (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- Ventas domicilio
CREATE TABLE aboutHamburger (
    id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- ===================================================
-- PEDIDOS
-- ===================================================
-- Pedidos venta física
CREATE TABLE order_menu (
    id INT PRIMARY KEY,
    client_cc VARCHAR(20) NOT NULL,
    hamburger_id INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    total_price DECIMAL(10,2) NOT NULL,
    status VARCHAR(20) DEFAULT 'pending',
    store_id INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (client_cc) REFERENCES clients(cc),
    FOREIGN KEY (hamburger_id) REFERENCES menuHamburger(id),
    FOREIGN KEY (store_id) REFERENCES contact(id)
);

-- Pedidos venta domicilio
CREATE TABLE order_about (
    id INT PRIMARY KEY,
    client_cc VARCHAR(20) NOT NULL,
    hamburger_id INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    total_price DECIMAL(10,2) NOT NULL,
    status VARCHAR(20) DEFAULT 'pending',
    store_id INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (client_cc) REFERENCES clients(cc),
    FOREIGN KEY (hamburger_id) REFERENCES aboutHamburger(id),
    FOREIGN KEY (store_id) REFERENCES contact(id)
);

-- ===================================================
-- REVIEWS
-- ===================================================
CREATE TABLE review (
    id INT PRIMARY KEY,
    order_id INT NOT NULL,
    order_type VARCHAR(20) NOT NULL, -- 'menu' o 'about'
    comment VARCHAR(500),
    created_at DATETIME DEFAULT GETDATE()
);

-- ===================================================
-- BLOGS (Reportes)
-- ===================================================
CREATE TABLE blogs (
    id INT PRIMARY KEY,
    order_id INT NOT NULL,
    order_type VARCHAR(20) NOT NULL, -- 'menu' o 'about'
    client_cc VARCHAR(20) NOT NULL,
    hamburger_name VARCHAR(50) NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(10,2) NOT NULL,
    payment_method VARCHAR(50),
    store_name VARCHAR(50),
    status VARCHAR(20),
    created_at DATETIME DEFAULT GETDATE()
);

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
