

--CREATE DATABASE WebBurger
USE WebBurger

-- ===============================================
-- 1. TABLA: Clientes
-- ===============================================
CREATE TABLE Clientes (
    cliente_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    cedula NVARCHAR(30) NOT NULL UNIQUE,
    direccion NVARCHAR(200),
    telefono1 NVARCHAR(30),
    telefono2 NVARCHAR(30),
    referencia NVARCHAR(200),
    metodo_pago NVARCHAR(50)
);


-- ===============================================
-- 2. TABLA: Tiendas (Contact)
-- ===============================================
CREATE TABLE Tiendas (
    tienda_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    direccion NVARCHAR(200) NOT NULL,
    telefono NVARCHAR(30)
);


-- ===============================================
-- 3. TABLA: Productos (Menu / About)
-- ===============================================
CREATE TABLE Productos (
    producto_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    tipo NVARCHAR(20) NOT NULL  -- 'menu' o 'about'
);


-- ===============================================
-- 4. TABLA: Orders (unificada)
-- ===============================================
CREATE TABLE Orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    cliente_id INT NOT NULL,
    tienda_id INT NOT NULL,
    tipo_pedido NVARCHAR(20) NOT NULL,  -- 'menu' o 'about'
    estado NVARCHAR(20) NOT NULL DEFAULT 'pending',
    fecha DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (cliente_id) REFERENCES Clientes(cliente_id),
    FOREIGN KEY (tienda_id) REFERENCES Tiendas(tienda_id)
);


-- ===============================================
-- 5. TABLA: OrderItems (productos de cada pedido)
-- ===============================================
CREATE TABLE OrderItems (
    item_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);


-- ===============================================
-- 6. TABLA: Reviews (relación correcta)
-- ===============================================
CREATE TABLE Reviews (
    review_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    comentario NVARCHAR(300) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);


-- ===============================================
-- 7. TABLA: Blogs (histórico de pedidos)
-- ===============================================
CREATE TABLE Blogs (
    blog_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    estado NVARCHAR(20) NOT NULL,
    total DECIMAL(10,2) NOT NULL,

    -- Datos redundantes para reportes
    cliente_nombre NVARCHAR(100),
    tienda_nombre NVARCHAR(100),
    metodo_pago NVARCHAR(50),

    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);
