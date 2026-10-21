-- Menu items and their prices, seeded with the starting menu.
-- Follows the hardened employees shape: unsigned auto-increment PK, NOT NULL columns,
-- audit timestamps. Names are unique so the same item can't be listed twice.

CREATE TABLE `menu_items` (
  `menu_item_id` INT UNSIGNED  NOT NULL AUTO_INCREMENT,
  `name`         varchar(100)  NOT NULL,
  `price`        decimal(6,2)  NOT NULL,
  `created_at`   datetime(6)   NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `updated_at`   datetime(6)   NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`menu_item_id`),
  UNIQUE KEY `uq_menu_items_name` (`name`),
  CONSTRAINT `chk_menu_items_price_non_negative` CHECK (`price` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `menu_items` (`name`, `price`) VALUES
  ('Krabby Patty',      5.00),
  ('Krusty Krab Pizza', 10.00),
  ('Fries',             2.00),
  ('Drink',             1.00);
