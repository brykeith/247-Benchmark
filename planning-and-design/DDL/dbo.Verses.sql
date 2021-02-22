USE [BibleVerses]
GO

/****** Object: Table [dbo].[Verses] Script Date: 2/21/2021 9:29:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Verses] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Testament]     NVARCHAR (50)  NULL,
    [Book]          NVARCHAR (50)  NULL,
    [ChapterNumber] INT            NULL,
    [VerseNumber]   INT            NULL,
    [VerseText]     NVARCHAR (MAX) NULL
);


