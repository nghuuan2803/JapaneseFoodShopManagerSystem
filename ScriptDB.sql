use master
      CREATE DATABASE [JFSDB];
      go
      use JFSDB
          CREATE TABLE [__EFMigrationsHistory] (
              [MigrationId] nvarchar(150) NOT NULL,
              [ProductVersion] nvarchar(32) NOT NULL,
              CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
          );


      CREATE TABLE [Categories] (
          [Id] varchar(15) NOT NULL,
          [Name] nvarchar(30) NOT NULL,
          [Photo] nvarchar(max) NULL,
          [ParentId] varchar(15) NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Categories_Categories_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Categories] ([Id])
      );

      CREATE TABLE [Combos] (
          [Id] uniqueidentifier NOT NULL,
          [Name] nvarchar(100) NOT NULL,
          [Description] nvarchar(max) NULL,
          [Price] float NOT NULL,
          [StartDate] datetimeoffset NOT NULL,
          [EndDate] datetimeoffset NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Combos] PRIMARY KEY ([Id])
      );

      CREATE TABLE [Features] (
          [Id] varchar(15) NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Features] PRIMARY KEY ([Id])
      );

      CREATE TABLE [Promotions] (
          [Id] uniqueidentifier NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [Description] nvarchar(max) NULL,
          [StartDate] datetimeoffset NOT NULL,
          [EndDate] datetimeoffset NOT NULL,
          [CustomerLevelRequired] nvarchar(15) NOT NULL,
          [Banner] nvarchar(max) NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Promotions] PRIMARY KEY ([Id])
      );

      CREATE TABLE [Roles] (
          [Id] varchar(15) NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
      );

      CREATE TABLE [Setting] (
          [CloseOrder] bit NOT NULL,
          [OrderRequireLogin] bit NOT NULL
      );

      CREATE TABLE [Products] (
          [Id] varchar(15) NOT NULL,
          [Name] nvarchar(30) NOT NULL,
          [Description] nvarchar(max) NULL,
          [Price] float NOT NULL,
          [Quantity] int NOT NULL,
          [Expire] int NOT NULL,
          [UnitType] nvarchar(max) NOT NULL,
          [Photos] nvarchar(max) NULL,
          [IsHot] bit NOT NULL,
          [Discontinued] bit NOT NULL,
          [IsNew] bit NOT NULL,
          [IsDeleted] bit NOT NULL,
          [CategoryId] varchar(15) NULL,
          [LikeCount] int NOT NULL,
          [Rating] float NOT NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE SET NULL
      );

      CREATE TABLE [Permissions] (
          [Id] varchar(15) NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [ActionType] int NOT NULL,
          [FeatureId] varchar(15) NOT NULL,
          CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Permissions_Features_FeatureId] FOREIGN KEY ([FeatureId]) REFERENCES [Features] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [Users] (
          [Id] uniqueidentifier NOT NULL,
          [UserName] nvarchar(max) NOT NULL,
          [Password] nvarchar(max) NOT NULL,
          [LoginFailedAttempt] int NOT NULL,
          [LockedEnd] datetimeoffset NULL,
          [ConfirmAccount] bit NOT NULL,
          [RoleId] varchar(15) NOT NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [ProductCombos] (
          [ProductId] varchar(15) NOT NULL,
          [ComboId] uniqueidentifier NOT NULL,
          [Quantity] int NOT NULL,
          CONSTRAINT [PK_ProductCombos] PRIMARY KEY ([ComboId], [ProductId]),
          CONSTRAINT [FK_ProductCombos_Combos_ComboId] FOREIGN KEY ([ComboId]) REFERENCES [Combos] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_ProductCombos_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [ProductPromotions] (
          [Id] uniqueidentifier NOT NULL,
          [ProductId] varchar(15) NOT NULL,
          [PromotionId] uniqueidentifier NOT NULL,
          [DiscountType] int NOT NULL,
          [Value] float NOT NULL,
          [RequiredQuantity] int NOT NULL,
          [GiftId] varchar(15) NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_ProductPromotions] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_ProductPromotions_Products_GiftId] FOREIGN KEY ([GiftId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_ProductPromotions_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_ProductPromotions_Promotions_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [Promotions] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [RolePermissions] (
          [RoleId] varchar(15) NOT NULL,
          [PermissionId] varchar(15) NOT NULL,
          CONSTRAINT [PK_RolePermissions] PRIMARY KEY ([PermissionId], [RoleId]),
          CONSTRAINT [FK_RolePermissions_Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Permissions] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_RolePermissions_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [Customers] (
          [Id] varchar(32) NOT NULL,
          [Name] nvarchar(30) NOT NULL,
          [Gender] nvarchar(max) NOT NULL,
          [Address] nvarchar(150) NOT NULL,
          [Email] nvarchar(30) NULL,
          [PhoneNumber] nvarchar(15) NULL,
          [Level] nvarchar(30) NOT NULL,
          [CurrentPoint] int NOT NULL,
          [CumulativePoint] int NOT NULL,
          [UserId] uniqueidentifier NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Customers] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Customers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [FeedBacks] (
          [Id] uniqueidentifier NOT NULL,
          [UserId] uniqueidentifier NOT NULL,
          [ProductId] varchar(15) NOT NULL,
          [Content] nvarchar(max) NOT NULL,
          [Rate] int NOT NULL,
          [IsHide] bit NOT NULL,
          [LikeCount] int NOT NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_FeedBacks] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_FeedBacks_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_FeedBacks_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [FavoriteProducts] (
          [ProductId] varchar(15) NOT NULL,
          [CustomerId] varchar(32) NOT NULL,
          CONSTRAINT [PK_FavoriteProducts] PRIMARY KEY ([ProductId], [CustomerId]),
          CONSTRAINT [FK_FavoriteProducts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_FavoriteProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [Vouchers] (
          [Id] uniqueidentifier NOT NULL,
          [CustomerId] varchar(32) NULL,
          [DiscountType] int NOT NULL,
          [StartDate] datetimeoffset NOT NULL,
          [EndDate] datetimeoffset NULL,
          [Applied] bit NOT NULL,
          CONSTRAINT [PK_Vouchers] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Vouchers_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
      );

      CREATE TABLE [Employees] (
          [Id] nvarchar(450) NOT NULL,
          [Name] nvarchar(30) NOT NULL,
          [Gender] nvarchar(5) NOT NULL,
          [BirthDate] datetime2 NOT NULL,
          [StartDate] datetime2 NOT NULL,
          [EndDate] datetime2 NULL,
          [Address] nvarchar(150) NOT NULL,
          [StoreId] varchar(15) NULL,
          [UserId] uniqueidentifier NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Employees_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [Orders] (
          [Id] uniqueidentifier NOT NULL,
          [CustomerId] varchar(32) NULL,
          [HandlerId] nvarchar(450) NULL,
          [OrderCode] bigint NOT NULL,
          [Amount] float NOT NULL,
          [Final] float NOT NULL,
          [Status] nvarchar(max) NOT NULL,
          [VoucherId] uniqueidentifier NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]),
          CONSTRAINT [FK_Orders_Employees_HandlerId] FOREIGN KEY ([HandlerId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_Orders_Vouchers_VoucherId] FOREIGN KEY ([VoucherId]) REFERENCES [Vouchers] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [ReplyFeedBacks] (
          [Id] uniqueidentifier NOT NULL,
          [ReplierId] nvarchar(450) NOT NULL,
          [FeedBackId] uniqueidentifier NOT NULL,
          [Content] nvarchar(max) NOT NULL,
          [IsHide] bit NOT NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_ReplyFeedBacks] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_ReplyFeedBacks_Employees_ReplierId] FOREIGN KEY ([ReplierId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_ReplyFeedBacks_FeedBacks_FeedBackId] FOREIGN KEY ([FeedBackId]) REFERENCES [FeedBacks] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [Stores] (
          [Id] varchar(15) NOT NULL,
          [Name] nvarchar(30) NOT NULL,
          [Email] nvarchar(30) NOT NULL,
          [PhoneNumber] nvarchar(15) NOT NULL,
          [FbPage] nvarchar(30) NULL,
          [Address] nvarchar(150) NOT NULL,
          [Profit] float NOT NULL,
          [ManagerId] nvarchar(450) NULL,
          [CreatedAt] datetimeoffset NOT NULL,
          [CreatedBy] nvarchar(max) NOT NULL,
          [UpdatedAt] datetimeoffset NULL,
          [UpdatedBy] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Stores] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Stores_Employees_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Employees] ([Id]) ON DELETE SET NULL
      );

      CREATE TABLE [OrderCombos] (
          [OrderId] uniqueidentifier NOT NULL,
          [ComboId] uniqueidentifier NOT NULL,
          [Quantity] int NOT NULL,
          CONSTRAINT [PK_OrderCombos] PRIMARY KEY ([OrderId], [ComboId]),
          CONSTRAINT [FK_OrderCombos_Combos_ComboId] FOREIGN KEY ([ComboId]) REFERENCES [Combos] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_OrderCombos_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
      );

      CREATE TABLE [OrderProducts] (
          [OrderId] uniqueidentifier NOT NULL,
          [ProductId] varchar(15) NOT NULL,
          [Quantity] int NOT NULL,
          [Price] float NOT NULL,
          [ProductPromotionId] uniqueidentifier NULL,
          CONSTRAINT [PK_OrderProducts] PRIMARY KEY ([OrderId], [ProductId]),
          CONSTRAINT [FK_OrderProducts_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_OrderProducts_ProductPromotions_ProductPromotionId] FOREIGN KEY ([ProductPromotionId]) REFERENCES [ProductPromotions] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_OrderProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
      );

      CREATE INDEX [IX_Categories_ParentId] ON [Categories] ([ParentId]);

      CREATE UNIQUE INDEX [IX_Customers_UserId] ON [Customers] ([UserId]) WHERE [UserId] IS NOT NULL;

      CREATE INDEX [IX_Employees_StoreId] ON [Employees] ([StoreId]);

      CREATE UNIQUE INDEX [IX_Employees_UserId] ON [Employees] ([UserId]) WHERE [UserId] IS NOT NULL;

      CREATE INDEX [IX_FavoriteProducts_CustomerId] ON [FavoriteProducts] ([CustomerId]);

      CREATE INDEX [IX_FeedBacks_ProductId] ON [FeedBacks] ([ProductId]);

      CREATE INDEX [IX_FeedBacks_UserId] ON [FeedBacks] ([UserId]);

      CREATE INDEX [IX_OrderCombos_ComboId] ON [OrderCombos] ([ComboId]);

      CREATE INDEX [IX_OrderProducts_ProductId] ON [OrderProducts] ([ProductId]);

      CREATE INDEX [IX_OrderProducts_ProductPromotionId] ON [OrderProducts] ([ProductPromotionId]);

      CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);

      CREATE INDEX [IX_Orders_HandlerId] ON [Orders] ([HandlerId]);

      CREATE UNIQUE INDEX [IX_Orders_VoucherId] ON [Orders] ([VoucherId]) WHERE [VoucherId] IS NOT NULL;

      CREATE INDEX [IX_Permissions_FeatureId] ON [Permissions] ([FeatureId]);

      CREATE INDEX [IX_ProductCombos_ProductId] ON [ProductCombos] ([ProductId]);
      
      CREATE INDEX [IX_ProductPromotions_GiftId] ON [ProductPromotions] ([GiftId]);

      CREATE INDEX [IX_ProductPromotions_ProductId] ON [ProductPromotions] ([ProductId]);

      CREATE INDEX [IX_ProductPromotions_PromotionId] ON [ProductPromotions] ([PromotionId]);

      CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);

      CREATE INDEX [IX_ReplyFeedBacks_FeedBackId] ON [ReplyFeedBacks] ([FeedBackId]);

      CREATE INDEX [IX_ReplyFeedBacks_ReplierId] ON [ReplyFeedBacks] ([ReplierId]);

      CREATE INDEX [IX_RolePermissions_RoleId] ON [RolePermissions] ([RoleId]);

      CREATE UNIQUE INDEX [IX_Stores_ManagerId] ON [Stores] ([ManagerId]) WHERE [ManagerId] IS NOT NULL;

      CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);

      CREATE INDEX [IX_Vouchers_CustomerId] ON [Vouchers] ([CustomerId]);

      ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_Stores_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Stores] ([Id]) ON DELETE SET NULL;

      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20241210054440_init', N'9.0.0');
