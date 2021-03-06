USE [master]
GO
/****** Object:  Database [SMCFE]    Script Date: 04/27/2017 02:13:38 ******/
CREATE DATABASE [SMCFE] ON  PRIMARY 
( NAME = N'SMCFE', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SMCFE.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SMCFE_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SMCFE_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SMCFE] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SMCFE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SMCFE] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SMCFE] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SMCFE] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SMCFE] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SMCFE] SET ARITHABORT OFF
GO
ALTER DATABASE [SMCFE] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SMCFE] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SMCFE] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SMCFE] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SMCFE] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SMCFE] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SMCFE] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SMCFE] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SMCFE] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SMCFE] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SMCFE] SET  DISABLE_BROKER
GO
ALTER DATABASE [SMCFE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SMCFE] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SMCFE] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SMCFE] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SMCFE] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SMCFE] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SMCFE] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SMCFE] SET  READ_WRITE
GO
ALTER DATABASE [SMCFE] SET RECOVERY SIMPLE
GO
ALTER DATABASE [SMCFE] SET  MULTI_USER
GO
ALTER DATABASE [SMCFE] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SMCFE] SET DB_CHAINING OFF
GO
USE [SMCFE]
GO
/****** Object:  Table [dbo].[COMPETENCIA]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPETENCIA](
	[ID_COMPETENCIA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_COMPETENCIA] [varchar](60) NULL,
	[TIPO_COMPETENCIA] [int] NULL,
	[DESCRIPCION_COMPETENCIA] [text] NULL,
 CONSTRAINT [PK_COMPETENCIA] PRIMARY KEY NONCLUSTERED 
(
	[ID_COMPETENCIA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ESCUELA]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ESCUELA](
	[ID_ESCUELA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_ESCUELA] [varchar](100) NULL,
 CONSTRAINT [PK_ESCUELA] PRIMARY KEY NONCLUSTERED 
(
	[ID_ESCUELA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROFESION]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROFESION](
	[ID_PROFESION] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_PROFESION] [varchar](60) NULL,
 CONSTRAINT [PK_PROFESION] PRIMARY KEY NONCLUSTERED 
(
	[ID_PROFESION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIPO_USUARIO]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPO_USUARIO](
	[ID_TIPO_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_TIPO_USUARIO] [varchar](45) NULL,
 CONSTRAINT [PK_TIPO_USUARIO] PRIMARY KEY NONCLUSTERED 
(
	[ID_TIPO_USUARIO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIPO_PREGUNTA]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPO_PREGUNTA](
	[ID_TIPO_PREGUNTA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_TIPO_PREGUNTA] [varchar](45) NULL,
 CONSTRAINT [PK_TIPO_PREGUNTA] PRIMARY KEY NONCLUSTERED 
(
	[ID_TIPO_PREGUNTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PAIS]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PAIS](
	[ID_PAIS] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_PAIS] [varchar](45) NULL,
 CONSTRAINT [PK_PAIS] PRIMARY KEY NONCLUSTERED 
(
	[ID_PAIS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[RUT_USUARIO] [varchar](10) NOT NULL,
	[ID_TIPO_USUARIO_USUARIO] [int] NOT NULL,
	[NOMBRE_USUARIO] [varchar](100) NULL,
	[CONTRASENA_USUARIO] [char](32) NULL,
	[CORREO_USUARIO] [varchar](60) NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY NONCLUSTERED 
(
	[RUT_USUARIO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_12_FK] ON [dbo].[USUARIO] 
(
	[ID_TIPO_USUARIO_USUARIO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PREGUNTA]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PREGUNTA](
	[ID_PREGUNTA] [int] IDENTITY(1,1) NOT NULL,
	[ID_COMPETENCIA_PREGUNTA] [int] NOT NULL,
	[ID_TIPO_PREGUNTA_PREGUNTA] [int] NOT NULL,
	[NOMBRE_PREGUNTA] [varchar](400) NULL,
	[IMAGEN_PREGUNTA] [varchar](60) NULL,
 CONSTRAINT [PK_PREGUNTA] PRIMARY KEY NONCLUSTERED 
(
	[ID_PREGUNTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_13_FK] ON [dbo].[PREGUNTA] 
(
	[ID_TIPO_PREGUNTA_PREGUNTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_8_FK] ON [dbo].[PREGUNTA] 
(
	[ID_COMPETENCIA_PREGUNTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 04/27/2017 02:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERSONA](
	[RUT_PERSONA] [varchar](10) NOT NULL,
	[ID_PAIS] [int] NOT NULL,
	[NOMBRE_PERSONA] [varchar](100) NULL,
	[FECHA_NACIMIENTO_PERSONA] [datetime] NULL,
	[DIRECCION_PERSONA] [varchar](150) NULL,
	[TELEFONO_PERSONA] [int] NULL,
	[SEXO_PERSONA] [bit] NULL,
	[CORREO_PERSONA] [varchar](60) NULL,
 CONSTRAINT [PK_PERSONA] PRIMARY KEY NONCLUSTERED 
(
	[RUT_PERSONA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_18_FK] ON [dbo].[PERSONA] 
(
	[ID_PAIS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[insCompetencia]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insCompetencia]
(
@nombre_competencia varchar(60),
@tipo_competencia bit,
@descripcion_competencia varchar(200)
)
as 
insert into competencia values(@nombre_competencia, @tipo_competencia, @descripcion_competencia)
GO
/****** Object:  StoredProcedure [dbo].[insEscuela]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insEscuela]
(
@id_escuela int,
@nombre_escuela varchar(100)
)
as insert into escuela values(@nombre_escuela)
GO
/****** Object:  StoredProcedure [dbo].[mostrarCompetencias]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarCompetencias]
as select nombre_competencia, tipo_competencia, id_competencia from competencia
GO
/****** Object:  StoredProcedure [dbo].[insProfesion]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insProfesion]
(
@nombre_profesion varchar(60)
)
as insert into profesion values(@nombre_profesion)
GO
/****** Object:  StoredProcedure [dbo].[competenciaPA]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[competenciaPA]
(
@accion int,
@id_competencia int,
@nombre_competencia varchar(60),
@tipo_competencia bit,
@descripcion_competencia varchar(200)
)
as 
if(@accion=1)
insert into competencia values(@nombre_competencia, @tipo_competencia, @descripcion_competencia)

else if(@accion=2)
delete from competencia where id_competencia=@id_competencia

else if(@accion=3)
update competenca set nombre_competencia=@nombre_competencia, tipo_competencia=@tipo_competencia, descripcion_competencia=@descripcion_competencia
GO
/****** Object:  StoredProcedure [dbo].[eliminarCompetencia]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarCompetencia]
(
@id_competencia int
)
as 
delete from competencia where id_competencia=@id_competencia
GO
/****** Object:  StoredProcedure [dbo].[editarProfesion]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarProfesion]
(
@id_profesion int,
@nombre_profesion varchar(60)
)
as update profesion set nombre_profesion=@nombre_profesion where id_profesion=@id_profesion
GO
/****** Object:  StoredProcedure [dbo].[editarEscuelas]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarEscuelas]
(
@id_escuela int,
@nombre_escuela varchar(100)
)
as update escuela set nombre_escuela=@nombre_escuela where @id_escuela=id_escuela
GO
/****** Object:  StoredProcedure [dbo].[editarCompetencia]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarCompetencia]
(
@id_competencia int,
@nombre_competencia varchar(60),
@tipo_competencia bit,
@descripcion_competencia varchar(200)
)
as update competencia set nombre_competencia=@nombre_competencia, tipo_competencia=@tipo_competencia, descripcion_competencia=@descripcion_competencia where id_competencia=@id_competencia
GO
/****** Object:  StoredProcedure [dbo].[eliminarEscuela]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[eliminarEscuela]
@id_escuela int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM escuela WHERE escuela.id_escuela=@id_escuela 
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarProfesion]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[eliminarProfesion]
@id_profesion int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM profesion WHERE profesion.id_profesion=@id_profesion 
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarPregunta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[eliminarPregunta]
(
@id_pregunta int
)
as 
delete from pregunta where id_pregunta=@id_pregunta
GO
/****** Object:  StoredProcedure [dbo].[editarClaveUsuario]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarClaveUsuario]
(
@rut_usuario varchar(10),
@contrasena_actual varchar (10),
@contrasena_nueva varchar (10)
)
as
  update usuario set contrasena_usuario=@contrasena_nueva 
  where rut_usuario=@rut_usuario and contrasena_usuario=@contrasena_actual
  select @@rowcount
GO
/****** Object:  StoredProcedure [dbo].[autentificarUsuario]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[autentificarUsuario]
(
	@rut_usuario varchar(10),
	@contraseña_usuario char(32),
	@id_tipo_usuario_usuario int
)
as SELECT COUNT(*) FROM Usuario WHERE rut_usuario = @rut_usuario AND contrasena_usuario = @contraseña_usuario AND id_tipo_usuario_usuario = @id_tipo_usuario_usuario
GO
/****** Object:  StoredProcedure [dbo].[buscarCorreoRut]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[buscarCorreoRut]
(
@rut_usuario varchar(10)
)
as select correo_usuario from usuario where rut_usuario=@rut_usuario
GO
/****** Object:  Table [dbo].[DOCENTE]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DOCENTE](
	[RUT_DOCENTE] [varchar](10) NOT NULL,
	[ID_PROFESION_DOCENTE] [int] NOT NULL,
	[ID_PAIS_DOCENTE] [int] NULL,
	[NOMBRE_DOCENTE] [varchar](100) NULL,
	[FECHA_NACIMIENTO_DOCENTE] [datetime] NULL,
	[DIRECCION_DOCENTE] [varchar](150) NULL,
	[TELEFONO_DOCENTE] [int] NULL,
	[SEXO_DOCENTE] [bit] NULL,
	[CORREO_DOCENTE] [varchar](60) NULL,
	[DISPONIBILIDAD_DOCENTE] [bit] NULL,
 CONSTRAINT [PK_DOCENTE] PRIMARY KEY CLUSTERED 
(
	[RUT_DOCENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_1_FK] ON [dbo].[DOCENTE] 
(
	[ID_PROFESION_DOCENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ALUMNO]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ALUMNO](
	[RUT_ALUMNO] [varchar](10) NOT NULL,
	[ID_ESCUELA_ALUMNO] [int] NOT NULL,
	[ID_PAIS_ALUMNO] [int] NULL,
	[NOMBRE_ALUMNO] [varchar](100) NULL,
	[FECHA_NACIMIENTO_ALUMNO] [datetime] NULL,
	[DIRECCION_ALUMNO] [varchar](150) NULL,
	[TELEFONO_ALUMNO] [int] NULL,
	[SEXO_ALUMNO] [bit] NULL,
	[CORREO_ALUMNO] [varchar](60) NULL,
	[PROMOCION_ALUMNO] [int] NULL,
	[BENEFICIO_ALUMNO] [bit] NULL,
 CONSTRAINT [PK_ALUMNO] PRIMARY KEY CLUSTERED 
(
	[RUT_ALUMNO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_2_FK] ON [dbo].[ALUMNO] 
(
	[ID_ESCUELA_ALUMNO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[actualizarPregunta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[actualizarPregunta]
(
@id_pregunta int,
@id_competencia_pregunta int,
@id_tipo_pregunta_pregunta int, 
@nombre_pregunta varchar(150)
)
as update pregunta set id_competencia_pregunta=@id_competencia_pregunta, id_tipo_pregunta_pregunta=@id_tipo_pregunta_pregunta, nombre_pregunta=@nombre_pregunta where id_pregunta=@id_pregunta
GO
/****** Object:  StoredProcedure [dbo].[insPregunta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insPregunta]
(
@id_competencia_pregunta int,
@id_tipo_pregunta_pregunta int,
@nombre_pregunta varchar(400),
@imagen_pregunta varchar(60)
)
as 
insert into pregunta values(@id_competencia_pregunta, @id_tipo_pregunta_pregunta, @nombre_pregunta, @imagen_pregunta)
GO
/****** Object:  Table [dbo].[RESPUESTA]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RESPUESTA](
	[ID_RESPUESTA] [int] IDENTITY(1,1) NOT NULL,
	[ID_PREGUNTA_RESPUESTA] [int] NOT NULL,
	[NOMBRE_RESPUESTA] [varchar](200) NULL,
	[CORRECTA_RESPUESTA] [bit] NULL,
 CONSTRAINT [PK_RESPUESTA] PRIMARY KEY NONCLUSTERED 
(
	[ID_RESPUESTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_7_FK] ON [dbo].[RESPUESTA] 
(
	[ID_PREGUNTA_RESPUESTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[recuperarClaveUsuario]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[recuperarClaveUsuario]
(
@rut_usuario varchar(10),
@contrasena_nueva char (32)
)
as
  update usuario set contrasena_usuario=@contrasena_nueva 
  where rut_usuario=@rut_usuario
  select @@rowcount
GO
/****** Object:  StoredProcedure [dbo].[mostrarRespuestasDePregunta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarRespuestasDePregunta]
(
@id_pregunta_respuesta int
)
as select * FROM RESPUESTA where id_pregunta_respuesta=@id_pregunta_respuesta
GO
/****** Object:  StoredProcedure [dbo].[mostrarTodasRespuestas]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarTodasRespuestas]
as select id_respuesta, nombre_respuesta, correcta_respuesta, id_pregunta_respuesta from respuesta
GO
/****** Object:  StoredProcedure [dbo].[insAlumnos]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insAlumnos]
(
@rut_alumno varchar(10),
@contraseña_usuario char (32),
@id_escuela_alumno int,
@id_pais_alumno int,
@nombre_alumno varchar(100),
@fecha_nacimiento_alumno date,
@direccion_alumno varchar(150),
@telefono_alumno int,
@sexo_alumno bit,
@correo_alumno varchar(60),
@promocion_alumno int,
@beneficio_alumno bit
)
as 
insert into persona values(@rut_alumno, @id_pais_alumno, @nombre_alumno, @fecha_nacimiento_alumno, @direccion_alumno, @telefono_alumno, @sexo_alumno, @correo_alumno)
insert into alumno values(@rut_alumno,@id_escuela_alumno, @id_pais_alumno, @nombre_alumno,@fecha_nacimiento_alumno,@direccion_alumno,@telefono_alumno,@sexo_alumno,@correo_alumno,@promocion_alumno,@beneficio_alumno)
insert into usuario values(@rut_alumno, 1, @nombre_alumno, @contraseña_usuario, @correo_alumno)
GO
/****** Object:  StoredProcedure [dbo].[insDocentes]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insDocentes]
(
@rut_docente varchar(10),
@id_profesion_docente int,
@nombre_docente varchar(100),
@fecha_nacimiento_docente date,
@direccion_docente varchar(150),
@telefono_docente int,
@id_pais_docente int,
@sexo_docente bit,
@correo_docente varchar(60),
@contraseña_usuario char(32),
@disponibilidad_docente bit
)
as 
insert into persona values(@rut_docente,@id_pais_docente, @nombre_docente, @fecha_nacimiento_docente, @direccion_docente, @telefono_docente, @sexo_docente, @correo_docente)
insert into DOCENTE values(@rut_docente, @id_profesion_docente, @id_pais_docente, @nombre_docente, @fecha_nacimiento_docente, @direccion_docente,@telefono_docente, @sexo_docente, @correo_docente, @disponibilidad_docente)
insert into usuario values(@rut_docente, 2, @nombre_docente, @contraseña_usuario, @correo_docente)
GO
/****** Object:  StoredProcedure [dbo].[mostrarAlumnosBusqueda]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarAlumnosBusqueda]
(
@buscar varchar(45)
)
as select * from alumno where nombre_alumno like @buscar+'%'  or rut_alumno like @buscar+'%'
GO
/****** Object:  StoredProcedure [dbo].[mostrarAlumnos]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarAlumnos]
as select nombre_alumno, rut_alumno, id_escuela_alumno, promocion_alumno from alumno
GO
/****** Object:  StoredProcedure [dbo].[insRespuesta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insRespuesta]
(
@id_pregunta_respuesta int,
@nombre_respuesta varchar(200),
@correcta_respuesta bit
)
as insert into respuesta values(@id_pregunta_respuesta, @nombre_respuesta, @correcta_respuesta)
GO
/****** Object:  StoredProcedure [dbo].[mostrarDocentes]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarDocentes]
as select nombre_docente, rut_docente, id_profesion_docente from docente
GO
/****** Object:  Table [dbo].[ASIGNATURA]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ASIGNATURA](
	[ID_ASIGNATURA] [int] IDENTITY(1,1) NOT NULL,
	[ID_ESCUELA_ASIGNATURA] [int] NOT NULL,
	[RUT_DOCENTE_ASIGNATURA] [varchar](10) NOT NULL,
	[NOMBRE_ASIGNATURA] [varchar](100) NULL,
	[ANO_ASIGNATURA] [int] NULL,
	[DURACION_ASIGNATURA] [bit] NULL,
 CONSTRAINT [PK_ASIGNATURA] PRIMARY KEY NONCLUSTERED 
(
	[ID_ASIGNATURA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_3_FK] ON [dbo].[ASIGNATURA] 
(
	[ID_ESCUELA_ASIGNATURA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_4_FK] ON [dbo].[ASIGNATURA] 
(
	[RUT_DOCENTE_ASIGNATURA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[buscarDocente]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[buscarDocente]
(
@rut varchar(10)
)
as select* from docente where rut_docente=@rut
GO
/****** Object:  StoredProcedure [dbo].[editarAlumnos]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarAlumnos]
(
@rut_alumno varchar(10),
@id_escuela_alumno int,
@id_pais_alumno int,
@nombre_alumno varchar(100),
@fecha_nacimiento_alumno date,
@direccion_alumno varchar(150),
@telefono_alumno int,
@sexo_alumno bit,
@correo_alumno varchar(60),
@promocion_alumno int,
@beneficio_alumno bit
)
as update alumno set rut_alumno=@rut_alumno, id_escuela_alumno=@id_escuela_alumno, id_pais_alumno=@id_pais_alumno, nombre_alumno=@nombre_alumno,fecha_nacimiento_alumno=@fecha_nacimiento_alumno,direccion_alumno=@direccion_alumno,telefono_alumno=@telefono_alumno,sexo_alumno=@sexo_alumno,correo_alumno=@correo_alumno,promocion_alumno=@promocion_alumno,beneficio_alumno=@beneficio_alumno where rut_alumno=@rut_alumno
update persona set id_pais=@id_pais_alumno, nombre_persona=@nombre_alumno, fecha_nacimiento_persona=@fecha_nacimiento_alumno, direccion_persona=@direccion_alumno, telefono_persona=@telefono_alumno, sexo_persona=@sexo_alumno, correo_persona=@correo_alumno where rut_persona=@rut_alumno
GO
/****** Object:  StoredProcedure [dbo].[buscarAlumnoPorRut]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscarAlumnoPorRut]
(
@rut varchar(10)
)
as select * from alumno where rut_alumno=@rut
GO
/****** Object:  StoredProcedure [dbo].[editarDocente]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarDocente]
(
@rut_docente varchar(10),
@id_profesion_docente int,
@id_pais_docente int,
@nombre_docente varchar(100),
@fecha_nacimiento_docente date,
@direccion_docente varchar(150),
@telefono_docente int,
@sexo_docente bit,
@correo_docente varchar(60),
@disponibilidad_docente bit
)
as update docente set rut_docente=@rut_docente,id_profesion_docente=@id_profesion_docente, id_pais_docente=@id_pais_docente, nombre_docente=@nombre_docente,fecha_nacimiento_docente=@fecha_nacimiento_docente,direccion_docente=@direccion_docente,telefono_docente=@telefono_docente, sexo_docente=@sexo_docente,correo_docente=@correo_docente,disponibilidad_docente=@disponibilidad_docente where @rut_docente=rut_docente
GO
/****** Object:  StoredProcedure [dbo].[eliminarAlumno]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarAlumno]
@rut_alumno varchar (10)
AS
BEGIN
	SET NOCOUNT ON;
	 
	delete from usuario where usuario.rut_usuario=@rut_alumno
	DELETE FROM ALUMNO WHERE ALUMNO.RUT_ALUMNO=@rut_alumno
	delete from persona where persona.rut_persona=@rut_alumno
END
GO
/****** Object:  StoredProcedure [dbo].[editarRespuesta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarRespuesta]
(
@id_respuesta int,
@nombre_respuesta varchar(200),
@correcta_respuesta bit
)
as update respuesta set nombre_respuesta=@nombre_respuesta, correcta_respuesta=@correcta_respuesta where id_respuesta=@id_respuesta
GO
/****** Object:  StoredProcedure [dbo].[eliminarRespuestas]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarRespuestas]
(
@id_pregunta int
)
as 
delete from respuesta where id_pregunta_respuesta=@id_pregunta
GO
/****** Object:  StoredProcedure [dbo].[eliminarRespuesta]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[eliminarRespuesta]
(
@id_respuesta int
)
as 
delete from respuesta where id_respuesta=@id_respuesta
GO
/****** Object:  StoredProcedure [dbo].[eliminarDocente]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarDocente]
@rut_docente varchar (10)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM docente WHERE docente.RUT_docente=@rut_docente 
	delete from usuario where usuario.rut_usuario=@rut_docente
END
GO
/****** Object:  Table [dbo].[EVALUACION]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EVALUACION](
	[ID_EVALUACION] [int] IDENTITY(1,1) NOT NULL,
	[ID_ASIGNATURA_EVALUACION] [int] NOT NULL,
	[NOMBRE_EVALUACION] [varchar](60) NULL,
	[FECHA_EVALUACION] [datetime] NULL,
 CONSTRAINT [PK_EVALUACION] PRIMARY KEY NONCLUSTERED 
(
	[ID_EVALUACION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [ES_EVALUADA_FK] ON [dbo].[EVALUACION] 
(
	[ID_ASIGNATURA_EVALUACION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[eliminarAsignatura]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarAsignatura]
(
@id_asignatura int
)
as 
delete from asignatura where id_asignatura=@id_asignatura
GO
/****** Object:  StoredProcedure [dbo].[editarAsignatura]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarAsignatura]
(
@id_asignatura int,
@id_escuela_asignatura int,
@rut_docente_asignatura varchar(10),
@nombre_asignatura varchar (100),
@ano_asignatura int, 
@duracion_asignatura bit
)
as update asignatura set id_escuela_asignatura=@id_escuela_asignatura, rut_docente_asignatura=@rut_docente_asignatura, nombre_asignatura=@nombre_asignatura, ano_asignatura=@ano_asignatura, duracion_asignatura= @duracion_asignatura where id_asignatura=@id_asignatura
GO
/****** Object:  Table [dbo].[ASIGNATURA_COMPETENCIA]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASIGNATURA_COMPETENCIA](
	[ID_AC] [int] IDENTITY(1,1) NOT NULL,
	[ID_ASIGNATURA_AC] [int] NOT NULL,
	[ID_COMPETENCIA_AC] [int] NOT NULL,
 CONSTRAINT [PK_ASIGNATURA_COMPETENCIA] PRIMARY KEY CLUSTERED 
(
	[ID_ASIGNATURA_AC] ASC,
	[ID_COMPETENCIA_AC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [ESTA_ASOCIADA_FK] ON [dbo].[ASIGNATURA_COMPETENCIA] 
(
	[ID_ASIGNATURA_AC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [POSEE_FK] ON [dbo].[ASIGNATURA_COMPETENCIA] 
(
	[ID_COMPETENCIA_AC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CURSA]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CURSA](
	[ID_AA] [int] IDENTITY(1,1) NOT NULL,
	[RUT_ALUMNO_AA] [varchar](10) NOT NULL,
	[ID_ASIGNATURA_AA] [int] NOT NULL,
 CONSTRAINT [PK_RELATIONSHIP_19] PRIMARY KEY CLUSTERED 
(
	[RUT_ALUMNO_AA] ASC,
	[ID_ASIGNATURA_AA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [CURSA_FK] ON [dbo].[CURSA] 
(
	[ID_ASIGNATURA_AA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [ES_CURSADA_FK] ON [dbo].[CURSA] 
(
	[RUT_ALUMNO_AA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[mostrarAsignaturas]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarAsignaturas]
as select id_asignatura, id_escuela_asignatura, rut_docente_asignatura, nombre_asignatura, ano_asignatura, duracion_asignatura from asignatura
GO
/****** Object:  StoredProcedure [dbo].[insAsignatura]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insAsignatura]
(
@id_asignatura int,
@id_escuela_asignatura int,
@rut_docente_asignatura varchar(10),
@nombre_asignatura varchar(100),
@ano_asignatura int,
@duracion_asignatura bit
)
as insert into asignatura values(@id_escuela_asignatura, @rut_docente_asignatura, @nombre_asignatura, @ano_asignatura, @duracion_asignatura)
GO
/****** Object:  StoredProcedure [dbo].[insAC]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insAC]
(
@id_asignatura_ac int, 
@id_competencia_ac int
)
as insert into asignatura_competencia values(@id_asignatura_ac, @id_competencia_ac)
GO
/****** Object:  Table [dbo].[HISTORICO_PRUEBA_ALUMNO]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO](
	[ID_HPA] [int] IDENTITY(1,1) NOT NULL,
	[ID_EVALUACION_HPA] [int] NOT NULL,
	[ID_RESPUESTA_HPA] [int] NOT NULL,
	[ID_PREGUNTA_HPA] [int] NOT NULL,
	[RUT_ALUMNO_HPA] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HISTORICO_PRUEBA_ALUMNO] PRIMARY KEY NONCLUSTERED 
(
	[ID_HPA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_14_FK] ON [dbo].[HISTORICO_PRUEBA_ALUMNO] 
(
	[RUT_ALUMNO_HPA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_15_FK] ON [dbo].[HISTORICO_PRUEBA_ALUMNO] 
(
	[ID_PREGUNTA_HPA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_16_FK] ON [dbo].[HISTORICO_PRUEBA_ALUMNO] 
(
	[ID_RESPUESTA_HPA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [RELATIONSHIP_17_FK] ON [dbo].[HISTORICO_PRUEBA_ALUMNO] 
(
	[ID_EVALUACION_HPA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[mostrarCompetenciasAsignatura]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarCompetenciasAsignatura]
(
	@id_asignatura_ac int
)
as SELECT id_competencia_ac, NOMBRE_COMPETENCIA FROM ASIGNATURA_COMPETENCIA INNER JOIN COMPETENCIA ON ID_COMPETENCIA_AC = ID_COMPETENCIA where id_asignatura_ac=@id_asignatura_ac
GO
/****** Object:  StoredProcedure [dbo].[mostrarPYREvaluaciones]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarPYREvaluaciones]
(
	@id_asignatura_evaluacion int
)
as SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta, imagen_pregunta, id_pregunta 
FROM [ASIGNATURA_COMPETENCIA] inner join asignatura 
on [asignatura_competencia].id_asignatura_ac = asignatura.id_asignatura inner join competencia 
on [asignatura_competencia].id_competencia_ac = competencia.id_competencia inner join pregunta 
on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta 
on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta 
on id_pregunta_respuesta=id_pregunta 
where asignatura.id_asignatura =@id_asignatura_evaluacion 
order by nombre_tipo_pregunta;
GO
/****** Object:  StoredProcedure [dbo].[mostrarPreguntasEvaluacionAsignatura]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarPreguntasEvaluacionAsignatura]
(
	@id_asignatura int
)
as SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta, id_pregunta, id_respuesta FROM [ASIGNATURA_COMPETENCIA] inner join asignatura on [asignatura_competencia].id_asignatura_ac = asignatura.id_asignatura inner join competencia on [asignatura_competencia].id_competencia_ac = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura =@id_asignatura order by nombre_tipo_pregunta
GO
/****** Object:  StoredProcedure [dbo].[mostrarEvaluacionesAsignatura]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarEvaluacionesAsignatura]
(
	@id_asignatura int
)
as SELECT ID_EVALUACION, NOMBRE_EVALUACION FROM evaluacion where id_asignatura_evaluacion=@id_asignatura
GO
/****** Object:  StoredProcedure [dbo].[mostrarEvaluaciones]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarEvaluaciones]
as SELECT ID_EVALUACION, NOMBRE_EVALUACION FROM evaluacion
GO
/****** Object:  StoredProcedure [dbo].[verificarExistenciaEvaluacion]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[verificarExistenciaEvaluacion]
(
@id_asignatura_evaluacion int
)
as
SELECT count(*)FROM EVALUACION where id_asignatura_evaluacion=@id_asignatura_evaluacion;
GO
/****** Object:  StoredProcedure [dbo].[insEvaluacion]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insEvaluacion]
(
@id_evaluacion int,
@id_asignatura_evaluacion int,
@nombre_evaluacion varchar (60),
@fecha_evaluacion date
)
as insert into evaluacion values(@id_asignatura_evaluacion, @nombre_evaluacion, @fecha_evaluacion)
GO
/****** Object:  StoredProcedure [dbo].[mostrarRespuestasCompetencia]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarRespuestasCompetencia]
(
@rut_alumno varchar (10),
@id_competencia int
)
as SELECT     ID_RESPUESTA_HPA, CORRECTA_RESPUESTA, ID_COMPETENCIA_PREGUNTA, ID_PREGUNTA_HPA
                      
FROM         HISTORICO_PRUEBA_ALUMNO INNER JOIN
                      PREGUNTA ON ID_PREGUNTA_HPA = ID_PREGUNTA INNER JOIN
                      RESPUESTA ON ID_RESPUESTA_HPA = ID_RESPUESTA AND 
                      PREGUNTA.ID_PREGUNTA = ID_PREGUNTA_RESPUESTA
                      
                      where rut_alumno_hpa=@rut_alumno and ID_COMPETENCIA_PREGUNTA=@id_competencia
GO
/****** Object:  StoredProcedure [dbo].[mostrarRespuestasEvaluacion]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarRespuestasEvaluacion]
(
@rut_alumno varchar (10),
@id_evaluacion int
)
as SELECT     ID_RESPUESTA_HPA, CORRECTA_RESPUESTA, ID_COMPETENCIA_PREGUNTA, ID_PREGUNTA_HPA
                      
FROM         HISTORICO_PRUEBA_ALUMNO INNER JOIN
                      PREGUNTA ON ID_PREGUNTA_HPA = ID_PREGUNTA INNER JOIN
                      RESPUESTA ON ID_RESPUESTA_HPA = ID_RESPUESTA AND 
                      PREGUNTA.ID_PREGUNTA = ID_PREGUNTA_RESPUESTA
                      
                      where HISTORICO_PRUEBA_ALUMNO.rut_alumno_hpa=@rut_alumno and id_evaluacion_hpa=@id_evaluacion
GO
/****** Object:  StoredProcedure [dbo].[insHPA]    Script Date: 04/27/2017 02:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insHPA]
(
@id_hpa int,
@id_evaluacion_hpa int,
@id_respuesta_hpa int,
@id_pregunta_hpa int,
@rut_alumno_hpa varchar (10)
)
as insert into HISTORICO_PRUEBA_ALUMNO values(@id_evaluacion_hpa, @id_respuesta_hpa, @id_pregunta_hpa, @rut_alumno_hpa)
GO
/****** Object:  ForeignKey [FK_USUARIO_RELATIONS_TIPO_USU]    Script Date: 04/27/2017 02:13:39 ******/
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_RELATIONS_TIPO_USU] FOREIGN KEY([ID_TIPO_USUARIO_USUARIO])
REFERENCES [dbo].[TIPO_USUARIO] ([ID_TIPO_USUARIO])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_RELATIONS_TIPO_USU]
GO
/****** Object:  ForeignKey [FK_PREGUNTA_RELATIONS_COMPETEN]    Script Date: 04/27/2017 02:13:39 ******/
ALTER TABLE [dbo].[PREGUNTA]  WITH CHECK ADD  CONSTRAINT [FK_PREGUNTA_RELATIONS_COMPETEN] FOREIGN KEY([ID_COMPETENCIA_PREGUNTA])
REFERENCES [dbo].[COMPETENCIA] ([ID_COMPETENCIA])
GO
ALTER TABLE [dbo].[PREGUNTA] CHECK CONSTRAINT [FK_PREGUNTA_RELATIONS_COMPETEN]
GO
/****** Object:  ForeignKey [FK_PREGUNTA_RELATIONS_TIPO_PRE]    Script Date: 04/27/2017 02:13:39 ******/
ALTER TABLE [dbo].[PREGUNTA]  WITH CHECK ADD  CONSTRAINT [FK_PREGUNTA_RELATIONS_TIPO_PRE] FOREIGN KEY([ID_TIPO_PREGUNTA_PREGUNTA])
REFERENCES [dbo].[TIPO_PREGUNTA] ([ID_TIPO_PREGUNTA])
GO
ALTER TABLE [dbo].[PREGUNTA] CHECK CONSTRAINT [FK_PREGUNTA_RELATIONS_TIPO_PRE]
GO
/****** Object:  ForeignKey [FK_PERSONA_RELATIONS_PAIS]    Script Date: 04/27/2017 02:13:39 ******/
ALTER TABLE [dbo].[PERSONA]  WITH CHECK ADD  CONSTRAINT [FK_PERSONA_RELATIONS_PAIS] FOREIGN KEY([ID_PAIS])
REFERENCES [dbo].[PAIS] ([ID_PAIS])
GO
ALTER TABLE [dbo].[PERSONA] CHECK CONSTRAINT [FK_PERSONA_RELATIONS_PAIS]
GO
/****** Object:  ForeignKey [FK_DOCENTE_INHERITAN_PERSONA]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[DOCENTE]  WITH CHECK ADD  CONSTRAINT [FK_DOCENTE_INHERITAN_PERSONA] FOREIGN KEY([RUT_DOCENTE])
REFERENCES [dbo].[PERSONA] ([RUT_PERSONA])
GO
ALTER TABLE [dbo].[DOCENTE] CHECK CONSTRAINT [FK_DOCENTE_INHERITAN_PERSONA]
GO
/****** Object:  ForeignKey [FK_DOCENTE_RELATIONS_PROFESIO]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[DOCENTE]  WITH CHECK ADD  CONSTRAINT [FK_DOCENTE_RELATIONS_PROFESIO] FOREIGN KEY([ID_PROFESION_DOCENTE])
REFERENCES [dbo].[PROFESION] ([ID_PROFESION])
GO
ALTER TABLE [dbo].[DOCENTE] CHECK CONSTRAINT [FK_DOCENTE_RELATIONS_PROFESIO]
GO
/****** Object:  ForeignKey [FK_ALUMNO_INHERITAN_PERSONA]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK_ALUMNO_INHERITAN_PERSONA] FOREIGN KEY([RUT_ALUMNO])
REFERENCES [dbo].[PERSONA] ([RUT_PERSONA])
GO
ALTER TABLE [dbo].[ALUMNO] CHECK CONSTRAINT [FK_ALUMNO_INHERITAN_PERSONA]
GO
/****** Object:  ForeignKey [FK_ALUMNO_RELATIONS_ESCUELA]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK_ALUMNO_RELATIONS_ESCUELA] FOREIGN KEY([ID_ESCUELA_ALUMNO])
REFERENCES [dbo].[ESCUELA] ([ID_ESCUELA])
GO
ALTER TABLE [dbo].[ALUMNO] CHECK CONSTRAINT [FK_ALUMNO_RELATIONS_ESCUELA]
GO
/****** Object:  ForeignKey [FK_RESPUEST_RELATIONS_PREGUNTA]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[RESPUESTA]  WITH CHECK ADD  CONSTRAINT [FK_RESPUEST_RELATIONS_PREGUNTA] FOREIGN KEY([ID_PREGUNTA_RESPUESTA])
REFERENCES [dbo].[PREGUNTA] ([ID_PREGUNTA])
GO
ALTER TABLE [dbo].[RESPUESTA] CHECK CONSTRAINT [FK_RESPUEST_RELATIONS_PREGUNTA]
GO
/****** Object:  ForeignKey [FK_ASIGNATU_RELATIONS_DOCENTE]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[ASIGNATURA]  WITH CHECK ADD  CONSTRAINT [FK_ASIGNATU_RELATIONS_DOCENTE] FOREIGN KEY([RUT_DOCENTE_ASIGNATURA])
REFERENCES [dbo].[DOCENTE] ([RUT_DOCENTE])
GO
ALTER TABLE [dbo].[ASIGNATURA] CHECK CONSTRAINT [FK_ASIGNATU_RELATIONS_DOCENTE]
GO
/****** Object:  ForeignKey [FK_ASIGNATU_RELATIONS_ESCUELA]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[ASIGNATURA]  WITH CHECK ADD  CONSTRAINT [FK_ASIGNATU_RELATIONS_ESCUELA] FOREIGN KEY([ID_ESCUELA_ASIGNATURA])
REFERENCES [dbo].[ESCUELA] ([ID_ESCUELA])
GO
ALTER TABLE [dbo].[ASIGNATURA] CHECK CONSTRAINT [FK_ASIGNATU_RELATIONS_ESCUELA]
GO
/****** Object:  ForeignKey [FK_EVALUACI_ES_EVALUA_ASIGNATU]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[EVALUACION]  WITH CHECK ADD  CONSTRAINT [FK_EVALUACI_ES_EVALUA_ASIGNATU] FOREIGN KEY([ID_ASIGNATURA_EVALUACION])
REFERENCES [dbo].[ASIGNATURA] ([ID_ASIGNATURA])
GO
ALTER TABLE [dbo].[EVALUACION] CHECK CONSTRAINT [FK_EVALUACI_ES_EVALUA_ASIGNATU]
GO
/****** Object:  ForeignKey [FK_ASIGNATU_ESTA_ASOC_ASIGNATU]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[ASIGNATURA_COMPETENCIA]  WITH CHECK ADD  CONSTRAINT [FK_ASIGNATU_ESTA_ASOC_ASIGNATU] FOREIGN KEY([ID_ASIGNATURA_AC])
REFERENCES [dbo].[ASIGNATURA] ([ID_ASIGNATURA])
GO
ALTER TABLE [dbo].[ASIGNATURA_COMPETENCIA] CHECK CONSTRAINT [FK_ASIGNATU_ESTA_ASOC_ASIGNATU]
GO
/****** Object:  ForeignKey [FK_ASIGNATU_POSEE_COMPETEN]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[ASIGNATURA_COMPETENCIA]  WITH CHECK ADD  CONSTRAINT [FK_ASIGNATU_POSEE_COMPETEN] FOREIGN KEY([ID_COMPETENCIA_AC])
REFERENCES [dbo].[COMPETENCIA] ([ID_COMPETENCIA])
GO
ALTER TABLE [dbo].[ASIGNATURA_COMPETENCIA] CHECK CONSTRAINT [FK_ASIGNATU_POSEE_COMPETEN]
GO
/****** Object:  ForeignKey [FK_RELATION_CURSA_ASIGNATU]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[CURSA]  WITH CHECK ADD  CONSTRAINT [FK_RELATION_CURSA_ASIGNATU] FOREIGN KEY([ID_ASIGNATURA_AA])
REFERENCES [dbo].[ASIGNATURA] ([ID_ASIGNATURA])
GO
ALTER TABLE [dbo].[CURSA] CHECK CONSTRAINT [FK_RELATION_CURSA_ASIGNATU]
GO
/****** Object:  ForeignKey [FK_RELATION_ES_CURSAD_ALUMNO]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[CURSA]  WITH CHECK ADD  CONSTRAINT [FK_RELATION_ES_CURSAD_ALUMNO] FOREIGN KEY([RUT_ALUMNO_AA])
REFERENCES [dbo].[ALUMNO] ([RUT_ALUMNO])
GO
ALTER TABLE [dbo].[CURSA] CHECK CONSTRAINT [FK_RELATION_ES_CURSAD_ALUMNO]
GO
/****** Object:  ForeignKey [FK_HISTORIC_RELATIONS_ALUMNO]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK_HISTORIC_RELATIONS_ALUMNO] FOREIGN KEY([RUT_ALUMNO_HPA])
REFERENCES [dbo].[ALUMNO] ([RUT_ALUMNO])
GO
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO] CHECK CONSTRAINT [FK_HISTORIC_RELATIONS_ALUMNO]
GO
/****** Object:  ForeignKey [FK_HISTORIC_RELATIONS_EVALUACI]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK_HISTORIC_RELATIONS_EVALUACI] FOREIGN KEY([ID_EVALUACION_HPA])
REFERENCES [dbo].[EVALUACION] ([ID_EVALUACION])
GO
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO] CHECK CONSTRAINT [FK_HISTORIC_RELATIONS_EVALUACI]
GO
/****** Object:  ForeignKey [FK_HISTORIC_RELATIONS_PREGUNTA]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK_HISTORIC_RELATIONS_PREGUNTA] FOREIGN KEY([ID_PREGUNTA_HPA])
REFERENCES [dbo].[PREGUNTA] ([ID_PREGUNTA])
GO
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO] CHECK CONSTRAINT [FK_HISTORIC_RELATIONS_PREGUNTA]
GO
/****** Object:  ForeignKey [FK_HISTORIC_RELATIONS_RESPUEST]    Script Date: 04/27/2017 02:13:52 ******/
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK_HISTORIC_RELATIONS_RESPUEST] FOREIGN KEY([ID_RESPUESTA_HPA])
REFERENCES [dbo].[RESPUESTA] ([ID_RESPUESTA])
GO
ALTER TABLE [dbo].[HISTORICO_PRUEBA_ALUMNO] CHECK CONSTRAINT [FK_HISTORIC_RELATIONS_RESPUEST]
GO
