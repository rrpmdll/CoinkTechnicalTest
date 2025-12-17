-- =============================================
-- Coink Microservice Seed Data
-- PostgreSQL Data Insertion Script
-- =============================================

-- =============================================
-- Insert Country: Colombia
-- =============================================
INSERT INTO "Country" ("Name", "Code", "IsActive") VALUES 
('Colombia', 'CO', TRUE)
ON CONFLICT ("Code") DO NOTHING;

-- =============================================
-- Insert Departments of Colombia
-- =============================================
INSERT INTO "Department" ("Name", "Code", "CountryId", "IsActive") VALUES 
('Antioquia', 'ANT', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Cundinamarca', 'CUN', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Valle del Cauca', 'VAL', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Atlantico', 'ATL', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Santander', 'SAN', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Bolivar', 'BOL', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Boyaca', 'BOY', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Tolima', 'TOL', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Norte de Santander', 'NSA', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE),
('Risaralda', 'RIS', (SELECT "Id" FROM "Country" WHERE "Code" = 'CO'), TRUE)
ON CONFLICT ("Code", "CountryId") DO NOTHING;

-- =============================================
-- Insert Municipalities
-- =============================================

-- Antioquia municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Medellin', 'MED', (SELECT "Id" FROM "Department" WHERE "Code" = 'ANT'), TRUE),
('Bello', 'BEL', (SELECT "Id" FROM "Department" WHERE "Code" = 'ANT'), TRUE),
('Itagui', 'ITA', (SELECT "Id" FROM "Department" WHERE "Code" = 'ANT'), TRUE),
('Envigado', 'ENV', (SELECT "Id" FROM "Department" WHERE "Code" = 'ANT'), TRUE),
('Rionegro', 'RIO', (SELECT "Id" FROM "Department" WHERE "Code" = 'ANT'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Cundinamarca municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Bogota', 'BOG', (SELECT "Id" FROM "Department" WHERE "Code" = 'CUN'), TRUE),
('Soacha', 'SOA', (SELECT "Id" FROM "Department" WHERE "Code" = 'CUN'), TRUE),
('Chia', 'CHI', (SELECT "Id" FROM "Department" WHERE "Code" = 'CUN'), TRUE),
('Zipaquira', 'ZIP', (SELECT "Id" FROM "Department" WHERE "Code" = 'CUN'), TRUE),
('Facatativa', 'FAC', (SELECT "Id" FROM "Department" WHERE "Code" = 'CUN'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Valle del Cauca municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Cali', 'CAL', (SELECT "Id" FROM "Department" WHERE "Code" = 'VAL'), TRUE),
('Palmira', 'PAL', (SELECT "Id" FROM "Department" WHERE "Code" = 'VAL'), TRUE),
('Buenaventura', 'BUE', (SELECT "Id" FROM "Department" WHERE "Code" = 'VAL'), TRUE),
('Tulua', 'TUL', (SELECT "Id" FROM "Department" WHERE "Code" = 'VAL'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Atlantico municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Barranquilla', 'BAR', (SELECT "Id" FROM "Department" WHERE "Code" = 'ATL'), TRUE),
('Soledad', 'SOL', (SELECT "Id" FROM "Department" WHERE "Code" = 'ATL'), TRUE),
('Malambo', 'MAL', (SELECT "Id" FROM "Department" WHERE "Code" = 'ATL'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Santander municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Bucaramanga', 'BUC', (SELECT "Id" FROM "Department" WHERE "Code" = 'SAN'), TRUE),
('Floridablanca', 'FLO', (SELECT "Id" FROM "Department" WHERE "Code" = 'SAN'), TRUE),
('Giron', 'GIR', (SELECT "Id" FROM "Department" WHERE "Code" = 'SAN'), TRUE),
('Piedecuesta', 'PIE', (SELECT "Id" FROM "Department" WHERE "Code" = 'SAN'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Bolivar municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Cartagena', 'CAR', (SELECT "Id" FROM "Department" WHERE "Code" = 'BOL'), TRUE),
('Magangue', 'MAG', (SELECT "Id" FROM "Department" WHERE "Code" = 'BOL'), TRUE),
('Turbaco', 'TUR', (SELECT "Id" FROM "Department" WHERE "Code" = 'BOL'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Boyaca municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Tunja', 'TUN', (SELECT "Id" FROM "Department" WHERE "Code" = 'BOY'), TRUE),
('Duitama', 'DUI', (SELECT "Id" FROM "Department" WHERE "Code" = 'BOY'), TRUE),
('Sogamoso', 'SOG', (SELECT "Id" FROM "Department" WHERE "Code" = 'BOY'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Tolima municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Ibague', 'IBA', (SELECT "Id" FROM "Department" WHERE "Code" = 'TOL'), TRUE),
('Espinal', 'ESP', (SELECT "Id" FROM "Department" WHERE "Code" = 'TOL'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Norte de Santander municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Cucuta', 'CUC', (SELECT "Id" FROM "Department" WHERE "Code" = 'NSA'), TRUE),
('Ocana', 'OCA', (SELECT "Id" FROM "Department" WHERE "Code" = 'NSA'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- Risaralda municipalities
INSERT INTO "Municipality" ("Name", "Code", "DepartmentId", "IsActive") VALUES 
('Pereira', 'PER', (SELECT "Id" FROM "Department" WHERE "Code" = 'RIS'), TRUE),
('Dosquebradas', 'DOS', (SELECT "Id" FROM "Department" WHERE "Code" = 'RIS'), TRUE)
ON CONFLICT ("Code", "DepartmentId") DO NOTHING;

-- =============================================
-- Verify data insertion
-- =============================================
-- SELECT 'Countries: ' || COUNT(*) FROM "Country";
-- SELECT 'Departments: ' || COUNT(*) FROM "Department";
-- SELECT 'Municipalities: ' || COUNT(*) FROM "Municipality";
