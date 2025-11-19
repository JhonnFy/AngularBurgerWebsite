# AngularNetAppi

Aplicación desarrollada en .NET con arquitectura en capas (Data, Business, Controller, Interface)

---

## Tabla de Contenidos

1. [FlujoDePedidosClientes](#FlujoDePedidosClientes)  
2. [DiagramaRelacional](#DiagramaRelacional)
3. [OrdenInsert](#OrdenInsert)
4. [Test](#Test)
5. [ReglasDeNegocio](#ReglasDeNegocio)
6. [Docker](#Docker)
---

## FlujoDePedidosClientes

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

## OrdenInsert

1️⃣ contact  
2️⃣ menuHamburger  
3️⃣ aboutHamburger  
4️⃣ clients  
5️⃣ order_menu  
6️⃣ order_about  
7️⃣ review


---


## Test
<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/2810f32d-8003-4f35-81d8-8110f14f3d28" />
</figure>


<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/e9a55b10-6229-4c36-abdf-ff52bf82acc1" />
</figure>

<figure align="center">  
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/b0593e81-a7e9-4954-990c-6bc423c19e5d" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/d693f522-169c-4bd6-8c6a-480b2a42d39b" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/52577e92-2d2d-4f4f-b9cd-e76cfa1fcfae" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/c4361717-b488-45b2-a931-e4ea303a8f3b" />
</figure>

---

## ReglasDeNegocio

- Solo se puede registrar un cliente cuando hace un pedido.
- Validar que la cédula (CC) sea única por cliente.
- Validar que los campos obligatorios estén completos: nombre, dirección, teléfono principal.
- Normalizar el nombre: mayúsculas, quitar acentos.
- Verificar formato de teléfonos y dirección.

- Cada pedido debe tener un cliente registrado.
- Cada pedido debe estar asociado a una tienda válida (Contact).
- El estado inicial del pedido debe ser pending.
- Validar que los productos pedidos existan en la tabla correspondiente (order_menu o order_about).
- Evitar pedidos duplicados de la misma orden si ya se registró.

- No se permite registrar clientes ni pedidos desde Home.
- Cambiar estado a Entregado solo si estaba en EnDespacho.

- Cada pedido registrado genera automáticamente un registro en Blogs.
- Solo puede registrar información que provenga de pedidos reales.
- Permitir filtrar por estado: cancelado, pendiente, despachado.
- Mantener historial completo de ventas para estadísticas.

- Cada pedido debe estar vinculado a una tienda existente.
- Validar que los datos de la tienda estén completos: nombre, dirección, teléfono.
- Evitar eliminar tiendas si existen pedidos asociados.

---

## Docker
<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/50aca1a1-9d21-4d90-a198-257d41632187" />
</figure>
