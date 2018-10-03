
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/01/2018 16:54:32
-- Generated from EDMX file: D:\MySystem_admin\MySystem_admin\MySystem_admin\Models\MySystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MySystemDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VendorVendorTradeTerm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendor] DROP CONSTRAINT [FK_VendorVendorTradeTerm];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorVendorCertification]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendorCertification] DROP CONSTRAINT [FK_VendorVendorCertification];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorVendorMainProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendorMainProduct] DROP CONSTRAINT [FK_VendorVendorMainProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorVendorManufacture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendorManufacture] DROP CONSTRAINT [FK_VendorVendorManufacture];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorVendorMainCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendorMainCustomer] DROP CONSTRAINT [FK_VendorVendorMainCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorVendorContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendor] DROP CONSTRAINT [FK_VendorVendorContact];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Vendor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vendor];
GO
IF OBJECT_ID(N'[dbo].[VendorCertification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorCertification];
GO
IF OBJECT_ID(N'[dbo].[VendorContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorContact];
GO
IF OBJECT_ID(N'[dbo].[VendorMainCustomer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorMainCustomer];
GO
IF OBJECT_ID(N'[dbo].[VendorMainProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorMainProduct];
GO
IF OBJECT_ID(N'[dbo].[VendorManufacture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorManufacture];
GO
IF OBJECT_ID(N'[dbo].[VendorTradeTerm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendorTradeTerm];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleId] nvarchar(10)  NOT NULL,
    [System1] nvarchar(2)  NULL,
    [System2] nvarchar(2)  NULL,
    [System3] nvarchar(2)  NULL,
    [System4] nvarchar(2)  NULL,
    [System5] nvarchar(2)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserId] nvarchar(50)  NOT NULL,
    [GroupId] nvarchar(5)  NOT NULL,
    [FactoryId] nvarchar(5)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [UserName] nvarchar(20)  NULL,
    [RoleId] nvarchar(10)  NULL,
    [Email] nvarchar(150)  NULL
);
GO

-- Creating table 'Vendor'
CREATE TABLE [dbo].[Vendor] (
    [VendorId] nvarchar(20)  NOT NULL,
    [VendorName] nvarchar(50)  NULL,
    [Address] nvarchar(150)  NULL,
    [Establishment] datetime  NULL,
    [LawRepresentative] nvarchar(20)  NULL,
    [BusinessLicense] nvarchar(50)  NULL,
    [ExpirationDate] datetime  NULL,
    [Tariff] decimal(4,2)  NULL,
    [LY_Renvenue] decimal(19,4)  NULL,
    [Area1_Renvenue] decimal(19,4)  NULL,
    [Area2_Renvenue] decimal(19,4)  NULL,
    [Area3_Renvenue] decimal(19,4)  NULL,
    [SalesAmounts] decimal(19,4)  NULL,
    [ManagementType] nvarchar(50)  NULL,
    [ManagementCategory] nvarchar(50)  NULL,
    [Subsidiary] nvarchar(50)  NULL,
    [IsFTA] bit  NULL,
    [System] nvarchar(30)  NULL,
    [EmpHeadcount] int  NULL,
    [Flag] bit  NULL
);
GO

-- Creating table 'VendorCertification'
CREATE TABLE [dbo].[VendorCertification] (
    [VendorId] nvarchar(20)  NOT NULL,
    [Certificate] nchar(10)  NOT NULL,
    [CertificateName] nvarchar(30)  NULL,
    [Organization] nvarchar(50)  NULL,
    [CertificationDate] datetime  NULL,
    [VendorVendorId] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'VendorContact'
CREATE TABLE [dbo].[VendorContact] (
    [VendorId] nvarchar(20)  NOT NULL,
    [Contact] nvarchar(20)  NOT NULL,
    [ContactEmail] nvarchar(150)  NULL,
    [ContactTel] nvarchar(30)  NULL
);
GO

-- Creating table 'VendorMainCustomer'
CREATE TABLE [dbo].[VendorMainCustomer] (
    [VendorId] nvarchar(20)  NOT NULL,
    [CustomerName] nvarchar(50)  NOT NULL,
    [CustomerProductName] nvarchar(50)  NULL,
    [VendorVendorId] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'VendorMainProduct'
CREATE TABLE [dbo].[VendorMainProduct] (
    [VendorId] nvarchar(20)  NOT NULL,
    [ProductId] nvarchar(20)  NOT NULL,
    [MainProduct] nvarchar(50)  NULL,
    [MainCustomer] nvarchar(20)  NULL,
    [ProductRemark] nvarchar(100)  NULL,
    [VendorVendorId] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'VendorManufacture'
CREATE TABLE [dbo].[VendorManufacture] (
    [VendorId] nvarchar(20)  NOT NULL,
    [ManufactureId] nvarchar(10)  NOT NULL,
    [ManufactureCountry] nvarchar(20)  NULL,
    [ManufactureFactory] nvarchar(20)  NULL,
    [MonthlyYield] int  NULL,
    [FactoryArea] int  NULL,
    [VendorVendorId] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'VendorTradeTerm'
CREATE TABLE [dbo].[VendorTradeTerm] (
    [VendorId] nvarchar(20)  NOT NULL,
    [OADate] int  NULL,
    [IsDiscount] bit  NULL,
    [Currency] nchar(8)  NULL,
    [PayingMethod] nvarchar(30)  NULL,
    [IsContract] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RoleId] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId], [GroupId], [FactoryId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserId], [GroupId], [FactoryId] ASC);
GO

-- Creating primary key on [VendorId] in table 'Vendor'
ALTER TABLE [dbo].[Vendor]
ADD CONSTRAINT [PK_Vendor]
    PRIMARY KEY CLUSTERED ([VendorId] ASC);
GO

-- Creating primary key on [VendorId] in table 'VendorCertification'
ALTER TABLE [dbo].[VendorCertification]
ADD CONSTRAINT [PK_VendorCertification]
    PRIMARY KEY CLUSTERED ([VendorId] ASC);
GO

-- Creating primary key on [VendorId], [Contact] in table 'VendorContact'
ALTER TABLE [dbo].[VendorContact]
ADD CONSTRAINT [PK_VendorContact]
    PRIMARY KEY CLUSTERED ([VendorId], [Contact] ASC);
GO

-- Creating primary key on [VendorId], [CustomerName] in table 'VendorMainCustomer'
ALTER TABLE [dbo].[VendorMainCustomer]
ADD CONSTRAINT [PK_VendorMainCustomer]
    PRIMARY KEY CLUSTERED ([VendorId], [CustomerName] ASC);
GO

-- Creating primary key on [VendorId], [ProductId] in table 'VendorMainProduct'
ALTER TABLE [dbo].[VendorMainProduct]
ADD CONSTRAINT [PK_VendorMainProduct]
    PRIMARY KEY CLUSTERED ([VendorId], [ProductId] ASC);
GO

-- Creating primary key on [VendorId], [ManufactureId] in table 'VendorManufacture'
ALTER TABLE [dbo].[VendorManufacture]
ADD CONSTRAINT [PK_VendorManufacture]
    PRIMARY KEY CLUSTERED ([VendorId], [ManufactureId] ASC);
GO

-- Creating primary key on [VendorId] in table 'VendorTradeTerm'
ALTER TABLE [dbo].[VendorTradeTerm]
ADD CONSTRAINT [PK_VendorTradeTerm]
    PRIMARY KEY CLUSTERED ([VendorId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------