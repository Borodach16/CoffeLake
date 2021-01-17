
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2021 20:29:32
-- Generated from EDMX file: G:\Учеба\Web-программирование\MVC\CoffeLake\CoffeLake.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CoffeLake];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductCategorySet'
CREATE TABLE [dbo].[ProductCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Caption] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Caption] nvarchar(max)  NOT NULL,
    [Quantity] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [ProductCategoryId] int  NOT NULL
);
GO

-- Creating table 'MenuCategorySet'
CREATE TABLE [dbo].[MenuCategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Caption] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CoffeLakeMenuSet'
CREATE TABLE [dbo].[CoffeLakeMenuSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Caption] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [MenuCategoryId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductCategorySet'
ALTER TABLE [dbo].[ProductCategorySet]
ADD CONSTRAINT [PK_ProductCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MenuCategorySet'
ALTER TABLE [dbo].[MenuCategorySet]
ADD CONSTRAINT [PK_MenuCategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoffeLakeMenuSet'
ALTER TABLE [dbo].[CoffeLakeMenuSet]
ADD CONSTRAINT [PK_CoffeLakeMenuSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductCategoryId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_ProductCategoryProduct]
    FOREIGN KEY ([ProductCategoryId])
    REFERENCES [dbo].[ProductCategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategoryProduct'
CREATE INDEX [IX_FK_ProductCategoryProduct]
ON [dbo].[ProductSet]
    ([ProductCategoryId]);
GO

-- Creating foreign key on [MenuCategoryId] in table 'CoffeLakeMenuSet'
ALTER TABLE [dbo].[CoffeLakeMenuSet]
ADD CONSTRAINT [FK_MenuCategoryCoffeLakeMenu]
    FOREIGN KEY ([MenuCategoryId])
    REFERENCES [dbo].[MenuCategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuCategoryCoffeLakeMenu'
CREATE INDEX [IX_FK_MenuCategoryCoffeLakeMenu]
ON [dbo].[CoffeLakeMenuSet]
    ([MenuCategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------