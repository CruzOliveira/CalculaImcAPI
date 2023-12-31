USE [master]
GO
/****** Object:  Database [Estuda_Sql]    Script Date: 23/10/2023 16:32:24 ******/
CREATE DATABASE [Estuda_Sql]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Estuda_Sql', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.PDA_DEV\MSSQL\DATA\Estuda_Sql.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Estuda_Sql_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.PDA_DEV\MSSQL\DATA\Estuda_Sql_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Estuda_Sql] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Estuda_Sql].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Estuda_Sql] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Estuda_Sql] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Estuda_Sql] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Estuda_Sql] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Estuda_Sql] SET ARITHABORT OFF 
GO
ALTER DATABASE [Estuda_Sql] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Estuda_Sql] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Estuda_Sql] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Estuda_Sql] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Estuda_Sql] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Estuda_Sql] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Estuda_Sql] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Estuda_Sql] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Estuda_Sql] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Estuda_Sql] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Estuda_Sql] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Estuda_Sql] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Estuda_Sql] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Estuda_Sql] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Estuda_Sql] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Estuda_Sql] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Estuda_Sql] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Estuda_Sql] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Estuda_Sql] SET  MULTI_USER 
GO
ALTER DATABASE [Estuda_Sql] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Estuda_Sql] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Estuda_Sql] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Estuda_Sql] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Estuda_Sql] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Estuda_Sql] SET QUERY_STORE = OFF
GO
USE [Estuda_Sql]
GO
/****** Object:  UserDefinedFunction [dbo].[IMC_FN_CALCULA_IMC]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IMC_FN_CALCULA_IMC]
   (@PESO DECIMAL(5,2), @ALTURA DECIMAL(5,2))
RETURNS DECIMAL(5,2)
AS
BEGIN
    DECLARE @IMC DECIMAL(5,2)
    SET @IMC = @PESO / (@ALTURA * @ALTURA)
    RETURN @IMC
END
GO
/****** Object:  UserDefinedFunction [dbo].[IMC_FN_CLASSIFICACAO]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IMC_FN_CLASSIFICACAO] (@IMC DECIMAL(18,2)) 
RETURNS VARCHAR(255) 
AS  
BEGIN  
      RETURN (
	  SELECT CASE WHEN @IMC < 16.9                THEN 'MUITO ABAIXO DO PESO' 
				WHEN @IMC BETWEEN 17   AND 18.4 THEN 'ABAIXO DO PESO'
				WHEN @IMC BETWEEN 18.5 AND 24.9 THEN 'PESO NORMAL'
				WHEN @IMC BETWEEN 25   AND 29.9	THEN 'ACIMA DO PESO'
				WHEN @IMC BETWEEN 30   AND 34.9	THEN 'OBESIDADE GRAU I'
				WHEN @IMC BETWEEN 35   AND 40	THEN 'OBESIDADE GRAU II'
				WHEN @IMC > 40					THEN 'OBESIDADE GRAU III'
		   END )
END  
GO
/****** Object:  UserDefinedFunction [dbo].[IMC_FN_VALIDA_CPF]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IMC_FN_VALIDA_CPF] (@CPF VARCHAR(11))
RETURNS BIT
AS
BEGIN
    DECLARE @RESULTADO BIT = 0;
    DECLARE @SOMA1 INT, @SOMA2 INT;
    DECLARE @DIGITO1 INT, @DIGITO2 INT;

    -- REMOVER CARACTERES NÃO NUMÉRICOS
    SET @CPF = REPLACE(@CPF, '-', '');
    SET @CPF = REPLACE(@CPF, '.', '');

    -- VERIFICAR SE O CPF TEM 11 DÍGITOS
    IF LEN(@CPF) = 11
    BEGIN
        -- CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR
        SET @SOMA1 = CAST(SUBSTRING(@CPF, 1, 1) AS INT) * 10
                  + CAST(SUBSTRING(@CPF, 2, 1) AS INT) * 9
                  + CAST(SUBSTRING(@CPF, 3, 1) AS INT) * 8
                  + CAST(SUBSTRING(@CPF, 4, 1) AS INT) * 7
                  + CAST(SUBSTRING(@CPF, 5, 1) AS INT) * 6
                  + CAST(SUBSTRING(@CPF, 6, 1) AS INT) * 5
                  + CAST(SUBSTRING(@CPF, 7, 1) AS INT) * 4
                  + CAST(SUBSTRING(@CPF, 8, 1) AS INT) * 3
                  + CAST(SUBSTRING(@CPF, 9, 1) AS INT) * 2;

        SET @DIGITO1 = 11 - (@SOMA1 % 11);

        IF @DIGITO1 >= 10
            SET @DIGITO1 = 0;

        -- CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR
        SET @SOMA2 = CAST(SUBSTRING(@CPF, 1, 1) AS INT) * 11
                  + CAST(SUBSTRING(@CPF, 2, 1) AS INT) * 10
                  + CAST(SUBSTRING(@CPF, 3, 1) AS INT) * 9
                  + CAST(SUBSTRING(@CPF, 4, 1) AS INT) * 8
                  + CAST(SUBSTRING(@CPF, 5, 1) AS INT) * 7
                  + CAST(SUBSTRING(@CPF, 6, 1) AS INT) * 6
                  + CAST(SUBSTRING(@CPF, 7, 1) AS INT) * 5
                  + CAST(SUBSTRING(@CPF, 8, 1) AS INT) * 4
                  + CAST(SUBSTRING(@CPF, 9, 1) AS INT) * 3
                  + @DIGITO1 * 2;

        SET @DIGITO2 = 11 - (@SOMA2 % 11);

        IF @DIGITO2 >= 10
            SET @DIGITO2 = 0;

        -- VERIFICAR SE OS DÍGITOS VERIFICADORES SÃO IGUAIS AOS DO CPF
        IF @DIGITO1 = CAST(SUBSTRING(@CPF, 10, 1) AS INT)
           AND @DIGITO2 = CAST(SUBSTRING(@CPF, 11, 1) AS INT)
            SET @RESULTADO = 1;
    END

    RETURN @RESULTADO;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[IMC_FN_VALIDA_STATUS]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IMC_FN_VALIDA_STATUS]
   (@ID_USER INT)
RETURNS BIT
AS
BEGIN
	DECLARE @STATUS BIT
    SELECT @STATUS = STATUS FROM IMC_TB_USER WHERE ID_USER = @ID_USER
	RETURN @STATUS
END
GO
/****** Object:  Table [dbo].[IMC_TB_INFO_USER]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMC_TB_INFO_USER](
	[ID_INFO_USER] [int] IDENTITY(1,1) NOT NULL,
	[ID_USER] [int] NOT NULL,
	[NOME] [varchar](255) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[DT_NACIMENTO] [varchar](255) NOT NULL,
 CONSTRAINT [PK_IMC_TB_INFO_USER] PRIMARY KEY CLUSTERED 
(
	[ID_INFO_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMC_TB_RESULTADO]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMC_TB_RESULTADO](
	[ID_RESULTADO] [int] IDENTITY(1,1) NOT NULL,
	[ID_INFO_USER] [int] NOT NULL,
	[PESO] [decimal](5, 2) NOT NULL,
	[ALTURA] [decimal](5, 2) NOT NULL,
	[IMC] [decimal](5, 2) NOT NULL,
	[CLASSIFICADO] [varchar](255) NOT NULL,
	[DT_PESQUISA] [date] NOT NULL,
 CONSTRAINT [PK_IMC_TB_RESULTADO] PRIMARY KEY CLUSTERED 
(
	[ID_RESULTADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMC_TB_USER]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMC_TB_USER](
	[ID_USER] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](255) NOT NULL,
	[EMAIL] [varchar](255) NOT NULL,
	[PASSWORD] [varchar](255) NOT NULL,
	[STATUS] [bit] NOT NULL,
	[DT_CADASTRO] [datetime] NOT NULL,
 CONSTRAINT [PK_IMC_TB_USER] PRIMARY KEY CLUSTERED 
(
	[ID_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IMC_TB_INFO_USER]  WITH CHECK ADD  CONSTRAINT [FK_IMC_TB_INFO_USER_IMC_TB_USER1] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[IMC_TB_USER] ([ID_USER])
GO
ALTER TABLE [dbo].[IMC_TB_INFO_USER] CHECK CONSTRAINT [FK_IMC_TB_INFO_USER_IMC_TB_USER1]
GO
ALTER TABLE [dbo].[IMC_TB_RESULTADO]  WITH CHECK ADD  CONSTRAINT [FK_IMC_TB_RESULTADO_IMC_TB_INFO_USER] FOREIGN KEY([ID_INFO_USER])
REFERENCES [dbo].[IMC_TB_INFO_USER] ([ID_INFO_USER])
GO
ALTER TABLE [dbo].[IMC_TB_RESULTADO] CHECK CONSTRAINT [FK_IMC_TB_RESULTADO_IMC_TB_INFO_USER]
GO
/****** Object:  StoredProcedure [dbo].[IMC_SP_ALTERAR_PESO_ALTURA]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IMC_SP_ALTERAR_PESO_ALTURA] 

	@ID_USER INT 
  , @PESO DECIMAL(10,2) 
  , @ALTURA DECIMAL(10,2)
  , @STATUS_VALIDA BIT = NULL
  , @RETORNO VARCHAR(255) = null OUTPUT
AS
BEGIN

	select @ID_USER = ID_USER from IMC_TB_INFO_USER WHERE ID_USER = @ID_USER
	SET @STATUS_VALIDA = dbo.IMC_FN_VALIDA_STATUS(@ID_USER)

	if(@STATUS_VALIDA = 1)
	BEGIN
		UPDATE IMC_TB_RESULTADO SET PESO = @PESO, ALTURA = @ALTURA WHERE ID_INFO_USER = (
		SELECT ID_INFO_USER 
		FROM IMC_TB_INFO_USER 
	    WHERE ID_USER = @ID_USER
	    );
		SET @RETORNO = 'Informacoes alteradas com sucesso'
	END
	ELSE
	BEGIN
		SET @RETORNO = 'Usuario nao existente'
	END
	

END
SELECT * FROM IMC_TB_INFO_USER
GO
/****** Object:  StoredProcedure [dbo].[IMC_SP_ALTERAR_SENHA]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IMC_SP_ALTERAR_SENHA]
      @ID_USER INT 
    , @SENHA_ATUAL VARCHAR(255)
	, @NOVA_SENHA VARCHAR(255) 
	, @STATUS_VALIDA BIT = NULL
	, @RETORNO VARCHAR(255) = NULL OUTPUT
AS
BEGIN
	select @ID_USER = ID_USER from IMC_TB_INFO_USER WHERE ID_USER = @ID_USER
	SET @STATUS_VALIDA = dbo.IMC_FN_VALIDA_STATUS(@ID_USER)

	if(@STATUS_VALIDA = 1)
	BEGIN
		DECLARE @SENHA_ARMAZENADA VARCHAR(255)
    
		SELECT @SENHA_ARMAZENADA = PASSWORD FROM IMC_TB_USER WHERE ID_USER = @ID_USER

		IF @SENHA_ATUAL = @SENHA_ARMAZENADA
		BEGIN
			IF (LEN(@NOVA_SENHA) >= 8)  
			BEGIN
				UPDATE IMC_TB_USER SET PASSWORD = @NOVA_SENHA WHERE ID_USER = @ID_USER
				 SET @RETORNO = 'SENHA ALTERADA COM SUCESSO!'
			END
			ELSE
			BEGIN
				SET @RETORNO = 'NOVA SENHA NÃO ATENDE AOS REQUISITOS MÍNIMOS'
			END
		END
		ELSE
		BEGIN
			SET @RETORNO = 'SENHA INVALIDA'
		END
	END
	ELSE
	BEGIN
		SET @RETORNO = 'Usuario nao existente'		
	END
END

SELECT * FROM IMC_TB_USER
GO
/****** Object:  StoredProcedure [dbo].[IMC_SP_ALTERAR_STATUS_USER]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IMC_SP_ALTERAR_STATUS_USER]
@id_user int
AS
BEGIN 
UPDATE IMC_TB_USER 
	SET STATUS = CASE 
		WHEN STATUS <> 0 THEN 1 
    ELSE 0 
	END
WHERE ID_USER = @id_user;
END

GO
/****** Object:  StoredProcedure [dbo].[IMC_SP_CONSULTA_USUARIO]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IMC_SP_CONSULTA_USUARIO] --[IMC_SP_CONSULTA_USUARIO] 3
        @ID_USER INT
	  , @STATUS_VALIDA BIT = NULL
AS
BEGIN
	SELECT @ID_USER = ID_USER FROM IMC_TB_INFO_USER WHERE ID_USER = @ID_USER
	SET @STATUS_VALIDA = DBO.IMC_FN_VALIDA_STATUS(@ID_USER)

	IF(@STATUS_VALIDA = 1)
	BEGIN
		;WITH CONSULTA AS (
			SELECT
				  A.ID_USER         
				, A.NOME
				, B.PESO
				, B.ALTURA
				, B.IMC
				, B.CLASSIFICADO
				, B.DT_PESQUISA
			FROM IMC_TB_INFO_USER A
			JOIN IMC_TB_RESULTADO B  ON A.ID_INFO_USER = B.ID_INFO_USER
			WHERE A.ID_USER = @ID_USER
		)
	
		SELECT
			  A.ID_USER 
			, A.NOME
			,(
				SELECT
					  B.PESO
					, B.ALTURA
					, B.IMC
					, B.CLASSIFICADO
					, B.DT_PESQUISA
				FROM CONSULTA B
				WHERE A.ID_USER = B.ID_USER
				FOR JSON PATH
			) AS 'HISTORIOCOIMC'
		FROM CONSULTA A
		GROUP BY A.ID_USER
			   , A.NOME
		FOR JSON PATH, ROOT ('USUARIO')
	END
END

GO
/****** Object:  StoredProcedure [dbo].[IMC_SP_CRIACAO_RESULTADO]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IMC_SP_CRIACAO_RESULTADO] 
      @ID_USER INT
	, @ALTURA DECIMAL(5,2) 
	, @PESO DECIMAL(5,2) 
	, @IMC DECIMAL(5,2) = NULL
	, @STATUS_VALIDA BIT = NULL
	, @ID_INFO_USER INT = NULL
	, @RETORNO VARCHAR(255) = NULL OUTPUT
AS
BEGIN
	
	SELECT @ID_USER = ID_USER 
	FROM IMC_TB_INFO_USER 
	WHERE ID_USER = @ID_USER

	SET @STATUS_VALIDA = DBO.IMC_FN_VALIDA_STATUS(@ID_USER)

	IF(@STATUS_VALIDA = 1)
	BEGIN
		SELECT @ID_INFO_USER = ID_INFO_USER 
		FROM IMC_TB_INFO_USER 
		WHERE ID_USER = @ID_USER

		SET @IMC = DBO.IMC_FN_CALCULA_IMC(@PESO
		                                , @ALTURA)

		IF(
		SELECT ID_USER 
		FROM IMC_TB_INFO_USER 
		WHERE ID_USER = @ID_USER
		) != 0
		BEGIN
		INSERT INTO IMC_TB_RESULTADO(
					  ID_INFO_USER
					, PESO
					, ALTURA
					, IMC
					, CLASSIFICADO
					, DT_PESQUISA
				  ) 
				  VALUES (
				  (SELECT ID_INFO_USER 
				  FROM IMC_TB_INFO_USER 
				  WHERE ID_USER = @ID_USER)
				, @PESO
				, @ALTURA
				, @IMC
				, (SELECT DBO.IMC_FN_CLASSIFICACAO(@IMC))
				, GETDATE()
				)
				SET @RETORNO = 'CALCULO FEITO COM SUCESSO!'
		END
		ELSE
		BEGIN
			SET @RETORNO = 'ID NAO ENCONTRADO!'
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[IMC_SP_CRIACAO_USUARIO]    Script Date: 23/10/2023 16:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IMC_SP_CRIACAO_USUARIO]
	  @USERNAME VARCHAR(255) 
	, @PASSWORD VARCHAR(255) 
	, @EMAIL VARCHAR(255) 
	, @STATUS BIT = 1
	, @NOME VARCHAR(30) 
    , @CPF VARCHAR(11) 
    , @DT_NACIMENTO DATE 
	, @USER_ID INT = NULL
	, @CPFVALIDO BIT = NULL
	, @RETORNO VARCHAR(255) = null OUTPUT

AS
BEGIN

    SET @CPFVALIDO = DBO.IMC_FN_VALIDA_CPF(@CPF);

    IF @CPFVALIDO = 1
		BEGIN
			INSERT INTO IMC_TB_USER(USERNAME
								  , EMAIL
								  , PASSWORD
								  , STATUS
								  , DT_CADASTRO)
			VALUES (@USERNAME, @EMAIL, @PASSWORD, @STATUS, GETDATE());
			SET @USER_ID = @@IDENTITY
			INSERT INTO IMC_TB_INFO_USER(ID_USER, NOME, CPF, DT_NACIMENTO)
			VALUES (@USER_ID, @NOME, @CPF, @DT_NACIMENTO)
			SET @RETORNO = 'USUARIO CADASTRADO COM SUCESSO!'
		END;
	ELSE
		BEGIN
			SET @RETORNO = 'CPF INVALIDO!'
		END;
END;
GO
USE [master]
GO
ALTER DATABASE [Estuda_Sql] SET  READ_WRITE 
GO
