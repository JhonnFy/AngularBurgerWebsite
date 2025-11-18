
-- ===================================================
-- INDICE(OrderMenu_Contact)
-- ===================================================
CREATE INDEX OrderMenu_Contact ON order_menu(store_id)

-- ===================================================
-- INDICE(OrderAbout_Contact)
-- ===================================================
CREATE INDEX OrderAbout_Contact ON order_about(store_id)

SELECT *
FROM order_about
WHERE store_id = 1;

