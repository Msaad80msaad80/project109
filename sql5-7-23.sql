/*
Navicat SQL Server Data Transfer

Source Server         : ktb
Source Server Version : 120000
Source Host           : sql5070.site4now.net:1433
Source Database       : db_a99a9e_g109se23
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2023-07-05 15:37:35
*/


-- ----------------------------
-- Table structure for authors
-- ----------------------------
DROP TABLE [authors]
GO
CREATE TABLE [authors] (
[Id] int NOT NULL IDENTITY(1,1) ,
[author_name] nvarchar(500) NULL 
)


GO
DBCC CHECKIDENT(N'[authors]', RESEED, 9)
GO

-- ----------------------------
-- Records of authors
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [authors] ON
GO
INSERT INTO [authors] ([Id], [author_name]) VALUES (N'1', N'احمد شوقي'), (N'2', N'عبد الحميد جودة السحار'), (N'3', N'Steaph Jubs'), (N'4', N'Alexandar Domas'), (N'5', N'د. طارق علي'), (N'6', N'د. عاطف  رسلان'), (N'7', N'د. اشرف عبد المنعم'), (N'8', N'د. عبير مسعد'), (N'9', N'كامل الكيلاني')
GO
GO
SET IDENTITY_INSERT [authors] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for books
-- ----------------------------
DROP TABLE [books]
GO
CREATE TABLE [books] (
[Id] int NOT NULL IDENTITY(1,1) ,
[book_Title] nvarchar(2000) NULL ,
[price] decimal(18) NULL ,
[author_id] int NULL ,
[sold_by] int NULL ,
[publisher_id] int NULL ,
[publishing_year] int NULL ,
[stock] varchar(1) NULL ,
[book_cover] nvarchar(2000) NULL ,
[book_softcopy] nvarchar(2000) NULL ,
[date_insert] datetime NULL ,
[last_update] datetime NULL ,
[active] bit NULL ,
[book_language] nvarchar(50) NULL ,
[book_cat] int NULL 
)


GO
DBCC CHECKIDENT(N'[books]', RESEED, 42)
GO

-- ----------------------------
-- Records of books
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [books] ON
GO
INSERT INTO [books] ([Id], [book_Title], [price], [author_id], [sold_by], [publisher_id], [publishing_year], [stock], [book_cover], [book_softcopy], [date_insert], [last_update], [active], [book_language], [book_cat]) VALUES (N'13', N'Good life ', N'5500', N'4', N'14', N'2', N'2000', N'1', N'project109_good-life.jpg', null, N'2023-05-26 04:54:28.370', N'2023-05-26 04:54:28.370', N'1', N'Arabic', N'2'), (N'14', N'Graph Theory', N'17', N'3', N'14', N'3', N'2011', N'1', null, null, N'2023-05-26 05:05:21.947', N'2023-05-26 05:05:21.947', N'1', N'English', N'4'), (N'15', N'تطوير المشروعات البرمجية فى ضوء المتغيرات الحديثة و الزكاء الاصطناعي', N'1500', N'5', N'14', N'2', N'2022', N'1', N'project109_dwdw.png', null, N'2023-05-26 05:05:59.510', N'2023-05-26 05:05:59.510', N'1', N'English', N'3'), (N'16', N'AI Modern', N'21', N'4', N'14', N'3', N'2019', N'1', null, null, N'2023-05-26 05:07:33.570', N'2023-05-26 05:07:33.570', N'1', N'English', N'4'), (N'17', N'Similarity & Distance', N'13', N'4', N'14', N'3', N'2017', N'1', null, null, N'2023-05-26 05:13:08.340', N'2023-05-26 05:13:08.340', N'1', N'English', N'4'), (N'21', N'المخ السعيد', N'260', N'4', N'18', N'2', N'2021', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٠٢١٠٦.jpg', null, N'2023-05-26 11:49:20.347', N'2023-05-26 11:49:20.347', N'1', N'Arabic', N'4'), (N'23', N'قد جعلها ربي حقًا', N'180', N'1', N'18', N'1', N'2021', N'1', N'project109_٢٠٢٣٠٥٢٦_٢١٥٧٣٦.jpg', null, N'2023-05-26 11:59:36.560', N'2023-05-26 11:59:36.560', N'1', N'Arabic', N'1'), (N'24', N'كُن لنفسك كل شيء', N'150', N'1', N'18', N'1', N'2017', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢٠٠٥٩.jpg', null, N'2023-05-26 12:02:41.700', N'2023-05-26 12:02:41.700', N'1', N'Arabic', N'4'), (N'25', N'فاتتني صلاة', N'170', N'2', N'18', N'1', N'2019', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢٠٤٢٩.jpg', null, N'2023-05-26 12:06:05.800', N'2023-05-26 12:06:05.800', N'1', N'Arabic', N'1'), (N'26', N'كيف أنظّم حياتي', N'150', N'4', N'18', N'2', N'2020', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢٠٧٠٤.jpg', null, N'2023-05-26 12:08:37.870', N'2023-05-26 12:08:37.870', N'1', N'Arabic', N'4'), (N'27', N'حديث السعادة', N'120', N'2', N'18', N'1', N'2020', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢١٦٠٠.jpg', null, N'2023-05-26 12:17:50.740', N'2023-05-26 12:17:50.740', N'1', N'Arabic', N'4'), (N'28', N'" المخ الأبله "', N'100', N'1', N'18', N'2', N'2018', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢١٨١٠.jpg', null, N'2023-05-26 12:19:40.387', N'2023-05-26 12:19:40.387', N'1', N'Arabic', N'4'), (N'29', N'علم الشّخصيّات', N'70', N'1', N'18', N'2', N'2021', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢٢١٣٣.jpg', null, N'2023-05-26 12:22:50.900', N'2023-05-26 12:22:50.900', N'1', N'Arabic', N'4'), (N'30', N' 30 يومًا', N'120', N'1', N'18', N'2', N'2022', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢٢٣١٨.jpg', null, N'2023-05-26 12:24:21.330', N'2023-05-26 12:24:21.330', N'1', N'Arabic', N'4'), (N'31', N'ولتطمئن قلوبكم', N'180', N'1', N'18', N'2', N'2021', N'1', N'project109_٢٠٢٣٠٥٢٦_٢٢٢٨٥٠.jpg', null, N'2023-05-26 12:30:08.187', N'2023-05-26 12:30:08.187', N'1', N'Arabic', N'1'), (N'32', N'الحياة المثالية', N'400', N'2', N'14', N'3', N'2000', N'1', null, null, N'2023-05-27 17:26:46.490', N'2023-05-27 17:26:47.527', N'1', N'Arabic', N'1'), (N'33', N'تاريخ ادارة المشروعات البرمجية', N'1200', N'5', N'14', N'2', N'2009', N'1', N'project109_cvr1.jpg', N'project109docs_ProjectSkills_L1.pdf', N'2023-06-26 02:12:00.530', N'2023-06-26 02:15:10.100', N'1', N'Arabic', N'3'), (N'34', N'الثورة العلمية', N'150', N'1', N'20', N'2', N'2021', N'1', null, null, N'2023-07-02 04:03:28.577', N'2023-07-02 04:03:28.577', N'1', N'Arabic', N'4'), (N'35', N'الثورة العلمية', N'150', N'1', N'20', N'2', N'2021', N'1', null, null, N'2023-07-02 04:03:52.640', N'2023-07-02 04:03:52.640', N'1', N'Arabic', N'4'), (N'36', N'رحلة الي معرفة الله', N'120', N'2', N'20', N'4', N'2020', N'1', null, null, N'2023-07-02 04:14:07.443', N'2023-07-02 04:14:07.443', N'1', N'Arabic', N'1'), (N'37', N'صدي السنين ', N'100', N'2', N'16', N'6', N'1997', N'1', null, N'project109docs_صدى السنين_27601_Foulabook.com_.pdf', N'2023-07-02 05:05:16.290', N'2023-07-02 05:05:16.290', N'1', N'Arabic', N'4'), (N'38', N'العرب في اوروبا ', N'100', N'2', N'16', N'6', N'1999', N'1', null, N'project109docs_العرب في أوروبا_88327_Foulabook.com_.pdf', N'2023-07-02 05:07:55.493', N'2023-07-02 05:07:55.493', N'1', N'Arabic', N'1'), (N'39', N'ليلة عاصفة ', N'50', N'2', N'16', N'6', N'1995', N'1', null, N'project109docs_ليلة عاصفة_93998_Foulabook.com_.pdf', N'2023-07-02 05:10:56.937', N'2023-07-02 05:10:56.937', N'1', N'Arabic', N'4'), (N'40', N'Something Wrong In Japan', N'30', N'5', N'21', N'5', N'2023', N'1', N'project109_415XT-3oBhL._SX332_BO1,204,203,200_.jpg', N'project109docs_SomethingWrongJapan.pdf', N'2023-07-02 05:20:01.797', N'2023-07-02 05:23:19.833', N'1', N'English', N'4'), (N'41', N'Race And Racism In France', N'50', N'5', N'21', N'3', N'2023', N'1', N'project109_Nael.jpg', N'project109docs_Race_and_racism_in_France.pdf', N'2023-07-02 05:38:06.793', N'2023-07-02 05:38:06.793', N'1', N'English', N'4'), (N'42', N'رواية ويطمئن قلبي', N'100', N'1', N'19', N'1', N'5', N'1', null, N'project109docs_مكتبة كتوباتي - ليطمئن قلبي.pdf', N'2023-07-03 03:19:59.430', N'2023-07-03 03:19:59.430', N'1', N'Arabic', N'1')
GO
GO
SET IDENTITY_INSERT [books] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for books_categories
-- ----------------------------
DROP TABLE [books_categories]
GO
CREATE TABLE [books_categories] (
[Id] int NOT NULL IDENTITY(1,1) ,
[cat_name] nvarchar(500) NULL 
)


GO
DBCC CHECKIDENT(N'[books_categories]', RESEED, 4)
GO

-- ----------------------------
-- Records of books_categories
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [books_categories] ON
GO
INSERT INTO [books_categories] ([Id], [cat_name]) VALUES (N'1', N'كتب دينية'), (N'2', N'كتب رياضية'), (N'3', N'كتب تقنية'), (N'4', N'كتب علمية')
GO
GO
SET IDENTITY_INSERT [books_categories] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE [orders]
GO
CREATE TABLE [orders] (
[Id] int NOT NULL IDENTITY(1,1) ,
[order_date] datetime NULL ,
[buyer_id] int NULL ,
[vendor_id] int NULL ,
[book_id] int NULL ,
[qty] int NULL ,
[done_sel] bit NULL ,
[deal_date] datetime NULL ,
[canceled] bit NULL 
)


GO
DBCC CHECKIDENT(N'[orders]', RESEED, 13)
GO

-- ----------------------------
-- Records of orders
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [orders] ON
GO
INSERT INTO [orders] ([Id], [order_date], [buyer_id], [vendor_id], [book_id], [qty], [done_sel], [deal_date], [canceled]) VALUES (N'1', N'2023-06-26 02:17:13.713', N'14', N'18', N'31', N'1', N'0', null, N'0'), (N'2', N'2023-06-26 02:18:06.937', N'14', N'18', N'30', N'1', N'0', null, N'0'), (N'3', N'2023-06-26 13:31:26.617', N'14', N'18', N'31', N'1', N'0', null, N'0'), (N'4', N'2023-07-02 03:53:58.257', N'20', N'18', N'23', N'1', N'0', null, N'0'), (N'5', N'2023-07-02 03:54:11.700', N'20', N'18', N'24', N'1', N'0', null, N'0'), (N'6', N'2023-07-02 03:54:25.930', N'20', N'14', N'15', N'1', N'1', N'2023-07-02 06:29:13.927', N'0'), (N'7', N'2023-07-02 03:54:38.133', N'20', N'14', N'13', N'1', N'0', N'2023-07-02 06:29:03.580', N'1'), (N'8', N'2023-07-02 04:22:39.777', N'16', N'18', N'26', N'1', N'0', null, N'0'), (N'9', N'2023-07-02 04:23:50.340', N'16', N'14', N'33', N'1', N'1', N'2023-07-02 06:28:25.580', N'0'), (N'10', N'2023-07-02 06:32:18.210', N'14', N'20', N'34', N'1', N'0', null, N'0'), (N'11', N'2023-07-02 06:35:32.320', N'14', N'21', N'40', N'1', N'0', null, N'0'), (N'12', N'2023-07-02 06:35:47.700', N'14', N'16', N'38', N'1', N'1', N'2023-07-02 06:39:29.640', N'0'), (N'13', N'2023-07-02 06:36:26.303', N'14', N'16', N'37', N'1', N'1', N'2023-07-02 06:39:36.630', N'0')
GO
GO
SET IDENTITY_INSERT [orders] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for publishers
-- ----------------------------
DROP TABLE [publishers]
GO
CREATE TABLE [publishers] (
[Id] int NOT NULL IDENTITY(1,1) ,
[publisher_name] nvarchar(1000) NULL 
)


GO
DBCC CHECKIDENT(N'[publishers]', RESEED, 6)
GO

-- ----------------------------
-- Records of publishers
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [publishers] ON
GO
INSERT INTO [publishers] ([Id], [publisher_name]) VALUES (N'1', N'دار الهلال'), (N'2', N'المؤسسة العربية الحديثة'), (N'3', N'long man'), (N'4', N'دار الازهر الشريف'), (N'5', N'Sams'), (N'6', N'نهضة مصر')
GO
GO
SET IDENTITY_INSERT [publishers] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for users_types
-- ----------------------------
DROP TABLE [users_types]
GO
CREATE TABLE [users_types] (
[Id] int NOT NULL IDENTITY(1,1) ,
[type_name] nvarchar(100) NULL 
)


GO

-- ----------------------------
-- Records of users_types
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [users_types] ON
GO
SET IDENTITY_INSERT [users_types] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for UsersAdmins
-- ----------------------------
DROP TABLE [UsersAdmins]
GO
CREATE TABLE [UsersAdmins] (
[Id] bigint NOT NULL IDENTITY(1,1) ,
[RealName] nvarchar(1000) NULL ,
[Title] nvarchar(1000) NULL ,
[Email] nvarchar(1000) NULL ,
[Username] nvarchar(1000) NULL ,
[Password] nvarchar(1000) NULL ,
[IsAdmin] bit NULL ,
[Active] bit NULL ,
[Phone] nvarchar(500) NULL ,
[Address] nvarchar(1000) NULL ,
[UserType] int NULL ,
[date_insert] datetime NULL ,
[last_update] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[UsersAdmins]', RESEED, 22)
GO

-- ----------------------------
-- Records of UsersAdmins
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [UsersAdmins] ON
GO
INSERT INTO [UsersAdmins] ([Id], [RealName], [Title], [Email], [Username], [Password], [IsAdmin], [Active], [Phone], [Address], [UserType], [date_insert], [last_update]) VALUES (N'1', N'Mohamed Saad', N'Dev', N'msaad@amcham.org.eg', N'msaad', N'q9whvHWWlzY8NX1Yb2IeEa33d5iKiYmx6X0xPsYIpgQ=', N'1', N'1', null, null, null, null, null), (N'2', N'Admin', N'Dev', N'event1@amcham.org.eg', N'admin', N'pdrEaavYrMG6rhsygYErxw==', N'1', N'1', N'666666', N'88888', null, null, N'2023-01-01 00:00:00.000'), (N'10', null, null, null, null, null, null, null, null, null, null, null, null), (N'11', N'gsgsfgfs', N'ewrewrrwe', N'dsfdsfs@fds.ff', N'rrrr', N'33333', N'0', N'1', N'34243', N'dfsfsd', null, N'2023-01-01 00:00:00.000', N'2023-01-01 00:00:00.000'), (N'12', N'abdo abdo', N'leader', N'fsd@fsfds.gg', N'abdo', N'adoooo', N'0', N'1', N'434234', N'dasasd', null, N'2023-01-01 00:00:00.000', N'2023-01-01 00:00:00.000'), (N'13', N'ms ma', N'wrwe', N'dsfdsfs@fds.ff', N'ms', N'pdrEaavYrMG6rhsygYErxw==', N'0', N'1', N'434324', N'sfdfdsf', null, N'2023-01-01 00:00:00.000', N'2023-01-01 00:00:00.000'), (N'14', N'Mohamed Saad', N'Developer', N'msaad80@gmail.com', N'msadmin', N'KnwIZwbriI/AAvr1dzQ+lgITfgejuNFMyzvHxghcciA=', N'0', N'1', N'01001234434343', N'Cairo', N'2', N'2023-05-26 04:48:35.353', N'2023-05-26 04:48:35.353'), (N'15', N'Mohamed Gioushy', N'Mr.', N'mohamed@outlook.com', N'Mohamed', N'sUD6jnHpKZP1UthRzTHR7g==', N'0', N'1', N'0123456789', null, N'2', N'2023-05-26 05:02:08.387', N'2023-05-26 05:02:08.387'), (N'16', N'alaa ahmed', null, N'alaahmed675@gmail.com', N'alaa', N'PaxcZqZDoKJ0UvX3ZNfbgA==', N'0', N'1', N'012345678', N'giza', N'2', N'2023-05-26 05:07:03.730', N'2023-07-02 03:58:07.137'), (N'17', N'Asmaa Mohamed ', N'Cairo - Egypt', N'asmaamohamed@gmail.com', N'Asmaa mohmed', N'3cluRcgzuWIr1OIb6N9DiA==', N'0', N'1', N'123456789', N'Cairo - Egypt', N'2', N'2023-05-26 09:59:30.637', N'2023-05-26 09:59:30.637'), (N'18', N'Asmaa Mohamed ', N'Cairo -Egypt ', N'asmaamohamed@gmail.com', N'Asmaa Mohamed', N'mf6Ktyy+J2F3kIblg1a/BPDuh4TBE6ETDMvEk+ha3NM=', N'0', N'1', N'123456789', N'Cairo -Egypt ', N'2', N'2023-05-26 10:09:51.570', N'2023-05-26 10:09:51.570'), (N'19', N'Anwar', N'Cairo', N'anwar54@gmail.com', N'Anwar', N'dAQWIrbtHv/eDbu+4oJD0g==', N'0', N'1', N'01002255331', null, N'2', N'2023-06-01 10:27:26.610', N'2023-06-01 10:27:26.610'), (N'20', N'Osama', null, N'usamaana77@gmail.com', N'Usama metwaly', N'2JOr3bFMhG7KDKcSBUym9w==', N'0', N'1', N'01091181254', N'Mansoura', N'2', N'2023-07-02 03:51:22.160', N'2023-07-02 03:51:22.160'), (N'21', N'mostafa gamal ', N'mr', N'mostafa.gamal@gmail.com', N'mostafa', N'TYXXw/lIUMD7sTy/g9serw==', N'0', N'1', N'966534576392', N'Riyadh-KSA', N'2', N'2023-07-02 05:15:16.453', N'2023-07-02 05:15:16.453'), (N'22', N'anwar rargab ', N'giza', N'anwar@gmail.com', N'anwar', N'dAQWIrbtHv/eDbu+4oJD0g==', N'0', N'1', N'01112225846', N'giza', N'2', N'2023-07-03 02:45:00.900', N'2023-07-03 02:45:00.900')
GO
GO
SET IDENTITY_INSERT [UsersAdmins] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- View structure for view_books
-- ----------------------------
DROP VIEW [view_books]
GO
CREATE VIEW [view_books] AS 
SELECT
dbo.books.Id,
dbo.books.book_Title,
dbo.books.price,
dbo.books.author_id,
dbo.books.sold_by,
dbo.books.publisher_id,
dbo.books.publishing_year,
dbo.books.stock,
dbo.books.book_cover,
dbo.books.book_softcopy,
dbo.books.date_insert,
dbo.books.last_update,
dbo.books.active,
dbo.books.book_language,
dbo.authors.author_name,
dbo.UsersAdmins.RealName,
dbo.publishers.publisher_name,
dbo.books.book_cat,
dbo.books_categories.cat_name

FROM
dbo.books
LEFT OUTER JOIN dbo.authors ON dbo.books.author_id = dbo.authors.Id
LEFT OUTER JOIN dbo.publishers ON dbo.books.publisher_id = dbo.publishers.Id
LEFT OUTER JOIN dbo.UsersAdmins ON dbo.books.sold_by = dbo.UsersAdmins.Id
LEFT OUTER JOIN dbo.books_categories ON dbo.books.book_cat = dbo.books_categories.Id
GO

-- ----------------------------
-- View structure for view_orders
-- ----------------------------
DROP VIEW [view_orders]
GO
CREATE VIEW [view_orders] AS 
SELECT
dbo.orders.Id,
dbo.orders.order_date,
dbo.orders.buyer_id,
dbo.orders.vendor_id,
dbo.orders.book_id,
dbo.orders.qty,
dbo.orders.done_sel,
dbo.orders.deal_date,
dbo.orders.canceled,
useradminbuyer.RealName AS buyername,
dbo.books.book_Title,
dbo.books.price,
useradminvendor.RealName AS vendorname

FROM
dbo.orders
LEFT OUTER JOIN dbo.UsersAdmins AS useradminbuyer ON dbo.orders.buyer_id = useradminbuyer.Id
LEFT OUTER JOIN dbo.UsersAdmins AS useradminvendor ON dbo.orders.vendor_id = useradminvendor.Id  
LEFT OUTER JOIN dbo.books ON dbo.orders.book_id = dbo.books.Id
GO

-- ----------------------------
-- View structure for view_users
-- ----------------------------
DROP VIEW [view_users]
GO
CREATE VIEW [view_users] AS 
SELECT
dbo.UsersAdmins.Id,
dbo.UsersAdmins.RealName,
dbo.UsersAdmins.Title,
dbo.UsersAdmins.Email,
dbo.UsersAdmins.Username,
dbo.UsersAdmins.Password,
dbo.UsersAdmins.IsAdmin,
dbo.UsersAdmins.Active,
dbo.UsersAdmins.Phone,
dbo.UsersAdmins.Address,
dbo.UsersAdmins.UserType,
dbo.UsersAdmins.date_insert,
dbo.UsersAdmins.last_update,
dbo.users_types.type_name

FROM
dbo.UsersAdmins
LEFT OUTER JOIN dbo.users_types ON dbo.UsersAdmins.UserType = dbo.users_types.Id
GO

-- ----------------------------
-- Indexes structure for table authors
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table authors
-- ----------------------------
ALTER TABLE [authors] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table books
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table books
-- ----------------------------
ALTER TABLE [books] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table books_categories
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table books_categories
-- ----------------------------
ALTER TABLE [books_categories] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table orders
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table orders
-- ----------------------------
ALTER TABLE [orders] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table publishers
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table publishers
-- ----------------------------
ALTER TABLE [publishers] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table users_types
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table users_types
-- ----------------------------
ALTER TABLE [users_types] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table UsersAdmins
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table UsersAdmins
-- ----------------------------
ALTER TABLE [UsersAdmins] ADD PRIMARY KEY ([Id])
GO
