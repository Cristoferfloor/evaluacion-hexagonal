USE EvaluacionCreditos;
GO
WITH CuotasVencidas AS
(
    SELECT
        cu.Capital,
        DATEDIFF(DAY, cu.FechaVencimiento, CAST(GETDATE() AS DATE)) AS DiasVencidos
    FROM dbo.CuotaCredito  AS cu
    INNER JOIN dbo.Credito AS cr
            ON cr.NumeroCredito = cu.NumeroCredito
           AND cr.Sucursal      = cu.Sucursal
    INNER JOIN dbo.TipoGarantia AS tg
            ON tg.TipoGarantia  = cr.TipoGarantia
    WHERE cu.Pagada            = 'N'
      AND cr.EstatusCredito    = 'VIGENTE'
      AND tg.NombreGarantia    = 'PRENDARIA'
      AND cu.FechaVencimiento  < CAST(GETDATE() AS DATE)
)
SELECT
    SUM(CASE WHEN DiasVencidos BETWEEN   1 AND  30 THEN Capital ELSE 0 END) AS [1_A_30_DIAS],
    SUM(CASE WHEN DiasVencidos BETWEEN  31 AND  90 THEN Capital ELSE 0 END) AS [31_A_90_DIAS],
    SUM(CASE WHEN DiasVencidos BETWEEN  91 AND 180 THEN Capital ELSE 0 END) AS [91_A_180_DIAS],
    SUM(CASE WHEN DiasVencidos BETWEEN 181 AND 360 THEN Capital ELSE 0 END) AS [181_A_360_DIAS],
    SUM(CASE WHEN DiasVencidos >  360              THEN Capital ELSE 0 END) AS [MAYOR_360_DIAS],
    SUM(Capital)                                                            AS [TOTAL_CAPITAL]
FROM CuotasVencidas;
GO



WITH CuotasVencidas AS
(
    SELECT
        cu.Capital,
        DATEDIFF(DAY, cu.FechaVencimiento, CAST(GETDATE() AS DATE)) AS DiasVencidos
    FROM dbo.CuotaCredito  AS cu
    INNER JOIN dbo.Credito AS cr
            ON cr.NumeroCredito = cu.NumeroCredito
           AND cr.Sucursal      = cu.Sucursal
    INNER JOIN dbo.TipoGarantia AS tg
            ON tg.TipoGarantia  = cr.TipoGarantia
    WHERE cu.Pagada            = 'N'
      AND cr.EstatusCredito    = 'VIGENTE'
      AND tg.NombreGarantia    = 'PRENDARIA'
      AND cu.FechaVencimiento  < CAST(GETDATE() AS DATE)
),
Clasificadas AS
(
    SELECT
        Capital,
        CASE
            WHEN DiasVencidos BETWEEN   1 AND  30 THEN 1
            WHEN DiasVencidos BETWEEN  31 AND  90 THEN 2
            WHEN DiasVencidos BETWEEN  91 AND 180 THEN 3
            WHEN DiasVencidos BETWEEN 181 AND 360 THEN 4
            ELSE 5
        END AS Orden
    FROM CuotasVencidas
)
SELECT
    CASE Orden
        WHEN 1 THEN 'De 1 a 30 días'
        WHEN 2 THEN 'De 31 a 90 días'
        WHEN 3 THEN 'De 91 a 180 días'
        WHEN 4 THEN 'De 181 a 360 días'
        ELSE        'Mayor a 360 días'
    END                 AS BandaVencimiento,
    SUM(Capital)        AS CapitalVencido,
    COUNT(*)            AS CantidadCuotas
FROM Clasificadas
GROUP BY Orden
ORDER BY Orden;
GO
