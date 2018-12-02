SELECT 
    [Extent1].[Discriminator] AS [Discriminator], 
    [Extent1].[Id] AS [Id], 
    [Extent1].[Email] AS [Email], 
    [Extent1].[EmailConfirmed] AS [EmailConfirmed], 
    [Extent1].[PasswordHash] AS [PasswordHash], 
    [Extent1].[SecurityStamp] AS [SecurityStamp], 
    [Extent1].[PhoneNumber] AS [PhoneNumber], 
    [Extent1].[PhoneNumberConfirmed] AS [PhoneNumberConfirmed], 
    [Extent1].[TwoFactorEnabled] AS [TwoFactorEnabled], 
    [Extent1].[LockoutEndDateUtc] AS [LockoutEndDateUtc], 
    [Extent1].[LockoutEnabled] AS [LockoutEnabled], 
    [Extent1].[AccessFailedCount] AS [AccessFailedCount], 
    [Extent1].[UserName] AS [UserName]
    FROM [dbo].[AspNetUsers] AS [Extent1]
    WHERE [Extent1].[Discriminator] IN (N'MGOEmployee',N'MGOManager',N'Teacher',N'ApplicationUser')
