DELIMITER $$
-- Returns the one employee with the given id, or an empty result set if there isn't one.
-- DELIMITER stays on the first line; see 0003.

CREATE PROCEDURE `get_employee_by_id`(IN p_employee_id INT UNSIGNED)
READS SQL DATA
BEGIN
  SELECT `employee_id`, `first_name`, `last_name`, `hourly_pay`, `hire_date`
  FROM `employees`
  WHERE `employee_id` = p_employee_id;
END$$
