
-- ===================================================
-- INDICE(OrderMenu_Contact)
-- ===================================================
CREATE INDEX OrderMenu_Contact ON order_menu(store_id)

-- ===================================================
-- INDICE(OrderMenu_menuHamburger)
-- ===================================================
CREATE INDEX OrderMenu_MenuHamburger ON order_menu(hamburger_id)

-- ===================================================
-- INDICE(OrderMenu_clients)
-- ===================================================
CREATE INDEX OrderMenu_Clients ON order_menu(client_cc)

-- ===================================================
-- INDICE(OrderAbout_aboutHamburger)
-- ===================================================
CREATE INDEX OrderAbout_aboutHamburger on order_about(hamburger_id)

-- ===================================================
-- INDICE(OrderAbout_Contact)
-- ===================================================
CREATE INDEX OrderAbout_Contact ON order_about(store_id)

-- ===================================================
-- INDICE(OrderAbout_clients)
-- ===================================================
CREATE INDEX OrderAbout_clients ON order_about(client_cc)



SELECT *
FROM order_menu
WHERE hamburger_id = 123;


SELECT *
FROM order_about
WHERE store_id = 1;

