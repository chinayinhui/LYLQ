IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Department] (
    [Code]        NVARCHAR (50) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Type]        INT           NOT NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [CreatedDate] DATETIME      NULL,
    [UpdatedBy]   NVARCHAR (50) NULL,
    [UpdatedDate] DATETIME      NULL    
);
END;

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[User] (
    [Id]          NVARCHAR (50)  NOT NULL,
    [Account]     NVARCHAR (50)  NOT NULL,
    [Password]    NVARCHAR (500) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Demartment]  NVARCHAR (50)  NULL,
    [Enabled]     INT            NOT NULL,
    [CreatedDate] DATETIME       NULL,
    [CreatedBy]   NVARCHAR (50)  NULL,
    [UpdatedDate] DATETIME       NULL,
    [UpdatedBy]   NVARCHAR (50)  NULL    
);
END;

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materiel]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Materiel] (
    [Code]        NVARCHAR (50) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Type]        NVARCHAR (50) NOT NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [CreatedDate] DATETIME      NULL,
    [UpdatedBy]   NVARCHAR (50) NULL,
    [UpdatedDate] DATETIME      NULL
);
END;

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InStore]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[InStore] (
    [Id]               NVARCHAR (50)   NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [UnitPrice]        DECIMAL (18, 2) NULL,
    [Number]           INT             NOT NULL,
    [TotalPrice]       DECIMAL (18, 2) NULL,
    [Department]       NVARCHAR (50)   NOT NULL,
    [Type]             NVARCHAR (50)   NOT NULL,
    [CreatedBy]        NVARCHAR (50)   NULL,
    [CreatedDate]      DATETIME        NULL,
    [UpdatedBy]        NVARCHAR (50)   NULL,
    [UpdatedDate]      DATETIME        NULL,    
    [RemainNumber]     INT             NULL,
    [RemainTotalPrice] DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
END;


IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OutStore]') AND type in (N'U'))
BEGIN
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[OutStore] (
    [Id]          NVARCHAR (50)   NOT NULL,
    [InstoreId]   NVARCHAR (50)   NOT NULL,
    [Code]        NVARCHAR (50)   NOT NULL,
    [UnitPrice]   DECIMAL (18, 2) NULL,
    [Number]      INT             NOT NULL,
    [TotalPrice]  DECIMAL (18, 2) NULL,
    [Department]  NVARCHAR (50)   NOT NULL,
    [Type]        NVARCHAR (50)   NOT NULL,
    [CreatedBy]   NVARCHAR (50)   NULL,
    [CreatedDate] DATETIME        NULL,
    [UpdatedBy]   NVARCHAR (50)   NULL,
    [UpdatedDate] DATETIME        NULL,    
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
END;




