# AngularNetAppi

Aplicación desarrollada en .NET con arquitectura en capas (Data, Business, Controller, Interface)

---

## Tabla de Contenidos

1. [Interface](#Interface)  
2. [DiagramaRelacional](#DiagramaRelacional)
3. [OrdenIsert](#OrdenIsert)
---

## Interface

# Flujo de Pedidos y Clientes

## 1️⃣ Registro de Clientes

El cliente solo se registra cuando hace un pedido, ya sea en **Menu** (venta física) o **About** (venta a domicilio).

Datos que se registran:

- Nombre  
- Cédula (CC)  
- Dirección  
- Teléfono principal  
- Teléfono secundario  
- Referencia  
- Método de pago  

---

## 2️⃣ Pedidos

- **Menu (venta física)** → se registran pedidos de:  
  - Cheese Hamburger  
  - BBQ Hamburger  
  - Hawaiian Burger  

- **About (domicilio)** → se registran pedidos de:  
  - The Classics About Burger  

Cada pedido:

- Se vincula con un cliente (ya registrado en este momento).  
- Se vincula con una tienda (Contact) donde se despachará.  
- Se guarda en la tabla correspondiente (`order_menu` o `order_about`).  
- Tiene un estado inicial: `pending`.  

---

## 3️⃣ Despacho en Home

Desde **Home**, el administrador solo **consulta y actualiza estados** de pedidos:

- `pending` → `EnDespacho` → `Entregado`  
- También puede marcar `canceled`.  

> Home **no registra clientes ni pedidos**, solo gestiona y despacha.  

---

## 4️⃣ Reviews

Después de recibir el pedido, el cliente puede dejar un comentario en **Review**:

- Se busca el pedido por número de orden.  
- Se guarda el comentario del cliente.  
- Esto puede actualizar el estado a `Entregado` si aún estaba en despacho.  

---

## 5️⃣ Blogs (Reportes)

Cada pedido registrado en **Menu** o **About** genera un registro en **Blogs**:

- Contiene todos los detalles del pedido: cliente, tienda, producto, cantidad, total, método de pago, estado.  
- Sirve para consultas de reportes:  
  - Pedidos cancelados  
  - Pedidos pendientes  
  - Pedidos despachados  
- Permite ver el historial completo de ventas y generar estadísticas.  

---

## 6️⃣ Tiendas (Contact)

Tabla de sedes / tiendas:

- Nombre de la tienda  
- Dirección  
- Teléfono  

> Cada pedido se asocia a una tienda específica.



---



## DiagramaRelacional

<img width="1366" height="630" alt="image" src="https://github.com/user-attachments/assets/877bd216-20c6-43d9-8070-0d4820b388c4" />

---

## OrdenIsert

1️⃣ contact  
2️⃣ menuHamburger  
3️⃣ aboutHamburger  
4️⃣ clients  
5️⃣ order_menu  
6️⃣ order_about  
7️⃣ review


---


