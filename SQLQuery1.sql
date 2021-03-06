
/****** Object:  Table [dbo].[Customer]    Script Date: 01-03-2020 07:35:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[RateListID] [int] NULL,
	[WineID] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RateList]    Script Date: 01-03-2020 07:35:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_RateList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 01-03-2020 07:35:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wine]    Script Date: 01-03-2020 07:35:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wine](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Wine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([ID], [Name], [Age], [Email], [RateListID], [WineID]) VALUES (1, N'Nirmal Singh', N'30', N'singhnirmal128@gmail.com', 1, 1)
GO
INSERT [dbo].[Customer] ([ID], [Name], [Age], [Email], [RateListID], [WineID]) VALUES (2, N'Kamal1', N'20', N'ss@ss.s', 1, 2)
GO
INSERT [dbo].[Customer] ([ID], [Name], [Age], [Email], [RateListID], [WineID]) VALUES (3, N'Kamal', N'20', N'ss@ss.s', 2, 3)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[RateList] ON 

GO
INSERT [dbo].[RateList] ([ID], [Price]) VALUES (1, CAST(6002 AS Decimal(18, 0)))
GO
INSERT [dbo].[RateList] ([ID], [Price]) VALUES (2, CAST(300 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[RateList] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([ID], [Email], [Password]) VALUES (1, N'admin@admin.com', N'admin')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Wine] ON 

GO
INSERT [dbo].[Wine] ([ID], [Name]) VALUES (1, N'Blenders pride')
GO
INSERT [dbo].[Wine] ([ID], [Name]) VALUES (2, N'Royal Stag1')
GO
INSERT [dbo].[Wine] ([ID], [Name]) VALUES (3, N'Royal Stag')
GO
SET IDENTITY_INSERT [dbo].[Wine] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_RateList] FOREIGN KEY([RateListID])
REFERENCES [dbo].[RateList] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_RateList]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Wine] FOREIGN KEY([WineID])
REFERENCES [dbo].[Wine] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Wine]
GO
USE [master]
GO
ALTER DATABASE [WineShop] SET  READ_WRITE 
GO
