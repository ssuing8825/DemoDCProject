CREATE TABLE [dbo].[Token] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
	[BillingAccountId] INT  NOT NULL,
    [Pec] VARCHAR (50) NOT NULL,
	 [TokenNumber] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BillingAccountId]
    ON [dbo].[Token]([BillingAccountId] ASC);
