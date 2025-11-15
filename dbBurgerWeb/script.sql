
--CREATE DATABASE BurgerWeb
USE BurgerWeb

-- ==============================
-- TABLAS
-- ==============================

CREATE TABLE clients (
    cc VARCHAR(20) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(255),
    phone1 VARCHAR(20),
    phone2 VARCHAR(20),
    reference VARCHAR(255),
    payment_method VARCHAR(50)
);

CREATE TABLE stores (
    id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(255),
    phone VARCHAR(20)
);

CREATE TABLE menu (
    id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description NVARCHAR(MAX)
);

CREATE TABLE about (
    id INT PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    product_name VARCHAR(100) NOT NULL
);

CREATE TABLE order_menu (
    id INT PRIMARY KEY,
    client_cc VARCHAR(20) NOT NULL,
    store_id INT NOT NULL,
    menu_id INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    total_price DECIMAL(10,2) NOT NULL,
    status VARCHAR(20),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (client_cc) REFERENCES clients(cc),
    FOREIGN KEY (store_id) REFERENCES stores(id),
    FOREIGN KEY (menu_id) REFERENCES menu(id)
);

CREATE TABLE order_about (
    id INT PRIMARY KEY,
    client_cc VARCHAR(20) NOT NULL,
    store_id INT NOT NULL,
    about_id INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    total_price DECIMAL(10,2) NOT NULL,
    status VARCHAR(20),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (client_cc) REFERENCES clients(cc),
    FOREIGN KEY (store_id) REFERENCES stores(id),
    FOREIGN KEY (about_id) REFERENCES about(id)
);

CREATE TABLE blogs (
    id INT PRIMARY KEY IDENTITY,
    order_type VARCHAR(10), -- 'menu' o 'about'
    order_id INT,
    client_name VARCHAR(100),
    client_cc VARCHAR(20),
    store_name VARCHAR(100),
    product_name VARCHAR(100),
    quantity INT,
    total_price DECIMAL(10,2),
    status VARCHAR(20),
    created_at DATETIME
);

CREATE TABLE reviews (
    id INT PRIMARY KEY IDENTITY,
    order_type VARCHAR(10), -- 'menu' o 'about'
    order_id INT,
    client_cc VARCHAR(20),
    comment NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE()
);

