-- =============================================
-- Coink Microservice - Drop All
-- PostgreSQL Script to remove all data and objects
-- =============================================

-- =============================================
-- Drop Stored Procedures/Functions
-- =============================================
DROP FUNCTION IF EXISTS sp_user_create(VARCHAR, VARCHAR, VARCHAR, UUID);
DROP FUNCTION IF EXISTS sp_user_get_by_id(UUID);
DROP FUNCTION IF EXISTS sp_user_get_all(INT, INT);
DROP FUNCTION IF EXISTS sp_user_update(UUID, VARCHAR, VARCHAR, VARCHAR, UUID);
DROP FUNCTION IF EXISTS sp_user_delete(UUID);

DROP FUNCTION IF EXISTS sp_municipality_get_all();
DROP FUNCTION IF EXISTS sp_municipality_get_by_id(UUID);
DROP FUNCTION IF EXISTS sp_municipality_get_by_department_id(UUID);
DROP FUNCTION IF EXISTS sp_municipality_exists(UUID);

DROP FUNCTION IF EXISTS sp_department_get_all();
DROP FUNCTION IF EXISTS sp_department_get_by_id(UUID);
DROP FUNCTION IF EXISTS sp_department_get_by_country_id(UUID);

DROP FUNCTION IF EXISTS sp_country_get_all();
DROP FUNCTION IF EXISTS sp_country_get_by_id(UUID);

-- Drop old snake_case functions if they exist
DROP FUNCTION IF EXISTS sp_person_create(VARCHAR, VARCHAR, VARCHAR, UUID);
DROP FUNCTION IF EXISTS sp_person_get_by_id(UUID);
DROP FUNCTION IF EXISTS sp_person_get_all(INT, INT);
DROP FUNCTION IF EXISTS sp_person_update(UUID, VARCHAR, VARCHAR, VARCHAR, UUID);
DROP FUNCTION IF EXISTS sp_person_delete(UUID);

-- =============================================
-- Drop Tables (order matters due to foreign keys)
-- =============================================

-- Drop new PascalCase tables
DROP TABLE IF EXISTS "User" CASCADE;
DROP TABLE IF EXISTS "Municipality" CASCADE;
DROP TABLE IF EXISTS "Department" CASCADE;
DROP TABLE IF EXISTS "Country" CASCADE;

-- Drop old snake_case tables if they exist
DROP TABLE IF EXISTS "persons" CASCADE;
DROP TABLE IF EXISTS "user" CASCADE;
DROP TABLE IF EXISTS "municipalities" CASCADE;
DROP TABLE IF EXISTS "municipality" CASCADE;
DROP TABLE IF EXISTS "departments" CASCADE;
DROP TABLE IF EXISTS "department" CASCADE;
DROP TABLE IF EXISTS "countries" CASCADE;
DROP TABLE IF EXISTS "country" CASCADE;

-- =============================================
-- Verify cleanup
-- =============================================
-- SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';
-- SELECT proname FROM pg_proc WHERE proname LIKE 'sp_%';
