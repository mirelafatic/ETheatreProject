USE [master]
GO
/****** Object:  Database [MyETheatre]    Script Date: 4/22/2022 6:32:32 PM ******/
CREATE DATABASE [MyETheatre]
ALTER DATABASE [MyETheatre] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyETheatre].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyETheatre] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyETheatre] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyETheatre] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyETheatre] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyETheatre] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyETheatre] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyETheatre] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyETheatre] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyETheatre] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyETheatre] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyETheatre] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyETheatre] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyETheatre] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyETheatre] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyETheatre] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyETheatre] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyETheatre] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyETheatre] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyETheatre] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyETheatre] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyETheatre] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyETheatre] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyETheatre] SET RECOVERY FULL 
GO
ALTER DATABASE [MyETheatre] SET  MULTI_USER 
GO
ALTER DATABASE [MyETheatre] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyETheatre] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyETheatre] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyETheatre] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyETheatre] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyETheatre] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyETheatre', N'ON'
GO
ALTER DATABASE [MyETheatre] SET QUERY_STORE = OFF
GO
USE [MyETheatre]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorID] [int] IDENTITY(1,1) NOT NULL,
	[ActorName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorPlayMap]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorPlayMap](
	[ActorPlayMapID] [int] IDENTITY(1,1) NOT NULL,
	[ActorID] [int] NOT NULL,
	[PlayID] [int] NOT NULL,
 CONSTRAINT [PK_ActorPlayMap] PRIMARY KEY CLUSTERED 
(
	[ActorPlayMapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hall]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hall](
	[HallID] [int] IDENTITY(1,1) NOT NULL,
	[HallSeats] [int] NOT NULL,
 CONSTRAINT [PK_Hall] PRIMARY KEY CLUSTERED 
(
	[HallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Play]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Play](
	[PlayID] [int] IDENTITY(1,1) NOT NULL,
	[PlayName] [varchar](50) NOT NULL,
	[Director] [varchar](50) NOT NULL,
	[ShowingID] [int] NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Play] PRIMARY KEY CLUSTERED 
(
	[PlayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Showing]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Showing](
	[ShowingID] [int] IDENTITY(1,1) NOT NULL,
	[HallID] [int] NOT NULL,
	[ShowingDate] [datetime] NOT NULL,
	[PlayID] [int] NOT NULL,
	[Cijena] [int] NULL,
 CONSTRAINT [PK_Showing] PRIMARY KEY CLUSTERED 
(
	[ShowingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[ShowingID] [int] NOT NULL,
	[WatcherID] [int] NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketStatus]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketStatus](
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TicketStatus] PRIMARY KEY CLUSTERED 
(
	[StatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Watcher]    Script Date: 4/22/2022 6:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Watcher](
	[WatcherID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Username] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Watcher] PRIMARY KEY CLUSTERED 
(
	[WatcherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (1, N'Srdjan Grahovac')
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (2, N'Omar Bajramspahic')
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (3, N'Marija Djuric')
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (4, N'Tanja Boskovic')
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (5, N'Rade Marjanovic')
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (6, N'QuincyTyler Bernstine')
GO
INSERT [dbo].[Actor] ([ActorID], [ActorName]) VALUES (7, N'Ali Amin Carter')
GO
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[ActorPlayMap] ON 
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (2, 3, 2)
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (3, 2, 2)
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (4, 1, 2)
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (5, 4, 3)
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (6, 5, 3)
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (7, 6, 4)
GO
INSERT [dbo].[ActorPlayMap] ([ActorPlayMapID], [ActorID], [PlayID]) VALUES (8, 7, 4)
GO
SET IDENTITY_INSERT [dbo].[ActorPlayMap] OFF
GO
SET IDENTITY_INSERT [dbo].[Hall] ON 
GO
INSERT [dbo].[Hall] ([HallID], [HallSeats]) VALUES (1, 100)
GO
INSERT [dbo].[Hall] ([HallID], [HallSeats]) VALUES (2, 250)
GO
SET IDENTITY_INSERT [dbo].[Hall] OFF
GO
SET IDENTITY_INSERT [dbo].[Play] ON 
GO
INSERT [dbo].[Play] ([PlayID], [PlayName], [Director], [ShowingID], [Description]) VALUES (2, N'Sin', N'Marko Radonjic', 1, N'Komad ,,Sin” se ne bavi temom rata, vec onim sto u ljudima ostane nakon rata')
GO
INSERT [dbo].[Play] ([PlayID], [PlayName], [Director], [ShowingID], [Description]) VALUES (3, N'Suze su OK', N'Mirjana Bobic Mojsilovic', 3, N'Autorka teksta Mirjana Bobic Mojsilovic kaze da komad zanrovski mozemo odrediti kao melodramu, koja u centru price ima sredovecnu, usamljenu zenu koja zivi u stihovima i za stihove.')
GO
INSERT [dbo].[Play] ([PlayID], [PlayName], [Director], [ShowingID], [Description]) VALUES (4, N'Ruined', N'Lynn Nottage', 4, N'The play involves the plight of women in the civil war-torn Democratic Republic of Congo')
GO
SET IDENTITY_INSERT [dbo].[Play] OFF
GO
SET IDENTITY_INSERT [dbo].[Showing] ON 
GO
INSERT [dbo].[Showing] ([ShowingID], [HallID], [ShowingDate], [PlayID], [Cijena]) VALUES (1, 1, CAST(N'2022-03-01T00:00:00.000' AS DateTime), 2, 6)
GO
INSERT [dbo].[Showing] ([ShowingID], [HallID], [ShowingDate], [PlayID], [Cijena]) VALUES (3, 1, CAST(N'2022-05-04T00:00:00.000' AS DateTime), 3, 12)
GO
INSERT [dbo].[Showing] ([ShowingID], [HallID], [ShowingDate], [PlayID], [Cijena]) VALUES (4, 2, CAST(N'2022-06-28T00:00:00.000' AS DateTime), 4, 30)
GO
SET IDENTITY_INSERT [dbo].[Showing] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 
GO
INSERT [dbo].[Ticket] ([TicketID], [ShowingID], [WatcherID], [StatusName]) VALUES (1, 4, 1, N'Valid')
GO
INSERT [dbo].[Ticket] ([TicketID], [ShowingID], [WatcherID], [StatusName]) VALUES (2, 3, 3, N'Invalid')
GO
INSERT [dbo].[Ticket] ([TicketID], [ShowingID], [WatcherID], [StatusName]) VALUES (3, 1, 2, N'Valid')
GO
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
INSERT [dbo].[TicketStatus] ([StatusName]) VALUES (N'Invalid')
GO
INSERT [dbo].[TicketStatus] ([StatusName]) VALUES (N'Valid')
GO
SET IDENTITY_INSERT [dbo].[Watcher] ON 
GO
INSERT [dbo].[Watcher] ([WatcherID], [Email], [Password], [Username]) VALUES (1, N'mirela.fatic000@gmail.com', N'nekiPassword1', N'Mirela')
GO
INSERT [dbo].[Watcher] ([WatcherID], [Email], [Password], [Username]) VALUES (2, N'emir.fatic002@gmail.com', N'nekiPassword2', N'Emir')
GO
INSERT [dbo].[Watcher] ([WatcherID], [Email], [Password], [Username]) VALUES (4, N'brigdgit2032@gmail.com', N'nekiPassword3', N'Bridgit')
GO
SET IDENTITY_INSERT [dbo].[Watcher] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20220422-163900]    Script Date: 4/22/2022 6:32:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20220422-163900] ON [dbo].[Watcher]
(
	[WatcherID] ASC,
	[Email] ASC,
	[Password] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MyETheatre] SET  READ_WRITE 
GO
