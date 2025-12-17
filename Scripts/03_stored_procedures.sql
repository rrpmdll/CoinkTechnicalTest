-- =============================================
-- Coink Microservice Stored Procedures
-- PostgreSQL Stored Procedures Script
-- =============================================

-- =============================================
-- Country Stored Procedures
-- =============================================

-- Get all countries
CREATE OR REPLACE FUNCTION sp_country_get_all()
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT c."Id", c."Name", c."Code", c."IsActive", c."CreatedAt", c."UpdatedAt"
    FROM "Country" c
    WHERE c."IsActive" = TRUE
    ORDER BY c."Name";
END;
$$ LANGUAGE plpgsql;

-- Get country by ID
CREATE OR REPLACE FUNCTION sp_country_get_by_id(p_id UUID)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT c."Id", c."Name", c."Code", c."IsActive", c."CreatedAt", c."UpdatedAt"
    FROM "Country" c
    WHERE c."Id" = p_id AND c."IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;

-- =============================================
-- Department Stored Procedures
-- =============================================

-- Get all departments
CREATE OR REPLACE FUNCTION sp_department_get_all()
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "CountryId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT d."Id", d."Name", d."Code", d."CountryId", d."IsActive", d."CreatedAt", d."UpdatedAt"
    FROM "Department" d
    WHERE d."IsActive" = TRUE
    ORDER BY d."Name";
END;
$$ LANGUAGE plpgsql;

-- Get department by ID
CREATE OR REPLACE FUNCTION sp_department_get_by_id(p_id UUID)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "CountryId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT d."Id", d."Name", d."Code", d."CountryId", d."IsActive", d."CreatedAt", d."UpdatedAt"
    FROM "Department" d
    WHERE d."Id" = p_id AND d."IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;

-- Get departments by country ID
CREATE OR REPLACE FUNCTION sp_department_get_by_country_id(p_country_id UUID)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "CountryId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT d."Id", d."Name", d."Code", d."CountryId", d."IsActive", d."CreatedAt", d."UpdatedAt"
    FROM "Department" d
    WHERE d."CountryId" = p_country_id AND d."IsActive" = TRUE
    ORDER BY d."Name";
END;
$$ LANGUAGE plpgsql;

-- =============================================
-- Municipality Stored Procedures
-- =============================================

-- Get all municipalities
CREATE OR REPLACE FUNCTION sp_municipality_get_all()
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "DepartmentId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT m."Id", m."Name", m."Code", m."DepartmentId", m."IsActive", m."CreatedAt", m."UpdatedAt"
    FROM "Municipality" m
    WHERE m."IsActive" = TRUE
    ORDER BY m."Name";
END;
$$ LANGUAGE plpgsql;

-- Get municipality by ID
CREATE OR REPLACE FUNCTION sp_municipality_get_by_id(p_id UUID)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "DepartmentId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT m."Id", m."Name", m."Code", m."DepartmentId", m."IsActive", m."CreatedAt", m."UpdatedAt"
    FROM "Municipality" m
    WHERE m."Id" = p_id AND m."IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;

-- Get municipalities by department ID
CREATE OR REPLACE FUNCTION sp_municipality_get_by_department_id(p_department_id UUID)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Code" VARCHAR(10),
    "DepartmentId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT m."Id", m."Name", m."Code", m."DepartmentId", m."IsActive", m."CreatedAt", m."UpdatedAt"
    FROM "Municipality" m
    WHERE m."DepartmentId" = p_department_id AND m."IsActive" = TRUE
    ORDER BY m."Name";
END;
$$ LANGUAGE plpgsql;

-- Check if municipality exists
CREATE OR REPLACE FUNCTION sp_municipality_exists(p_id UUID)
RETURNS BOOLEAN AS $$
BEGIN
    RETURN EXISTS (
        SELECT 1 FROM "Municipality" m
        WHERE m."Id" = p_id AND m."IsActive" = TRUE
    );
END;
$$ LANGUAGE plpgsql;

-- =============================================
-- User Stored Procedures
-- =============================================

-- Create user
CREATE OR REPLACE FUNCTION sp_user_create(
    p_name VARCHAR(100),
    p_phone VARCHAR(20),
    p_address VARCHAR(200),
    p_municipality_id UUID
)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Phone" VARCHAR(20),
    "Address" VARCHAR(200),
    "MunicipalityId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
DECLARE
    new_id UUID;
BEGIN
    INSERT INTO "User" ("Name", "Phone", "Address", "MunicipalityId", "IsActive", "CreatedAt")
    VALUES (p_name, p_phone, p_address, p_municipality_id, TRUE, CURRENT_TIMESTAMP)
    RETURNING "User"."Id" INTO new_id;
    
    RETURN QUERY
    SELECT u."Id", u."Name", u."Phone", u."Address", u."MunicipalityId", u."IsActive", u."CreatedAt", u."UpdatedAt"
    FROM "User" u
    WHERE u."Id" = new_id;
END;
$$ LANGUAGE plpgsql;

-- Get user by ID
CREATE OR REPLACE FUNCTION sp_user_get_by_id(p_id UUID)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Phone" VARCHAR(20),
    "Address" VARCHAR(200),
    "MunicipalityId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT u."Id", u."Name", u."Phone", u."Address", u."MunicipalityId", u."IsActive", u."CreatedAt", u."UpdatedAt"
    FROM "User" u
    WHERE u."Id" = p_id AND u."IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;

-- Get all users with pagination
CREATE OR REPLACE FUNCTION sp_user_get_all(
    p_page_number INT DEFAULT 1,
    p_page_size INT DEFAULT 10
)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Phone" VARCHAR(20),
    "Address" VARCHAR(200),
    "MunicipalityId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP,
    "TotalCount" BIGINT
) AS $$
DECLARE
    v_offset INT;
    v_total BIGINT;
BEGIN
    v_offset := (p_page_number - 1) * p_page_size;
    
    SELECT COUNT(*) INTO v_total
    FROM "User" u
    WHERE u."IsActive" = TRUE;
    
    RETURN QUERY
    SELECT u."Id", u."Name", u."Phone", u."Address", u."MunicipalityId", u."IsActive", u."CreatedAt", u."UpdatedAt", v_total
    FROM "User" u
    WHERE u."IsActive" = TRUE
    ORDER BY u."CreatedAt" DESC
    OFFSET v_offset LIMIT p_page_size;
END;
$$ LANGUAGE plpgsql;

-- Update user
CREATE OR REPLACE FUNCTION sp_user_update(
    p_id UUID,
    p_name VARCHAR(100),
    p_phone VARCHAR(20),
    p_address VARCHAR(200),
    p_municipality_id UUID
)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR(100),
    "Phone" VARCHAR(20),
    "Address" VARCHAR(200),
    "MunicipalityId" UUID,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMP,
    "UpdatedAt" TIMESTAMP
) AS $$
BEGIN
    UPDATE "User"
    SET "Name" = p_name,
        "Phone" = p_phone,
        "Address" = p_address,
        "MunicipalityId" = p_municipality_id,
        "UpdatedAt" = CURRENT_TIMESTAMP
    WHERE "User"."Id" = p_id AND "User"."IsActive" = TRUE;
    
    RETURN QUERY
    SELECT u."Id", u."Name", u."Phone", u."Address", u."MunicipalityId", u."IsActive", u."CreatedAt", u."UpdatedAt"
    FROM "User" u
    WHERE u."Id" = p_id;
END;
$$ LANGUAGE plpgsql;

-- Delete user (soft delete)
CREATE OR REPLACE FUNCTION sp_user_delete(p_id UUID)
RETURNS BOOLEAN AS $$
DECLARE
    rows_affected INT;
BEGIN
    UPDATE "User"
    SET "IsActive" = FALSE,
        "UpdatedAt" = CURRENT_TIMESTAMP
    WHERE "Id" = p_id AND "IsActive" = TRUE;
    
    GET DIAGNOSTICS rows_affected = ROW_COUNT;
    RETURN rows_affected > 0;
END;
$$ LANGUAGE plpgsql;

-- =============================================
-- Verify stored procedures creation
-- =============================================
-- SELECT proname, prosrc FROM pg_proc WHERE proname LIKE 'sp_%';
