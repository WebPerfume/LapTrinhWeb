USE master
GO
Create Database com
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [varchar](max) NULL,
	[ParentId] [int] NULL CONSTRAINT [DF__Categorys__Paren__108B795B]  DEFAULT ('0'),
	[Orders] [int] NULL,
	[Img] [nvarchar](255) NULL,
	[MetaKey] [nvarchar](155) NOT NULL,
	[MetaDesc] [nvarchar](max) NOT NULL,
	[Created_By] [int] NULL CONSTRAINT [DF__Categorys__Creat__117F9D94]  DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL CONSTRAINT [DF__Categorys__Updat__1273C1CD]  DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL CONSTRAINT [DF__Categorys__Statu__1367E606]  DEFAULT ('1'),
 CONSTRAINT [PK__Category__3214EC07DD3FC206] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](64) NOT NULL,
	[Detail] [text] NOT NULL,
	[FullName] [nvarchar](64) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[UserId] [int] NULL,
	[DateContact] [datetime] NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Links]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [nvarchar](255) NOT NULL,
	[TypeLink] [nvarchar](255) NOT NULL,
	[TableId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menus]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[ParentId] [int] NULL DEFAULT ('0'),
	[Orders] [int] NOT NULL,
	[MenuType] [varchar](155) NOT NULL,
	[Position] [varchar](155) NOT NULL,
	[TableId] [int] NULL,
	[Created_By] [int] NULL DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orderdetails]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orderdetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PriceBuy] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[DeliveryName] [nvarchar](255) NULL,
	[DeliveryEmail] [nvarchar](255) NULL,
	[DeliveryPhone] [nvarchar](255) NULL,
	[DeliveryAddress] [nvarchar](255) NULL,
	[Note] [nvarchar](255) NULL,
	[UserId] [int] NOT NULL,
	[DateOrder] [datetime] NOT NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopicId] [int] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](255) NOT NULL,
	[PostType] [nvarchar](100) NULL,
	[MetaKey] [nvarchar](155) NULL,
	[MetaDesc] [nvarchar](155) NULL,
	[Created_By] [int] NULL DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [varchar](max) NULL,
	[Detail] [text] NOT NULL,
	[PriceBuy] [float] NOT NULL,
	[Img] [varchar](255) NULL,
	[MetaKey] [nvarchar](155) NOT NULL,
	[MetaDesc] [nvarchar](155) NOT NULL,
	[Created_By] [int] NULL CONSTRAINT [DF__Products__Create__2C3393D0]  DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL CONSTRAINT [DF__Products__Update__2D27B809]  DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL CONSTRAINT [DF__Products__Status__2E1BDC42]  DEFAULT ('1'),
 CONSTRAINT [PK__Products__3214EC07AA4EEDCB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[PriceSale] [float] NULL,
	[DateBegin] [datetime] NULL,
	[DateEnd] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Link] [varchar](255) NOT NULL,
	[Img] [varchar](100) NOT NULL,
	[Position] [varchar](100) NOT NULL,
	[Orders] [int] NULL,
	[Created_By] [int] NULL DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[ParentId] [int] NOT NULL DEFAULT ('0'),
	[Orders] [int] NULL,
	[MetaKey] [nvarchar](155) NULL,
	[MetaDesc] [nvarchar](155) NULL,
	[Created_By] [int] NULL DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/24/2021 6:05:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[UserName] [varchar](225) NOT NULL,
	[Password] [varchar](40) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[Img] [varchar](255) NOT NULL,
	[Gender] [int] NULL,
	[Roles] [int] NOT NULL,
	[Created_By] [int] NULL DEFAULT ('1'),
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL DEFAULT ('1'),
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL DEFAULT ('1'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

