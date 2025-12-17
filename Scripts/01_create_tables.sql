-- =============================================
-- Configuración de Base de Datos Coink Microservice
-- Script de Creación de Base de Datos PostgreSQL
-- =============================================

-- Habilitar extensión UUID
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- =============================================
-- Tabla: Country
-- Descripción: Almacena información de países
-- =============================================
CREATE TABLE IF NOT EXISTS "Country" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    "Name" VARCHAR(100) NOT NULL,
    "Code" VARCHAR(10) NOT NULL UNIQUE,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NULL
);

-- =============================================
-- Tabla: Department
-- Descripción: Almacena información de departamentos/estados
-- =============================================
CREATE TABLE IF NOT EXISTS "Department" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    "Name" VARCHAR(100) NOT NULL,
    "Code" VARCHAR(10) NOT NULL,
    "CountryId" UUID NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NULL,
    CONSTRAINT fk_department_country FOREIGN KEY ("CountryId") 
        REFERENCES "Country"("Id") ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT uq_department_code_country UNIQUE ("Code", "CountryId")
);

-- Crear índice para búsquedas más rápidas
CREATE INDEX IF NOT EXISTS idx_department_country_id ON "Department"("CountryId");

-- =============================================
-- Tabla: Municipality
-- Descripción: Almacena información de municipios/ciudades
-- =============================================
CREATE TABLE IF NOT EXISTS "Municipality" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    "Name" VARCHAR(100) NOT NULL,
    "Code" VARCHAR(10) NOT NULL,
    "DepartmentId" UUID NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NULL,
    CONSTRAINT fk_municipality_department FOREIGN KEY ("DepartmentId") 
        REFERENCES "Department"("Id") ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT uq_municipality_code_department UNIQUE ("Code", "DepartmentId")
);

-- Crear índice para búsquedas más rápidas
CREATE INDEX IF NOT EXISTS idx_municipality_department_id ON "Municipality"("DepartmentId");

-- =============================================
-- Tabla: User
-- Descripción: Almacena información de usuarios
-- =============================================
CREATE TABLE IF NOT EXISTS "User" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    "Name" VARCHAR(150) NOT NULL,
    "Phone" VARCHAR(20) NOT NULL,
    "Address" VARCHAR(250) NOT NULL,
    "MunicipalityId" UUID NOT NULL,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NULL,
    CONSTRAINT fk_user_municipality FOREIGN KEY ("MunicipalityId") 
        REFERENCES "Municipality"("Id") ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Crear índices para búsquedas más rápidas
CREATE INDEX IF NOT EXISTS idx_user_municipality_id ON "User"("MunicipalityId");
CREATE INDEX IF NOT EXISTS idx_user_name ON "User"("Name");
CREATE INDEX IF NOT EXISTS idx_user_phone ON "User"("Phone");

-- =============================================
-- Comentarios para documentación
-- =============================================
COMMENT ON TABLE "Country" IS 'Almacena información de países para la jerarquía de ubicación';
COMMENT ON TABLE "Department" IS 'Almacena información de departamentos/estados, pertenece a un país';
COMMENT ON TABLE "Municipality" IS 'Almacena información de municipios/ciudades, pertenece a un departamento';
COMMENT ON TABLE "User" IS 'Almacena información de usuarios con su ubicación';

COMMENT ON COLUMN "Country"."Code" IS 'Código ISO del país (ej., CO para Colombia)';
COMMENT ON COLUMN "Department"."Code" IS 'Código del departamento (ej., ANT para Antioquia)';
COMMENT ON COLUMN "Municipality"."Code" IS 'Código del municipio';
COMMENT ON COLUMN "User"."Address" IS 'Campo de texto libre para la dirección';
