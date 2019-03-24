--
-- File generated with SQLiteStudio v3.2.1 on Tue Mar 19 11:34:31 2019
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: products
CREATE TABLE products (idproduct INTEGER PRIMARY KEY ASC AUTOINCREMENT NOT NULL UNIQUE, description CHAR (25) NOT NULL, barcode CHAR (13) NOT NULL UNIQUE, cost DECIMAL (12, 4) NOT NULL DEFAULT (0), id_producttype INTEGER (4) REFERENCES producttype (id_producttype));
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (1, 'Honda Civic 2018', '1234567891232', 18000, 1);
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (3, 'Acura MDX 2019', '4000', 50000, 2);
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (4, 'Laptop I7', 'strbarcode', 1200, 3);
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (10, 'Honda Civic Couple', '50003', 20000, 1);
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (11, 'Personal Computer', '50004', 900, 3);
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (15, 'Tablet', '50005', 500, 3);
INSERT INTO products (idproduct, description, barcode, cost, id_producttype) VALUES (16, 'Acura SUB', '50007', 49000, 2);

-- Table: producttype
CREATE TABLE producttype (id_producttype INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ON CONFLICT ROLLBACK, branch CHAR (20), model CHAR (20), year INTEGER, caracteristic CHAR (40));
INSERT INTO producttype (id_producttype, branch, model, year, caracteristic) VALUES (1, 'Honda', 'Civic', 2018, '4 Cylinder Sedan 4 Door');
INSERT INTO producttype (id_producttype, branch, model, year, caracteristic) VALUES (2, 'Acura', 'MDX', 2019, 'Tourist Sport');
INSERT INTO producttype (id_producttype, branch, model, year, caracteristic) VALUES (3, 'Dell', 'I7', 2019, '2.7 GHrz, 1 TB, 16 GBytes RAM');
INSERT INTO producttype (id_producttype, branch, model, year, caracteristic) VALUES (5, 'Alaca-tel', 'Fierce 303', 2019, 'Digital sensor');
INSERT INTO producttype (id_producttype, branch, model, year, caracteristic) VALUES (6, 'IPhone', '30 Fierce', 2018, '5'' Screen 32 GB');

-- View: viewProducts
CREATE VIEW viewProducts(description, barcode, cost, branch, model, year, caracteristic) AS SELECT description, barcode, cost,branch, model,year,caracteristic
FROM  products inner join producttype on products.id_producttype = producttype.id_producttype;

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
