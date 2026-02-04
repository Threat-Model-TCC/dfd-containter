CREATE TABLE dbo.dfd_elements (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100),
    x_value DECIMAL(10,3),
    y_value DECIMAL(10,3),
    width DECIMAL(10,3),
    height DECIMAL(10,3)
);