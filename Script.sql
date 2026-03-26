CREATE TABLE FUNCIONARIOS (
    ID          UNIQUEIDENTIFIER    PRIMARY KEY,
    NOME        VARCHAR             (150) NOT NULL,
    MATRICULA   CHAR                (6) NOT NULL,
    CPF         CHAR                (11) NOT NULL
);