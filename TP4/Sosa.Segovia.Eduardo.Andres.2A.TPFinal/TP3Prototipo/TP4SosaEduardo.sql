CREATE DATABASE TP4SosaDB_V1
GO
USE TP4SosaDB_V1
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 18/6/2022 08:48:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTOS](
	[ID] [int] NOT NULL,
	[PRECIO] [decimal](18, 0) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[CANTIDAD] [int] NOT NULL,
	[RAREZA] [int] NOT NULL
) ON [PRIMARY]
GO

INSERT [dbo].[PRODUCTOS] ([ID], [PRECIO], [NOMBRE], [CANTIDAD], [RAREZA]) VALUES (6, CAST(122 AS Decimal(18, 0)), N'Pin Tower', 42, 3);
INSERT [dbo].[PRODUCTOS] ([ID], [PRECIO], [NOMBRE], [CANTIDAD], [RAREZA]) VALUES (1, CAST(180 AS Decimal(18, 0)), N'Erinaceus Tower', 27, 3);
INSERT [dbo].[PRODUCTOS] ([ID], [PRECIO], [NOMBRE], [CANTIDAD], [RAREZA]) VALUES (2, CAST(40 AS Decimal(18, 0)), N'Turtur Tower', 60, 3);
INSERT [dbo].[PRODUCTOS] ([ID], [PRECIO], [NOMBRE], [CANTIDAD], [RAREZA]) VALUES (3, CAST(120 AS Decimal(18, 0)), N'Vulpes Tower', 68, 1);
INSERT [dbo].[PRODUCTOS] ([ID], [PRECIO], [NOMBRE], [CANTIDAD], [RAREZA]) VALUES (4, CAST(200 AS Decimal(18, 0)), N'Canis Tower', 18, 3);
INSERT [dbo].[PRODUCTOS] ([ID], [PRECIO], [NOMBRE], [CANTIDAD], [RAREZA]) VALUES (5, CAST(500 AS Decimal(18, 0)), N'Centrocercus Tower', 96, 3);
GO
USE [master]
GO
ALTER DATABASE TP4SosaDB_V1 SET  READ_WRITE 
GO