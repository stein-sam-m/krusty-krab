DELIMITER $$
-- Returns every menu item, ordered by id.
-- DELIMITER stays on the first line; see 0003.

CREATE PROCEDURE `get_menu_items`()
READS SQL DATA
BEGIN
  SELECT `menu_item_id`, `name`, `price`
  FROM `menu_items`
  ORDER BY `menu_item_id`;
END$$
