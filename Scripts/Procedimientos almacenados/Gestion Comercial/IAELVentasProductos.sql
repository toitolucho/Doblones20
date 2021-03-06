USE DOBLONES20
GO

DROP PROCEDURE InsertarVentaProducto
GO

CREATE PROCEDURE InsertarVentaProducto
@NumeroAgencia			INT,
@CodigoCliente			INT,
@CodigoUsuario			INT,
@NumeroFactura			INT,
@FechaHoraVenta			DATETIME,
@CodigoEstadoVenta		CHAR(1),
@MontoTotalVenta		DECIMAL(10,2),
@NumeroCredito			INT,
@CodigoMoneda			TINYINT,
@CodigoTipoVenta		CHAR(1),
@Observaciones			TEXT,
@MontoTotalVentaProductos DECIMAL(10,2),
@MontoTotalVentaServicios DECIMAL(10,2),
@NumeroVentaServicio	INT
AS
BEGIN
	INSERT INTO dbo.VentasProductos(NumeroAgencia, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, Observaciones, CodigoMoneda, CodigoTipoVenta, MontoTotalVentaProductos, MontoTotalVentaServicios, NumeroVentaServicio)
	VALUES (@NumeroAgencia, @CodigoCliente, @CodigoUsuario, @NumeroFactura, @FechaHoraVenta,  @CodigoEstadoVenta, @MontoTotalVenta, @NumeroCredito, @Observaciones, @CodigoMoneda, @CodigoTipoVenta, @MontoTotalVentaProductos, @MontoTotalVentaServicios, @NumeroVentaServicio)
END
GO

DROP PROCEDURE ActualizarVentaProducto
GO

CREATE PROCEDURE ActualizarVentaProducto
@NumeroAgencia			INT,
@NumeroVentaProducto	INT,
@CodigoCliente			INT,
@CodigoUsuario			INT,
@NumeroFactura			INT,
@FechaHoraVenta			DATETIME,
@CodigoEstadoVenta		CHAR(1),
@MontoTotalVenta		DECIMAL(10,2),
@NumeroCredito			INT,
@CodigoMoneda			TINYINT,
@CodigoTipoVenta		CHAR(1),
@Observaciones			TEXT,
@MontoTotalVentaProductos DECIMAL(10,2),
@MontoTotalVentaServicios DECIMAL(10,2),
@NumeroVentaServicio	INT
AS
BEGIN
	UPDATE 	dbo.VentasProductos
	SET		
		CodigoCliente			= @CodigoCliente,
		CodigoUsuario			= @CodigoUsuario,
		NumeroFactura			= @NumeroFactura,
		--FechaHoraVenta			= @FechaHoraVenta,
		CodigoEstadoVenta		= @CodigoEstadoVenta,		
		NumeroCredito			= @NumeroCredito,
		MontoTotalVenta			= @MontoTotalVenta,
		CodigoMoneda			= @CodigoMoneda,
		CodigoTipoVenta			= @CodigoTipoVenta,
		Observaciones			= @Observaciones,
		MontoTotalVentaProductos = @MontoTotalVentaProductos,
		MontoTotalVentaServicios = @MontoTotalVentaServicios,
		NumeroVentaServicio		= @NumeroVentaServicio
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
END
GO

DROP PROCEDURE EliminarVentaProducto
GO

CREATE PROCEDURE EliminarVentaProducto
@NumeroAgencia			INT,
@NumeroVentaProducto	INT
AS
BEGIN
	DELETE 
	FROM dbo.VentasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
END
GO

DROP PROCEDURE ListarVentasProductos
GO

CREATE PROCEDURE ListarVentasProductos
	@NumeroAgencia INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta,  CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, Observaciones, CodigoMoneda, CodigoTipoVenta, MontoTotalVentaProductos, MontoTotalVentaServicios, NumeroVentaServicio
	FROM dbo.VentasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	ORDER BY NumeroVentaProducto
END
GO

DROP PROCEDURE ObtenerVentaProducto
GO
CREATE PROCEDURE ObtenerVentaProducto
@NumeroAgencia			INT,
@NumeroVentaProducto	INT
AS
BEGIN
	SELECT NumeroAgencia, NumeroVentaProducto, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta,  CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, Observaciones, CodigoMoneda, CodigoTipoVenta, MontoTotalVentaProductos, MontoTotalVentaServicios, NumeroVentaServicio
	FROM dbo.VentasProductos
	WHERE NumeroAgencia = @NumeroAgencia
	AND NumeroVentaProducto = @NumeroVentaProducto
END
GO

DROP PROCEDURE ListarVentaProductoReporte
GO

CREATE PROCEDURE ListarVentaProductoReporte
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	DECLARE @FactorCambioCotizacion		DECIMAL(10,2),
			@CodigoMonedaSistema		INT,
			@CodigoMonedaCotizacion		INT,
			@CodigoMonedaRegion			INT,
			@FechaHoraVenta				DATETIME,
			@MontoTotalVenta			DECIMAL(10,2),
			@MontoTotalVentaCotizado	DECIMAL(10,2),
			@CadenaMontoTotal			VARCHAR(255),
			@CadenaMontoTotalCotizado	VARCHAR(255),
			@NombreMonedaRegion			VARCHAR(250),
			@NombreMonedaCotizacion		VARCHAR(250),
			@MascaraMonedaRegion		VARCHAR(20),
			@EsConFactura				BIT
			
	
	SELECT @FechaHoraVenta = FechaHoraVenta, @CodigoMonedaCotizacion = CodigoMoneda 
	FROM VentasProductos 
	WHERE NumeroAgencia = @NumeroAgencia 
	AND NumeroVentaProducto = @NumeroVentaProducto
	
	SELECT TOP(1) @CodigoMonedaRegion = CodigoMonedaRegion, @CodigoMonedaSistema = CodigoMonedaSistema 
	FROM PCsConfiguraciones 
	WHERE NumeroAgencia = @NumeroAgencia
	
	
	SELECT @EsConFactura = CASE WHEN NumeroFactura IS NULL THEN 0 ELSE 1 END  
	FROM VentasProductos 
	WHERE NumeroAgencia = @NumeroAgencia 
	AND NumeroVentaProducto = @NumeroVentaProducto
	
	
	SELECT @NombreMonedaRegion = NombreMoneda, @MascaraMonedaRegion = MascaraMoneda 
	FROM Monedas 
	WHERE CodigoMoneda = @CodigoMonedaRegion
	
	
	SELECT @NombreMonedaCotizacion = NombreMoneda
	FROM Monedas
	WHERE CodigoMoneda = @CodigoMonedaCotizacion
	
	--*-------------------------------------------------------------------------------
	--SELECT @MontoTotalVenta = SUM(CantidadVenta * PrecioUnitarioVentaOtraMoneda)
	--FROM VentasProductosDetalle
	--WHERE NumeroVentaProducto = @NumeroVentaProducto 	
	--AND NumeroAgencia = @NumeroAgencia				
	--*-------------------------------------------------------------------------------
	
	IF(@EsConFactura = 1)
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT
		
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT		
			
		IF(@CodigoMonedaSistema <> @CodigoMonedaRegion)
		BEGIN
			SELECT @MontoTotalVenta = SUM (CAST(@FactorCambioCotizacion * PrecioUnitarioVenta AS DECIMAL(10,2)) * CantidadVenta) 
			FROM VentasProductosDetalle
			WHERE NumeroVentaProducto = @NumeroVentaProducto 
			AND NumeroAgencia = @NumeroAgencia			
			
		END
		ELSE
		BEGIN
			SELECT @MontoTotalVenta = MontoTotalVenta FROM VentasProductos 
			WHERE NumeroVentaProducto = @NumeroVentaProducto AND NumeroAgencia = @NumeroAgencia		
							
		END
	END
	ELSE
	BEGIN
		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT	
		
		IF(@FactorCambioCotizacion = -1)
			EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaRegion, @FactorCambioCotizacion OUTPUT
			
		IF(@CodigoMonedaCotizacion <> @CodigoMonedaSistema)
		BEGIN
			SELECT @MontoTotalVenta = SUM (CAST(@FactorCambioCotizacion * PrecioUnitarioVenta AS DECIMAL(10,2)) * CantidadVenta) FROM VentasProductosDetalle
			WHERE NumeroVentaProducto = @NumeroVentaProducto AND NumeroAgencia = @NumeroAgencia				
		END
		ELSE
		BEGIN
			SELECT @MontoTotalVenta = MontoTotalVenta FROM VentasProductos 
			WHERE NumeroVentaProducto = @NumeroVentaProducto AND NumeroAgencia = @NumeroAgencia		
		END
	END
	
	--IF(@CodigoMonedaSistema <> @CodigoMonedaCotizacion)
	--BEGIN
	--	EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, @FechaHoraVenta, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT			
	--	IF(@FactorCambioCotizacion = -1)
	--		EXEC DBO.ObtenerFactorCambioCotizacion @CodigoMonedaSistema, NULL, @CodigoMonedaCotizacion, @FactorCambioCotizacion OUTPUT
			
	--	SELECT @MontoTotalVentaCotizado = SUM (CAST(@FactorCambioCotizacion * PrecioUnitarioVenta AS DECIMAL(10,2)) * CantidadVenta) 
	--	FROM VentasProductosDetalle
	--	WHERE NumeroVentaProducto = @NumeroVentaProducto 
	--	AND NumeroAgencia = @NumeroAgencia				
		
	--	--SELECT @MontoTotalVentaCotizado = SUM(CantidadVenta * PrecioUnitarioVentaOtraMoneda)
	--	--FROM VentasProductosDetalle
	--	--WHERE NumeroVentaProducto = @NumeroVentaProducto 
	--	--AND NumeroAgencia = @NumeroAgencia		
	--	--SET @MontoTotalVentaCotizado = @MontoTotalVentaCotizado * @FactorCambioCotizacion
	--END
	--ELSE
	--BEGIN
	--	SELECT @MontoTotalVentaCotizado = MontoTotalVenta 
	--	FROM VentasProductos 
	--	WHERE NumeroVentaProducto = @NumeroVentaProducto 
	--	AND NumeroAgencia = @NumeroAgencia	
		
	--	--SELECT @MontoTotalVentaCotizado = SUM(CantidadVenta * PrecioUnitarioVentaOtraMoneda)
	--	--FROM VentasProductosDetalle
	--	--WHERE NumeroVentaProducto = @NumeroVentaProducto 
	--	--AND NumeroAgencia = @NumeroAgencia	
	--END
	
	SELECT @MontoTotalVentaCotizado = SUM(CantidadVenta * PrecioUnitarioVentaOtraMoneda)
	FROM VentasProductosDetalle
	WHERE NumeroVentaProducto = @NumeroVentaProducto 
	AND NumeroAgencia = @NumeroAgencia	
		
		
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalVenta, @NombreMonedaRegion, @CadenaMontoTotal output
	EXEC ConvertirMontoNumerico_a_Texto @MontoTotalVentaCotizado, @NombreMonedaCotizacion, @CadenaMontoTotalCotizado output
	
	SELECT  VP.NumeroAgencia AS [Numero de Agencia],VP.NumeroVentaProducto, C.NombreCliente, 
			LTRIM(RTRIM(CAST(ISNULL(CAST(VP.NumeroFactura as varchar(8000)),
			'SIN FACTURA') AS VARCHAR(8000)))) AS [Numero Factura], VP.FechaHoraVenta,
			CASE WHEN (VP.NumeroCredito IS NULL AND CodigoTipoVenta = 'N') THEN 'EFECTIVO' 
			WHEN (VP.NumeroCredito IS NULL AND CodigoTipoVenta = 'T') THEN 'CONFIANZA'
			ELSE 'A CREDITO' END AS[Tipo Venta],
			CASE (VP.NumeroCredito) WHEN null THEN '-1' ELSE VP.NumeroCredito END AS [Numero de Cr?dito] ,VP.Observaciones,
			C.NITCliente, CASE (C.CodigoTipoCliente) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS [Tipo Cliente], 
			C.NombreRepresentante,C.Telefono,C.Direccion, MO.NombreMoneda, MO.MascaraMoneda, 
			@MontoTotalVenta AS MontoTotalVenta, 
			@NombreMonedaRegion AS NombreMonedaRegion, @MascaraMonedaRegion AS MascaraMonedaRegion, 
			@CadenaMontoTotal AS CadenaMontoTotal, @FactorCambioCotizacion AS FactorCambioCotizacion, 
			@MontoTotalVentaCotizado as MontoTotalVentaReal,
			@CadenaMontoTotalCotizado AS CadenaMontoTotalCotizacion,VP.CodigoVentaProducto			
	FROM VentasProductos VP LEFT JOIN VentasFacturas VF ON VP.NumeroAgencia = VF.NumeroAgencia AND VP.NumeroFactura = VF.NumeroFactura
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
	INNER JOIN Monedas MO ON MO.CodigoMoneda = VP.CodigoMoneda
	WHERE VP.NumeroAgencia = @NumeroAgencia
	AND VP.NumeroVentaProducto = @NumeroVentaProducto	
END
GO

--EXEC ListarVentaProductoReporte 1, 448
--119.40	BOLIVIANOS	Bs	CIENTO DIEZ Y NUEVE  40/100 BOLIVIANOS  	6.89	119.40	CIENTO DIEZ Y NUEVE  40/100 BOLIVIANOS                                                                                                                                                                                                                         


DROP PROCEDURE ListarVentasProductosReporte
GO

CREATE PROCEDURE ListarVentasProductosReporte
AS
BEGIN
	SELECT  VP.NumeroAgencia AS [Numero de Agencia],VP.NumeroVentaProducto, C.NombreCliente, VP.NumeroFactura, VP.FechaHoraVenta,
			CASE (VP.NumeroCredito) WHEN null THEN 'EFECTIVO' ELSE 'A CREDITO' END AS[Tipo Venta], 
			CASE (VP.NumeroCredito) WHEN null THEN '-1' ELSE VP.NumeroCredito END ,VP.Observaciones,
			C.NITCliente, CASE (C.CodigoTipoCliente) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS [Tipo Cliente], 
			C.NombreRepresentante,C.Telefono,C.Direccion, VP.CodigoVentaProducto
	FROM VentasProductos VP LEFT JOIN VentasFacturas VF ON VP.NumeroAgencia = VF.NumeroAgencia AND VP.NumeroFactura = VF.NumeroFactura
	INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente
END
GO


DROP PROCEDURE ListarVentaProductoReporteAnidado
GO

CREATE PROCEDURE ListarVentaProductoReporteAnidado
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT
AS
BEGIN
	SELECT  VP.NumeroAgencia AS [Numero de Agencia],VP.NumeroVentaProducto, C.NombreCliente, VP.NumeroFactura, VP.FechaHoraVenta,
			CASE (VP.NumeroCredito) WHEN null THEN 'EFECTIVO' ELSE 'A CREDITO' END AS[Tipo Venta], 
			CASE (VP.NumeroCredito) WHEN null THEN '-1' ELSE VP.NumeroCredito END ,VP.Observaciones,
			C.NITCliente, CASE (C.CodigoTipoCliente) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END AS [Tipo Cliente], 
			C.NombreRepresentante, C.Telefono, C.Direccion, VP.CodigoVentaProducto
			--VPD.CantidadVenta, VPD.PrecioUnitarioVenta, (VPD.CantidadVenta*VPD.PrecioUnitarioVenta) as PrecioTotalVenta, VPD.TiempoGarantiaVenta, P.NombreProducto, VPD.CodigoProducto, VPE.CodigoProductoEspecifico, VPE.TiempoGarantiaPE
	FROM VentasProductos VP 
		INNER JOIN VentasProductosDetalle VPD ON VPD.NumeroAgencia =VP.NumeroAgencia AND VPD.NumeroVentaProducto = VP.NumeroVentaProducto
		LEFT JOIN VentasFacturas VF ON VP.NumeroAgencia = VF.NumeroAgencia AND VP.NumeroFactura = VF.NumeroFactura
		INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente	
		INNER JOIN Productos P ON P.CodigoProducto = VPD.CodigoProducto
		LEFT JOIN VentasProductosEspecificos VPE 
		ON VPD.NumeroAgencia = VPE.NumeroAgencia AND VPD.NumeroVentaProducto = VPE.NumeroVentaProducto	
		AND VPD.CodigoProducto = VPE.CodigoProducto
	WHERE VP.NumeroAgencia = @NumeroAgencia
	AND VP.NumeroVentaProducto = @NumeroVentaProducto	
END
GO


DROP PROCEDURE ListarTuplaDatosVentaProductoReporte
GO


CREATE PROCEDURE ListarTuplaDatosVentaProductoReporte
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,
	@ListadoAtributosVenta VARCHAR(8000) OUTPUT
AS
BEGIN
	SELECT TOP(1) @ListadoAtributosVenta = RTRIM(LTRIM(CAST(VP.NumeroAgencia AS CHAR(100)))) +', '+ RTRIM(LTRIM(CAST(VP.NumeroVentaProducto AS VARCHAR(8000)))) +', '+ C.NombreCliente +', '+ CASE WHEN VP.NumeroFactura IS NULL THEN 'Sin Factura' ELSE RTRIM(LTRIM(CAST(VP.NumeroFactura  AS VARCHAR(8000)))) END +', '+ CONVERT(varchar, VP.FechaHoraVenta, 113) +', '+ 
				 CASE (VP.NumeroCredito) WHEN null THEN 'EFECTIVO' ELSE 'A CREDITO' END  +', '+CASE WHEN VP.NumeroCredito IS NULL THEN ' Cancelado ' ELSE RTRIM(LTRIM(CAST(VP.NumeroCredito AS VARCHAR(8000)))) END +', ' + CASE WHEN VP.Observaciones IS NULL OR LEN(RTRIM(LTRIM(CAST(VP.Observaciones AS VARCHAR(8000)))))<=1 THEN 'Ninguna' ELSE RTRIM(LTRIM(CAST(VP.Observaciones AS VARCHAR(8000)))) END +', '+
				 CASE WHEN C.NITCliente IS NULL THEN 'Ninguno'ELSE C.NITCliente END +', '+ CASE (C.CodigoTipoCliente) WHEN 'P' THEN 'PERSONA' WHEN 'E' THEN 'EMPRESA' END +', '+ CASE WHEN C.NombreRepresentante IS NULL THEN C.NombreCliente ELSE C.NombreRepresentante END +', ' + CASE WHEN C.Telefono IS NULL OR LEN(RTRIM(LTRIM(C.Telefono))) < 1 THEN  ' Sin N?mero' ELSE C.Telefono END +', '+ CASE WHEN C.Direccion IS NULL OR LEN(RTRIM(LTRIM(C.Direccion))) < 1 THEN ' Sin Direcci?n' ELSE C.Direccion 	END +', '+ U.Nombres+' '+U.Paterno+' '+U.Materno
	FROM VentasProductos VP 		
			LEFT JOIN VentasFacturas VF ON VP.NumeroAgencia = VF.NumeroAgencia AND VP.NumeroFactura = VF.NumeroFactura
			INNER JOIN Clientes C ON C.CodigoCliente = VP.CodigoCliente	
			INNER JOIN Usuarios U ON U.CodigoUsuario = VP.CodigoUsuario
	WHERE VP.NumeroAgencia = @NumeroAgencia
	AND VP.NumeroVentaProducto = @NumeroVentaProducto	
END
GO



DROP PROCEDURE ActualizarCodigoEstadoVenta
GO


CREATE PROCEDURE ActualizarCodigoEstadoVenta
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,
	@CodigoEstadoVenta		CHAR(1),	
	@NumeroFactura			INT
AS
BEGIN
	IF(@NumeroFactura IS NULL)
	BEGIN
		UPDATE VentasProductos
			SET CodigoEstadoVenta = @CodigoEstadoVenta
				--FechaHoraVenta = GETDATE()
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroVentaProducto	
	END
	ELSE
	BEGIN
		UPDATE VentasProductos
			SET CodigoEstadoVenta = @CodigoEstadoVenta,
				--FechaHoraVenta = GETDATE(),
				NumeroFactura = @NumeroFactura
		WHERE NumeroAgencia = @NumeroAgencia
		AND NumeroVentaProducto = @NumeroVentaProducto	
	END
END
GO



DROP PROCEDURE InsertarVentaProductoXMLDetalle
GO

CREATE PROCEDURE InsertarVentaProductoXMLDetalle
	@NumeroAgencia			INT,
	@CodigoCliente			INT,
	@CodigoUsuario			INT,
	@NumeroFactura			INT,
	@FechaHoraVenta			DATETIME,
	@CodigoEstadoVenta		CHAR(1),
	@MontoTotalVenta		DECIMAL(10,2),
	@NumeroCredito			INT,
	@CodigoMoneda			TINYINT,
	@CodigoTipoVenta		CHAR(1),
	@Observaciones			TEXT,
	@MontoTotalVentaProductos DECIMAL(10,2),
	@MontoTotalVentaServicios DECIMAL(10,2),
	@NumeroVentaServicio	INT,	
	@ProductosDetalle		TEXT
AS
BEGIN
	BEGIN TRANSACTION 
	
		DECLARE @PorcentajeImpuestoIVA	DECIMAL(10,2)
				
		SET @FechaHoraVenta = GETDATE()
		
		SELECT TOP(1) @PorcentajeImpuestoIVA = PorcentajeImpuesto
		FROM PCsConfiguraciones 
		WHERE NumeroAgencia = @NumeroAgencia
		
		
		
		IF(@NumeroCredito IS NULL)	
		BEGIN		
			INSERT INTO dbo.VentasProductos(NumeroAgencia, CodigoCliente, CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoEstadoVenta, MontoTotalVenta, NumeroCredito, Observaciones, CodigoMoneda, CodigoTipoVenta, MontoTotalVentaProductos, MontoTotalVentaServicios, NumeroVentaServicio)
			VALUES (@NumeroAgencia, @CodigoCliente, @CodigoUsuario, @NumeroFactura, @FechaHoraVenta,  @CodigoEstadoVenta, @MontoTotalVenta, @NumeroCredito, @Observaciones, @CodigoMoneda, @CodigoTipoVenta, @MontoTotalVentaProductos, @MontoTotalVentaServicios, @NumeroVentaServicio)
		END
		ELSE
		BEGIN
			DECLARE @CodigoTipoCredito CHAR(1)
			SELECT @CodigoTipoCredito = C.CodigoTipoCredito
			FROM Creditos C
			WHERE C.NumeroCredito = @NumeroCredito
			
			SELECT @CodigoEstadoVenta = CASE WHEN @CodigoTipoCredito = 'L' THEN 'I'
											 WHEN @CodigoTipoCredito = 'T' THEN 'I'
											 WHEN @CodigoTipoCredito = 'P' THEN 'I'  END
			
			INSERT INTO dbo.VentasProductos(
						NumeroAgencia, CodigoCliente, 
						CodigoUsuario, NumeroFactura, 
						FechaHoraVenta, 
						CodigoEstadoVenta, 
						MontoTotalVenta, NumeroCredito, 
						Observaciones, CodigoMoneda, 
						CodigoTipoVenta, 
						MontoTotalVentaProductos, 
						MontoTotalVentaServicios, NumeroVentaServicio)
			VALUES (	@NumeroAgencia, @CodigoCliente, 
						@CodigoUsuario, @NumeroFactura, 
						@FechaHoraVenta, 						
						@CodigoEstadoVenta,						
						CASE WHEN @NumeroFactura IS NULL THEN @MontoTotalVenta ELSE @MontoTotalVenta + (@MontoTotalVenta * (@PorcentajeImpuestoIVA / 100)) END,
						@NumeroCredito, 
						@Observaciones, @CodigoMoneda, 
						@CodigoTipoVenta, 
						@MontoTotalVentaProductos, 
						@MontoTotalVentaServicios, @NumeroVentaServicio)
		END
		
		DECLARE @punteroXMLProductosDetalle INT,
				@NumeroVentaProducto		INT
		
		--SET @NumeroVentaProducto = @@IDENTITY
		SET @NumeroVentaProducto = SCOPE_IDENTITY()--Devuelve el ultimo id Ingresado en una Tabla con una columna Identidad dentro del Ambito,
		--es Decir en este caso, devolver? el ultimo IDENTITY generado dentro de la Tabla VentasProductos para esta transacci?n
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
		
		INSERT INTO dbo.VentasProductosDetalle(
				NumeroAgencia, 
				NumeroVentaProducto, 
				CodigoProducto, 
				CantidadVenta, 
				CantidadEntregada, 
				PrecioUnitarioVenta, 
				PrecioUnitarioVentaOtraMoneda,
				TiempoGarantiaVenta, 
				PorcentajeDescuento, 
				NumeroPrecioSeleccionado,
				NumeroOrdenInsertado)
		SELECT  @NumeroAgencia, 
				@NumeroVentaProducto, 
				CodigoProducto, 
				Cantidad, 
				--CASE WHEN (Cantidad > CantidadExistencia) THEN CantidadEntregada ELSE Cantidad END AS CantidadEntregada, 
				CantidadEntregada,
				CASE WHEN @NumeroFactura IS NULL THEN Precio ELSE Precio + (Precio * (@PorcentajeImpuestoIVA / 100)) END, 
				PrecioUnitarioOtraMoneda,
				Garantia, 
				PorcentajeDescuento, 
				NumeroPrecioSeleccionado,
				NumeroOrdenInsertado
		FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
		WITH(	CodigoProducto				VARCHAR(15),
				Cantidad					INT,
				CantidadEntregada			INT,
				Precio						DECIMAL(10,2),
				PrecioUnitarioOtraMoneda	DECIMAL(10,2),
				Garantia					INT,
				PorcentajeDescuento			DECIMAL(10,2),
				NumeroPrecioSeleccionado	CHAR(1),
				NumeroOrdenInsertado		INT
				)
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo ingresar la Venta de Productos',1,16)	
			ROLLBACK TRAN
		END
	COMMIT TRANSACTION
END
GO



DROP PROCEDURE ActualizarVentaProductoXMLDetalle
GO
CREATE PROCEDURE ActualizarVentaProductoXMLDetalle
	@NumeroAgencia			INT,
	@NumeroVentaProducto	INT,
	@CodigoCliente			INT,
	@CodigoUsuario			INT,
	@NumeroFactura			INT,
	@FechaHoraVenta			DATETIME,
	@CodigoEstadoVenta		CHAR(1),
	@MontoTotalVenta		DECIMAL(10,2),
	@NumeroCredito			INT,
	@CodigoMoneda			TINYINT,
	@CodigoTipoVenta		CHAR(1),
	@Observaciones			TEXT,
	@MontoTotalVentaProductos DECIMAL(10,2),
	@MontoTotalVentaServicios DECIMAL(10,2),
	@NumeroVentaServicio	INT,
	@ProductosDetalle		TEXT
AS
BEGIN
	BEGIN TRANSACTION 
		DECLARE @PorcentajeImpuestoIVA	DECIMAL(10,2)		
		SELECT TOP(1) @PorcentajeImpuestoIVA = PorcentajeImpuesto
		FROM PCsConfiguraciones 
		WHERE NumeroAgencia = @NumeroAgencia
		
		
		SET @MontoTotalVenta = CASE WHEN @NumeroFactura IS NULL THEN @MontoTotalVenta ELSE @MontoTotalVenta + (@MontoTotalVenta * (@PorcentajeImpuestoIVA / 100)) END
		
		EXEC ActualizarVentaProducto @NumeroAgencia, @NumeroVentaProducto, @CodigoCliente,
			@CodigoUsuario, @NumeroFactura, @FechaHoraVenta, @CodigoEstadoVenta, 
			@MontoTotalVenta,
			@NumeroCredito, @CodigoMoneda, @CodigoTipoVenta, @Observaciones,
			@MontoTotalVentaProductos, @MontoTotalVentaServicios, @NumeroVentaServicio
			
			
		DECLARE @punteroXMLProductosDetalle INT		
		
					
		EXEC sp_xml_preparedocument @punteroXMLProductosDetalle OUTPUT, @ProductosDetalle
		--PARA INSERTAR LOS NUEVOS REGISTROS EN LA EDICI?N 
		------------------------------------------------------------------------------------
		
		INSERT INTO dbo.VentasProductosDetalle(
				NumeroAgencia,
				NumeroVentaProducto,
				CodigoProducto,
				CantidadVenta,
				CantidadEntregada,
				PrecioUnitarioVenta,
				PrecioUnitarioVentaOtraMoneda,
				TiempoGarantiaVenta,
				PorcentajeDescuento,
				NumeroPrecioSeleccionado
				)
		SELECT  @NumeroAgencia, 
				@NumeroVentaProducto, 
				CodigoProducto,				
				Cantidad,
				CantidadEntregada,
				CASE WHEN @NumeroFactura IS NULL THEN Precio ELSE Precio + (Precio * (@PorcentajeImpuestoIVA / 100)) END, 
				PrecioUnitarioOtraMoneda,
				Garantia,
				PorcentajeDescuento,
				NumeroPrecioSeleccionado				
		FROM  OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)
		WITH (CodigoProducto			VARCHAR(15),
			  Cantidad					INT,	
			  CantidadEntregada			INT,					  
			  Precio					DECIMAL(10,2),	
			  PrecioUnitarioOtraMoneda	DECIMAL(10,2),					  
			  Garantia					INT,
			  PorcentajeDescuento		DECIMAL(10,2),
			  NumeroPrecioSeleccionado	CHAR(1)
		)
		WHERE CodigoProducto NOT IN(
			SELECT VSD.CodigoProducto
			FROM dbo.VentasProductosDetalle VSD
			WHERE VSD.NumeroAgencia = @NumeroAgencia
			AND VSD.NumeroVentaProducto = @NumeroVentaProducto
		)
		
		--ACTUALIZAR LOS REGISTROS
		------------------------------------------------------------------------------------
		UPDATE VentasProductosDetalle
			SET VentasProductosDetalle.PrecioUnitarioVenta = CASE WHEN @NumeroFactura IS NULL THEN VSDXML.Precio ELSE VSDXML.Precio + (VSDXML.Precio * (@PorcentajeImpuestoIVA / 100)) END,
				VentasProductosDetalle.PrecioUnitarioVentaOtraMoneda = VSDXML.PrecioUnitarioOtraMoneda,
				VentasProductosDetalle.CantidadVenta = VSDXML.Cantidad,
				VentasProductosDetalle.CantidadEntregada = CASE WHEN VSDXML.CantidadEntregada > VSDXML.Cantidad THEN VSDXML.Cantidad ELSE VSDXML.CantidadEntregada END,
				VentasProductosDetalle.TiempoGarantiaVenta = VSDXML.Garantia,
				VentasProductosDetalle.PorcentajeDescuento = VSDXML.PorcentajeDescuento,
				VentasProductosDetalle.NumeroPrecioSeleccionado = VSDXML.NumeroPrecioSeleccionado				
		FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2) 
		WITH(	
			CodigoProducto			VARCHAR(15),
			Cantidad				INT,			
			Precio					DECIMAL(10,2),
			PrecioUnitarioOtraMoneda DECIMAL(10,2),
			Garantia				INT,
			CantidadEntregada		INT,
			PorcentajeDescuento		DECIMAL(10,2),
			NumeroPrecioSeleccionado	CHAR(1)			
		) VSDXML
		WHERE VentasProductosDetalle.NumeroAgencia = @NumeroAgencia
		AND VentasProductosDetalle.NumeroVentaProducto = @NumeroVentaProducto
		AND VentasProductosDetalle.CodigoProducto = VSDXML.CodigoProducto
		
		--QUITAR LOS REGISTROS QUE FUERON ELIMINADOS
		--------------------------------------------------------------------------
		DELETE
		FROM dbo.VentasProductosDetalle
		WHERE CodigoProducto NOT IN
		(
			SELECT  CodigoProducto				
			FROM OPENXML (@punteroXMLProductosDetalle, '/Productos/ProductosDetalle',2)		
			WITH(
					CodigoProducto			CHAR(15)
				)
		)
		AND VentasProductosDetalle.NumeroAgencia = @NumeroAgencia
		AND VentasProductosDetalle.NumeroVentaProducto = @NumeroVentaProducto
		
		EXEC sp_xml_removedocument @punteroXMLProductosDetalle
		IF(@@ERROR <> 0)
		BEGIN
			RAISERROR('No se Pudo Actualizar la Venta de Servicios',1,16)	
			ROLLBACK TRAN
		END
		ELSE
			COMMIT TRANSACTION
END
GO



DROP PROCEDURE ObtenerCreditoDesdeCodigoAutorizacion
GO
CREATE PROCEDURE ObtenerCreditoDesdeCodigoAutorizacion
	@CodigoAutorizacion				CHAR(10),
	@NumeroAgencia					INT,
	@EsParaCreditoLibreDisposicion	BIT
AS
BEGIN	
	SELECT NumeroCredito, dbo.ObtenerNombreCompleto(DIDeudor) AS NombreCompletoDeudor,
			dbo.ObtenerNombreCompleto(DIGarante1) AS NombreCompletoGarante,
			MontoDeuda, MontoDisponible, CodigoTipoCredito, CodigoEstadoCredito,
			InteresAnual, FechaHoraAutorizacion, Observaciones, CodigoMoneda,
			dbo.ObtenerMontoGastadoCreditoVentas(NumeroCredito) AS MontoGastadoCredito,
			NumeroCotizacion
		FROM Creditos	
		WHERE CodigoAutorizacion = @CodigoAutorizacion
		AND  NumeroAgenciaAutorizacion = @NumeroAgencia	

	
	--IF(@EsParaCreditoLibreDisposicion = 1)
	--	SELECT NumeroCredito, dbo.ObtenerNombreCompleto(DIDeudor) AS NombreCompletoDeudor,
	--		dbo.ObtenerNombreCompleto(DIGarante1) AS NombreCompletoGarante,
	--		MontoDeuda, MontoDisponible, CodigoTipoCredito, CodigoEstadoCredito,
	--		InteresAnual, FechaHoraAutorizacion, Observaciones, CodigoMoneda,
	--		dbo.ObtenerMontoGastadoCreditoVentas(NumeroCredito) AS MontoGastadoCredito
	--	FROM Creditos	
	--	WHERE CodigoAutorizacion = @CodigoAutorizacion
	--	AND  NumeroAgenciaAutorizacion = @NumeroAgencia	
	--	AND CodigoTipoCredito = 'L'
	--ELSE
	--	SELECT NumeroCredito, dbo.ObtenerNombreCompleto(DIDeudor) AS NombreCompletoDeudor,
	--		dbo.ObtenerNombreCompleto(DIGarante1) AS NombreCompletoGarante,
	--		MontoDeuda, MontoDisponible, CodigoTipoCredito, CodigoEstadoCredito,
	--		InteresAnual, FechaHoraAutorizacion, Observaciones, CodigoMoneda,
	--		dbo.ObtenerMontoGastadoCreditoVentas(NumeroCredito) AS MontoGastadoCredito
	--	FROM Creditos	
	--	WHERE CodigoAutorizacion = @CodigoAutorizacion
	--	AND  NumeroAgenciaAutorizacion = @NumeroAgencia	
	--	AND CodigoTipoCredito IN ('P','T')
	
END
GO

--exec ObtenerCreditoDesdeCodigoAutorizacion '4534872081',1, 0





--SELECT NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadVenta, CantidadEntregada, PrecioUnitarioVenta, TiempoGarantiaVenta, PorcentajeDescuento, NumeroPrecioSeleccionado
--from VentasProductosDetalle
--'<Productos>
--  <ProductosDetalle>
--    <CodigoProducto>1</CodigoProducto>
--    <NombreProducto>PROCESADOR DUAL CORE</NombreProducto>
--    <Cantidad>1</Cantidad>
--    <Precio>12.00</Precio>
--    <PrecioTotal>12.00</PrecioTotal>
--    <Garantia>0</Garantia>
--    <EsProductoEspecifico>false</EsProductoEspecifico>
--    <VendidoComoAgregado>false</VendidoComoAgregado>
--    <CantidadExistencia>1</CantidadExistencia>
--    <CantidadEntregada>1</CantidadEntregada>
--    <PorcentajeDescuento>0</PorcentajeDescuento>
--    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
--  </ProductosDetalle>  
--</Productos>'

--go

--select @@IDENTITY as IDENTITYT, SCOPE_IDENTITY() AS SCOPE_IDENTITY



--<Productos>
--  <ProductosDetalle>
--    <CodigoProducto>001-TAR-000026</CodigoProducto>
--    <Cantidad>1</Cantidad>
--    <Precio>120.00</Precio>
--    <PrecioTotal>120.00</PrecioTotal>
--    <Garantia>180</Garantia>
--    <EsProductoEspecifico>true</EsProductoEspecifico>
--    <VendidoComoAgregado>false</VendidoComoAgregado>
--    <CantidadExistencia>1</CantidadExistencia>
--    <CantidadEntregada>1</CantidadEntregada>
--    <PorcentajeDescuento>0</PorcentajeDescuento>
--    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
--    <NumeroOrdenInsertado>0</NumeroOrdenInsertado>
--  </ProductosDetalle>
--  <ProductosDetalle>
--    <CodigoProducto>001-MON-000042</CodigoProducto>
--    <Cantidad>1</Cantidad>
--    <Precio>399.98</Precio>
--    <PrecioTotal>399.98</PrecioTotal>
--    <Garantia>0</Garantia>
--    <EsProductoEspecifico>true</EsProductoEspecifico>
--    <VendidoComoAgregado>false</VendidoComoAgregado>
--    <CantidadExistencia>1</CantidadExistencia>
--    <CantidadEntregada>1</CantidadEntregada>
--    <PorcentajeDescuento>0</PorcentajeDescuento>
--    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
--    <NumeroOrdenInsertado>1</NumeroOrdenInsertado>
--  </ProductosDetalle>
--  <ProductosDetalle>
--    <CodigoProducto>001-EST-000010</CodigoProducto>
--    <Cantidad>1</Cantidad>
--    <Precio>23.50</Precio>
--    <PrecioTotal>23.50</PrecioTotal>
--    <Garantia>720</Garantia>
--    <EsProductoEspecifico>true</EsProductoEspecifico>
--    <VendidoComoAgregado>false</VendidoComoAgregado>
--    <CantidadExistencia>1</CantidadExistencia>
--    <CantidadEntregada>1</CantidadEntregada>
--    <PorcentajeDescuento>0</PorcentajeDescuento>
--    <NumeroPrecioSeleccionado>1</NumeroPrecioSeleccionado>
--    <NumeroOrdenInsertado>2</NumeroOrdenInsertado>
--  </ProductosDetalle>
--</Productos>