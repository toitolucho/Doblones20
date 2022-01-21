use DOBLONES20
GO

DROP PROCEDURE InsertarProductoImagen
GO

CREATE PROCEDURE InsertarProductoImagen
	@CodigoProducto		CHAR(15),
	@NumeroImagen		INT,
	@RutaImagenProducto	TEXT
AS
BEGIN
	INSERT INTO dbo.ProductosImagenes (CodigoProducto, NumeroImagen, RutaImagenProducto)
	VALUES (@CodigoProducto, @NumeroImagen, @RutaImagenProducto)
END
GO

DROP PROCEDURE ActualizarProductoImagen
GO

CREATE PROCEDURE ActualizarProductoImagen
	@CodigoProducto		CHAR(15),
	@NumeroImagen		INT,
	@RutaImagenProducto	TEXT
AS
BEGIN
	UPDATE 	dbo.ProductosImagenes
	SET		
		RutaImagenProducto = @RutaImagenProducto		
	WHERE (@CodigoProducto = CodigoProducto) AND (@NumeroImagen = NumeroImagen)
END
GO

DROP PROCEDURE EliminarProductoImagen
GO

CREATE PROCEDURE EliminarProductoImagen
	@CodigoProducto		CHAR(15),
	@NumeroImagen		INT
AS
BEGIN
	DELETE 
	FROM dbo.ProductosImagenes
	WHERE (@CodigoProducto = CodigoProducto) AND (@NumeroImagen = NumeroImagen)
END
GO

DROP PROCEDURE ListarProductosImagenes
GO

CREATE PROCEDURE ListarProductosImagenes
AS
BEGIN
	SELECT CodigoProducto,NumeroImagen,RutaImagenProducto 
	FROM dbo.ProductosImagenes
	ORDER BY CodigoProducto,NumeroImagen
END
GO

DROP PROCEDURE ObtenerProductoImagen
GO

CREATE PROCEDURE ObtenerProductoImagen
	@CodigoProducto		CHAR(15),
	@NumeroImagen		INT
AS
BEGIN
	SELECT CodigoProducto, NumeroImagen, RutaImagenProducto 
	FROM dbo.ProductosImagenes
	WHERE (@CodigoProducto = CodigoProducto) AND (@NumeroImagen = NumeroImagen)
END
GO

DROP PROCEDURE ListarProductosImagenesPorProducto
GO

CREATE PROCEDURE ListarProductosImagenesPorProducto
@CodigoProducto			CHAR(15)
AS
BEGIN
	SELECT CodigoProducto, NumeroImagen, RutaImagenProducto 
	FROM dbo.ProductosImagenes
	WHERE CodigoProducto = @CodigoProducto
	ORDER BY CodigoProducto, NumeroImagen
END
GO
