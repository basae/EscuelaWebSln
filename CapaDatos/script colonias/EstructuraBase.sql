USE [master]
GO
/****** Object:  Database [EscuelaWeb]    Script Date: 27/08/2023 09:48:31 p. m. ******/
CREATE DATABASE [EscuelaWeb]
GO
ALTER DATABASE [EscuelaWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EscuelaWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EscuelaWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EscuelaWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EscuelaWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EscuelaWeb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EscuelaWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EscuelaWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EscuelaWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EscuelaWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EscuelaWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EscuelaWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EscuelaWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EscuelaWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EscuelaWeb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EscuelaWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EscuelaWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EscuelaWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EscuelaWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EscuelaWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EscuelaWeb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EscuelaWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EscuelaWeb] SET RECOVERY FULL 
GO
ALTER DATABASE [EscuelaWeb] SET  MULTI_USER 
GO
ALTER DATABASE [EscuelaWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EscuelaWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EscuelaWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EscuelaWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EscuelaWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EscuelaWeb] SET QUERY_STORE = OFF
GO
USE [EscuelaWeb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [EscuelaWeb]
GO
/****** Object:  User [api_user]    Script Date: 27/08/2023 09:48:31 p. m. ******/
CREATE USER [api_user] FOR LOGIN [api_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [api_user]
GO
/****** Object:  UserDefinedTableType [dbo].[RolUserType]    Script Date: 27/08/2023 09:48:31 p. m. ******/
CREATE TYPE [dbo].[RolUserType] AS TABLE(
	[Id_Rol] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[NoControl] [int] IDENTITY(1,1) NOT NULL,
	[Id_Persona] [int] NOT NULL,
	[Id_GradoGrupo] [int] NOT NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[NoControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[Cve_Materia] [varchar](10) NOT NULL,
	[Cve_Alumno] [int] NOT NULL,
	[Id_Periodo] [int] NOT NULL,
	[Calificacion] [decimal](10, 2) NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cve_Materia] ASC,
	[Cve_Alumno] ASC,
	[Id_Periodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Colonia]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Colonia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPostal] [varchar](5) NULL,
	[Descripcion] [varchar](100) NULL,
	[Id_Municipio] [int] NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
 CONSTRAINT [PK__Cat_Colo__3214EC0781D1B1FF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_DiasSemana]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_DiasSemana](
	[Id] [int] NOT NULL,
	[Clave] [varchar](2) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Estado]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Clave] [varchar](10) NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
 CONSTRAINT [PK__Cat_Esta__3214EC077FBF504E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_EstadoReg]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_EstadoReg](
	[Clave] [varchar](2) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Genero]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Genero](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Municipio]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Municipio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Clave] [varchar](10) NULL,
	[Id_Estado] [int] NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
 CONSTRAINT [PK__Cat_Muni__3214EC071D1B172B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_NivelEducativo]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_NivelEducativo](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Periodo]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Periodo](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Id_Escuela] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Roles]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Turno]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Turno](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Colonia] [int] NULL,
	[Calle] [varchar](150) NULL,
	[NoInt] [varchar](10) NULL,
	[NoExt] [varchar](10) NULL,
	[Lat] [decimal](10, 8) NULL,
	[Lng] [decimal](10, 8) NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
 CONSTRAINT [PK__Direccio__3214EC074358B44D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuela]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuela](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[Id_Direccion] [int] NULL,
	[Id_Contacto] [int] NOT NULL,
	[AnioRegistro] [datetime] NULL,
	[Id_Nivel_Educativo] [int] NULL,
	[Id_Usuario] [int] NOT NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK__Escuela__3214EC0768C90683] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grado]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grado] [varchar](10) NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[Id_Escuela] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK__Cat_Grad__DF0ADB6173093AC2] PRIMARY KEY CLUSTERED 
(
	[Grado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grado_Grupo_Turno]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grado_Grupo_Turno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cve_Grado] [varchar](10) NOT NULL,
	[Cve_Grupo] [varchar](10) NOT NULL,
	[Id_Turno] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grupo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](150) NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[Id_Escuela] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK__Cat_Grup__D00393CBB2A7A5B8] PRIMARY KEY CLUSTERED 
(
	[Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario_Grupo]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario_Grupo](
	[Id_GradoGrupo] [int] NOT NULL,
	[Cve_Materia] [varchar](10) NOT NULL,
	[Id_DiaSemana] [int] NOT NULL,
	[HoraInicio] [time](7) NULL,
	[HoraFin] [time](7) NULL,
	[Nota] [varchar](500) NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestro]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CedulaProfesional] [varchar](150) NOT NULL,
	[Id_Persona] [int] NOT NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[Clave] [varchar](10) NOT NULL,
	[Descripción] [varchar](250) NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia_Maestro]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia_Maestro](
	[Cve_Materia] [varchar](10) NULL,
	[Id_Maestro] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apaterno] [varchar](50) NULL,
	[Amaterno] [varchar](50) NULL,
	[FechaNacimiento] [date] NULL,
	[Id_Genero] [int] NULL,
	[Id_Direccion] [int] NOT NULL,
	[Id_usuario] [int] NULL,
	[Id_Contacto] [int] NOT NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK__Persona__3214EC07B742FEBE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contrasena] [binary](256) NOT NULL,
	[Cve_EstadoReg] [varchar](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK__Usuario__3214EC0749C40F26] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Roles]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Roles](
	[Id_usuario] [int] NOT NULL,
	[Id_Rol] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC,
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD FOREIGN KEY([Id_GradoGrupo])
REFERENCES [dbo].[Grado_Grupo_Turno] ([Id])
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK__Alumno__Id_Perso__74AE54BC] FOREIGN KEY([Id_Persona])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK__Alumno__Id_Perso__74AE54BC]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([Cve_Alumno])
REFERENCES [dbo].[Alumno] ([NoControl])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([Cve_Materia])
REFERENCES [dbo].[Materia] ([Clave])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([Id_Periodo])
REFERENCES [dbo].[Cat_Periodo] ([Id])
GO
ALTER TABLE [dbo].[Cat_Colonia]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Colon__Cve_E__0B91BA14] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Cat_Colonia] CHECK CONSTRAINT [FK__Cat_Colon__Cve_E__0B91BA14]
GO
ALTER TABLE [dbo].[Cat_Colonia]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Colon__Id_Mu__5070F446] FOREIGN KEY([Id_Municipio])
REFERENCES [dbo].[Cat_Municipio] ([Id])
GO
ALTER TABLE [dbo].[Cat_Colonia] CHECK CONSTRAINT [FK__Cat_Colon__Id_Mu__5070F446]
GO
ALTER TABLE [dbo].[Cat_Estado]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Estad__Cve_E__01142BA1] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Cat_Estado] CHECK CONSTRAINT [FK__Cat_Estad__Cve_E__01142BA1]
GO
ALTER TABLE [dbo].[Cat_Municipio]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Munic__Cve_E__05D8E0BE] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Cat_Municipio] CHECK CONSTRAINT [FK__Cat_Munic__Cve_E__05D8E0BE]
GO
ALTER TABLE [dbo].[Cat_Municipio]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Munic__Id_Es__4D94879B] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Cat_Estado] ([Id])
GO
ALTER TABLE [dbo].[Cat_Municipio] CHECK CONSTRAINT [FK__Cat_Munic__Id_Es__4D94879B]
GO
ALTER TABLE [dbo].[Cat_Periodo]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Perio__Id_Es__08B54D69] FOREIGN KEY([Id_Escuela])
REFERENCES [dbo].[Escuela] ([Id])
GO
ALTER TABLE [dbo].[Cat_Periodo] CHECK CONSTRAINT [FK__Cat_Perio__Id_Es__08B54D69]
GO
ALTER TABLE [dbo].[Cat_Roles]  WITH CHECK ADD FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK__Direccion__Id_Co__534D60F1] FOREIGN KEY([Id_Colonia])
REFERENCES [dbo].[Cat_Colonia] ([Id])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK__Direccion__Id_Co__534D60F1]
GO
ALTER TABLE [dbo].[Escuela]  WITH CHECK ADD  CONSTRAINT [FK__Escuela__Cve_Est__35BCFE0A] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Escuela] CHECK CONSTRAINT [FK__Escuela__Cve_Est__35BCFE0A]
GO
ALTER TABLE [dbo].[Escuela]  WITH CHECK ADD FOREIGN KEY([Id_Contacto])
REFERENCES [dbo].[Contacto] ([Id])
GO
ALTER TABLE [dbo].[Escuela]  WITH CHECK ADD  CONSTRAINT [FK__Escuela__Id_Dire__5812160E] FOREIGN KEY([Id_Direccion])
REFERENCES [dbo].[Direccion] ([Id])
GO
ALTER TABLE [dbo].[Escuela] CHECK CONSTRAINT [FK__Escuela__Id_Dire__5812160E]
GO
ALTER TABLE [dbo].[Escuela]  WITH CHECK ADD  CONSTRAINT [FK__Escuela__Id_Nive__37A5467C] FOREIGN KEY([Id_Nivel_Educativo])
REFERENCES [dbo].[Cat_NivelEducativo] ([Id])
GO
ALTER TABLE [dbo].[Escuela] CHECK CONSTRAINT [FK__Escuela__Id_Nive__37A5467C]
GO
ALTER TABLE [dbo].[Escuela]  WITH CHECK ADD  CONSTRAINT [FK__Escuela__Id_Usua__37703C52] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Escuela] CHECK CONSTRAINT [FK__Escuela__Id_Usua__37703C52]
GO
ALTER TABLE [dbo].[Grado]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Grado__Cve_E__3F466844] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Grado] CHECK CONSTRAINT [FK__Cat_Grado__Cve_E__3F466844]
GO
ALTER TABLE [dbo].[Grado]  WITH CHECK ADD  CONSTRAINT [FK__Grado__Id_Escuel__4316F928] FOREIGN KEY([Id_Escuela])
REFERENCES [dbo].[Escuela] ([Id])
GO
ALTER TABLE [dbo].[Grado] CHECK CONSTRAINT [FK__Grado__Id_Escuel__4316F928]
GO
ALTER TABLE [dbo].[Grado_Grupo_Turno]  WITH CHECK ADD FOREIGN KEY([Cve_Grado])
REFERENCES [dbo].[Grado] ([Grado])
GO
ALTER TABLE [dbo].[Grado_Grupo_Turno]  WITH CHECK ADD FOREIGN KEY([Cve_Grupo])
REFERENCES [dbo].[Grupo] ([Grupo])
GO
ALTER TABLE [dbo].[Grado_Grupo_Turno]  WITH CHECK ADD FOREIGN KEY([Id_Turno])
REFERENCES [dbo].[Cat_Turno] ([Id])
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK__Cat_Grupo__Cve_E__4222D4EF] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK__Cat_Grupo__Cve_E__4222D4EF]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK__Grupo__Id_Escuel__440B1D61] FOREIGN KEY([Id_Escuela])
REFERENCES [dbo].[Escuela] ([Id])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK__Grupo__Id_Escuel__440B1D61]
GO
ALTER TABLE [dbo].[Horario_Grupo]  WITH CHECK ADD FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Horario_Grupo]  WITH CHECK ADD FOREIGN KEY([Cve_Materia])
REFERENCES [dbo].[Materia] ([Clave])
GO
ALTER TABLE [dbo].[Horario_Grupo]  WITH CHECK ADD FOREIGN KEY([Id_DiaSemana])
REFERENCES [dbo].[Cat_DiasSemana] ([Id])
GO
ALTER TABLE [dbo].[Horario_Grupo]  WITH CHECK ADD FOREIGN KEY([Id_GradoGrupo])
REFERENCES [dbo].[Grado_Grupo_Turno] ([Id])
GO
ALTER TABLE [dbo].[Maestro]  WITH CHECK ADD FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Maestro]  WITH CHECK ADD  CONSTRAINT [FK__Maestro__Id_Pers__797309D9] FOREIGN KEY([Id_Persona])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Maestro] CHECK CONSTRAINT [FK__Maestro__Id_Pers__797309D9]
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Materia_Maestro]  WITH CHECK ADD FOREIGN KEY([Cve_Materia])
REFERENCES [dbo].[Materia] ([Clave])
GO
ALTER TABLE [dbo].[Materia_Maestro]  WITH CHECK ADD FOREIGN KEY([Id_Maestro])
REFERENCES [dbo].[Maestro] ([Id])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK__Persona__Cve_Est__6A30C649] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK__Persona__Cve_Est__6A30C649]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD FOREIGN KEY([Id_Contacto])
REFERENCES [dbo].[Contacto] ([Id])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK__Persona__Id_Dire__6754599E] FOREIGN KEY([Id_Direccion])
REFERENCES [dbo].[Direccion] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK__Persona__Id_Dire__6754599E]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK__Persona__Id_Gene__68487DD7] FOREIGN KEY([Id_Genero])
REFERENCES [dbo].[Cat_Genero] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK__Persona__Id_Gene__68487DD7]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK__Persona__Id_usua__693CA210] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK__Persona__Id_usua__693CA210]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK__Usuario__Cve_Est__60A75C0F] FOREIGN KEY([Cve_EstadoReg])
REFERENCES [dbo].[Cat_EstadoReg] ([Clave])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK__Usuario__Cve_Est__60A75C0F]
GO
ALTER TABLE [dbo].[Usuario_Roles]  WITH CHECK ADD FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Cat_Roles] ([Id])
GO
ALTER TABLE [dbo].[Usuario_Roles]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_R__Id_us__6383C8BA] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Usuario_Roles] CHECK CONSTRAINT [FK__Usuario_R__Id_us__6383C8BA]
GO
/****** Object:  StoredProcedure [dbo].[sp_contacto_ins]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_contacto_ins]
@Email varchar(250),
@Telefono varchar(15)
AS
INSERT INTO [dbo].[Contacto]([Email], [Telefono], [FechaRegistro])
SELECT @Email,@Telefono,GETDATE()
SELECT CAST(SCOPE_IDENTITY() AS int)
GO
/****** Object:  StoredProcedure [dbo].[sp_contacto_sel]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_contacto_sel]
@Id int
AS
SELECT 
[Id], 
[Email], 
[Telefono]
FROM [dbo].[Contacto]
WHERE
ID= @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_contacto_upd]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_contacto_upd]
@Id int,
@Email varchar(250) = null,
@Telefono varchar(15) = null
AS
UPDATE [dbo].[Contacto]	SET
[Email]					=ISNULL(@Email,Email), 
[Telefono]				=ISNULL(@Telefono,Telefono), 
[FechaModificacion]		=GETDATE()
WHERE
Id	=	@Id
GO
/****** Object:  StoredProcedure [dbo].[sp_direccion_ins]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_direccion_ins]
@Id_Colonia		INT, 
@Calle			VARCHAR(150), 
@NoInt			VARCHAR(10)	=	NULL, 
@NoExt			VARCHAR(10), 
@Lat			DECIMAL(10,8)	=	NULL, 
@Lng			DECIMAL(10,8)	=	NULL
AS
BEGIN TRY
	INSERT INTO [dbo].[Direccion](Id_Colonia, Calle, NoInt, NoExt, Lat, Lng, Cve_EstadoReg, FechaRegistro)
	VALUES(@Id_Colonia,@Calle,@NoInt,@NoExt,@Lat,@Lng,'AC',GETDATE())
	SELECT CAST(SCOPE_IDENTITY() AS INT)
END TRY
BEGIN CATCH
	DECLARE @ERROR VARCHAR(MAX)
	SET @ERROR = ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_direccion_sel_by_id]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_direccion_sel_by_id]
@id_direccion INT
AS
SELECT 
D.Id,
D.Calle,
D.NoExt,
D.NoInt,
CC.CodigoPostal,
CAST(CC.Id AS VARCHAR)[Colonia_Id],
CAST(CM.Id AS VARCHAR)[Municipio_Id],
CAST(CE.Id AS VARCHAR)[Estado_Id],
CC.Descripcion[Colonia_Desc],
CM.Descripcion[Municipio_Desc],
CE.Descripcion[Estado_Desc]
FROM Direccion D
INNER JOIN Cat_Colonia CC ON CC.Id=D.Id_Colonia
INNER JOIN Cat_Municipio CM ON CM.Id=CC.Id_Municipio
INNER JOIN Cat_Estado CE ON CE.Id= CM.Id_Estado
GO
/****** Object:  StoredProcedure [dbo].[sp_direccion_sel_cp]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--sp_direccion_sel_cp '42088'
CREATE procedure [dbo].[sp_direccion_sel_cp]
@CodigoPostal varchar(5)
AS
SELECT 
C.CodigoPostal,
CAST(c.Id AS VARCHAR)[Id],
c.Descripcion,
CAST(M.Id AS VARCHAR)[id_municipio],
M.Descripcion[desc_municipio],
CAST(e.Id AS VARCHAR)[id_estado],
e.Descripcion[desc_estado]
FROM Cat_Colonia C
INNER JOIN Cat_Municipio M ON M.Id=C.Id_Municipio
INNER JOIN Cat_Estado E ON E.ID=M.Id_Estado
WHERE
C.CodigoPostal= @CodigoPostal
ORDER BY C.Descripcion 
GO
/****** Object:  StoredProcedure [dbo].[sp_direccion_upd]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_direccion_upd]
@Id int,
@Id_Colonia		INT	=	NULL, 
@Calle			VARCHAR(150)	=	NULL, 
@NoInt			VARCHAR(10)	=	NULL, 
@NoExt			VARCHAR(10)	=	NULL, 
@Lat			DECIMAL(10,8)	=	NULL, 
@Lng			DECIMAL(10,8)	=	NULL,
@Cve_Estado		varchar(2)	=	null
AS
BEGIN TRY
	UPDATE [dbo].[Direccion]	SET
	Id_Colonia			=	ISNULL(@Id_Colonia,Id_Colonia), 
	Calle				=	ISNULL(@Calle,Calle), 
	NoInt				=	ISNULL(@NoInt,NoInt), 
	NoExt				=	ISNULL(@NoExt,NoExt), 
	Lat					=	ISNULL(@Lat,Lat), 
	Lng					=	ISNULL(@Lng,Lng), 
	Cve_EstadoReg		=	ISNULL(@Cve_Estado,Cve_EstadoReg), 
	FechaModificacion	=	GETDATE()
	WHERE
	ID=@Id
	
	SELECT @Id
END TRY
BEGIN CATCH
	DECLARE @ERROR VARCHAR(MAX)
	SET @ERROR = ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_escuela_ins]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_escuela_ins]
(
@Clave VARCHAR(50),
@Nombre VARCHAR(250),
@Id_Direccion INT,
@AnioRegistro DATE,
@Id_Nivel_Educativo INT,
@Id_Contacto int,
@Id_usuario int
)
AS
BEGIN TRY

IF EXISTS(SELECT ID FROM [dbo].[Escuela] WHERE Clave = @Clave and Cve_EstadoReg = 'AC')
BEGIN
	RAISERROR('Esta clave de registro ya existe, verifica los datos.',16,1)
END

INSERT INTO [dbo].[Escuela](Clave, Nombre, Id_Direccion, AnioRegistro, Id_Nivel_Educativo,Id_Usuario,Id_Contacto, Cve_EstadoReg, FechaRegistro)
VALUES(@Clave,@Nombre,@Id_Direccion,@AnioRegistro,@Id_Nivel_Educativo,@Id_usuario,@Id_Contacto,'AC',GETDATE())

SELECT CAST(SCOPE_IDENTITY() AS INT)

END TRY
BEGIN CATCH
	DECLARE @ERROR VARCHAR(MAX)
	SET @ERROR= ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_escuela_sel]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--sp_escuela_sel_by_id 3
CREATE procedure [dbo].[sp_escuela_sel]
AS
SELECT 
E.Id,
E.Clave,
Nombre,
AnioRegistro,
CAST(Id_Nivel_Educativo AS VARCHAR)[Id_Nivel_Educativo],
NE.Descripcion[NivelEducativo_Desc],
E.Cve_EstadoReg,
ER.Descripcion[EstadoReg_Desc],
E.FechaRegistro,
E.FechaModificacion,
E.Id_Usuario,
E.Id_Contacto,
E.Id_Direccion
FROM Escuela E
INNER JOIN Cat_EstadoReg ER ON ER.Clave=E.Cve_EstadoReg
INNER JOIN Cat_NivelEducativo NE ON NE.Id= E.Id_Nivel_Educativo
INNER JOIN Direccion D ON D.Id= E.ID_DIRECCION
order by Nombre
GO
/****** Object:  StoredProcedure [dbo].[sp_escuela_sel_by_id]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--sp_escuela_sel_by_id 1
CREATE procedure [dbo].[sp_escuela_sel_by_id]
@ID_ESCUELA INT
AS
SELECT 
E.Id,
E.Clave,
Nombre,
AnioRegistro,
CAST(Id_Nivel_Educativo AS VARCHAR)[Id_Nivel_Educativo],
NE.Descripcion[NivelEducativo_Desc],
E.Cve_EstadoReg,
ER.Descripcion[EstadoReg_Desc],
E.FechaRegistro,
E.FechaModificacion,
E.Id_Contacto,
E.Id_Usuario,
E.Id_Direccion
FROM Escuela E
INNER JOIN Cat_EstadoReg ER ON ER.Clave=E.Cve_EstadoReg
INNER JOIN Cat_NivelEducativo NE ON NE.Id= E.Id_Nivel_Educativo
INNER JOIN Direccion D ON D.Id= E.ID_DIRECCION
WHERE E.Id= @id_escuela


GO
/****** Object:  StoredProcedure [dbo].[sp_escuela_upd]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_escuela_upd]
(
@Id int,
@Clave VARCHAR(50)	=	NULL,
@Nombre VARCHAR(250)	=	NULL,
@AnioRegistro DATE	=	NULL,
@Id_Nivel_Educativo INT	=	NULL,
@Cve_Estatus	VARCHAR(2)	=	NULL
)
AS
BEGIN TRY

IF @Clave IS NOT NULL AND EXISTS(SELECT ID FROM [dbo].[Escuela] WHERE Clave = @Clave and Cve_EstadoReg = 'AC')
BEGIN
	RAISERROR('Esta clave de registro ya existe, verifica los datos.',16,1)
END

UPDATE [dbo].[Escuela] SET
Clave= ISNULL(@Clave,Clave), 
Nombre	=	ISNULL(@Nombre,Nombre), 
AnioRegistro	=	ISNULL(@AnioRegistro,AnioRegistro), 
Id_Nivel_Educativo	=	ISNULL(@Id_Nivel_Educativo,Id_Nivel_Educativo), 
Cve_EstadoReg	=	ISNULL(@Cve_Estatus, Cve_EstadoReg),
FechaModificacion	=	GETDATE()
WHERE Id=@Id

SELECT @Id

END TRY
BEGIN CATCH
	DECLARE @ERROR VARCHAR(MAX)
	SET @ERROR= ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario_ins]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_usuario_ins]
(
@NombreUsuario	VARCHAR(50),
@Contrasena		VARCHAR(64),
@ListaRol		RolUserType	READONLY
)
AS
BEGIN TRY
	IF EXISTS (SELECT ID FROM [dbo].[Usuario] WHERE	NombreUsuario	=	@NombreUsuario AND	Cve_EstadoReg	=	'AC')
	BEGIN
		DECLARE @ERR VARCHAR(250)
		SET @ERR	=CONCAT('YA EXISTE ESTE NOMBRE EL USUARIO "',@NombreUsuario,'"')
		RAISERROR(@ERR,16,1)
	END
	INSERT INTO [dbo].[Usuario]([NombreUsuario], [Contrasena], [Cve_EstadoReg], [FechaRegistro])
	VALUES(@NombreUsuario,HASHBYTES('SHA2_256',@Contrasena),'AC',GETDATE())
	DECLARE @ID INT
	SELECT @ID = SCOPE_IDENTITY()
	IF(SELECT COUNT(*) FROM @ListaRol) > 0
	BEGIN
		INSERT INTO [dbo].[Usuario_Roles]([Id_usuario], [Id_Rol], [FechaRegistro])
		SELECT
		@ID,
		R.ID_ROL,
		GETDATE()
		FROM @ListaRol R 
		INNER JOIN Cat_Roles CR ON CR.Id= R.ID_ROL		
	END
	select @ID
END TRY
BEGIN CATCH
	DECLARE @ERROR	VARCHAR(MAX)
	SET @ERROR= ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario_sel_by_id]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_usuario_sel_by_id]
@Id int
AS
SELECT
[Id], 
[NombreUsuario], 

[Cve_EstadoReg], 
CE.Descripcion[Desc_EstadoReg],
U.[FechaRegistro], 
U.[FechaModificacion]
FROM [dbo].[Usuario]	U
INNER JOIN Cat_EstadoReg CE	ON	CE.Clave	=	U.Cve_EstadoReg
WHERE ID= @Id

SELECT 
UR.Id_Rol,
CR.Descripcion
FROM [dbo].[Usuario_Roles] UR
INNER JOIN Cat_Roles CR	ON	CR.Id=UR.Id_Rol
WHERE UR.Id_usuario = @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario_sel_login]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--sp_usuario_sel_login 'ESCU000001','edrei8989'
CREATE procedure [dbo].[sp_usuario_sel_login]
@usuario varchar(50),
@contrasena varchar(256)
AS
BEGIN TRY
SELECT 
*
INTO #USUARIO_TEMPORAL
FROM
(
	--USUARIO ESCUELA
	SELECT
	U.[Id], 
	[NombreUsuario], 
	U.[Cve_EstadoReg], 
	CE.Descripcion[Desc_EstadoReg],	
	C.Email,
	C.Telefono,
	U.[FechaRegistro], 
	U.[FechaModificacion],
	CAST(1 AS INT)[TipoAut],
	CAST(E.Id AS VARCHAR)[Id_Entidad]
	FROM [dbo].[Usuario]	U
	INNER JOIN Cat_EstadoReg CE	ON	CE.Clave	=	U.Cve_EstadoReg
	INNER JOIN Escuela E ON E.Id_Usuario = U.Id
	INNER JOIN Contacto C ON C.Id= E.Id_Contacto
	WHERE u.NombreUsuario = @usuario and
	Contrasena = HASHBYTES('SHA2_256',@contrasena)
	UNION
	--USUARIO ALUMNO/MAESTRO
	SELECT
	U.[Id], 
	[NombreUsuario], 
	U.[Cve_EstadoReg], 
	CE.Descripcion[Desc_EstadoReg],	
	C.Email,
	C.Telefono,
	U.[FechaRegistro], 
	U.[FechaModificacion],
	CAST(CASE WHEN A.NoControl IS NULL THEN 3 ELSE 2 END AS INT)[TipoAut],
	CAST(CASE WHEN A.NoControl IS NULL THEN M.Id ELSE A.NoControl END AS VARCHAR)[Id_Entidad]
	FROM [dbo].[Usuario]	U
	INNER JOIN Cat_EstadoReg CE	ON	CE.Clave	=	U.Cve_EstadoReg
	INNER JOIN Persona P ON P.Id_Usuario = U.Id
	INNER JOIN Contacto C ON C.Id= P.Id_Contacto
	LEFT JOIN Alumno A	ON A.Id_Persona	=	P.Id
	LEFT JOIN Maestro M ON M.Id_Persona = P.Id
	WHERE u.NombreUsuario = @usuario and
	Contrasena = HASHBYTES('SHA2_256',@contrasena)
	UNION
	SELECT
	U.[Id], 
	[NombreUsuario], 
	U.[Cve_EstadoReg], 
	CE.Descripcion[Desc_EstadoReg],	
	NULL[Email],
	NULL[Telefono],
	U.[FechaRegistro], 
	U.[FechaModificacion],
	CAST(4 AS INT)[TipoAut],
	NULL[Id_Entidad]
	FROM [dbo].[Usuario]	U
	INNER JOIN Cat_EstadoReg CE	ON	CE.Clave	=	U.Cve_EstadoReg	
	LEFT JOIN Escuela E ON E.Id_Usuario = U.Id
	WHERE u.NombreUsuario = @usuario and
	Contrasena = HASHBYTES('SHA2_256',@contrasena)
	AND
	E.Id IS NULL
)T
IF @@ROWCOUNT = 0
RAISERROR('USUARIO O CONTRASEÑA INCORRECTOS',16,1)

SELECT * FROM #USUARIO_TEMPORAL
SELECT 
UR.Id_Rol,
CR.Descripcion
FROM [dbo].[Usuario_Roles] UR
INNER JOIN Cat_Roles CR	ON	CR.Id=UR.Id_Rol
INNER JOIN #USUARIO_TEMPORAL U ON U.Id= UR.Id_usuario
IF OBJECT_ID('tempdb..#USUARIO_TEMPORAL') IS NOT NULL DROP TABLE #USUARIO_TEMPORAL
END TRY
BEGIN CATCH
	DECLARE @ERROR VARCHAR(MAX)
	SET @ERROR = ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario_upd]    Script Date: 27/08/2023 09:48:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_usuario_upd]
(
@ID	INT,
@Contrasena		VARCHAR(64) = NULL,
@ListaRol		RolUserType	READONLY
)
AS
BEGIN TRY
	
	UPDATE [dbo].[Usuario]	SET
	Contrasena	=	ISNULL(HASHBYTES('SHA2_256',@Contrasena),Contrasena),
	FechaModificacion	=	GETDATE()
	WHERE	Id=	@ID

	IF(SELECT COUNT(*) FROM @ListaRol)>0
	BEGIN		
		INSERT INTO [dbo].[Usuario_Roles]([Id_usuario], [Id_Rol], [FechaRegistro])
		SELECT
		@ID,
		R.ID_ROL,
		GETDATE()
		FROM @ListaRol R 
		INNER JOIN Cat_Roles CR ON CR.Id= R.ID_ROL		
		LEFT JOIN [dbo].[Usuario_Roles]	UR	ON UR.Id_usuario = @ID AND UR.Id_Rol = R.ID_ROL
		WHERE
		UR.Id_Rol	IS NULL
	END
	
END TRY
BEGIN CATCH
	DECLARE @ERROR	VARCHAR(MAX)
	SET @ERROR= ERROR_MESSAGE()
	RAISERROR(@ERROR,16,1)
END CATCH
GO
USE [master]
GO
ALTER DATABASE [EscuelaWeb] SET  READ_WRITE 
GO
