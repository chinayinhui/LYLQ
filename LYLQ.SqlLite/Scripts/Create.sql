CREATE TABLE Department (
    [Code]        NVARCHAR (50) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Type]        INTEGER          NOT NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [CreatedDate] DATETIME      NULL,
    [UpdatedBy]   NVARCHAR (50) NULL,
    [UpdatedDate] DATETIME      NULL    
)

CREATE TABLE [User] (
    [Id] nvarchar (50) NOT NULL,
    [Account] nvarchar (50) NOT NULL,
    [Password] nvarchar (500) NOT NULL,
    [Name] nvarchar (50) NOT NULL,
    [Demartment] nvarchar (50),
    [Enabled] integer NOT NULL,
    [CreatedDate] datetime,
    [CreatedBy] nvarchar (50),
    [UpdatedDate] datetime,
    [UpdatedBy] nvarchar (50)
)

CREATE TABLE Materiel (
    [Code]        NVARCHAR (50) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Type]        NVARCHAR (50) NOT NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [CreatedDate] DATETIME      NULL,
    [UpdatedBy]   NVARCHAR (50) NULL,
    [UpdatedDate] DATETIME      NULL
)

CREATE TABLE InStore (
    [Id]               NVARCHAR (50) PRIMARY KEY   NOT NULL,
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
    [RemainTotalPrice] DECIMAL (18, 2) NULL
)

CREATE TABLE OutStore (
    [Id]          NVARCHAR (50) PRIMARY KEY  NOT NULL,
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
    [UpdatedDate] DATETIME        NULL
)

CREATE TABLE Stock (
    [Id]               NVARCHAR (50) PRIMARY KEY   NOT NULL,
	[InstoreId]        NVARCHAR (50) NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [UnitPrice]        DECIMAL (18, 2) NULL,
    [Number]           INT             NOT NULL,
    [TotalPrice]       DECIMAL (18, 2) NULL,
    [Department]       NVARCHAR (50)   NOT NULL,
    [Type]             NVARCHAR (50)   NOT NULL,
    [CreatedBy]        NVARCHAR (50)   NULL,
    [CreatedDate]      DATETIME        NULL,
    [UpdatedBy]        NVARCHAR (50)   NULL,
    [UpdatedDate]      DATETIME        NULL        
)





