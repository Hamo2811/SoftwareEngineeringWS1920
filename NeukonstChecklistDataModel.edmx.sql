
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/07/2020 23:27:59
-- Generated from EDMX file: C:\Users\I2CM Developer\Google Drive\07012020_NeukonstChecklist_V2.1\NeukonstChecklistApp\NeukonstChecklistLibDb\NeukonstChecklistDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NekonstChecklistSql];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AuftragsknotenCheckpoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Checkpoints] DROP CONSTRAINT [FK_AuftragsknotenCheckpoint];
GO
IF OBJECT_ID(N'[dbo].[FK_UserKonstruiertAuftragsknoten]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Auftragsknotens] DROP CONSTRAINT [FK_UserKonstruiertAuftragsknoten];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auftragsknotens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auftragsknotens];
GO
IF OBJECT_ID(N'[dbo].[Checkpoints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Checkpoints];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Auftragsknotens'
CREATE TABLE [dbo].[Auftragsknotens] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KnotenID] nvarchar(max)  NOT NULL,
    [Sachnummer] int  NOT NULL,
    [Freigabe] bit  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Checkpoints'
CREATE TABLE [dbo].[Checkpoints] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [AuftragsknotenId] int  NOT NULL,
    [Erledigt] bit  NOT NULL,
    [Auftragsnummer] int  NOT NULL,
    [Baureihe] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Initialen] nvarchar(max)  NOT NULL,
    [Passwort] nvarchar(max)  NOT NULL,
    [Admin] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Auftragsknotens'
ALTER TABLE [dbo].[Auftragsknotens]
ADD CONSTRAINT [PK_Auftragsknotens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Checkpoints'
ALTER TABLE [dbo].[Checkpoints]
ADD CONSTRAINT [PK_Checkpoints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AuftragsknotenId] in table 'Checkpoints'
ALTER TABLE [dbo].[Checkpoints]
ADD CONSTRAINT [FK_AuftragsknotenCheckpoint]
    FOREIGN KEY ([AuftragsknotenId])
    REFERENCES [dbo].[Auftragsknotens]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuftragsknotenCheckpoint'
CREATE INDEX [IX_FK_AuftragsknotenCheckpoint]
ON [dbo].[Checkpoints]
    ([AuftragsknotenId]);
GO

-- Creating foreign key on [UserId] in table 'Auftragsknotens'
ALTER TABLE [dbo].[Auftragsknotens]
ADD CONSTRAINT [FK_UserKonstruiertAuftragsknoten]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserKonstruiertAuftragsknoten'
CREATE INDEX [IX_FK_UserKonstruiertAuftragsknoten]
ON [dbo].[Auftragsknotens]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------