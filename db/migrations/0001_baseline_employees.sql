-- Baseline: the employees table as it existed before migrations were introduced.
-- IF NOT EXISTS / INSERT IGNORE make this a no-op against the original database
-- while still letting a fresh database be built from scratch.

CREATE TABLE IF NOT EXISTS `employees` (
  `employee_id` varchar(100) NOT NULL,
  `first_name`  varchar(50)  DEFAULT NULL,
  `last_name`   varchar(50)  DEFAULT NULL,
  `hourly_pay`  decimal(5,2) DEFAULT NULL,
  `hire_date`   date         DEFAULT NULL,
  PRIMARY KEY (`employee_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT IGNORE INTO `employees` (`employee_id`, `first_name`, `last_name`, `hourly_pay`, `hire_date`) VALUES
  ('1', 'Eugene',    'Krabs',       25.50, '2023-01-02'),
  ('2', 'Squidward', 'Tentacles',   15.00, '2023-01-03'),
  ('3', 'Spongebob', 'Squarepants', 12.50, '2023-01-04'),
  ('4', 'Patrick',   'Star',        12.50, '2023-01-05'),
  ('5', 'Sandy',     'Cheeks',      17.25, '2023-01-06');
