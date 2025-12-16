# AngularNetAppi

Aplicación desarrollada en .NET con arquitectura en capas (Data, Business, Controller, Interface
         
---  
## Tabla de Contenidos
     
1. [FlujoDePedidosClientes](#FlujoDePedidosClientes)  
2. [DiagramaRelacional](#DiagramaRelacional)
3. [OrdenInsert](#OrdenInsert)
4. [Test](#Test)
5. [ReglasDeNegocio](#ReglasDeNegocio)
6. [SeguridadAppConfig](#SeguridadAppConfig)
     
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

1️⃣ contact » 
2️⃣ menuHamburger »
3️⃣ aboutHamburger »  
4️⃣ clients » 
5️⃣ order_menu  
6️⃣ order_about  
7️⃣ review


---

## Test
<figure align="center">
  <img width="1364" height="778" alt="image" src="https://github.com/user-attachments/assets/8aea4f83-ad35-493f-9c40-a1d370400111" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/d2530f6b-e290-41b4-80f2-e878d0aee77c" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/5df0f9ce-970d-415c-916c-b9c6429693ba" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/f0879601-f318-4d64-96ef-9133436168a3" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/69396c8d-17df-4966-82fd-63385a80b750" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/51aba56d-776f-43f2-80b4-a12fd0f6fdcc" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/dbae1b5d-ef1f-40cf-90ba-38a190ad9974" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/fccf81b6-421c-457d-81d8-5156f1c5c865" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/b2a9d75d-13e5-4bac-bfb1-80b0f1704258" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/d62c80fb-c46a-4f26-b09a-298dca729c9e" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/e0b4ef4c-57e4-40c5-bf1a-6de32b6dd5dd" />
</figure>

<figure align="center">
  <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/aa50c4cd-667b-43ef-92d4-a930f560a926" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/1f34aa0d-8382-4c40-b5f5-628c35913a79" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/4443d5ee-5817-483f-8d48-366e84be2a35" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/d13aca22-ae2a-4ecc-af27-2b3148148bae" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/2c9c5633-42c9-4fed-9473-0a1d0d613fba" />
</figure>

<figure align="center">
   <img width="1364" height="1000" alt="image" src="https://github.com/user-attachments/assets/93001eff-2d2e-43fb-adfc-75f0baf165a2" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/36c293fe-2f72-4388-b901-ee508873bff0" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/3a5bbccd-d0d8-419c-b360-8f3e9735371a" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/1e9778b7-da8f-43cf-a1e0-94764eede9b0" />
</figure>

<figure align="center">
   <img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/bb152669-d701-4460-b04c-6ad9a09066e3" />
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

## SeguridadAppConfig
- Install-Package Microsoft.Extensions.Configuration
- Install-Package Microsoft.Extensions.Configuration.Json
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/9ba2db52-3ece-49d4-91c3-9f772eacd793" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/90650fec-f585-4198-ab8f-700dac652085" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/50e515b4-d68e-4052-8953-75e06819f455" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/663967dc-4275-401d-8cff-a23879fdea28" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/0c47091e-ef51-455c-9a68-ac7dd7eb2f36" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/f9f65f37-adea-4712-8d88-84cd79a7eced" />















































