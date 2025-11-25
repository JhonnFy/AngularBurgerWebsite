

CREATE DATABASE BurgerWeb
GO

USE BurgerWeb
GO

-- ===================================================
-- TABLA DE CLIENTES
-- ===================================================
CREATE TABLE clients (
    cc BIGINT PRIMARY KEY,          
    name VARCHAR(100) NOT NULL,
    address VARCHAR(200),
    phone1 BIGINT,
    phone2 BIGINT,
    reference VARCHAR(200),
    payment_method VARCHAR(50)
);

-- ===================================================
-- TABLA DE TIENDAS (Contact)
-- ===================================================
CREATE TABLE contact (
    id BIGINT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    address VARCHAR(200),
    phone BIGINT
);

-- ===================================================
-- HAMBURGUESAS POR CANAL
-- ===================================================
CREATE TABLE menuHamburger (
    id BIGINT  PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE aboutHamburger (
    id BIGINT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- ===================================================
-- PEDIDOS
-- ===================================================
CREATE TABLE order_menu (
    id BIGINT  PRIMARY KEY,
    client_cc BIGINT NOT NULL,
    hamburger_id BIGINT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    total_price DECIMAL(10,2) NOT NULL,
    status VARCHAR(20) DEFAULT 'pending',
    store_id BIGINT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (client_cc) REFERENCES clients(cc),
    FOREIGN KEY (hamburger_id) REFERENCES menuHamburger(id),
    FOREIGN KEY (store_id) REFERENCES contact(id)
);

CREATE TABLE order_about (
    id BIGINT  PRIMARY KEY,
    client_cc BIGINT NOT NULL,
    hamburger_id BIGINT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    total_price DECIMAL(10,2) NOT NULL,
    status VARCHAR(20) DEFAULT 'pending',
    store_id BIGINT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (client_cc) REFERENCES clients(cc),
    FOREIGN KEY (hamburger_id) REFERENCES aboutHamburger(id),
    FOREIGN KEY (store_id) REFERENCES contact(id)
);
  
-- ===================================================
-- REVIEWS
-- ===================================================
CREATE TABLE review (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    order_id BIGINT NOT NULL,
    order_type VARCHAR(20) NOT NULL,
    comment VARCHAR(500),
    created_at DATETIME DEFAULT GETDATE()
);
   
-- ===================================================
-- BLOGS (Reportes)
-- ===================================================
CREATE TABLE blogs (
	id BIGINT IDENTITY(1,1) PRIMARY KEY,
    order_id BIGINT NOT NULL,
    order_type VARCHAR(20) NOT NULL,
    client_cc BIGINT NOT NULL,
    hamburger_name VARCHAR(50) NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(10,2) NOT NULL,
    payment_method VARCHAR(50),
    store_name VARCHAR(50),
    status VARCHAR(20),
    created_at DATETIME DEFAULT GETDATE()
);








