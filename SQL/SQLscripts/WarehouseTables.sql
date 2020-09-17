use Warehouse
go
CREATE TABLE [dbo].[Articles](
    [articleId] [int] IDENTITY(1,1) NOT NULL,
    [articleTitle] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED
(
    [articleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Customers](
    [customerId] [int] IDENTITY(1,1) NOT NULL,
    [customerTitle] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED
(
    [customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Documents](
    [documentId] [timestamp] NOT NULL,
    [documentType] [nchar](3) NOT NULL,
    [articleId] [int] NOT NULL,
    [customerId] [int] NOT NULL,
    [documentDate] [date] NOT NULL,
    [price] [money] NOT NULL,
    [amount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [documentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

 

ALTER TABLE [dbo].[Documents]  WITH CHECK ADD FOREIGN KEY([articleId])
REFERENCES [dbo].[Articles] ([articleId])
GO

 

ALTER TABLE [dbo].[Documents]  WITH CHECK ADD FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([customerId])
GO
 