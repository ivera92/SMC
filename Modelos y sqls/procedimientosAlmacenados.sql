USE [SMC]
GO
/****** Object:  StoredProcedure [dbo].[mostrarCompetencias]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarCompetencias]
as select nombre_competencia, tipo_competencia, id_competencia from competencia
GO
/****** Object:  StoredProcedure [dbo].[insEscuela]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insEscuela]
(
@id_escuela int,
@nombre_escuela varchar(60)
)
as insert into escuela values(@nombre_escuela)
GO
/****** Object:  StoredProcedure [dbo].[insProfesion]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[insCompetencia]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[eliminarEscuela]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[eliminarProfesion]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[eliminarCompetencia]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[editarCompetencia]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarCompetencia]
(
@id_competencia int,
@nombre_competencia varchar(60),
@tipo_competencia bit,
@descripcion_competencia varchar(250)
)
as update competencia set nombre_competencia=@nombre_competencia, tipo_competencia=@tipo_competencia, descripcion_competencia=@descripcion_competencia where id_competencia=@id_competencia
GO
/****** Object:  StoredProcedure [dbo].[editarProfesion]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[editarEscuelas]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarEscuelas]
(
@id_escuela int,
@nombre_escuela varchar(60)
)
as update escuela set nombre_escuela=@nombre_escuela where @id_escuela=id_escuela
GO
/****** Object:  StoredProcedure [dbo].[competenciaPA]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[buscarDocente]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[buscarDocente]
(
@rut varchar
)
as select* from docente where rut_docente=@rut
GO
/****** Object:  StoredProcedure [dbo].[buscarAlumnoPorRut]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[editarDocente]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarDocente]
(
@rut_docente varchar(10),
@id_profesion_docente int,
@id_pais_docente int,
@nombre_docente varchar(60),
@fecha_nacimiento_docente date,
@direccion_docente varchar(60),
@telefono_docente int,
@sexo_docente bit,
@correo_docente varchar(45),
@disponibilidad_docente bit
)
as update docente set rut_docente=@rut_docente,id_profesion_docente=@id_profesion_docente, id_pais_docente=@id_pais_docente, nombre_docente=@nombre_docente,fecha_nacimiento_docente=@fecha_nacimiento_docente,direccion_docente=@direccion_docente,telefono_docente=@telefono_docente, sexo_docente=@sexo_docente,correo_docente=@correo_docente,disponibilidad_docente=@disponibilidad_docente where @rut_docente=rut_docente
GO
/****** Object:  StoredProcedure [dbo].[eliminarAlumno]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarAlumno]
@rut_alumno varchar (10)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM ALUMNO WHERE ALUMNO.RUT_ALUMNO=@rut_alumno 
	delete from usuario where usuario.rut_usuario=@rut_alumno
END
GO
/****** Object:  StoredProcedure [dbo].[editarAlumnos]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editarAlumnos]
(
@rut_alumno varchar(10),
@id_escuela_alumno int,
@id_pais_alumno int,
@nombre_alumno varchar(60),
@fecha_nacimiento_alumno date,
@direccion_alumno varchar(60),
@telefono_alumno int,
@sexo_alumno bit,
@correo_alumno varchar(45),
@promocion_alumno int,
@beneficio_alumno bit
)
as update alumno set rut_alumno=@rut_alumno, id_escuela_alumno=@id_escuela_alumno, id_pais_alumno=@id_pais_alumno, nombre_alumno=@nombre_alumno,fecha_nacimiento_alumno=@fecha_nacimiento_alumno,direccion_alumno=@direccion_alumno,telefono_alumno=@telefono_alumno,sexo_alumno=@sexo_alumno,correo_alumno=@correo_alumno,promocion_alumno=@promocion_alumno,beneficio_alumno=@beneficio_alumno where @rut_alumno=rut_alumno
GO
/****** Object:  StoredProcedure [dbo].[eliminarPregunta]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarPregunta]
(
@id_pregunta int
)
as 
delete from pregunta where id_pregunta=@id_pregunta
GO
/****** Object:  StoredProcedure [dbo].[eliminarDocente]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[insAlumnos]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insAlumnos]
(
@rut_alumno varchar(10),
@id_escuela_alumno int,
@id_pais_alumno int,
@nombre_alumno varchar(60),
@fecha_nacimiento_alumno date,
@direccion_alumno varchar(60),
@telefono_alumno int,
@sexo_alumno bit,
@correo_alumno varchar(45),
@promocion_alumno int,
@beneficio_alumno bit
)
as insert into alumno values(@rut_alumno,@id_escuela_alumno, @id_pais_alumno, @nombre_alumno,@fecha_nacimiento_alumno,@direccion_alumno,@telefono_alumno,@sexo_alumno,@correo_alumno,@promocion_alumno,@beneficio_alumno)
   insert into usuario values(@rut_alumno, 1, @nombre_alumno, @rut_alumno)
GO
/****** Object:  StoredProcedure [dbo].[mostrarDocentes]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarDocentes]
as select nombre_docente, rut_docente, id_profesion_docente from docente
GO
/****** Object:  StoredProcedure [dbo].[insPregunta]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insPregunta]
(
@id_competencia_pregunta int,
@id_tipo_pregunta_pregunta int,
@nombre_pregunta varchar(80)
)
as 
insert into pregunta values(@id_competencia_pregunta, @id_tipo_pregunta_pregunta, @nombre_pregunta)
GO
/****** Object:  StoredProcedure [dbo].[insDocentes]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insDocentes]
(
@rut_docente varchar(10),
@id_profesion_docente int,
@nombre_docente varchar(60),
@fecha_nacimiento_docente date,
@direccion_docente varchar(60),
@telefono_docente int,
@id_pais_docente int,
@sexo_docente bit,
@correo_docente varchar(45),
@disponibilidad_docente bit
)
as insert into DOCENTE values(@rut_docente, @id_profesion_docente, @id_pais_docente, @nombre_docente, @fecha_nacimiento_docente, @direccion_docente,@telefono_docente, @sexo_docente, @correo_docente, @disponibilidad_docente)
   insert into usuario values(@rut_docente, 2, @nombre_docente, @rut_docente)
GO
/****** Object:  StoredProcedure [dbo].[mostrarAlumnosBusqueda]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarAlumnosBusqueda]
(
@buscar varchar(15)
)
as select * from alumno where nombre_alumno like @buscar+'%'  or rut_alumno like @buscar+'%'  or id_escuela_alumno like @buscar+'%'  or promocion_alumno like @buscar+'%'  or promocion_alumno like @buscar+'%'
GO
/****** Object:  StoredProcedure [dbo].[mostrarAlumnos]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarAlumnos]
as select nombre_alumno, rut_alumno, id_escuela_alumno, promocion_alumno from alumno
GO
/****** Object:  StoredProcedure [dbo].[mostrarAsignaturas]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarAsignaturas]
as select id_asignatura, id_escuela_asignatura, rut_docente_asignatura, nombre_asignatura, ano_asignatura, duracion_asignatura from asignatura
GO
/****** Object:  StoredProcedure [dbo].[insRespuesta]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insRespuesta]
(
@id_pregunta_respuesta int,
@nombre_respuesta varchar(45),
@correcta_respuesta bit
)
as insert into respuesta values(@id_pregunta_respuesta, @nombre_respuesta, @correcta_respuesta)
GO
/****** Object:  StoredProcedure [dbo].[insAsignatura]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insAsignatura]
(
@id_asignatura int,
@id_escuela_asignatura int,
@rut_docente_asignatura varchar(10),
@nombre_asignatura varchar(60),
@ano_asignatura int,
@duracion_asignatura bit
)
as insert into asignatura values(@id_escuela_asignatura, @rut_docente_asignatura, @nombre_asignatura, @ano_asignatura, @duracion_asignatura)
GO
/****** Object:  StoredProcedure [dbo].[eliminarAsignatura]    Script Date: 02/01/2017 18:11:39 ******/
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
/****** Object:  StoredProcedure [dbo].[editarAsignatura]    Script Date: 02/01/2017 18:11:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editarAsignatura]
(
@id_asignatura int,
@id_escuela_asignatura int,
@rut_docente_asignatura varchar(10),
@nombre_asignatura varchar (60),
@ano_asignatura int, 
@duracion_asignatura bit
)
as update asignatura set id_escuela_asignatura=@id_escuela_asignatura, rut_docente_asignatura=@rut_docente_asignatura, nombre_asignatura=@nombre_asignatura, ano_asignatura=@ano_asignatura, duracion_asignatura= @duracion_asignatura where @id_asignatura=id_asignatura
GO
