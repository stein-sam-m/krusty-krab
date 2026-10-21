DELIMITER $$
-- First stored procedure: returns every employee, ordered by id.
-- DELIMITER swaps the statement terminator so DbUp doesn't split the script at the
-- semicolons inside BEGIN...END. Keep it on the very first line: DbUp ignored it
-- when it came after these comments.

CREATE PROCEDURE `get_employees`()
READS SQL DATA
BEGIN
  SELECT `employee_id`, `first_name`, `last_name`, `hourly_pay`, `hire_date`
  FROM `employees`
  ORDER BY `employee_id`;
END$$
