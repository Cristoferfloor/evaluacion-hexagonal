IF DB_ID('EvaluacionCreditos') IS NULL
    CREATE DATABASE EvaluacionCreditos;
GO

USE EvaluacionCreditos;
GO
DROP TABLE IF EXISTS dbo.CuotaCredito;
DROP TABLE IF EXISTS dbo.Credito;
DROP TABLE IF EXISTS dbo.TipoGarantia;
GO
CREATE TABLE dbo.TipoGarantia
(
    TipoGarantia    CHAR(2)         NOT NULL,
    NombreGarantia  VARCHAR(50)     NOT NULL,

    CONSTRAINT PK_TipoGarantia PRIMARY KEY (TipoGarantia),
    CONSTRAINT UQ_TipoGarantia_Nombre UNIQUE (NombreGarantia)
);
GO
CREATE TABLE dbo.Credito
(
    NumeroCredito   BIGINT          NOT NULL,
    Sucursal        INT             NOT NULL,
    EstatusCredito  VARCHAR(10)     NOT NULL,
    TipoGarantia    CHAR(2)         NOT NULL,

    CONSTRAINT PK_Credito PRIMARY KEY (NumeroCredito, Sucursal),

    CONSTRAINT FK_Credito_TipoGarantia
        FOREIGN KEY (TipoGarantia)
        REFERENCES dbo.TipoGarantia (TipoGarantia),

    CONSTRAINT CK_Credito_Estatus
        CHECK (EstatusCredito IN ('VIGENTE', 'CANCELADO'))
);
GO
CREATE TABLE dbo.CuotaCredito
(
    NumeroCredito       BIGINT          NOT NULL,
    NumeroCuota         INT             NOT NULL,
    Sucursal            INT             NOT NULL,
    FechaVencimiento    DATE            NOT NULL,
    Capital             DECIMAL(18,2)   NOT NULL CONSTRAINT DF_Cuota_Capital DEFAULT (0),
    Interes             DECIMAL(18,2)   NOT NULL CONSTRAINT DF_Cuota_Interes DEFAULT (0),
    Mora                DECIMAL(18,2)   NOT NULL CONSTRAINT DF_Cuota_Mora    DEFAULT (0),
    Pagada              CHAR(1)         NOT NULL,

    CONSTRAINT PK_CuotaCredito PRIMARY KEY (NumeroCredito, NumeroCuota, Sucursal),

    CONSTRAINT FK_CuotaCredito_Credito
        FOREIGN KEY (NumeroCredito, Sucursal)
        REFERENCES dbo.Credito (NumeroCredito, Sucursal),

    CONSTRAINT CK_CuotaCredito_Pagada
        CHECK (Pagada IN ('S', 'N')),

    CONSTRAINT CK_CuotaCredito_Montos
        CHECK (Capital >= 0 AND Interes >= 0 AND Mora >= 0)
);
GO
CREATE NONCLUSTERED INDEX IX_CuotaCredito_Pendientes
    ON dbo.CuotaCredito (Pagada, FechaVencimiento)
    INCLUDE (Capital);
GO
