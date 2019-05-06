
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/03/2019 20:03:38
-- Generated from EDMX file: C:\Lab\01football\01football\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [demo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[plan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[plan];
GO
IF OBJECT_ID(N'[dbo].[team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[team];
GO
IF OBJECT_ID(N'[demoModelStoreContainer].[home]', 'U') IS NOT NULL
    DROP TABLE [demoModelStoreContainer].[home];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'plans'
CREATE TABLE [dbo].[plans] (
    [id] nchar(10)  NOT NULL,
    [name] varchar(100)  NULL,
    [price] nchar(10)  NULL,
    [DefaultImageId] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'teams'
CREATE TABLE [dbo].[teams] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [couuntry] varchar(50)  NULL,
    [GP] nchar(10)  NULL,
    [win] nchar(10)  NULL,
    [flat] nchar(10)  NULL,
    [lose] nchar(10)  NULL,
    [score] nchar(10)  NULL,
    [loseball] nchar(10)  NULL,
    [GD] nchar(10)  NULL,
    [score2] nchar(10)  NULL
);
GO

-- Creating table 'homes'
CREATE TABLE [dbo].[homes] (
    [picture] varchar(250)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'plans'
ALTER TABLE [dbo].[plans]
ADD CONSTRAINT [PK_plans]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'teams'
ALTER TABLE [dbo].[teams]
ADD CONSTRAINT [PK_teams]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [picture] in table 'homes'
ALTER TABLE [dbo].[homes]
ADD CONSTRAINT [PK_homes]
    PRIMARY KEY CLUSTERED ([picture] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------