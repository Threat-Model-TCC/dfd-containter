CREATE TABLE projects (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(255),
    description NVARCHAR(MAX),
    context_diagram_id BIGINT,
    created_at DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT fk_projects_Dfds FOREIGN KEY (context_diagram_id) REFERENCES dfds (id)
);