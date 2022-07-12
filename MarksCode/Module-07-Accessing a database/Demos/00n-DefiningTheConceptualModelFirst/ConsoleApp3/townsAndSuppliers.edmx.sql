
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/11/2022 23:57:16
-- Generated from EDMX file: C:\Users\Admin\source\repos\ConsoleApp3\ConsoleApp3\townsAndSuppliers.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Towns];
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

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [ContactId] int IDENTITY(1,1) NOT NULL,
    [ContactName] nvarchar(max)  NOT NULL,
    [ContactAddress] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Towns'
CREATE TABLE [dbo].[Towns] (
    [TownId] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Contacts_Supplier'
CREATE TABLE [dbo].[Contacts_Supplier] (
    [BusinessNumber] nvarchar(max)  NOT NULL,
    [Capitlization] decimal(18,0)  NOT NULL,
    [ContactId] int  NOT NULL
);
GO

-- Creating table 'Contacts_Customer'
CREATE TABLE [dbo].[Contacts_Customer] (
    [FavouriteProduct] nvarchar(max)  NOT NULL,
    [ContactId] int  NOT NULL
);
GO

-- Creating table 'TownSupplier'
CREATE TABLE [dbo].[TownSupplier] (
    [Towns_TownId] int  NOT NULL,
    [Suppliers_ContactId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ContactId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([ContactId] ASC);
GO

-- Creating primary key on [TownId] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [PK_Towns]
    PRIMARY KEY CLUSTERED ([TownId] ASC);
GO

-- Creating primary key on [ContactId] in table 'Contacts_Supplier'
ALTER TABLE [dbo].[Contacts_Supplier]
ADD CONSTRAINT [PK_Contacts_Supplier]
    PRIMARY KEY CLUSTERED ([ContactId] ASC);
GO

-- Creating primary key on [ContactId] in table 'Contacts_Customer'
ALTER TABLE [dbo].[Contacts_Customer]
ADD CONSTRAINT [PK_Contacts_Customer]
    PRIMARY KEY CLUSTERED ([ContactId] ASC);
GO

-- Creating primary key on [Towns_TownId], [Suppliers_ContactId] in table 'TownSupplier'
ALTER TABLE [dbo].[TownSupplier]
ADD CONSTRAINT [PK_TownSupplier]
    PRIMARY KEY CLUSTERED ([Towns_TownId], [Suppliers_ContactId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Towns_TownId] in table 'TownSupplier'
ALTER TABLE [dbo].[TownSupplier]
ADD CONSTRAINT [FK_TownSupplier_Town]
    FOREIGN KEY ([Towns_TownId])
    REFERENCES [dbo].[Towns]
        ([TownId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Suppliers_ContactId] in table 'TownSupplier'
ALTER TABLE [dbo].[TownSupplier]
ADD CONSTRAINT [FK_TownSupplier_Supplier]
    FOREIGN KEY ([Suppliers_ContactId])
    REFERENCES [dbo].[Contacts_Supplier]
        ([ContactId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TownSupplier_Supplier'
CREATE INDEX [IX_FK_TownSupplier_Supplier]
ON [dbo].[TownSupplier]
    ([Suppliers_ContactId]);
GO

-- Creating foreign key on [ContactId] in table 'Contacts_Supplier'
ALTER TABLE [dbo].[Contacts_Supplier]
ADD CONSTRAINT [FK_Supplier_inherits_Contact]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([ContactId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ContactId] in table 'Contacts_Customer'
ALTER TABLE [dbo].[Contacts_Customer]
ADD CONSTRAINT [FK_Customer_inherits_Contact]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([ContactId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------