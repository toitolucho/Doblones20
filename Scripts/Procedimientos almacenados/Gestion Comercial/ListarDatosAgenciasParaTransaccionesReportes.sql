USE Doblones20
GO


DROP PROCEDURE ListarDatosAgenciasParaTransaccionesReportes
GO

CREATE PROCEDURE ListarDatosAgenciasParaTransaccionesReportes
	@NumeroAgencia		INT	
AS
BEGIN
	SELECT A.NombreAgencia, P.NombrePais, D.NombreDepartamento, A.DireccionAgencia, A.NITAgencia, A.NumeroAutorizacion, '64-42164 64-31182' AS Telefono, 'ceatec-ventas@hotmail.com' as CorreoElectronico1, 'ceatec-ventas@yahoo.es' as CorreoElectronico2, 'ceatec.comercializadores@hotmail.com' as CorreoElectronico3
	FROM Agencias A LEFT JOIN Paises P ON P.CodigoPais = A.CodigoPais
	LEFT JOIN Departamentos D ON A.CodigoDepartamento = D.CodigoDepartamento	
	WHERE A.NumeroAgencia = @NumeroAgencia;
END