USE [Graham]
GO
/****** Object:  Table [dbo].[Holder]    Script Date: 8/4/2019 12:20:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holder](
	[IdHolder] [int] NOT NULL,
	[Denomination] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
 CONSTRAINT [PK_Holder] PRIMARY KEY CLUSTERED 
(
	[IdHolder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Market]    Script Date: 8/4/2019 12:20:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Market](
	[IdMarket] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Ticker] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Market] PRIMARY KEY CLUSTERED 
(
	[IdMarket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portfolio]    Script Date: 8/4/2019 12:20:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolio](
	[IdPortfolio] [int] NOT NULL,
	[IdHolder] [int] NOT NULL,
	[IdCurrency] [int] NOT NULL,
 CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED 
(
	[IdPortfolio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortfolioSecurity]    Script Date: 8/4/2019 12:20:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortfolioSecurity](
	[IdPortfolioSecurity] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPortfolio] [int] NOT NULL,
	[IdSecurity] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_PortfolioHolder] PRIMARY KEY CLUSTERED 
(
	[IdPortfolioSecurity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Security]    Script Date: 8/4/2019 12:20:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Security](
	[IdSecurity] [int] NOT NULL,
	[Ticker] [varchar](10) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IdMarket] [int] NOT NULL,
	[Notes] [varchar](50) NULL,
	[CurrentPrice] [decimal](8, 5) NULL,
 CONSTRAINT [PK_Security] PRIMARY KEY CLUSTERED 
(
	[IdSecurity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Portfolio]  WITH CHECK ADD  CONSTRAINT [FK_Portfolio_Holder] FOREIGN KEY([IdHolder])
REFERENCES [dbo].[Holder] ([IdHolder])
GO
ALTER TABLE [dbo].[Portfolio] CHECK CONSTRAINT [FK_Portfolio_Holder]
GO
ALTER TABLE [dbo].[PortfolioSecurity]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioHolder_Portfolio] FOREIGN KEY([IdPortfolio])
REFERENCES [dbo].[Portfolio] ([IdPortfolio])
GO
ALTER TABLE [dbo].[PortfolioSecurity] CHECK CONSTRAINT [FK_PortfolioHolder_Portfolio]
GO
ALTER TABLE [dbo].[PortfolioSecurity]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioHolder_Security] FOREIGN KEY([IdSecurity])
REFERENCES [dbo].[Security] ([IdSecurity])
GO
ALTER TABLE [dbo].[PortfolioSecurity] CHECK CONSTRAINT [FK_PortfolioHolder_Security]
GO
ALTER TABLE [dbo].[Security]  WITH CHECK ADD  CONSTRAINT [FK_Security_Market] FOREIGN KEY([IdMarket])
REFERENCES [dbo].[Market] ([IdMarket])
GO
ALTER TABLE [dbo].[Security] CHECK CONSTRAINT [FK_Security_Market]
GO
