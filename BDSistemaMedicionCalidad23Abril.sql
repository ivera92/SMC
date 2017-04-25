/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     25/04/2017 1:23:27                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ALUMNO') and o.name = 'FK_ALUMNO_INHERITAN_PERSONA')
alter table ALUMNO
   drop constraint FK_ALUMNO_INHERITAN_PERSONA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ALUMNO') and o.name = 'FK_ALUMNO_RELATIONS_ESCUELA')
alter table ALUMNO
   drop constraint FK_ALUMNO_RELATIONS_ESCUELA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASIGNATURA') and o.name = 'FK_ASIGNATU_RELATIONS_ESCUELA')
alter table ASIGNATURA
   drop constraint FK_ASIGNATU_RELATIONS_ESCUELA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASIGNATURA') and o.name = 'FK_ASIGNATU_RELATIONS_DOCENTE')
alter table ASIGNATURA
   drop constraint FK_ASIGNATU_RELATIONS_DOCENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASIGNATURA_COMPETENCIA') and o.name = 'FK_ASIGNATU_ESTA_ASOC_ASIGNATU')
alter table ASIGNATURA_COMPETENCIA
   drop constraint FK_ASIGNATU_ESTA_ASOC_ASIGNATU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASIGNATURA_COMPETENCIA') and o.name = 'FK_ASIGNATU_POSEE_COMPETEN')
alter table ASIGNATURA_COMPETENCIA
   drop constraint FK_ASIGNATU_POSEE_COMPETEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DOCENTE') and o.name = 'FK_DOCENTE_INHERITAN_PERSONA')
alter table DOCENTE
   drop constraint FK_DOCENTE_INHERITAN_PERSONA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DOCENTE') and o.name = 'FK_DOCENTE_RELATIONS_PROFESIO')
alter table DOCENTE
   drop constraint FK_DOCENTE_RELATIONS_PROFESIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EVALUACION') and o.name = 'FK_EVALUACI_ES_EVALUA_ASIGNATU')
alter table EVALUACION
   drop constraint FK_EVALUACI_ES_EVALUA_ASIGNATU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HISTORICO_PRUEBA_ALUMNO') and o.name = 'FK_HISTORIC_RELATIONS_ALUMNO')
alter table HISTORICO_PRUEBA_ALUMNO
   drop constraint FK_HISTORIC_RELATIONS_ALUMNO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HISTORICO_PRUEBA_ALUMNO') and o.name = 'FK_HISTORIC_RELATIONS_PREGUNTA')
alter table HISTORICO_PRUEBA_ALUMNO
   drop constraint FK_HISTORIC_RELATIONS_PREGUNTA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HISTORICO_PRUEBA_ALUMNO') and o.name = 'FK_HISTORIC_RELATIONS_RESPUEST')
alter table HISTORICO_PRUEBA_ALUMNO
   drop constraint FK_HISTORIC_RELATIONS_RESPUEST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HISTORICO_PRUEBA_ALUMNO') and o.name = 'FK_HISTORIC_RELATIONS_EVALUACI')
alter table HISTORICO_PRUEBA_ALUMNO
   drop constraint FK_HISTORIC_RELATIONS_EVALUACI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERSONA') and o.name = 'FK_PERSONA_RELATIONS_PAIS')
alter table PERSONA
   drop constraint FK_PERSONA_RELATIONS_PAIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PREGUNTA') and o.name = 'FK_PREGUNTA_RELATIONS_TIPO_PRE')
alter table PREGUNTA
   drop constraint FK_PREGUNTA_RELATIONS_TIPO_PRE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PREGUNTA') and o.name = 'FK_PREGUNTA_RELATIONS_COMPETEN')
alter table PREGUNTA
   drop constraint FK_PREGUNTA_RELATIONS_COMPETEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RELATIONSHIP_19') and o.name = 'FK_RELATION_CURSA_ASIGNATU')
alter table RELATIONSHIP_19
   drop constraint FK_RELATION_CURSA_ASIGNATU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RELATIONSHIP_19') and o.name = 'FK_RELATION_ES_CURSAD_ALUMNO')
alter table RELATIONSHIP_19
   drop constraint FK_RELATION_ES_CURSAD_ALUMNO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESPUESTA') and o.name = 'FK_RESPUEST_RELATIONS_PREGUNTA')
alter table RESPUESTA
   drop constraint FK_RESPUEST_RELATIONS_PREGUNTA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_RELATIONS_TIPO_USU')
alter table USUARIO
   drop constraint FK_USUARIO_RELATIONS_TIPO_USU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ALUMNO')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index ALUMNO.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ALUMNO')
            and   type = 'U')
   drop table ALUMNO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASIGNATURA')
            and   name  = 'RELATIONSHIP_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASIGNATURA.RELATIONSHIP_4_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASIGNATURA')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASIGNATURA.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ASIGNATURA')
            and   type = 'U')
   drop table ASIGNATURA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASIGNATURA_COMPETENCIA')
            and   name  = 'POSEE_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASIGNATURA_COMPETENCIA.POSEE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASIGNATURA_COMPETENCIA')
            and   name  = 'ESTA_ASOCIADA_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASIGNATURA_COMPETENCIA.ESTA_ASOCIADA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ASIGNATURA_COMPETENCIA')
            and   type = 'U')
   drop table ASIGNATURA_COMPETENCIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMPETENCIA')
            and   type = 'U')
   drop table COMPETENCIA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DOCENTE')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index DOCENTE.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DOCENTE')
            and   type = 'U')
   drop table DOCENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESCUELA')
            and   type = 'U')
   drop table ESCUELA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EVALUACION')
            and   name  = 'ES_EVALUADA_FK'
            and   indid > 0
            and   indid < 255)
   drop index EVALUACION.ES_EVALUADA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EVALUACION')
            and   type = 'U')
   drop table EVALUACION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HISTORICO_PRUEBA_ALUMNO')
            and   name  = 'RELATIONSHIP_17_FK'
            and   indid > 0
            and   indid < 255)
   drop index HISTORICO_PRUEBA_ALUMNO.RELATIONSHIP_17_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HISTORICO_PRUEBA_ALUMNO')
            and   name  = 'RELATIONSHIP_16_FK'
            and   indid > 0
            and   indid < 255)
   drop index HISTORICO_PRUEBA_ALUMNO.RELATIONSHIP_16_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HISTORICO_PRUEBA_ALUMNO')
            and   name  = 'RELATIONSHIP_15_FK'
            and   indid > 0
            and   indid < 255)
   drop index HISTORICO_PRUEBA_ALUMNO.RELATIONSHIP_15_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HISTORICO_PRUEBA_ALUMNO')
            and   name  = 'RELATIONSHIP_14_FK'
            and   indid > 0
            and   indid < 255)
   drop index HISTORICO_PRUEBA_ALUMNO.RELATIONSHIP_14_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HISTORICO_PRUEBA_ALUMNO')
            and   type = 'U')
   drop table HISTORICO_PRUEBA_ALUMNO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAIS')
            and   type = 'U')
   drop table PAIS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PERSONA')
            and   name  = 'RELATIONSHIP_18_FK'
            and   indid > 0
            and   indid < 255)
   drop index PERSONA.RELATIONSHIP_18_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERSONA')
            and   type = 'U')
   drop table PERSONA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PREGUNTA')
            and   name  = 'RELATIONSHIP_13_FK'
            and   indid > 0
            and   indid < 255)
   drop index PREGUNTA.RELATIONSHIP_13_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PREGUNTA')
            and   name  = 'RELATIONSHIP_8_FK'
            and   indid > 0
            and   indid < 255)
   drop index PREGUNTA.RELATIONSHIP_8_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PREGUNTA')
            and   type = 'U')
   drop table PREGUNTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PROFESION')
            and   type = 'U')
   drop table PROFESION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RELATIONSHIP_19')
            and   name  = 'CURSA_FK'
            and   indid > 0
            and   indid < 255)
   drop index RELATIONSHIP_19.CURSA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RELATIONSHIP_19')
            and   name  = 'ES_CURSADA_FK'
            and   indid > 0
            and   indid < 255)
   drop index RELATIONSHIP_19.ES_CURSADA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RELATIONSHIP_19')
            and   type = 'U')
   drop table RELATIONSHIP_19
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RESPUESTA')
            and   name  = 'RELATIONSHIP_7_FK'
            and   indid > 0
            and   indid < 255)
   drop index RESPUESTA.RELATIONSHIP_7_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RESPUESTA')
            and   type = 'U')
   drop table RESPUESTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO_PREGUNTA')
            and   type = 'U')
   drop table TIPO_PREGUNTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO_USUARIO')
            and   type = 'U')
   drop table TIPO_USUARIO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USUARIO')
            and   name  = 'RELATIONSHIP_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO.RELATIONSHIP_12_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ALUMNO                                                */
/*==============================================================*/
create table ALUMNO (
   RUT_ALUMNO           varchar(10)          not null,
   ID_ESCUELA_ALUMNO    int                  not null,
   ID_PAIS_ALUMNO       int                  null,
   NOMBRE_ALUMNO        varchar(100)         null,
   FECHA_NACIMIENTO_ALUMNO datetime             null,
   DIRECCION_ALUMNO     varchar(150)         null,
   TELEFONO_ALUMNO      int                  null,
   SEXO_ALUMNO          bit                  null,
   CORREO_ALUMNO        varchar(60)          null,
   PROMOCION_ALUMNO     int                  null,
   BENEFICIO_ALUMNO     bit                  null,
   constraint PK_ALUMNO primary key (RUT_ALUMNO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on ALUMNO (
ID_ESCUELA_ALUMNO ASC
)
go

/*==============================================================*/
/* Table: ASIGNATURA                                            */
/*==============================================================*/
create table ASIGNATURA (
   ID_ASIGNATURA        int                  identity,
   ID_ESCUELA_ASIGNATURA int                  not null,
   RUT_DOCENTE_ASIGNATURA varchar(10)          not null,
   NOMBRE_ASIGNATURA    varchar(100)         null,
   ANO_ASIGNATURA       int                  null,
   DURACION_ASIGNATURA  bit                  null,
   constraint PK_ASIGNATURA primary key nonclustered (ID_ASIGNATURA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on ASIGNATURA (
ID_ESCUELA_ASIGNATURA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_4_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_4_FK on ASIGNATURA (
RUT_DOCENTE_ASIGNATURA ASC
)
go

/*==============================================================*/
/* Table: ASIGNATURA_COMPETENCIA                                */
/*==============================================================*/
create table ASIGNATURA_COMPETENCIA (
   ID_AC                int                  identity,
   ID_ASIGNATURA_AC     int                  not null,
   ID_COMPETENCIA_AC    int                  not null,
   constraint PK_ASIGNATURA_COMPETENCIA primary key (ID_ASIGNATURA_AC, ID_COMPETENCIA_AC)
)
go

/*==============================================================*/
/* Index: ESTA_ASOCIADA_FK                                      */
/*==============================================================*/
create index ESTA_ASOCIADA_FK on ASIGNATURA_COMPETENCIA (
ID_ASIGNATURA_AC ASC
)
go

/*==============================================================*/
/* Index: POSEE_FK                                              */
/*==============================================================*/
create index POSEE_FK on ASIGNATURA_COMPETENCIA (
ID_COMPETENCIA_AC ASC
)
go

/*==============================================================*/
/* Table: COMPETENCIA                                           */
/*==============================================================*/
create table COMPETENCIA (
   ID_COMPETENCIA       int                  identity,
   NOMBRE_COMPETENCIA   varchar(60)          null,
   TIPO_COMPETENCIA     int                  null,
   DESCRIPCION_COMPETENCIA text                 null,
   constraint PK_COMPETENCIA primary key nonclustered (ID_COMPETENCIA)
)
go

/*==============================================================*/
/* Table: DOCENTE                                               */
/*==============================================================*/
create table DOCENTE (
   RUT_DOCENTE          varchar(10)          not null,
   ID_PROFESION_DOCENTE int                  not null,
   ID_PAIS_DOCENTE      int                  null,
   NOMBRE_DOCENTE       varchar(100)         null,
   FECHA_NACIMIENTO_DOCENTE datetime             null,
   DIRECCION_DOCENTE    varchar(150)         null,
   TELEFONO_DOCENTE     int                  null,
   SEXO_DOCENTE         bit                  null,
   CORREO_DOCENTE       varchar(60)          null,
   DISPONIBILIDAD_DOCENTE bit                  null,
   constraint PK_DOCENTE primary key (RUT_DOCENTE)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on DOCENTE (
ID_PROFESION_DOCENTE ASC
)
go

/*==============================================================*/
/* Table: ESCUELA                                               */
/*==============================================================*/
create table ESCUELA (
   ID_ESCUELA           int                  identity,
   NOMBRE_ESCUELA       varchar(100)         null,
   constraint PK_ESCUELA primary key nonclustered (ID_ESCUELA)
)
go

/*==============================================================*/
/* Table: EVALUACION                                            */
/*==============================================================*/
create table EVALUACION (
   ID_EVALUACION        int                  identity,
   ID_ASIGNATURA_EVALUACION int                  not null,
   NOMBRE_EVALUACION    varchar(60)          null,
   FECHA_EVALUACION     datetime             null,
   constraint PK_EVALUACION primary key nonclustered (ID_EVALUACION)
)
go

/*==============================================================*/
/* Index: ES_EVALUADA_FK                                        */
/*==============================================================*/
create index ES_EVALUADA_FK on EVALUACION (
ID_ASIGNATURA_EVALUACION ASC
)
go

/*==============================================================*/
/* Table: HISTORICO_PRUEBA_ALUMNO                               */
/*==============================================================*/
create table HISTORICO_PRUEBA_ALUMNO (
   ID_HPA               int                  identity,
   ID_EVALUACION_HPA    int                  not null,
   ID_RESPUESTA_HPA     int                  not null,
   ID_PREGUNTA_HPA      int                  not null,
   RUT_ALUMNO_HPA       varchar(10)          not null,
   constraint PK_HISTORICO_PRUEBA_ALUMNO primary key nonclustered (ID_HPA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_14_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_14_FK on HISTORICO_PRUEBA_ALUMNO (
RUT_ALUMNO_HPA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_15_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_15_FK on HISTORICO_PRUEBA_ALUMNO (
ID_PREGUNTA_HPA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_16_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_16_FK on HISTORICO_PRUEBA_ALUMNO (
ID_RESPUESTA_HPA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_17_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_17_FK on HISTORICO_PRUEBA_ALUMNO (
ID_EVALUACION_HPA ASC
)
go

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table PAIS (
   ID_PAIS              int                  identity,
   NOMBRE_PAIS          varchar(45)          null,
   constraint PK_PAIS primary key nonclustered (ID_PAIS)
)
go

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA (
   RUT_PERSONA          varchar(10)          not null,
   ID_PAIS              int                  not null,
   NOMBRE_PERSONA       varchar(100)         null,
   FECHA_NACIMIENTO_PERSONA datetime             null,
   DIRECCION_PERSONA    varchar(150)         null,
   TELEFONO_PERSONA     int                  null,
   SEXO_PERSONA         bit                  null,
   CORREO_PERSONA       varchar(60)          null,
   constraint PK_PERSONA primary key nonclustered (RUT_PERSONA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_18_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_18_FK on PERSONA (
ID_PAIS ASC
)
go

/*==============================================================*/
/* Table: PREGUNTA                                              */
/*==============================================================*/
create table PREGUNTA (
   ID_PREGUNTA          int                  identity,
   ID_COMPETENCIA_PREGUNTA int                  not null,
   ID_TIPO_PREGUNTA_PREGUNTA int                  not null,
   NOMBRE_PREGUNTA      varchar(150)         null,
   IMAGEN_PREGUNTA      varchar(60)          null,
   constraint PK_PREGUNTA primary key nonclustered (ID_PREGUNTA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_8_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_8_FK on PREGUNTA (
ID_COMPETENCIA_PREGUNTA ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_13_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_13_FK on PREGUNTA (
ID_TIPO_PREGUNTA_PREGUNTA ASC
)
go

/*==============================================================*/
/* Table: PROFESION                                             */
/*==============================================================*/
create table PROFESION (
   ID_PROFESION         int                  identity,
   NOMBRE_PROFESION     varchar(60)          null,
   constraint PK_PROFESION primary key nonclustered (ID_PROFESION)
)
go

/*==============================================================*/
/* Table: RELATIONSHIP_19                                       */
/*==============================================================*/
create table RELATIONSHIP_19 (
   ID_AA                int                  identity,
   RUT_ALUMNO_AA        varchar(10)          not null,
   ID_ASIGNATURA_AA     int                  not null,
   constraint PK_RELATIONSHIP_19 primary key (RUT_ALUMNO_AA, ID_ASIGNATURA_AA)
)
go

/*==============================================================*/
/* Index: ES_CURSADA_FK                                         */
/*==============================================================*/
create index ES_CURSADA_FK on RELATIONSHIP_19 (
RUT_ALUMNO_AA ASC
)
go

/*==============================================================*/
/* Index: CURSA_FK                                              */
/*==============================================================*/
create index CURSA_FK on RELATIONSHIP_19 (
ID_ASIGNATURA_AA ASC
)
go

/*==============================================================*/
/* Table: RESPUESTA                                             */
/*==============================================================*/
create table RESPUESTA (
   ID_RESPUESTA         int                  identity,
   ID_PREGUNTA_RESPUESTA int                  not null,
   NOMBRE_RESPUESTA     varchar(100)         null,
   CORRECTA_RESPUESTA   bit                  null,
   constraint PK_RESPUESTA primary key nonclustered (ID_RESPUESTA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_7_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_7_FK on RESPUESTA (
ID_PREGUNTA_RESPUESTA ASC
)
go

/*==============================================================*/
/* Table: TIPO_PREGUNTA                                         */
/*==============================================================*/
create table TIPO_PREGUNTA (
   ID_TIPO_PREGUNTA     int                  identity,
   NOMBRE_TIPO_PREGUNTA varchar(45)          null,
   constraint PK_TIPO_PREGUNTA primary key nonclustered (ID_TIPO_PREGUNTA)
)
go

/*==============================================================*/
/* Table: TIPO_USUARIO                                          */
/*==============================================================*/
create table TIPO_USUARIO (
   ID_TIPO_USUARIO      int                  identity,
   NOMBRE_TIPO_USUARIO  varchar(45)          null,
   constraint PK_TIPO_USUARIO primary key nonclustered (ID_TIPO_USUARIO)
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   RUT_USUARIO          varchar(10)          not null,
   ID_TIPO_USUARIO      int                  not null,
   NOMBRE_USUARIO       varchar(100)         null,
   CONTRASENA_USUARIO   char(32)             null,
   CORREO_USUARIO       varchar(60)          null,
   constraint PK_USUARIO primary key nonclustered (RUT_USUARIO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_12_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_12_FK on USUARIO (
ID_TIPO_USUARIO ASC
)
go

alter table ALUMNO
   add constraint FK_ALUMNO_INHERITAN_PERSONA foreign key (RUT_ALUMNO)
      references PERSONA (RUT_PERSONA)
go

alter table ALUMNO
   add constraint FK_ALUMNO_RELATIONS_ESCUELA foreign key (ID_ESCUELA_ALUMNO)
      references ESCUELA (ID_ESCUELA)
go

alter table ASIGNATURA
   add constraint FK_ASIGNATU_RELATIONS_ESCUELA foreign key (ID_ESCUELA_ASIGNATURA)
      references ESCUELA (ID_ESCUELA)
go

alter table ASIGNATURA
   add constraint FK_ASIGNATU_RELATIONS_DOCENTE foreign key (RUT_DOCENTE_ASIGNATURA)
      references DOCENTE (RUT_DOCENTE)
go

alter table ASIGNATURA_COMPETENCIA
   add constraint FK_ASIGNATU_ESTA_ASOC_ASIGNATU foreign key (ID_ASIGNATURA_AC)
      references ASIGNATURA (ID_ASIGNATURA)
go

alter table ASIGNATURA_COMPETENCIA
   add constraint FK_ASIGNATU_POSEE_COMPETEN foreign key (ID_COMPETENCIA_AC)
      references COMPETENCIA (ID_COMPETENCIA)
go

alter table DOCENTE
   add constraint FK_DOCENTE_INHERITAN_PERSONA foreign key (RUT_DOCENTE)
      references PERSONA (RUT_PERSONA)
go

alter table DOCENTE
   add constraint FK_DOCENTE_RELATIONS_PROFESIO foreign key (ID_PROFESION_DOCENTE)
      references PROFESION (ID_PROFESION)
go

alter table EVALUACION
   add constraint FK_EVALUACI_ES_EVALUA_ASIGNATU foreign key (ID_ASIGNATURA_EVALUACION)
      references ASIGNATURA (ID_ASIGNATURA)
go

alter table HISTORICO_PRUEBA_ALUMNO
   add constraint FK_HISTORIC_RELATIONS_ALUMNO foreign key (RUT_ALUMNO_HPA)
      references ALUMNO (RUT_ALUMNO)
go

alter table HISTORICO_PRUEBA_ALUMNO
   add constraint FK_HISTORIC_RELATIONS_PREGUNTA foreign key (ID_PREGUNTA_HPA)
      references PREGUNTA (ID_PREGUNTA)
go

alter table HISTORICO_PRUEBA_ALUMNO
   add constraint FK_HISTORIC_RELATIONS_RESPUEST foreign key (ID_RESPUESTA_HPA)
      references RESPUESTA (ID_RESPUESTA)
go

alter table HISTORICO_PRUEBA_ALUMNO
   add constraint FK_HISTORIC_RELATIONS_EVALUACI foreign key (ID_EVALUACION_HPA)
      references EVALUACION (ID_EVALUACION)
go

alter table PERSONA
   add constraint FK_PERSONA_RELATIONS_PAIS foreign key (ID_PAIS)
      references PAIS (ID_PAIS)
go

alter table PREGUNTA
   add constraint FK_PREGUNTA_RELATIONS_TIPO_PRE foreign key (ID_TIPO_PREGUNTA_PREGUNTA)
      references TIPO_PREGUNTA (ID_TIPO_PREGUNTA)
go

alter table PREGUNTA
   add constraint FK_PREGUNTA_RELATIONS_COMPETEN foreign key (ID_COMPETENCIA_PREGUNTA)
      references COMPETENCIA (ID_COMPETENCIA)
go

alter table RELATIONSHIP_19
   add constraint FK_RELATION_CURSA_ASIGNATU foreign key (ID_ASIGNATURA_AA)
      references ASIGNATURA (ID_ASIGNATURA)
go

alter table RELATIONSHIP_19
   add constraint FK_RELATION_ES_CURSAD_ALUMNO foreign key (RUT_ALUMNO_AA)
      references ALUMNO (RUT_ALUMNO)
go

alter table RESPUESTA
   add constraint FK_RESPUEST_RELATIONS_PREGUNTA foreign key (ID_PREGUNTA_RESPUESTA)
      references PREGUNTA (ID_PREGUNTA)
go

alter table USUARIO
   add constraint FK_USUARIO_RELATIONS_TIPO_USU foreign key (ID_TIPO_USUARIO)
      references TIPO_USUARIO (ID_TIPO_USUARIO)
go

