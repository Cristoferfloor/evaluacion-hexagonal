USE EvaluacionCreditos;
GO

DELETE FROM dbo.CuotaCredito;
DELETE FROM dbo.Credito;
DELETE FROM dbo.TipoGarantia;
GO

INSERT INTO dbo.TipoGarantia (TipoGarantia, NombreGarantia) VALUES
    ('PR', 'PRENDARIA'),
    ('QU', 'QUIROGRAFARIA');
GO

INSERT INTO dbo.Credito (NumeroCredito, Sucursal, EstatusCredito, TipoGarantia) VALUES
    (1001, 1, 'VIGENTE',   'PR'),
    (1002, 1, 'VIGENTE',   'PR'),
    (1003, 2, 'VIGENTE',   'PR'),
    (1004, 1, 'CANCELADO', 'PR'),
    (1005, 2, 'VIGENTE',   'QU'),
    (1001, 2, 'VIGENTE',   'QU');
GO

DECLARE @hoy DATE = CAST(GETDATE() AS DATE);

INSERT INTO dbo.CuotaCredito
    (NumeroCredito, NumeroCuota, Sucursal, FechaVencimiento, Capital, Interes, Mora, Pagada)
VALUES
    (1001, 1, 1, DATEADD(DAY,  -15, @hoy), 100.00, 10.00, 2.00, 'N'),
    (1001, 2, 1, DATEADD(DAY,  -45, @hoy), 200.00, 15.00, 5.00, 'N'),
    (1001, 3, 1, DATEADD(DAY, -120, @hoy), 300.00, 20.00, 9.00, 'N'),
    (1001, 4, 1, DATEADD(DAY,  -10, @hoy), 999.00, 10.00, 1.00, 'S'),
    (1001, 5, 1, DATEADD(DAY,  +30, @hoy), 888.00, 10.00, 0.00, 'N'),
    (1002, 1, 1, DATEADD(DAY,  -25, @hoy), 150.00, 12.00, 3.00, 'N'),
    (1002, 2, 1, DATEADD(DAY, -200, @hoy), 400.00, 30.00, 18.00,'N'),
    (1002, 3, 1, DATEADD(DAY, -500, @hoy), 500.00, 45.00, 60.00,'N'),
    (1003, 1, 2, DATEADD(DAY,  -90, @hoy), 250.00, 18.00, 7.00, 'N'),
    (1003, 2, 2, DATEADD(DAY, -180, @hoy), 350.00, 25.00, 12.00,'N'),
    (1003, 3, 2, DATEADD(DAY, -360, @hoy), 450.00, 40.00, 30.00,'N'),
    (1004, 1, 1, DATEADD(DAY,  -50, @hoy), 777.00, 20.00, 5.00, 'N'),
    (1005, 1, 2, DATEADD(DAY,  -50, @hoy), 666.00, 20.00, 5.00, 'N'),
    (1001, 1, 2, DATEADD(DAY, -400, @hoy), 555.00, 50.00, 40.00,'N');
GO
