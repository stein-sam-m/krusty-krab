-- - employee_id: varchar -> INT UNSIGNED AUTO_INCREMENT (numeric ordering, compact PK/FKs).
--   Fails under strict mode if any existing id is non-numeric, rather than silently coercing.
-- - Required columns become NOT NULL; fails if any existing row has NULLs.
-- - Adds audit timestamps.
-- Single ALTER so it applies atomically (MySQL DDL can't be wrapped in a transaction).

ALTER TABLE `employees`
  MODIFY `employee_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  MODIFY `first_name`  varchar(50)  NOT NULL,
  MODIFY `last_name`   varchar(50)  NOT NULL,
  MODIFY `hourly_pay`  decimal(5,2) NOT NULL,
  MODIFY `hire_date`   date         NOT NULL,
  ADD COLUMN `created_at` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  ADD COLUMN `updated_at` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6);
