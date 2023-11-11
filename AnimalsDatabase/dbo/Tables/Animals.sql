Create Table [dbo].[Animals]
(
    [Id] INT Identity(1, 1) not null,
    [Name] nvarchar(255) not null,
    [Color] nvarchar(255) not null,
    [Age] int not null,
    [Extinct] bit not null
)


