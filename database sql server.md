USE [master]
GO
/****** Object:  Database [DrivingTestDB]    Script Date: 12/17/2025 8:22:04 PM ******/
CREATE DATABASE [DrivingTestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrivingTestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DrivingTestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrivingTestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DrivingTestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DrivingTestDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrivingTestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrivingTestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrivingTestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrivingTestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrivingTestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrivingTestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrivingTestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrivingTestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrivingTestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrivingTestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrivingTestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrivingTestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrivingTestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrivingTestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrivingTestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrivingTestDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DrivingTestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrivingTestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrivingTestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrivingTestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrivingTestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrivingTestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrivingTestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrivingTestDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DrivingTestDB] SET  MULTI_USER 
GO
ALTER DATABASE [DrivingTestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrivingTestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrivingTestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrivingTestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrivingTestDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DrivingTestDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DrivingTestDB', N'ON'
GO
ALTER DATABASE [DrivingTestDB] SET QUERY_STORE = OFF
GO
USE [DrivingTestDB]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OptionKey] [char](1) NOT NULL,
	[OptionText] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[Status] [nvarchar](20) NULL,
	[Title] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[Category] [nvarchar](50) NULL,
	[CorrectAnswer] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCategories]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCategories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionCount] [int] NOT NULL,
	[DurationMinutes] [int] NOT NULL,
	[PassingScore] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestDetails]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestDetails](
	[TestDetailId] [int] IDENTITY(1,1) NOT NULL,
	[TestId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[SelectedAnswer] [char](1) NULL,
	[IsCorrect] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TestDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Score] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActivityLogs]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivityLogs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[Timestamp] [datetime] NULL,
	[Details] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/17/2025 8:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Role] [tinyint] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (1, 1, N'A', N'Tốc độ tối đa cho phép.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (2, 1, N'B', N'Hết hạn chế tốc độ tối đa')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (3, 1, N'C', N'Tốc độ tối thiểu.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (4, 1, N'D', N'Cấm dừng xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (5, 2, N'A', N'Dừng xe tạm thời để nhận khách')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (6, 2, N'B', N'Dừng xe lâu dài')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (7, 2, N'C', N'Đỗ xe qua đêm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (8, 2, N'D', N'Không được dừng xe trong mọi trường hợp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (9, 3, N'A', N'Trên cầu vượt')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (10, 3, N'B', N'Trên đường cong')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (11, 3, N'C', N'Trên đường thẳng có tầm nhìn tốt')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (12, 3, N'D', N'Gần ngã tư')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (13, 4, N'A', N'Biển báo cấm đi ngược chiều')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (14, 4, N'B', N'Biển báo chỉ dẫn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (15, 4, N'C', N'Biển báo cảnh báo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (16, 4, N'D', N'Biển báo hiệu lệnh')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (17, 5, N'A', N'Chỉ tuân thủ luật giao thông')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (18, 5, N'B', N'Chỉ tuân thủ biển báo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (19, 5, N'C', N'Chỉ tuân thủ tín hiệu đèn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (20, 5, N'D', N'Tuân thủ tất cả các quy tắc giao thông')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (21, 6, N'A', N'Xe từ bên phải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (22, 6, N'B', N'Xe cứu thương đang làm nhiệm vụ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (23, 6, N'C', N'Xe từ bên trái')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (24, 6, N'D', N'Xe đi thẳng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (25, 7, N'A', N'Biển báo cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (26, 7, N'B', N'Biển báo cảnh báo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (27, 7, N'C', N'Biển báo chỉ dẫn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (28, 7, N'D', N'Biển báo hiệu lệnh')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (29, 8, N'A', N'10 mét')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (30, 8, N'B', N'20 mét')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (31, 8, N'C', N'30 mét')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (32, 8, N'D', N'40 mét')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (33, 9, N'A', N'Đậu xe ở làn đường chính')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (34, 9, N'B', N'Đưa xe ra khỏi phần xe chạy, bật đèn cảnh báo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (35, 9, N'C', N'Gọi điện thoại ngay tại chỗ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (36, 9, N'D', N'Tiếp tục lái xe chậm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (37, 10, N'A', N'Cấm quay đầu xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (38, 10, N'B', N'Được quay đầu xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (39, 10, N'C', N'Bắt buộc quay đầu xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (40, 10, N'D', N'Cấm đi thẳng.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (41, 11, N'A', N'Được đi ngược chiều')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (42, 11, N'B', N'Được vượt đèn đỏ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (43, 11, N'C', N'Được đi vào đường cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (44, 11, N'D', N'Tất cả các trường hợp trên khi làm nhiệm vụ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (45, 12, N'A', N'A1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (46, 12, N'B', N'A2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (47, 12, N'C', N'B1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (48, 12, N'D', N'B2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (49, 13, N'A', N'Chỉ cần kéo phanh tay')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (50, 13, N'B', N'Chỉ cần để số')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (51, 13, N'C', N'Kéo phanh tay và để số phù hợp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (52, 13, N'D', N'Không cần làm gì')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (53, 14, N'A', N'Đường cong nguy hiểm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (54, 14, N'B', N'Đường giao nhau')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (55, 14, N'C', N'Đường hẹp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (56, 14, N'D', N'Đường dốc')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (57, 15, N'A', N'Từ vị trí đặt biển đến ngã tư tiếp theo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (58, 15, N'B', N'Từ vị trí đặt biển đến biển hết cấm hoặc ra khỏi khu vực cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (59, 15, N'C', N'Chỉ tại vị trí đặt biển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (60, 15, N'D', N'Toàn bộ tuyến đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (61, 16, N'A', N'Quan sát, giảm tốc độ và về số thấp, đi sát vào phía bên phải của mình')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (62, 16, N'B', N'Tăng tốc để nhanh chóng qua đường vòng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (63, 16, N'C', N'Đi ở giữa đường để có tầm nhìn tốt nhất')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (64, 16, N'D', N'Bật đèn pha để cảnh báo các xe khác')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (65, 17, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (66, 17, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (67, 17, N'C', N'Biển 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (68, 17, N'D', N'Không có biển nào')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (69, 18, N'A', N'Xe nào đi nhanh hơn thì được đi trước')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (70, 18, N'B', N'Ưu tiên xe từ bên trái tới')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (71, 18, N'C', N'Phải nhường đường cho xe đi đến từ bên phải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (72, 18, N'D', N'Xe đi thẳng được đi trước, xe rẽ trái đi sau cùng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (73, 19, N'A', N'18 tuổi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (74, 19, N'B', N'21 tuổi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (75, 19, N'C', N'24 tuổi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (76, 19, N'D', N'27 tuổi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (77, 20, N'A', N'Dừng, đỗ xe ở bất kỳ đâu nếu thấy thuận tiện')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (78, 20, N'B', N'Chỉ được dừng, đỗ xe ở làn trong cùng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (79, 20, N'C', N'Dừng, đỗ xe ở làn dừng khẩn cấp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (80, 20, N'D', N'Chỉ được dừng, đỗ xe ở nơi quy định; trường hợp khẩn cấp phải đưa xe ra khỏi phần đường xe chạy')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (81, 21, N'A', N'Đua xe, cổ vũ đua xe trái phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (82, 21, N'B', N'Nhường đường cho xe ưu tiên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (83, 21, N'C', N'Giúp đỡ người bị tai nạn giao thông')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (84, 21, N'D', N'Đi đúng phần đường, làn đường quy định')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (85, 22, N'A', N'Tăng tốc cho xe nhanh chóng vượt qua đường sắt')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (86, 22, N'B', N'Dừng lại cách đường sắt tối thiểu 5 mét, quan sát an toàn rồi mới đi qua')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (87, 22, N'C', N'Bấm còi liên tục để báo hiệu')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (88, 22, N'D', N'Đi theo các phương tiện khác')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (89, 23, N'A', N'Đường một chiều')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (90, 23, N'B', N'Nơi đỗ xe')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (91, 23, N'C', N'Cấm các phương tiện đi vào trừ xe ưu tiên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (92, 23, N'D', N'Bắt đầu đường ưu tiên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (93, 24, N'A', N'Chỉ cần nhìn gương chiếu hậu bên trái')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (94, 24, N'B', N'Chỉ cần nhìn gương chiếu hậu bên phải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (95, 24, N'C', N'Mở cửa và quan sát')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (96, 24, N'D', N'Phải quan sát phía sau, hai bên và bật tín hiệu báo lùi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (97, 25, N'A', N'Là sự hiểu biết và chấp hành nghiêm chỉnh pháp luật về giao thông; là ý thức trách nhiệm với cộng đồng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (98, 25, N'B', N'Là thói quen lái xe nhanh, vượt ẩu')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (99, 25, N'C', N'Là việc chỉ tuân thủ luật khi có cảnh sát giao thông')
GO
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (100, 25, N'D', N'Là việc trang trí xe đẹp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (101, 26, N'A', N'Chuyển làn ngay khi có ý định')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (102, 26, N'B', N'Phải có tín hiệu báo trước và phải đảm bảo an toàn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (103, 26, N'C', N'Chỉ cần quan sát gương chiếu hậu là đủ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (104, 26, N'D', N'Tăng tốc và chuyển làn đột ngột')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (105, 27, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (106, 27, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (107, 27, N'C', N'Biển 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (108, 27, N'D', N'Biển 1 và 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (109, 28, N'A', N'Xe ô tô đến 9 chỗ ngồi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (110, 28, N'B', N'Xe tải dưới 3.500 kg')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (111, 28, N'C', N'Cả A và B')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (112, 28, N'D', N'Xe ô tô chở người trên 30 chỗ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (113, 29, N'A', N'Xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (114, 29, N'B', N'Xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (115, 29, N'C', N'Cả hai xe đều phải nhường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (116, 29, N'D', N'Xe nào đi nhanh hơn thì được đi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (117, 30, N'A', N'Chỉ bật đèn chiếu gần')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (118, 30, N'B', N'Chỉ bật đèn chiếu xa')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (119, 30, N'C', N'Bật đèn sương mù')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (120, 30, N'D', N'Phải bật đèn chiếu sáng; trong đô thị dùng đèn chiếu gần')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (121, 31, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (122, 31, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (123, 31, N'C', N'Cả hai biển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (124, 31, N'D', N'Không biển nào')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (125, 32, N'A', N'Chỉ cần có nồng độ cồn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (126, 32, N'B', N'Vượt quá 50 miligam/100 mililít máu')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (127, 32, N'C', N'Bị cấm tuyệt đối khi trong máu hoặc hơi thở có nồng độ cồn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (128, 32, N'D', N'Vượt quá 80 miligam/100 mililít máu')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (129, 33, N'A', N'Xe con, xe tải, xe khách')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (130, 33, N'B', N'Xe cứu thương, xe con, xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (131, 33, N'C', N'Xe khách, xe cứu thương, xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (132, 33, N'D', N'Xe tải, xe khách, xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (133, 34, N'A', N'Đến ngã tư gần nhất hoặc đến vị trí có biển báo hết hiệu lực cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (134, 34, N'B', N'Chỉ có hiệu lực tại vị trí đặt biển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (135, 34, N'C', N'Trên toàn bộ tuyến đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (136, 34, N'D', N'Trong phạm vi 500m từ biển báo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (137, 35, N'A', N'Tăng tốc độ để người đi bộ đi nhanh hơn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (138, 35, N'B', N'Bấm còi để cảnh báo')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (139, 35, N'C', N'Giảm tốc độ, có thể dừng lại để nhường đường cho người đi bộ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (140, 35, N'D', N'Ra hiệu tay yêu cầu họ dừng lại')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (141, 36, N'A', N'Dùng để thay đổi hướng chuyển động')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (142, 36, N'B', N'Dùng để giảm tốc độ, dừng chuyển động của xe')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (143, 36, N'C', N'Dùng để truyền lực')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (144, 36, N'D', N'Dùng để tăng tốc độ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (145, 37, N'A', N'Biển báo nguy hiểm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (146, 37, N'B', N'Biển báo cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (147, 37, N'C', N'Biển báo hiệu lệnh')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (148, 37, N'D', N'Biển báo chỉ dẫn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (149, 38, N'A', N'Xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (150, 38, N'B', N'Xe mô tô')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (151, 38, N'C', N'Xe của bạn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (152, 38, N'D', N'Xe cứu hỏa')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (153, 39, N'A', N'8 giờ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (154, 39, N'B', N'Không quá 10 giờ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (155, 39, N'C', N'12 giờ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (156, 39, N'D', N'Không giới hạn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (157, 40, N'A', N'Giảm tốc độ, đi sát về bên phải và nhường đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (158, 40, N'B', N'Tăng tốc để xe sau không vượt được')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (159, 40, N'C', N'Đi sang làn đường bên trái')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (160, 40, N'D', N'Ra hiệu cho xe sau không được vượt')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (161, 41, N'A', N'Đường dành cho người đi bộ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (162, 41, N'B', N'Cấm người đi bộ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (163, 41, N'C', N'Nơi trẻ em qua đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (164, 41, N'D', N'Cảnh báo có người đi bộ cắt ngang')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (165, 42, N'A', N'Phải có tín hiệu báo trước bằng đèn xi-nhan')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (166, 42, N'B', N'Cả A và C')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (167, 42, N'C', N'Phải đảm bảo an toàn cho xe phía sau và chỉ vượt khi không có chướng ngại vật')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (168, 42, N'D', N'Có thể vượt bất cứ lúc nào')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (169, 43, N'A', N'Chỉ được đi thẳng và rẽ phải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (170, 43, N'B', N'Được đi tất cả các hướng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (171, 43, N'C', N'Phải dừng lại')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (172, 43, N'D', N'Chỉ được rẽ trái')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (173, 44, N'A', N'Được phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (174, 44, N'B', N'Tùy trường hợp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (175, 44, N'C', N'Được phép nếu không có người đi bộ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (176, 44, N'D', N'Không được phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (177, 45, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (178, 45, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (179, 45, N'C', N'Cả hai biển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (180, 45, N'D', N'Không biển nào')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (181, 46, N'A', N'Đạp hết hành trình bàn đạp ly hợp (côn)')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (182, 46, N'B', N'Nhả hết bàn đạp ga')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (183, 46, N'C', N'Phải thực hiện các thao tác: đạp hết côn, vào số, tăng ga từ từ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (184, 46, N'D', N'Không cần đạp côn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (185, 47, N'A', N'Là phần của đường bộ được sử dụng cho các phương tiện giao thông qua lại')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (186, 47, N'B', N'Là phần đường dành cho xe cơ giới')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (187, 47, N'C', N'Là phần đường dành cho xe thô sơ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (188, 47, N'D', N'Bao gồm cả hành lang an toàn đường bộ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (189, 48, N'A', N'Xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (190, 48, N'B', N'Xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (191, 48, N'C', N'Xe mô tô')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (192, 48, N'D', N'Cả xe con và xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (193, 49, N'A', N'Biển 1 và 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (194, 49, N'B', N'Biển 1 và 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (195, 49, N'C', N'Biển 2 và 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (196, 49, N'D', N'Cả ba biển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (197, 50, N'A', N'Xe lên dốc phải nhường đường cho xe xuống dốc')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (198, 50, N'B', N'Xe xuống dốc phải nhường đường cho xe đang lên dốc')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (199, 50, N'C', N'Xe nào có chướng ngại vật phía trước phải nhường đường')
GO
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (200, 50, N'D', N'Xe nào to hơn thì được ưu tiên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (201, 51, N'A', N'Được phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (202, 51, N'B', N'Được phép nhưng phải được cấp phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (203, 51, N'C', N'Tuyệt đối không được phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (204, 51, N'D', N'Tùy trường hợp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (205, 52, N'A', N'Xe của bạn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (206, 52, N'B', N'Xe tải và xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (207, 52, N'C', N'Xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (208, 52, N'D', N'Xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (209, 53, N'A', N'Hình tròn, nền xanh, hình vẽ màu trắng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (210, 53, N'B', N'Hình tam giác, nền vàng, viền đỏ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (211, 53, N'C', N'Hình tròn, viền đỏ, nền trắng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (212, 53, N'D', N'Hình chữ nhật, nền xanh')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (213, 54, N'A', N'Để xe trông đẹp hơn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (214, 54, N'B', N'Để thay đổi màu sơn xe')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (215, 54, N'C', N'Để tiết kiệm nhiên liệu')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (216, 54, N'D', N'Để đảm bảo xe luôn ở trạng thái kỹ thuật tốt, ngăn ngừa hỏng hóc')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (217, 55, N'A', N'Khi có biển báo nguy hiểm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (218, 55, N'B', N'Khi qua khu vực trường học, bệnh viện')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (219, 55, N'C', N'Khi điều khiển xe qua khu vực có trạm cảnh sát giao thông')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (220, 55, N'D', N'Tất cả các trường hợp trên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (221, 56, N'A', N'Mô tô, xe con, xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (222, 56, N'B', N'Xe tải, mô tô, xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (223, 56, N'C', N'Mô tô, xe tải, xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (224, 56, N'D', N'Xe con, xe tải, mô tô')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (225, 57, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (226, 57, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (227, 57, N'C', N'Biển 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (228, 57, N'D', N'Không biển nào')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (229, 58, N'A', N'Chạy với tốc độ cao')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (230, 58, N'B', N'Tuân thủ tốc độ tối đa cho phép, chú ý quan sát')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (231, 58, N'C', N'Sử dụng còi liên tục')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (232, 58, N'D', N'Có thể dừng đỗ tùy ý')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (233, 59, N'A', N'Dùng để trang trí')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (234, 59, N'B', N'Dùng để làm mát')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (235, 59, N'C', N'Nhiệt năng được biến đổi thành cơ năng làm quay trục khuỷu')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (236, 59, N'D', N'Dùng để chiếu sáng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (237, 60, N'A', N'Được phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (238, 60, N'B', N'Không được phép')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (239, 60, N'C', N'Được phép nếu xe phía trước đi chậm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (240, 60, N'D', N'Được phép khi không có xe ngược chiều')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (241, 61, N'A', N'Phải dừng lại sau biển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (242, 61, N'B', N'Được đi thẳng')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (243, 61, N'C', N'Được rẽ trái')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (244, 61, N'D', N'Phải đi chậm lại')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (245, 62, N'A', N'Dừng, đỗ xe bên trái đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (246, 62, N'B', N'Dừng, đỗ xe trên vỉa hè')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (247, 62, N'C', N'Phải cho xe dừng, đỗ sát theo lề đường, hè phố phía bên phải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (248, 62, N'D', N'Dừng, đỗ xe dưới lòng đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (249, 63, N'A', N'Tuyệt đối bị nghiêm cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (250, 63, N'B', N'Không bị nghiêm cấm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (251, 63, N'C', N'Bị nghiêm cấm tùy trường hợp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (252, 63, N'D', N'Được phép nếu người đó có kinh nghiệm')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (253, 64, N'A', N'Xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (254, 64, N'B', N'Xe mô tô')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (255, 64, N'C', N'Xe con')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (256, 64, N'D', N'Tất cả đều phải dừng lại')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (257, 65, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (258, 65, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (259, 65, N'C', N'Biển 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (260, 65, N'D', N'Biển 1 và 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (261, 66, N'A', N'Giấy phép lái xe')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (262, 66, N'B', N'Giấy đăng ký xe, Giấy chứng nhận bảo hiểm TNDS')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (263, 66, N'C', N'Giấy chứng nhận kiểm định an toàn kỹ thuật và bảo vệ môi trường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (264, 66, N'D', N'Tất cả các giấy tờ trên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (265, 67, N'A', N'Biển 1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (266, 67, N'B', N'Biển 2')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (267, 67, N'C', N'Biển 3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (268, 67, N'D', N'Không có biển nào')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (269, 68, N'A', N'Tăng tốc vượt qua xe tải')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (270, 68, N'B', N'Dừng lại đột ngột')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (271, 68, N'C', N'Giảm tốc độ, đi sát lề bên phải và nhường đường cho xe đạp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (272, 68, N'D', N'Bấm còi inh ỏi để xe đạp tránh đường')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (273, 69, N'A', N'50 tuổi đối với nam, 45 tuổi đối với nữ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (274, 69, N'B', N'55 tuổi đối với nam, 50 tuổi đối với nữ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (275, 69, N'C', N'60 tuổi đối với nam, 55 tuổi đối với nữ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (276, 69, N'D', N'Không giới hạn tuổi')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (277, 70, N'A', N'Giao nhau với đường sắt có rào chắn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (278, 70, N'B', N'Giao nhau với đường ưu tiên')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (279, 70, N'C', N'Giao nhau với đường hai chiều')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (280, 70, N'D', N'Giao nhau với tuyến đường cùng cấp')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (281, 71, N'A', N'Vượt đèn đỏ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (282, 71, N'B', N'Đi theo hướng của người điều khiển')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (283, 71, N'C', N'Phải chấp hành nghiêm chỉnh hiệu lệnh')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (284, 71, N'D', N'Dừng lại ngay lập tức')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (285, 72, N'A', N'Cấm đi ngược chiều.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (286, 72, N'B', N'Cấm xe cơ giới.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (287, 72, N'C', N'Đường cấm.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (288, 72, N'D', N'Cấm đỗ xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (289, 73, N'A', N'Vạch màu vàng, nét đứt')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (290, 73, N'B', N'Vạch màu trắng, nét liền')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (291, 73, N'C', N'Vạch màu trắng, nét đứt')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (292, 73, N'D', N'Vạch màu vàng, nét liền')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (293, 74, N'A', N'Nhả ra từ từ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (294, 74, N'B', N'Kéo lên cao hơn')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (295, 74, N'C', N'Nhả ra thật nhanh')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (296, 74, N'D', N'Bóp khóa hãm, đẩy cần phanh tay về phía trước hết hành trình')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (297, 76, N'A', N'Ô tô con, ô tô chở người đến 30 chỗ (trừ xe buýt); ô tô tải có trọng tải nhỏ hơn hoặc bằng 3,5 tấn.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (298, 76, N'B', N'Xe gắn máy, xe mô tô chuyên dùng.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (299, 76, N'C', N'Ô tô buýt, ô tô đầu kéo kéo sơ mi rơ moóc.')
GO
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (300, 76, N'D', N'Ô tô kéo rơ moóc, ô tô kéo xe khác.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (301, 77, N'A', N'Tăng tốc độ để nhanh chóng qua chỗ giao nhau.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (302, 77, N'B', N'Bấm còi liên tục để cảnh báo.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (303, 77, N'C', N'Cách chỗ rẽ một khoảng cách an toàn, có tín hiệu rẽ trái, cho xe chạy chậm, quan sát và nhường đường cho các phương tiện đi ngược chiều.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (304, 77, N'D', N'Chỉ cần bật tín hiệu rẽ trái và lập tức rẽ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (305, 78, N'A', N'Xe gặp sự cố, tai nạn, hoặc trường hợp khẩn cấp không thể di chuyển bình thường.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (306, 78, N'B', N'Để nghỉ ngơi, ăn uống.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (307, 78, N'C', N'Để nghe điện thoại.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (308, 78, N'D', N'Để cho hành khách xuống xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (309, 79, N'A', N'Được phép mang vác tùy ý.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (310, 79, N'B', N'Không được mang, vác.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (311, 79, N'C', N'Chỉ được mang vác khi có người ngồi sau giữ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (312, 79, N'D', N'Chỉ được mang vác các vật nhẹ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (313, 80, N'A', N'Khi chạy trên đường xấu, nhiều ổ gà nên chạy nhanh để vượt qua.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (314, 80, N'B', N'Khi đổ hàng, phải chọn vị trí có nền đường cứng, phẳng, và lùi xe vào vị trí.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (315, 80, N'C', N'Khi ben xe, phải đảm bảo an toàn cho người và phương tiện xung quanh.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (316, 80, N'D', N'Cả ý B và C.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (317, 81, N'A', N'Tùy theo loại động vật sống, người kinh doanh vận tải yêu cầu người thuê vận tải áp tải để chăm sóc.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (318, 81, N'B', N'Người thuê vận tải chịu trách nhiệm về việc xếp dỡ động vật sống.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (319, 81, N'C', N'Có thể vận chuyển chung với hàng hóa khác để tiết kiệm không gian.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (320, 81, N'D', N'Cả ý A và B.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (321, 82, N'A', N'Người lái xe buýt phải chạy đúng tuyến, đúng lịch trình và dừng đỗ đúng nơi quy định.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (322, 82, N'B', N'Người lái xe chở hàng có thể đi vào mọi tuyến đường để giao hàng nhanh nhất.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (323, 82, N'C', N'Xe buýt có thể dừng lại bất cứ đâu để đón khách.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (324, 82, N'D', N'Xe chở hàng được phép hoạt động không giới hạn thời gian.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (325, 83, N'A', N'Có giấy phép lái xe phù hợp với loại xe được điều khiển.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (326, 83, N'B', N'Có trách nhiệm với bản thân và cộng đồng, tôn trọng và nhường nhịn người khác.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (327, 83, N'C', N'Cả ý A và B.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (328, 83, N'D', N'Chỉ cần lái xe cẩn thận.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (329, 84, N'A', N'Đặt các biển cảnh báo hoặc vật báo hiệu ở phía trước và phía sau hiện trường.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (330, 84, N'B', N'Nhanh chóng rời khỏi hiện trường để tránh rắc rối.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (331, 84, N'C', N'Cả ý A và thực hiện các biện pháp cứu người và tài sản.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (332, 84, N'D', N'Gọi điện thoại cho người thân trước tiên.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (333, 85, N'A', N'Tăng tốc và lao nhanh qua đoạn đường ngập nước.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (334, 85, N'B', N'Về số một, giữ đều ga và đi ở tốc độ chậm để tránh nước vào động cơ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (335, 85, N'C', N'Tắt máy và đẩy xe qua.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (336, 85, N'D', N'Mở cửa xe để cân bằng áp suất.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (337, 86, N'A', N'Đạp bàn đạp phanh chân với lực phù hợp để giảm tốc độ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (338, 86, N'B', N'Chuyển cần số về vị trí N (số mo) để xe trôi tự do.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (339, 86, N'C', N'Kéo phanh tay để dừng xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (340, 86, N'D', N'Đạp hết ga rồi nhả ra đột ngột.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (341, 87, N'A', N'Dùng để truyền mô men quay từ động cơ tới các bánh xe chủ động của ô tô.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (342, 87, N'B', N'Dùng để thay đổi hướng chuyển động của ô tô.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (343, 87, N'C', N'Dùng để giảm tốc độ của ô tô.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (344, 87, N'D', N'Dùng để hỗ trợ người lái.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (345, 88, N'A', N'Cấm xe tải.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (346, 88, N'B', N'Đường dành cho xe tải.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (347, 88, N'C', N'Cấm xe khách.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (348, 88, N'D', N'Tốc độ tối đa cho xe tải.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (349, 89, N'A', N'Cấm người đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (350, 89, N'B', N'Đường người đi bộ cắt ngang.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (351, 89, N'C', N'Đường dành cho người đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (352, 89, N'D', N'Bắt buộc đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (353, 90, N'A', N'Cấm người đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (354, 90, N'B', N'Đường người đi bộ cắt ngang.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (355, 90, N'C', N'Đường dành cho người đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (356, 90, N'D', N'Bắt buộc đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (357, 91, N'A', N'Cấm đi ngược chiều.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (358, 91, N'B', N'Đường đôi.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (359, 91, N'C', N'Cấm vượt.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (360, 91, N'D', N'Hết cấm vượt.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (361, 92, N'A', N'Cấm đi ngược chiều.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (362, 92, N'B', N'Đường cấm.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (363, 92, N'C', N'Cấm người đi bộ.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (364, 92, N'D', N'Cấm đỗ xe.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (365, 93, N'A', N'Bắt buộc theo hướng chỉ dẫn.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (366, 93, N'B', N'Chỉ dẫn hướng đi.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (367, 93, N'C', N'Cấm theo hướng đó.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (368, 93, N'D', N'Hết hạn chế.  ')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (369, 94, N'A', N'Biển 2 và 3.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (370, 94, N'B', N'Biển 1.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (371, 94, N'C', N'Biển 2.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (372, 94, N'D', N'Biển 3.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (373, 95, N'A', N'Giữ nguyên đèn chiếu gần, giảm tốc độ, đi sau xe phía trước.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (374, 95, N'B', N'Bật đèn chiếu xa, tăng tốc độ vượt xe cùng chiều.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (375, 95, N'C', N'Giữ nguyên đèn chiếu gần, tăng tốc độ vượt xe cùng chiều.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (376, 95, N'D', N'Nháy đèn pha liên tục để yêu cầu xe đối diện tắt đèn.')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (377, 95, N'A', N'1')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (378, 95, N'B', N'3')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (379, 96, N'A', N'd')
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OptionKey], [OptionText]) VALUES (380, 96, N'B', N'da')
SET IDENTITY_INSERT [dbo].[Answers] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackId], [UserId], [Message], [CreatedAt], [Status], [Title]) VALUES (8, 10, N'test', CAST(N'2025-08-27T08:11:05.250' AS DateTime), N'Chờ Xử Lý', N'123')
INSERT [dbo].[Feedback] ([FeedbackId], [UserId], [Message], [CreatedAt], [Status], [Title]) VALUES (9, 10, N'test', CAST(N'2025-08-27T08:24:38.363' AS DateTime), N'Chờ Xử Lý', N'456')
INSERT [dbo].[Feedback] ([FeedbackId], [UserId], [Message], [CreatedAt], [Status], [Title]) VALUES (10, 10, N'ftuf', CAST(N'2025-12-09T09:45:02.563' AS DateTime), N'Đã Xử Lý', N'hihi')
INSERT [dbo].[Feedback] ([FeedbackId], [UserId], [Message], [CreatedAt], [Status], [Title]) VALUES (11, 14, N'1', CAST(N'2025-12-15T23:12:21.043' AS DateTime), N'Đã Xử Lý', N'lỗi câu 1')
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (1, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, nền trắng, số 50 bị gạch chéo)', N'/images/3767e412-f9e5-4c0a-9643-c01f5de68fc2.jpg', N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (2, N'Khi gặp biển báo cấm dừng, xe cơ giới được phép:', NULL, N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (3, N'Trong tình huống nào xe được phép vượt?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (5, N'Khi tham gia giao thông, người lái xe cần tuân thủ:', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (6, N'Xe nào được quyền ưu tiên đi trước tại ngã tư?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (8, N'Khoảng cách an toàn khi đi sau xe khác ở tốc độ 50km/h là:', NULL, N'Sa hình', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (9, N'Khi xe bị hỏng trên đường cao tốc, người lái xe phải:', NULL, N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (10, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, nền trắng, hình mũi tên quay vòng tròn)', N'/images/32548f6a-3a3c-4cee-9177-ce8ada542162.png', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (11, N'Trong trường hợp khẩn cấp, xe cứu thương được phép:', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (12, N'Người điều khiển xe mô tô hai bánh trên 50cm³ phải có bằng lái hạng nào?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (13, N'Khi dừng xe ở nơi có dốc, người lái xe cần:', NULL, N'Sa hình', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (14, N'Biển báo W201 cảnh báo về:', N'/images/001c3894-c2f2-448f-916a-4b5c1602c8ed.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (15, N'Phạm vi tác dụng của biển báo cấm là:', NULL, N'Biển báo', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (16, N'Khi điều khiển xe trên đường vòng, người lái xe cần phải làm gì?', NULL, N'Kỹ thuật lái xe', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (17, N'Biển báo nào dưới đây chỉ dẫn hết đoạn đường ưu tiên?', N'/images/4ee12c10-046a-4bf4-a2b8-069b23784be0.png', N'Biển báo', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (18, N'Tại nơi đường giao nhau không có báo hiệu đi theo vòng xuyến, phải nhường đường như thế nào?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (19, N'Người đủ bao nhiêu tuổi trở lên thì được điều khiển xe ô tô tải có trọng tải từ 3.500 kg trở lên?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (20, N'Trên đường cao tốc, người lái xe phải dừng xe, đỗ xe như thế nào?', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (21, N'Hành vi nào sau đây bị nghiêm cấm?', NULL, N'Văn hóa giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (22, N'Khi xe ô tô, mô tô đến gần vị trí giao nhau với đường sắt không có rào chắn, người lái xe phải xử lý thế nào?', NULL, N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (23, N'Biển báo này có ý nghĩa gì?', N'traffic_sign_6.jpg', N'Biển báo', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (24, N'Khi lùi xe, người lái xe phải làm gì để đảm bảo an toàn?', NULL, N'Kỹ thuật lái xe', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (25, N'Khái niệm "văn hóa giao thông" được hiểu như thế nào là đúng?', NULL, N'Văn hóa giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (26, N'Trên đường có nhiều làn đường, khi chuyển làn, người lái xe phải làm gì?', NULL, N'Kỹ thuật lái xe', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (27, N'Biển nào báo hiệu "Giao nhau với đường không ưu tiên"?', N'traffic_sign_7.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (28, N'Người có giấy phép lái xe hạng B2 được điều khiển loại xe nào?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (29, N'Trong các tình huống dưới đây, xe nào phải nhường đường là đúng quy tắc giao thông?', N'sahinh_1.jpg', N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (30, N'Khi tham gia giao thông vào ban đêm, xe cơ giới phải bật đèn như thế nào?', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (31, N'Biển nào cấm xe rẽ trái?', N'traffic_sign_8.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (32, N'"Nồng độ cồn" trong máu hoặc hơi thở khi điều khiển xe là bao nhiêu thì bị cấm?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (33, N'Thứ tự các xe đi như thế nào là đúng quy tắc giao thông?', N'sahinh_2.jpg', N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (34, N'Hiệu lực của biển báo "Cấm đỗ xe" áp dụng đến đâu?', NULL, N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (35, N'Khi gặp người đi bộ đang qua đường tại nơi có vạch kẻ đường, người lái xe phải xử lý ra sao?', NULL, N'Văn hóa giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (36, N'Công dụng của hệ thống phanh là gì?', NULL, N'Cấu tạo và sửa chữa', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (37, N'Biển báo có hình tam giác đều, viền đỏ, nền vàng, hình vẽ màu đen là loại biển gì?', NULL, N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (38, N'Xe nào được đi trước trong trường hợp này?', N'sahinh_3.jpg', N'Sa hình', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (39, N'Thời gian làm việc của người lái xe ô tô không được vượt quá bao nhiêu giờ trong một ngày?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (40, N'Khi thấy xe phía sau xin vượt, nếu đủ điều kiện an toàn, người lái xe phải làm gì?', NULL, N'Kỹ thuật lái xe', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (41, N'Biển báo này có ý nghĩa gì?', N'traffic_sign_9.jpg', N'Biển báo', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (42, N'Trên đường cao tốc, khi muốn vượt xe, bạn phải làm gì?', NULL, N'Kỹ thuật lái xe', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (43, N'Xe của bạn đi theo hướng nào là đúng quy tắc giao thông?', N'sahinh_4.jpg', N'Sa hình', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (44, N'Người lái xe có được quay đầu xe trên phần đường dành cho người đi bộ qua đường không?', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (45, N'Biển nào cho phép xe được quay đầu?', N'traffic_sign_10.jpg', N'Biển báo', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (46, N'Khi điều khiển xe sử dụng hộp số cơ khí (số sàn) trên đường bằng, muốn tăng số, cần phải làm gì?', NULL, N'Kỹ thuật lái xe', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (47, N'Khái niệm "phần đường xe chạy" được hiểu như thế nào là đúng?', NULL, N'Luật giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (48, N'Theo bạn, trong trường hợp này, xe nào vi phạm quy tắc giao thông?', N'sahinh_5.jpg', N'Sa hình', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (50, N'Khi tránh xe đi ngược chiều, các xe phải nhường đường như thế nào là đúng?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (51, N'Hành vi lắp đặt, sử dụng còi, đèn không đúng thiết kế của nhà sản xuất có được phép không?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (52, N'Trong tình huống này, xe nào phải dừng lại?', N'sahinh_6.jpg', N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (53, N'Biển báo hiệu lệnh có đặc điểm gì?', NULL, N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (54, N'Mục đích của việc bảo dưỡng xe thường xuyên là gì?', NULL, N'Cấu tạo và sửa chữa', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (55, N'Người lái xe phải giảm tốc độ thấp hơn tốc độ tối đa cho phép trong trường hợp nào dưới đây?', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (56, N'Thứ tự các xe đi như thế nào là đúng?', N'sahinh_7.jpg', N'Sa hình', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (57, N'Biển nào báo hiệu bắt đầu khu dân cư?', N'traffic_sign_12.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (58, N'Khi điều khiển xe trong khu đô thị, người lái xe cần tuân thủ điều gì?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (59, N'Công dụng của động cơ ô tô là gì?', NULL, N'Cấu tạo và sửa chữa', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (60, N'Xe con màu xanh có được phép vượt trong tình huống này không?', N'sahinh_8.jpg', N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (61, N'Biển báo "Stop" có ý nghĩa gì?', NULL, N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (62, N'Khi dừng, đỗ xe trên đường phố, người lái xe phải tuân thủ quy định nào?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (63, N'Hành vi giao xe cơ giới cho người không đủ điều kiện điều khiển có bị nghiêm cấm không?', NULL, N'Luật giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (64, N'Xe nào được quyền đi trước khi qua đường giao nhau trong hình vẽ?', N'sahinh_9.jpg', N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (65, N'Biển nào cấm ô tô tải?', N'traffic_sign_13.jpg', N'Biển báo', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (66, N'Khi điều khiển xe chạy trên đường, người lái xe phải mang theo các loại giấy tờ gì?', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (67, N'Biển nào dưới đây là biển "Kè, vực sâu phía trước"?', N'traffic_sign_14.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (68, N'Trong tình huống này, bạn xử lý như thế nào?', N'sahinh_10.jpg', N'Sa hình', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (69, N'Tuổi tối đa của người lái xe ô tô chở người trên 30 chỗ ngồi hạng E là bao nhiêu?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (70, N'Biển báo này có ý nghĩa như thế nào?', N'traffic_sign_15.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (71, N'Khi gặp hiệu lệnh của người điều khiển giao thông, người tham gia giao thông phải làm gì?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (72, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, nền trắng, hình xe ô tô và xe máy bị gạch chéo đỏ)', N'/images/8c6c3512-266b-4ecc-b77a-c02fe74a6ea0.jpg', N'Sa hình', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (73, N'Vạch kẻ đường nào dưới đây là vạch phân chia hai chiều xe chạy?', NULL, N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (74, N'Khi nhả phanh tay, người lái xe cần phải làm gì?', NULL, N'Kỹ thuật lái xe', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (75, N'Trên đường bộ, ngoài khu vực đông dân cư, đường hai chiều không có dải phân cách giữa, loại xe nào được chạy với tốc độ 80 km/h?', NULL, N'Luật giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (76, N'Khi điều khiển xe ô tô rẽ trái ở chỗ đường giao nhau, người lái xe cần thực hiện các thao tác nào để đảm bảo an toàn?', NULL, N'Kỹ thuật lái xe', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (77, N'Người lái xe được dừng, đỗ xe trên làn dừng khẩn cấp của đường cao tốc trong trường hợp nào dưới đây?', NULL, N'Luật giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (78, N'Người ngồi trên xe mô tô, xe gắn máy khi tham gia giao thông có được mang, vác vật cồng kềnh hay không?', NULL, N'Luật giao thông', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (79, N'Khi điều khiển xe ô tô tự đổ, người lái xe cần chú ý những điểm gì để đảm bảo an toàn?', NULL, N'Kỹ thuật lái xe', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (80, N'Việc vận chuyển động vật sống phải tuân theo những quy định nào dưới đây?', NULL, N'Luật giao thông', N'D')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (81, N'Trong khu dân cư, người lái xe buýt, xe chở hàng phải thực hiện những quy định nào sau đây?', NULL, N'Luật giao thông', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (82, N'Người có văn hóa giao thông khi điều khiển xe cơ giới phải đảm bảo các điều kiện nào?', NULL, N'Văn hóa giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (83, N'Khi xảy ra tai nạn giao thông, người lái xe và người có mặt tại hiện trường vụ tai nạn phải thực hiện các quy định nào?', NULL, N'Luật giao thông', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (84, N'Khi điều khiển xe ô tô qua đoạn đường ngập nước, người lái xe cần thực hiện các thao tác nào?', NULL, N'Kỹ thuật lái xe', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (85, N'Để giảm tốc độ và dừng xe khi điều khiển xe ô tô hộp số tự động, người lái xe phải làm gì?', NULL, N'Kỹ thuật lái xe', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (86, N'Hãy nêu công dụng của hệ thống truyền lực của ô tô?', NULL, N'Cấu tạo và sửa chữa', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (87, N'Biển báo hiệu hình tròn có nền xanh lam, có hình vẽ màu trắng là loại biển gì?', NULL, N'Biển báo', N'C')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (88, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, nền trắng, hình xe tải)', N'/images/eee90533-4c3a-41d5-a240-f1640e222301.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (89, N'Biển báo này là biển báo gì? (Biển tam giác viền đỏ, hình người đi bộ)', N'/images/52cb8bc6-4f3f-44f7-bc28-171bcb40af67.jpg', N'Biển báo', N'B')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (90, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, hình người đi bộ)', N'/images/c67831e6-acba-48aa-aea2-654a29fa5c4a.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (91, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, nền trắng, hai mũi tên ngược chiều)', N'/images/88805daa-a1b7-4132-8424-1c3297daa150.jpg', N'Biển báo', N'A')
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [ImageUrl], [Category], [CorrectAnswer]) VALUES (92, N'Biển báo này là biển báo gì? (Biển tròn viền đỏ, nền trắng, chữ P bị gạch chéo)', N'/images/57c7ba77-345a-43e0-a1b5-8dfad157eb42.png', N'Biển báo', N'D')
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[TestCategories] ON 

INSERT [dbo].[TestCategories] ([CategoryId], [QuestionCount], [DurationMinutes], [PassingScore]) VALUES (1, 30, 20, 28)
INSERT [dbo].[TestCategories] ([CategoryId], [QuestionCount], [DurationMinutes], [PassingScore]) VALUES (2, 35, 22, 32)
INSERT [dbo].[TestCategories] ([CategoryId], [QuestionCount], [DurationMinutes], [PassingScore]) VALUES (3, 40, 24, 36)
INSERT [dbo].[TestCategories] ([CategoryId], [QuestionCount], [DurationMinutes], [PassingScore]) VALUES (4, 45, 26, 41)
INSERT [dbo].[TestCategories] ([CategoryId], [QuestionCount], [DurationMinutes], [PassingScore]) VALUES (5, 50, 45, 1)
SET IDENTITY_INSERT [dbo].[TestCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[TestDetails] ON 

INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (1, 10, 22, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (2, 10, 90, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (3, 11, 1, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (4, 11, 5, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (5, 11, 6, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (6, 11, 7, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (7, 11, 8, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (8, 11, 13, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (9, 11, 18, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (10, 11, 20, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (11, 11, 21, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (12, 11, 22, N'A', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (13, 11, 24, N'D', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (14, 11, 25, N'A', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (15, 11, 27, N'A', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (16, 11, 31, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (17, 11, 32, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (18, 11, 34, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (19, 11, 35, N'C', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (20, 11, 36, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (21, 11, 46, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (22, 11, 53, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (23, 11, 60, N'B', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (24, 11, 66, N'A', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (25, 11, 68, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (26, 11, 70, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (27, 11, 73, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (28, 11, 74, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (29, 11, 82, N'C', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (30, 11, 88, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (31, 11, 91, N'A', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (32, 12, 7, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (33, 12, 8, N'C', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (34, 12, 12, N'B', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (35, 12, 38, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (36, 12, 45, N'B', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (37, 12, 61, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (38, 12, 62, N'C', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (39, 12, 69, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (40, 12, 74, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (41, 12, 78, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (42, 13, 8, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (43, 13, 12, N'B', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (44, 13, 33, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (45, 13, 37, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (46, 13, 45, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (47, 13, 62, N'A', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (48, 13, 92, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (49, 18, 11, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (50, 18, 46, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (51, 18, 66, N'D', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (52, 19, 28, N'C', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (53, 20, 28, N'C', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (54, 20, 29, N'A', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (55, 20, 42, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (56, 20, 44, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (57, 20, 55, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (58, 20, 57, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (59, 20, 65, N'B', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (60, 20, 69, N'B', 1)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (61, 20, 73, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (62, 20, 78, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (63, 21, 1, N'A', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (64, 21, 31, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (65, 21, 45, N'D', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (66, 21, 78, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (67, 21, 90, N'C', 0)
INSERT [dbo].[TestDetails] ([TestDetailId], [TestId], [QuestionId], [SelectedAnswer], [IsCorrect]) VALUES (68, 21, 91, N'B', 0)
SET IDENTITY_INSERT [dbo].[TestDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Tests] ON 

INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (2, 3, 1, 8, CAST(N'2024-01-15T10:30:00.000' AS DateTime), CAST(N'2024-01-15T10:55:00.000' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (4, 5, 1, 10, CAST(N'2024-01-16T16:15:00.000' AS DateTime), CAST(N'2024-01-16T16:38:00.000' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (5, 6, 1, 13, CAST(N'2024-01-17T08:45:00.000' AS DateTime), CAST(N'2024-01-17T09:12:00.000' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (7, 3, 1, 11, CAST(N'2024-01-18T15:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (8, 10, 1, 0, CAST(N'2025-08-26T21:20:56.380' AS DateTime), CAST(N'2025-08-26T21:20:56.380' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (9, 10, 1, 0, CAST(N'2025-08-26T21:41:17.573' AS DateTime), CAST(N'2025-08-26T21:41:17.573' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (10, 10, 1, 0, CAST(N'2025-08-26T21:46:10.713' AS DateTime), CAST(N'2025-08-26T21:46:10.713' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (11, 10, 1, 6, CAST(N'2025-08-26T22:36:05.320' AS DateTime), CAST(N'2025-08-26T22:36:05.320' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (12, 10, 1, 4, CAST(N'2025-08-26T22:42:40.553' AS DateTime), CAST(N'2025-08-26T22:42:40.553' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (13, 10, 1, 1, CAST(N'2025-08-26T22:43:00.910' AS DateTime), CAST(N'2025-08-26T22:43:00.910' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (14, 10, 1, 0, CAST(N'2025-08-26T22:43:26.027' AS DateTime), CAST(N'2025-08-26T22:43:26.027' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (15, 10, 1, 0, CAST(N'2025-08-26T22:43:29.827' AS DateTime), CAST(N'2025-08-26T22:43:29.827' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (16, 10, 1, 0, CAST(N'2025-08-26T22:43:33.397' AS DateTime), CAST(N'2025-08-26T22:43:33.397' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (17, 10, 1, 0, CAST(N'2025-08-26T22:43:45.403' AS DateTime), CAST(N'2025-08-26T22:43:45.403' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (18, 10, 1, 1, CAST(N'2025-08-26T22:45:06.183' AS DateTime), CAST(N'2025-08-26T22:45:06.183' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (19, 10, 1, 1, CAST(N'2025-08-26T22:45:15.463' AS DateTime), CAST(N'2025-08-26T22:45:15.463' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (20, 10, 1, 2, CAST(N'2025-08-26T22:46:45.080' AS DateTime), CAST(N'2025-08-26T22:46:45.080' AS DateTime))
INSERT [dbo].[Tests] ([TestId], [UserId], [CategoryId], [Score], [StartTime], [EndTime]) VALUES (21, 10, 1, 0, CAST(N'2025-08-26T22:59:52.347' AS DateTime), CAST(N'2025-08-26T22:59:52.347' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tests] OFF
GO
SET IDENTITY_INSERT [dbo].[UserActivityLogs] ON 

INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1, 11, N'Đăng nhập', CAST(N'2025-08-24T15:19:57.800' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (2, 11, N'Đăng xuất', CAST(N'2025-08-24T15:20:11.827' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (3, 11, N'Đăng nhập', CAST(N'2025-08-24T15:21:25.840' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (4, 11, N'Đăng nhập', CAST(N'2025-08-24T15:25:48.710' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (5, 10, N'Đăng nhập', CAST(N'2025-08-24T15:29:48.973' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (6, 10, N'Đăng xuất', CAST(N'2025-08-24T15:33:01.410' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (7, 11, N'Đăng nhập', CAST(N'2025-08-24T15:33:05.053' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (8, 11, N'Đăng nhập', CAST(N'2025-08-24T15:34:28.713' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (9, 11, N'Đăng nhập', CAST(N'2025-08-24T15:37:59.720' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (10, 11, N'Đăng nhập', CAST(N'2025-08-24T15:38:40.397' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (11, 11, N'Đăng nhập', CAST(N'2025-08-26T09:16:42.453' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (12, 11, N'Đăng nhập', CAST(N'2025-08-26T09:21:14.320' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (13, 11, N'Đăng nhập', CAST(N'2025-08-26T09:26:36.713' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (14, 11, N'Đăng nhập', CAST(N'2025-08-26T09:33:00.670' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (15, 11, N'Đăng nhập', CAST(N'2025-08-26T09:41:49.127' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (16, 11, N'Đăng nhập', CAST(N'2025-08-26T09:54:53.363' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (17, 11, N'Đăng nhập', CAST(N'2025-08-26T09:58:19.640' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (18, 11, N'Đăng nhập', CAST(N'2025-08-26T10:00:32.653' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (19, 11, N'Đăng nhập', CAST(N'2025-08-26T10:04:28.503' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (20, 11, N'Đăng nhập', CAST(N'2025-08-26T10:17:04.807' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (21, 11, N'Đăng nhập', CAST(N'2025-08-26T10:27:09.090' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (22, 11, N'Đăng nhập', CAST(N'2025-08-26T10:29:36.343' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (23, 11, N'Đăng nhập', CAST(N'2025-08-26T10:31:43.380' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (24, 11, N'Đăng nhập', CAST(N'2025-08-26T10:37:07.703' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (25, 11, N'Đăng nhập', CAST(N'2025-08-26T10:42:01.673' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (26, 11, N'Đăng nhập', CAST(N'2025-08-26T10:43:12.637' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (27, 10, N'Đăng nhập', CAST(N'2025-08-26T11:05:57.103' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (28, 10, N'Đăng nhập', CAST(N'2025-08-26T11:38:50.380' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (29, 10, N'Đăng nhập', CAST(N'2025-08-26T11:46:08.713' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (30, 10, N'Đăng nhập', CAST(N'2025-08-26T16:15:23.273' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (31, 10, N'Đăng nhập', CAST(N'2025-08-26T16:17:45.620' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (32, 10, N'Đăng nhập', CAST(N'2025-08-26T16:19:17.743' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (33, 10, N'Đăng nhập', CAST(N'2025-08-26T20:30:25.313' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (34, 10, N'Đăng xuất', CAST(N'2025-08-26T20:30:42.067' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (35, 11, N'Đăng nhập', CAST(N'2025-08-26T20:33:04.440' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (36, 11, N'Đăng nhập', CAST(N'2025-08-26T20:35:08.000' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (37, 10, N'Đăng nhập', CAST(N'2025-08-26T20:37:46.340' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (38, 10, N'Đăng xuất', CAST(N'2025-08-26T20:39:15.777' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (39, 11, N'Đăng nhập', CAST(N'2025-08-26T20:39:19.203' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (40, 10, N'Đăng nhập', CAST(N'2025-08-26T20:54:19.400' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (41, 10, N'Đăng xuất', CAST(N'2025-08-26T20:55:09.603' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (42, 11, N'Đăng nhập', CAST(N'2025-08-26T20:55:13.193' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (43, 10, N'Đăng nhập', CAST(N'2025-08-26T21:03:36.787' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (44, 10, N'Đăng nhập', CAST(N'2025-08-26T21:05:14.307' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (45, 10, N'Đăng nhập', CAST(N'2025-08-26T21:20:46.803' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (46, 10, N'Đăng nhập', CAST(N'2025-08-26T21:21:35.033' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (47, 10, N'Đăng nhập', CAST(N'2025-08-26T21:25:30.550' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (48, 10, N'Đăng nhập', CAST(N'2025-08-26T21:26:20.527' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (49, 10, N'Đăng nhập', CAST(N'2025-08-26T21:27:40.363' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (50, 10, N'Đăng xuất', CAST(N'2025-08-26T21:28:12.577' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (51, 11, N'Đăng nhập', CAST(N'2025-08-26T21:28:15.917' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (52, 10, N'Đăng nhập', CAST(N'2025-08-26T21:29:46.740' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (53, 10, N'Đăng nhập', CAST(N'2025-08-26T21:32:33.157' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (54, 10, N'Đăng nhập', CAST(N'2025-08-26T21:33:01.453' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (55, 10, N'Đăng nhập', CAST(N'2025-08-26T21:34:05.247' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (56, 10, N'Đăng nhập', CAST(N'2025-08-26T21:37:02.003' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (57, 10, N'Đăng nhập', CAST(N'2025-08-26T21:41:05.513' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (58, 10, N'Đăng nhập', CAST(N'2025-08-26T21:46:02.060' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (59, 10, N'Đăng nhập', CAST(N'2025-08-26T22:34:56.937' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (60, 10, N'Đăng nhập', CAST(N'2025-08-26T22:42:20.123' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (61, 10, N'Đăng nhập', CAST(N'2025-08-26T22:44:57.643' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (62, 10, N'Đăng nhập', CAST(N'2025-08-26T22:46:21.170' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (63, 10, N'Đăng nhập', CAST(N'2025-08-26T22:59:37.497' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (64, 11, N'Đăng nhập', CAST(N'2025-08-26T23:06:34.930' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (65, 11, N'Đăng nhập', CAST(N'2025-08-26T23:16:24.247' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (66, 11, N'Đăng nhập', CAST(N'2025-08-26T23:31:30.370' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (67, 11, N'Đăng nhập', CAST(N'2025-08-26T23:39:13.933' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (68, 11, N'Đăng nhập', CAST(N'2025-08-26T23:42:52.207' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (69, 11, N'Đăng nhập', CAST(N'2025-08-27T00:07:00.060' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (70, 11, N'Đăng nhập', CAST(N'2025-08-27T00:30:28.763' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (71, 11, N'Đăng nhập', CAST(N'2025-08-27T00:35:17.677' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (72, 11, N'Đăng nhập', CAST(N'2025-08-27T00:37:38.820' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (73, 11, N'Đăng nhập', CAST(N'2025-08-27T00:40:09.237' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (74, 11, N'Đăng nhập', CAST(N'2025-08-27T00:48:10.507' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (75, 11, N'Đăng nhập', CAST(N'2025-08-27T00:50:58.493' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (76, 11, N'Đăng nhập', CAST(N'2025-08-27T00:53:20.553' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (77, 11, N'Đăng nhập', CAST(N'2025-08-27T00:57:46.600' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (78, 11, N'Đăng nhập', CAST(N'2025-08-27T01:00:01.657' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (79, 11, N'Đăng nhập', CAST(N'2025-08-27T01:01:09.867' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (80, 11, N'Đăng nhập', CAST(N'2025-08-27T01:05:32.687' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (81, 11, N'Đăng nhập', CAST(N'2025-08-27T01:06:24.080' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (82, 11, N'Đăng nhập', CAST(N'2025-08-27T01:08:29.283' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (83, 11, N'Đăng nhập', CAST(N'2025-08-27T01:12:28.657' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (84, 11, N'Đăng nhập', CAST(N'2025-08-27T01:19:10.460' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (85, 11, N'Đăng nhập', CAST(N'2025-08-27T01:20:41.087' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (86, 11, N'Đăng nhập', CAST(N'2025-08-27T01:21:24.877' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (87, 11, N'Đăng nhập', CAST(N'2025-08-27T01:28:58.620' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (88, 11, N'Đăng nhập', CAST(N'2025-08-27T01:30:38.887' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (89, 11, N'Đăng nhập', CAST(N'2025-08-27T01:35:14.840' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (90, 11, N'Đăng nhập', CAST(N'2025-08-27T01:35:28.713' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (91, 11, N'Đăng nhập', CAST(N'2025-08-27T01:39:05.380' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (92, 11, N'Đăng nhập', CAST(N'2025-08-27T01:43:57.670' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (93, 11, N'Đăng nhập', CAST(N'2025-08-27T01:45:27.153' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (94, 11, N'Đăng nhập', CAST(N'2025-08-27T01:45:47.357' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (95, 11, N'Đăng nhập', CAST(N'2025-08-27T01:47:05.893' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (96, 11, N'Đăng nhập', CAST(N'2025-08-27T01:48:36.927' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (97, 11, N'Đăng nhập', CAST(N'2025-08-27T01:49:34.557' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (98, 11, N'Đăng nhập', CAST(N'2025-08-27T02:07:00.910' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (99, 11, N'Đăng nhập', CAST(N'2025-08-27T02:09:04.403' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
GO
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (100, 11, N'Đăng nhập', CAST(N'2025-08-27T02:13:00.190' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (101, 11, N'Đăng nhập', CAST(N'2025-08-27T08:04:31.153' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (102, 11, N'Đăng nhập', CAST(N'2025-08-27T08:04:49.050' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (103, 11, N'Đăng nhập', CAST(N'2025-08-27T08:10:18.573' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (104, 10, N'Đăng nhập', CAST(N'2025-08-27T08:10:32.903' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (105, 10, N'Đăng xuất', CAST(N'2025-08-27T08:11:22.243' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (106, 10, N'Đăng nhập', CAST(N'2025-08-27T08:11:23.543' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (107, 10, N'Đăng xuất', CAST(N'2025-08-27T08:11:24.923' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (108, 11, N'Đăng nhập', CAST(N'2025-08-27T08:11:28.740' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (109, 11, N'Đăng nhập', CAST(N'2025-08-27T08:12:41.360' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (110, 11, N'Đăng nhập', CAST(N'2025-08-27T08:15:42.073' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (111, 10, N'Đăng nhập', CAST(N'2025-08-27T08:21:24.437' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (112, 10, N'Đăng nhập', CAST(N'2025-08-27T08:23:54.503' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (113, 10, N'Đăng nhập', CAST(N'2025-08-27T08:24:29.333' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (114, 10, N'Đăng xuất', CAST(N'2025-08-27T08:24:51.473' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (115, 11, N'Đăng nhập', CAST(N'2025-08-27T08:24:55.247' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (116, 11, N'Đăng nhập', CAST(N'2025-08-27T08:33:25.953' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (117, 11, N'Đăng nhập', CAST(N'2025-08-27T08:40:40.273' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (118, 11, N'Đăng nhập', CAST(N'2025-08-27T08:41:32.113' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (119, 11, N'Đăng nhập', CAST(N'2025-08-27T08:44:07.963' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (120, 11, N'Đăng nhập', CAST(N'2025-08-27T08:47:10.043' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (121, 11, N'Đăng nhập', CAST(N'2025-08-27T08:47:40.140' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (122, 11, N'Đăng nhập', CAST(N'2025-08-27T08:48:20.270' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (123, 11, N'Đăng nhập', CAST(N'2025-08-27T08:48:46.867' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (124, 11, N'Đăng nhập', CAST(N'2025-08-27T09:03:09.527' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (125, 11, N'Đăng nhập', CAST(N'2025-08-27T09:03:26.217' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (126, 11, N'Đăng nhập', CAST(N'2025-08-27T09:04:25.380' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (127, 11, N'Đăng nhập', CAST(N'2025-08-27T09:05:35.750' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (128, 11, N'Đăng nhập', CAST(N'2025-08-27T09:22:48.207' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (129, 11, N'Đăng nhập', CAST(N'2025-08-27T09:26:17.607' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (130, 11, N'Đăng nhập', CAST(N'2025-08-27T09:48:25.267' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (131, 10, N'Đăng nhập', CAST(N'2025-08-27T09:48:49.257' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (132, 10, N'Đăng xuất', CAST(N'2025-08-27T09:48:51.413' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (133, 11, N'Đăng nhập', CAST(N'2025-08-27T09:48:54.677' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (134, 11, N'Đăng nhập', CAST(N'2025-08-27T10:02:27.790' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (135, 11, N'Đăng nhập', CAST(N'2025-08-27T10:07:32.007' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (136, 11, N'Đăng nhập', CAST(N'2025-08-27T10:08:15.787' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (137, 11, N'Đăng nhập', CAST(N'2025-08-27T10:10:10.277' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (138, 11, N'Đăng nhập', CAST(N'2025-08-27T10:12:02.663' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (139, 11, N'Đăng nhập', CAST(N'2025-08-27T10:13:14.483' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (140, 11, N'Đăng nhập', CAST(N'2025-08-27T10:14:55.570' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (141, 11, N'Đăng nhập', CAST(N'2025-08-27T10:18:40.063' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (142, 11, N'Đăng nhập', CAST(N'2025-08-27T10:20:21.667' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (143, 11, N'Đăng nhập', CAST(N'2025-08-27T10:20:44.803' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (144, 11, N'Đăng nhập', CAST(N'2025-08-27T10:20:59.353' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (145, 11, N'Đăng nhập', CAST(N'2025-08-27T10:21:41.800' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (146, 11, N'Đăng nhập', CAST(N'2025-08-27T10:26:02.370' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (147, 11, N'Đăng nhập', CAST(N'2025-08-27T10:29:58.820' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (148, 11, N'Đăng nhập', CAST(N'2025-08-27T10:30:42.630' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (149, 11, N'Đăng nhập', CAST(N'2025-08-27T10:31:04.803' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (150, 11, N'Đăng nhập', CAST(N'2025-08-27T10:33:37.237' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (151, 11, N'Đăng nhập', CAST(N'2025-08-27T10:35:01.773' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (152, 11, N'Đăng nhập', CAST(N'2025-08-27T10:35:54.100' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (153, 11, N'Đăng nhập', CAST(N'2025-08-27T10:36:45.400' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (154, 11, N'Đăng nhập', CAST(N'2025-08-27T10:40:51.117' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (155, 11, N'Đăng nhập', CAST(N'2025-08-27T10:41:48.460' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (156, 11, N'Đăng nhập', CAST(N'2025-08-27T10:42:39.877' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (157, 11, N'Đăng nhập', CAST(N'2025-08-27T10:44:09.197' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (158, 11, N'Đăng nhập', CAST(N'2025-08-27T10:48:51.587' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (159, 11, N'Đăng nhập', CAST(N'2025-08-27T10:52:36.273' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (160, 11, N'Đăng nhập', CAST(N'2025-08-27T10:53:18.193' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (161, 11, N'Đăng nhập', CAST(N'2025-08-27T10:54:01.887' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (162, 11, N'Đăng nhập', CAST(N'2025-08-27T11:00:26.383' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (163, 11, N'Đăng nhập', CAST(N'2025-08-27T11:03:28.700' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (164, 11, N'Đăng nhập', CAST(N'2025-08-27T11:04:20.250' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (165, 11, N'Đăng nhập', CAST(N'2025-08-27T11:04:58.730' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (166, 11, N'Đăng nhập', CAST(N'2025-08-27T11:06:45.553' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (167, 11, N'Đăng nhập', CAST(N'2025-08-27T11:08:00.960' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (168, 11, N'Đăng nhập', CAST(N'2025-08-27T11:10:01.573' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (169, 11, N'Đăng nhập', CAST(N'2025-08-27T11:11:35.590' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (170, 11, N'Đăng nhập', CAST(N'2025-08-27T11:20:07.027' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (171, 11, N'Đăng nhập', CAST(N'2025-08-27T11:21:21.640' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (172, 11, N'Đăng nhập', CAST(N'2025-08-27T11:42:42.653' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (173, 11, N'Đăng nhập', CAST(N'2025-08-27T11:47:18.997' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (174, 11, N'Đăng nhập', CAST(N'2025-08-27T11:49:38.357' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (175, 11, N'Đăng nhập', CAST(N'2025-08-27T11:50:43.723' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (176, 11, N'Đăng nhập', CAST(N'2025-08-27T11:52:49.243' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (177, 11, N'Đăng nhập', CAST(N'2025-08-27T11:53:34.410' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (178, 11, N'Đăng nhập', CAST(N'2025-08-27T11:56:32.890' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (179, 11, N'Đăng nhập', CAST(N'2025-08-27T11:57:39.750' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (180, 11, N'Đăng xuất', CAST(N'2025-08-27T11:57:41.310' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (181, 10, N'Đăng nhập', CAST(N'2025-08-27T12:05:43.360' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (182, 10, N'Đăng nhập', CAST(N'2025-08-27T12:07:58.263' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (183, 10, N'Đăng nhập', CAST(N'2025-08-27T12:11:51.940' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (184, 10, N'Đăng nhập', CAST(N'2025-08-27T12:12:36.000' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (185, 10, N'Đăng xuất', CAST(N'2025-08-27T12:12:56.917' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (186, 10, N'Đăng nhập', CAST(N'2025-08-27T12:29:09.657' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (187, 10, N'Đăng xuất', CAST(N'2025-08-27T12:29:22.320' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (188, 10, N'Đăng nhập', CAST(N'2025-08-27T13:31:09.810' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (189, 10, N'Đăng xuất', CAST(N'2025-08-27T13:33:19.460' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (190, 11, N'Đăng nhập', CAST(N'2025-08-27T13:33:25.960' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (191, 10, N'Đăng nhập', CAST(N'2025-08-27T13:37:42.347' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (192, 10, N'Đăng nhập', CAST(N'2025-08-27T13:41:55.597' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (193, 10, N'Đăng nhập', CAST(N'2025-12-09T09:42:56.940' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (194, 10, N'Đăng xuất', CAST(N'2025-12-09T09:45:37.503' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (195, 10, N'Đăng nhập', CAST(N'2025-12-09T09:45:45.800' AS DateTime), N'Người dùng ''nat1'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (196, 10, N'Đăng xuất', CAST(N'2025-12-09T09:45:48.820' AS DateTime), N'Người dùng ''nat1'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (197, NULL, N'Đăng ký', CAST(N'2025-12-09T09:46:01.137' AS DateTime), N'Người dùng ''hihi'' đã đăng ký tài khoản thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (198, NULL, N'Đăng nhập', CAST(N'2025-12-09T09:46:19.377' AS DateTime), N'Người dùng ''hihi'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (199, NULL, N'Đăng xuất', CAST(N'2025-12-09T09:48:20.347' AS DateTime), N'Người dùng ''hihihi3'' đã đăng xuất.')
GO
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (200, 11, N'Đăng nhập', CAST(N'2025-12-09T09:48:46.387' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (201, 11, N'Đăng nhập', CAST(N'2025-12-09T09:52:32.373' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (202, 11, N'Đăng nhập', CAST(N'2025-12-09T09:58:12.913' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (203, 11, N'Đăng nhập', CAST(N'2025-12-09T10:00:02.163' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (204, 11, N'Đăng nhập', CAST(N'2025-12-09T10:00:40.253' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (205, 11, N'Đăng nhập', CAST(N'2025-12-09T10:01:54.780' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (206, 11, N'Đăng nhập', CAST(N'2025-12-09T10:04:53.583' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (207, 11, N'Đăng nhập', CAST(N'2025-12-09T10:07:05.633' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (208, 11, N'Đăng nhập', CAST(N'2025-12-09T10:07:49.623' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (209, 11, N'Đăng nhập', CAST(N'2025-12-09T10:08:57.080' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (210, 11, N'Đăng nhập', CAST(N'2025-12-09T10:21:25.283' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (211, 11, N'Đăng nhập', CAST(N'2025-12-09T10:25:20.930' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (212, 11, N'Đăng nhập', CAST(N'2025-12-09T10:26:20.043' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (213, 11, N'Đăng nhập', CAST(N'2025-12-09T10:26:49.360' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (214, 11, N'Đăng nhập', CAST(N'2025-12-09T10:27:47.107' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (215, 11, N'Đăng nhập', CAST(N'2025-12-09T10:41:23.610' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (216, 11, N'Đăng nhập', CAST(N'2025-12-09T10:42:47.877' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (217, 11, N'Đăng nhập', CAST(N'2025-12-09T10:44:13.743' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (218, 11, N'Đăng nhập', CAST(N'2025-12-09T10:44:49.057' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (219, 11, N'Đăng nhập', CAST(N'2025-12-09T10:46:39.600' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (220, 11, N'Đăng nhập', CAST(N'2025-12-14T08:52:30.990' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (221, 11, N'Đăng nhập', CAST(N'2025-12-14T09:04:44.913' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (222, 11, N'Đăng nhập', CAST(N'2025-12-14T09:26:25.640' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (223, 11, N'Đăng nhập', CAST(N'2025-12-14T09:28:59.887' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (224, 11, N'Đăng nhập', CAST(N'2025-12-14T09:30:40.200' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (225, 11, N'Đăng nhập', CAST(N'2025-12-14T09:33:40.250' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (226, 11, N'Đăng nhập', CAST(N'2025-12-14T09:35:25.797' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (227, 11, N'Đăng nhập', CAST(N'2025-12-14T09:37:52.417' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (228, 11, N'Đăng nhập', CAST(N'2025-12-14T09:43:24.060' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (229, 11, N'Đăng nhập', CAST(N'2025-12-14T09:45:34.453' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (230, 11, N'Đăng nhập', CAST(N'2025-12-14T09:57:33.857' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (231, 11, N'Đăng nhập', CAST(N'2025-12-14T09:58:23.390' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (232, 11, N'Đăng nhập', CAST(N'2025-12-14T09:59:33.863' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (233, 11, N'Đăng nhập', CAST(N'2025-12-14T10:00:44.517' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (234, 11, N'Đăng nhập', CAST(N'2025-12-14T10:16:06.047' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (235, 11, N'Đăng nhập', CAST(N'2025-12-14T10:17:11.133' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (236, 11, N'Đăng nhập', CAST(N'2025-12-14T10:19:11.497' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (237, 11, N'Đăng nhập', CAST(N'2025-12-14T10:24:27.460' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (238, 11, N'Đăng nhập', CAST(N'2025-12-14T10:27:30.210' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (239, 11, N'Đăng nhập', CAST(N'2025-12-14T10:27:47.967' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (240, 11, N'Đăng nhập', CAST(N'2025-12-14T10:28:57.030' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (241, 11, N'Đăng nhập', CAST(N'2025-12-14T10:39:40.417' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (242, 11, N'Đăng nhập', CAST(N'2025-12-14T10:45:07.843' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (243, 11, N'Đăng nhập', CAST(N'2025-12-14T10:52:19.763' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (244, 11, N'Đăng nhập', CAST(N'2025-12-14T11:04:18.613' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (245, 11, N'Đăng nhập', CAST(N'2025-12-14T11:06:05.153' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (246, 11, N'Đăng nhập', CAST(N'2025-12-14T11:13:47.413' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (247, 11, N'Đăng nhập', CAST(N'2025-12-14T11:20:57.943' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (248, 11, N'Đăng nhập', CAST(N'2025-12-14T11:22:29.043' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (249, 11, N'Đăng nhập', CAST(N'2025-12-14T11:22:42.220' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (250, 11, N'Đăng nhập', CAST(N'2025-12-14T11:25:24.533' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (251, 11, N'Đăng nhập', CAST(N'2025-12-14T11:25:59.547' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (252, 11, N'Đăng nhập', CAST(N'2025-12-14T11:29:46.873' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (253, 11, N'Đăng nhập', CAST(N'2025-12-14T11:30:23.707' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (254, 11, N'Đăng nhập', CAST(N'2025-12-14T11:35:18.570' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (255, 11, N'Đăng nhập', CAST(N'2025-12-14T11:53:01.747' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (256, 11, N'Đăng nhập', CAST(N'2025-12-14T11:54:23.903' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (257, 11, N'Đăng nhập', CAST(N'2025-12-14T14:47:19.550' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (258, 11, N'Đăng nhập', CAST(N'2025-12-14T14:54:19.110' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (259, 11, N'Đăng nhập', CAST(N'2025-12-14T16:44:22.133' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (260, 11, N'Đăng nhập', CAST(N'2025-12-14T16:44:51.370' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (261, 11, N'Đăng nhập', CAST(N'2025-12-14T16:47:31.907' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (262, 11, N'Đăng nhập', CAST(N'2025-12-14T16:53:41.170' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (263, 11, N'Đăng nhập', CAST(N'2025-12-14T17:04:29.987' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (264, 11, N'Đăng nhập', CAST(N'2025-12-14T17:06:52.143' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (265, 11, N'Đăng nhập', CAST(N'2025-12-14T17:07:52.157' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (266, 11, N'Đăng nhập', CAST(N'2025-12-14T17:09:40.820' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (267, 11, N'Đăng nhập', CAST(N'2025-12-14T17:13:15.053' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (268, 11, N'Đăng nhập', CAST(N'2025-12-14T17:15:01.513' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (269, 11, N'Đăng nhập', CAST(N'2025-12-14T17:19:44.883' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (270, 11, N'Đăng nhập', CAST(N'2025-12-14T17:22:40.120' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (271, 11, N'Đăng nhập', CAST(N'2025-12-14T17:26:13.633' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1220, 11, N'Đăng nhập', CAST(N'2025-12-14T17:29:11.417' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1221, 11, N'Đăng xuất', CAST(N'2025-12-14T17:32:04.373' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1222, 11, N'Đăng nhập', CAST(N'2025-12-14T17:33:34.277' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1223, 11, N'Đăng nhập', CAST(N'2025-12-14T17:37:46.240' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1224, 11, N'Đăng nhập', CAST(N'2025-12-14T17:42:12.830' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1225, 11, N'Đăng nhập', CAST(N'2025-12-14T17:42:46.987' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1226, 11, N'Đăng nhập', CAST(N'2025-12-14T17:59:59.380' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1227, 11, N'Đăng nhập', CAST(N'2025-12-14T18:02:58.170' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1228, 11, N'Đăng nhập', CAST(N'2025-12-14T18:04:57.973' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1229, 11, N'Đăng nhập', CAST(N'2025-12-14T18:05:33.223' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1230, 11, N'Đăng nhập', CAST(N'2025-12-14T18:07:45.360' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1231, 11, N'Đăng nhập', CAST(N'2025-12-14T18:11:31.500' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1232, 11, N'Đăng nhập', CAST(N'2025-12-14T18:16:04.713' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1233, 11, N'Đăng nhập', CAST(N'2025-12-14T18:19:20.060' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1234, 11, N'Đăng nhập', CAST(N'2025-12-14T18:20:42.600' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1235, 11, N'Đăng nhập', CAST(N'2025-12-14T18:24:17.830' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1236, 11, N'Đăng nhập', CAST(N'2025-12-14T18:28:08.093' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1237, 11, N'Đăng nhập', CAST(N'2025-12-14T18:31:39.797' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1238, 11, N'Đăng nhập', CAST(N'2025-12-14T18:44:55.397' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1239, 11, N'Đăng nhập', CAST(N'2025-12-14T18:46:04.833' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1240, 11, N'Đăng nhập', CAST(N'2025-12-14T18:56:50.250' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1241, 11, N'Đăng nhập', CAST(N'2025-12-14T19:01:30.160' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1242, 11, N'Đăng nhập', CAST(N'2025-12-14T19:05:12.530' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1243, 11, N'Đăng nhập', CAST(N'2025-12-14T19:06:06.373' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1244, 11, N'Đăng nhập', CAST(N'2025-12-14T19:11:21.190' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1245, 11, N'Đăng nhập', CAST(N'2025-12-14T19:12:52.027' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1246, 11, N'Đăng nhập', CAST(N'2025-12-14T19:15:31.357' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1247, 11, N'Đăng nhập', CAST(N'2025-12-14T19:17:09.377' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
GO
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1248, 11, N'Đăng nhập', CAST(N'2025-12-14T19:43:06.547' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1249, 11, N'Đăng nhập', CAST(N'2025-12-14T19:44:04.707' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1250, 11, N'Đăng nhập', CAST(N'2025-12-14T19:46:20.523' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1251, 11, N'Đăng nhập', CAST(N'2025-12-14T20:16:28.653' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1252, 11, N'Đăng nhập', CAST(N'2025-12-14T20:17:43.400' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1253, 11, N'Đăng nhập', CAST(N'2025-12-14T20:24:27.633' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1254, 11, N'Đăng nhập', CAST(N'2025-12-14T20:25:11.593' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1255, 11, N'Đăng nhập', CAST(N'2025-12-14T20:25:41.660' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1256, 11, N'Đăng nhập', CAST(N'2025-12-14T20:29:22.237' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1257, 11, N'Đăng nhập', CAST(N'2025-12-14T20:32:35.750' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1258, 11, N'Đăng nhập', CAST(N'2025-12-14T20:36:57.183' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1259, 11, N'Đăng nhập', CAST(N'2025-12-14T20:41:37.890' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1260, 11, N'Đăng nhập', CAST(N'2025-12-14T20:51:49.643' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1261, 11, N'Đăng nhập', CAST(N'2025-12-14T20:58:43.847' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1262, 11, N'Đăng nhập', CAST(N'2025-12-14T21:00:49.603' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1263, 11, N'Đăng nhập', CAST(N'2025-12-14T21:02:03.003' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1264, 11, N'Đăng nhập', CAST(N'2025-12-14T21:03:29.847' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1265, 11, N'Đăng nhập', CAST(N'2025-12-14T21:06:27.947' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1266, 11, N'Đăng nhập', CAST(N'2025-12-14T21:06:54.223' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1267, 11, N'Đăng nhập', CAST(N'2025-12-14T21:07:26.577' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1268, 11, N'Đăng nhập', CAST(N'2025-12-14T21:14:18.243' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1269, 11, N'Đăng nhập', CAST(N'2025-12-14T21:16:54.040' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1270, 11, N'Đăng nhập', CAST(N'2025-12-14T21:18:29.123' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1271, 11, N'Đăng nhập', CAST(N'2025-12-14T21:28:22.650' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1272, 11, N'Đăng nhập', CAST(N'2025-12-14T21:36:50.980' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1273, 11, N'Đăng nhập', CAST(N'2025-12-14T21:42:01.280' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1274, 11, N'Đăng nhập', CAST(N'2025-12-14T21:44:36.043' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1275, 11, N'Đăng nhập', CAST(N'2025-12-14T21:47:58.093' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1276, 11, N'Đăng nhập', CAST(N'2025-12-14T21:50:00.900' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1277, 11, N'Đăng nhập', CAST(N'2025-12-14T21:53:41.163' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1278, 11, N'Đăng nhập', CAST(N'2025-12-14T21:59:23.530' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1279, 11, N'Đăng nhập', CAST(N'2025-12-14T22:04:30.980' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1280, 11, N'Đăng nhập', CAST(N'2025-12-14T22:05:22.247' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1281, 11, N'Đăng nhập', CAST(N'2025-12-14T22:07:38.377' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1282, 11, N'Đăng nhập', CAST(N'2025-12-14T22:09:18.613' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1283, 11, N'Đăng nhập', CAST(N'2025-12-14T22:12:03.137' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1284, 11, N'Đăng nhập', CAST(N'2025-12-14T22:17:43.457' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1285, 11, N'Đăng nhập', CAST(N'2025-12-14T22:19:31.617' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1286, 11, N'Đăng nhập', CAST(N'2025-12-14T22:22:26.937' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1287, 11, N'Đăng nhập', CAST(N'2025-12-14T22:23:49.807' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1288, 11, N'Đăng nhập', CAST(N'2025-12-14T22:49:27.973' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1289, 11, N'Đăng nhập', CAST(N'2025-12-14T22:51:05.010' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1290, 11, N'Đăng nhập', CAST(N'2025-12-14T23:10:03.357' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1291, 11, N'Đăng nhập', CAST(N'2025-12-14T23:16:41.533' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1292, 11, N'Đăng nhập', CAST(N'2025-12-14T23:27:48.940' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1293, 11, N'Đăng nhập', CAST(N'2025-12-14T23:31:01.110' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1294, 11, N'Đăng nhập', CAST(N'2025-12-14T23:36:40.453' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1295, 11, N'Đăng nhập', CAST(N'2025-12-14T23:41:30.967' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1296, 11, N'Đăng nhập', CAST(N'2025-12-14T23:48:53.673' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1297, 11, N'Đăng nhập', CAST(N'2025-12-14T23:51:06.697' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1298, 13, N'Đăng ký', CAST(N'2025-12-14T23:54:01.093' AS DateTime), N'Người dùng ''hihi2'' đã đăng ký tài khoản thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1299, 14, N'Xác thực đăng ký', CAST(N'2025-12-15T00:07:01.950' AS DateTime), N'Người dùng ''hmmm'' đã xác thực email và hoàn tất đăng ký.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1300, 14, N'Đăng nhập', CAST(N'2025-12-15T00:07:16.970' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1301, 11, N'Đăng nhập', CAST(N'2025-12-15T09:30:40.073' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1302, 11, N'Đăng nhập', CAST(N'2025-12-15T09:39:28.933' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1303, 14, N'Đăng nhập', CAST(N'2025-12-15T15:26:44.317' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1304, 14, N'Đăng xuất', CAST(N'2025-12-15T15:30:36.683' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1305, 14, N'Đăng nhập', CAST(N'2025-12-15T15:42:37.157' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1306, 14, N'Đăng xuất', CAST(N'2025-12-15T15:42:45.113' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1307, 11, N'Đăng nhập', CAST(N'2025-12-15T15:43:08.310' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1308, 11, N'Đăng xuất', CAST(N'2025-12-15T15:43:14.307' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1309, 14, N'Đăng nhập', CAST(N'2025-12-15T15:43:39.117' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1310, 14, N'Đăng nhập', CAST(N'2025-12-15T20:38:12.243' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1311, 14, N'Đăng xuất', CAST(N'2025-12-15T20:40:26.353' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1312, 14, N'Đăng nhập', CAST(N'2025-12-15T20:40:51.000' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1313, 14, N'Đăng nhập', CAST(N'2025-12-15T20:43:09.527' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1314, 14, N'Đăng nhập', CAST(N'2025-12-15T20:48:00.860' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1315, 14, N'Đăng nhập', CAST(N'2025-12-15T20:48:47.750' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1316, 14, N'Đăng xuất', CAST(N'2025-12-15T20:49:03.833' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1317, 11, N'Đăng nhập', CAST(N'2025-12-15T20:49:13.370' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1318, 11, N'Đăng xuất', CAST(N'2025-12-15T20:49:21.670' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1319, 11, N'Đăng nhập', CAST(N'2025-12-15T21:00:42.037' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1320, 11, N'Đăng xuất', CAST(N'2025-12-15T21:00:48.643' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1321, 14, N'Đăng nhập', CAST(N'2025-12-15T21:00:54.117' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1322, 14, N'Đăng nhập', CAST(N'2025-12-15T21:02:04.463' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1323, 14, N'Đăng nhập', CAST(N'2025-12-15T21:03:48.263' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1324, 14, N'Đăng nhập', CAST(N'2025-12-15T21:08:36.790' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1325, 14, N'Đăng xuất', CAST(N'2025-12-15T21:08:59.290' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1326, 11, N'Đăng nhập', CAST(N'2025-12-15T21:09:11.887' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1327, 11, N'Đăng xuất', CAST(N'2025-12-15T21:09:25.663' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1328, 11, N'Đăng nhập', CAST(N'2025-12-15T21:35:08.337' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1329, 11, N'Đăng xuất', CAST(N'2025-12-15T21:35:21.283' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1330, 11, N'Đăng nhập', CAST(N'2025-12-15T21:35:47.273' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1331, 11, N'Đăng xuất', CAST(N'2025-12-15T21:36:12.713' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1332, 11, N'Đăng nhập', CAST(N'2025-12-15T21:37:47.717' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1333, 11, N'Đăng xuất', CAST(N'2025-12-15T21:38:15.523' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1334, 14, N'Đăng nhập', CAST(N'2025-12-15T21:38:33.703' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1335, 14, N'Đăng nhập', CAST(N'2025-12-15T21:39:25.973' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1336, 14, N'Đăng nhập', CAST(N'2025-12-15T21:40:43.850' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1337, 14, N'Đăng xuất', CAST(N'2025-12-15T21:41:08.413' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1338, 11, N'Đăng nhập', CAST(N'2025-12-15T21:41:13.493' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1339, 14, N'Đăng nhập', CAST(N'2025-12-15T21:41:27.367' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1340, 14, N'Đăng xuất', CAST(N'2025-12-15T21:41:33.937' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1341, 14, N'Đăng nhập', CAST(N'2025-12-15T21:43:07.707' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1342, 14, N'Đăng nhập', CAST(N'2025-12-15T21:45:44.943' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1343, 14, N'Đăng xuất', CAST(N'2025-12-15T21:45:57.627' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1344, 11, N'Đăng nhập', CAST(N'2025-12-15T21:46:02.703' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1345, 11, N'Đăng xuất', CAST(N'2025-12-15T21:46:09.537' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1346, 11, N'Đăng nhập', CAST(N'2025-12-15T21:46:34.617' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1347, 11, N'Đăng xuất', CAST(N'2025-12-15T21:46:54.303' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
GO
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1348, 11, N'Đăng nhập', CAST(N'2025-12-15T21:48:38.540' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1349, 11, N'Đăng xuất', CAST(N'2025-12-15T21:49:32.877' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1350, 14, N'Đăng nhập', CAST(N'2025-12-15T21:49:40.857' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1351, 14, N'Đăng nhập', CAST(N'2025-12-15T22:20:29.223' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1352, 11, N'Đăng nhập', CAST(N'2025-12-15T22:21:10.463' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1353, 11, N'Đăng xuất', CAST(N'2025-12-15T22:21:19.523' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1354, 11, N'Đăng nhập', CAST(N'2025-12-15T22:21:34.687' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1355, 11, N'Đăng nhập', CAST(N'2025-12-15T22:28:34.893' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1356, 11, N'Đăng nhập', CAST(N'2025-12-15T22:33:41.020' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1357, 11, N'Đăng nhập', CAST(N'2025-12-15T22:34:30.603' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1358, 11, N'Đăng nhập', CAST(N'2025-12-15T22:39:55.903' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1359, 11, N'Đăng nhập', CAST(N'2025-12-15T22:43:47.180' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1360, 11, N'Đăng nhập', CAST(N'2025-12-15T22:44:31.637' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1361, 11, N'Đăng nhập', CAST(N'2025-12-15T22:49:46.693' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1362, 11, N'Đăng nhập', CAST(N'2025-12-15T22:55:40.480' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1363, 11, N'Đăng xuất', CAST(N'2025-12-15T22:57:09.453' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1364, 14, N'Đăng nhập', CAST(N'2025-12-15T22:57:23.040' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1365, 14, N'Đăng nhập', CAST(N'2025-12-15T23:12:05.330' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1366, 14, N'Đăng xuất', CAST(N'2025-12-15T23:12:26.830' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1367, 11, N'Đăng nhập', CAST(N'2025-12-15T23:12:31.493' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1368, 11, N'Đăng xuất', CAST(N'2025-12-15T23:12:52.180' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1369, 11, N'Đăng nhập', CAST(N'2025-12-15T23:13:15.960' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1370, 11, N'Đăng xuất', CAST(N'2025-12-15T23:14:23.363' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1371, 14, N'Đăng nhập', CAST(N'2025-12-15T23:14:36.513' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1372, 14, N'Đăng xuất', CAST(N'2025-12-15T23:14:58.703' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1373, 11, N'Đăng nhập', CAST(N'2025-12-15T23:15:08.063' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1374, 11, N'Đăng nhập', CAST(N'2025-12-15T23:17:41.017' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1375, 11, N'Đăng nhập', CAST(N'2025-12-15T23:28:49.753' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1376, 11, N'Đăng xuất', CAST(N'2025-12-15T23:30:46.907' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1377, 14, N'Đăng nhập', CAST(N'2025-12-15T23:30:55.643' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1378, 14, N'Đăng xuất', CAST(N'2025-12-15T23:31:00.627' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1379, 15, N'Xác thực đăng ký', CAST(N'2025-12-16T13:07:44.633' AS DateTime), N'Người dùng ''hhhh'' đã xác thực email và hoàn tất đăng ký.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1380, 15, N'Đăng nhập', CAST(N'2025-12-16T13:08:01.600' AS DateTime), N'Người dùng ''hhhh'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1381, 15, N'Đăng xuất', CAST(N'2025-12-16T13:08:05.613' AS DateTime), N'Người dùng ''hhhh'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1382, 15, N'Đăng nhập', CAST(N'2025-12-16T13:09:05.110' AS DateTime), N'Người dùng ''hhhh'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1383, 15, N'Đăng xuất', CAST(N'2025-12-16T13:12:04.833' AS DateTime), N'Người dùng ''hhhh'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1384, 11, N'Đăng nhập', CAST(N'2025-12-16T13:12:19.123' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1385, 11, N'Đăng xuất', CAST(N'2025-12-16T13:15:59.293' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1386, 14, N'Đăng nhập', CAST(N'2025-12-16T13:16:08.657' AS DateTime), N'Người dùng ''hmmm'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1387, 14, N'Đăng xuất', CAST(N'2025-12-16T13:18:49.237' AS DateTime), N'Người dùng ''hmmm'' đã đăng xuất.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1388, 11, N'Đăng nhập', CAST(N'2025-12-16T13:18:56.830' AS DateTime), N'Người dùng ''unilateral4'' đã đăng nhập thành công.')
INSERT [dbo].[UserActivityLogs] ([LogId], [UserId], [ActionType], [Timestamp], [Details]) VALUES (1389, 11, N'Đăng xuất', CAST(N'2025-12-16T13:19:52.993' AS DateTime), N'Người dùng ''unilateral4'' đã đăng xuất.')
SET IDENTITY_INSERT [dbo].[UserActivityLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (1, N'admin', N'hashed_admin_password', N'admin@drivingtestdb.com', 1, CAST(N'2025-08-20T16:32:57.357' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (3, N'tranthib', N'hashed_password_456', N'tranthib@email.com', 0, CAST(N'2025-08-20T16:32:57.357' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (5, N'phamthid', N'hashed_password_111', N'phamthid@email.com', 0, CAST(N'2025-08-20T16:32:57.357' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (6, N'hoangvane', N'hashed_password_222', N'hoangvane@email.com', 0, CAST(N'2025-08-20T16:32:57.357' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (10, N'nat1', N'114bd151f8fb0c58642d2170da4ae7d7c57977260ac2cc8905306cab6b2acabc', N'admim1@gmail.com', 0, CAST(N'2025-08-21T10:04:06.407' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (11, N'unilateral4', N'b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0', N'nguyenanhtailc45@gmail.com', 1, CAST(N'2025-08-21T23:49:00.697' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (13, N'hihi2', N'a11dcd8df13a303793035c2a257c4f6c4178bf398e7e031de2473d2939d2e323', N'unilateralhoyoverse@gmail.com', 0, CAST(N'2025-12-14T23:54:01.050' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (14, N'hmmm', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'mienmien821@gmail.com', 0, CAST(N'2025-12-15T00:07:01.890' AS DateTime))
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Role], [CreatedAt]) VALUES (15, N'hhhh', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'cuocsongma2121@gmail.com', 0, CAST(N'2025-12-16T13:07:44.557' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E40672E29F]    Script Date: 12/17/2025 8:22:04 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[TestDetails] ADD  DEFAULT ((0)) FOR [IsCorrect]
GO
ALTER TABLE [dbo].[Tests] ADD  DEFAULT ((0)) FOR [Score]
GO
ALTER TABLE [dbo].[Tests] ADD  DEFAULT (getdate()) FOR [StartTime]
GO
ALTER TABLE [dbo].[UserActivityLogs] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Role]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Answers]  WITH NOCHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TestDetails]  WITH NOCHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestDetails]  WITH NOCHECK ADD FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[TestCategories] ([CategoryId])
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserActivityLogs]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Answers]  WITH NOCHECK ADD CHECK  (([OptionKey]='D' OR [OptionKey]='C' OR [OptionKey]='B' OR [OptionKey]='A'))
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD CHECK  (([CorrectAnswer]='D' OR [CorrectAnswer]='C' OR [CorrectAnswer]='B' OR [CorrectAnswer]='A'))
GO
ALTER TABLE [dbo].[TestDetails]  WITH NOCHECK ADD CHECK  (([SelectedAnswer]='D' OR [SelectedAnswer]='C' OR [SelectedAnswer]='B' OR [SelectedAnswer]='A'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]=(1) OR [Role]=(0)))
GO
USE [master]
GO
ALTER DATABASE [DrivingTestDB] SET  READ_WRITE 
GO
