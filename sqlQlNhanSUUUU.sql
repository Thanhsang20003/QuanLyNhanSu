USE [master]
GO
/****** Object:  Database [QLNhansu4]    Script Date: 30/11/2024 8:34:19 PM ******/
CREATE DATABASE [QLNhansu4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNhansu4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLNhansu4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLNhansu4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLNhansu4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLNhansu4] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNhansu4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNhansu4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNhansu4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNhansu4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNhansu4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNhansu4] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNhansu4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLNhansu4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNhansu4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNhansu4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNhansu4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNhansu4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNhansu4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNhansu4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNhansu4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNhansu4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLNhansu4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNhansu4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNhansu4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNhansu4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNhansu4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNhansu4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNhansu4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNhansu4] SET RECOVERY FULL 
GO
ALTER DATABASE [QLNhansu4] SET  MULTI_USER 
GO
ALTER DATABASE [QLNhansu4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNhansu4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNhansu4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNhansu4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLNhansu4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLNhansu4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLNhansu4', N'ON'
GO
ALTER DATABASE [QLNhansu4] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLNhansu4] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLNhansu4]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoPhan]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoPhan](
	[MaBP] [varchar](20) NOT NULL,
	[TenBP] [nvarchar](150) NOT NULL,
	[NgayTL] [varchar](20) NULL,
	[GhiChu] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[MaCC] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[NgayCham] [varchar](250) NULL,
	[GioVao] [varchar](250) NULL,
	[StatusIn] [nvarchar](50) NULL,
	[GioRa] [varchar](250) NULL,
	[StatusOut] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSBaoHiem]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSBaoHiem](
	[MaBH] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[LoaiBH] [nvarchar](50) NULL,
	[MaTheBH] [varchar](20) NULL,
	[NgayCap] [varchar](20) NULL,
	[NgayHetHan] [varchar](20) NULL,
	[NoiCap] [nvarchar](100) NULL,
	[PhiBaoHiem] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSKhenThuong]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSKhenThuong](
	[MaThuong] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[NgayThuong] [varchar](20) NULL,
	[LyDo] [nvarchar](300) NULL,
	[HinhThuc] [nvarchar](300) NULL,
	[TienThuong] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSKyLuat]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSKyLuat](
	[MaKyLuat] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[NgayKyLuat] [varchar](20) NULL,
	[LyDo] [nvarchar](300) NULL,
	[HinhThuc] [nvarchar](300) NULL,
	[TienPhat] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKyLuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSThaiSan]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSThaiSan](
	[MaThaiSan] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[NgayBatDau] [varchar](20) NULL,
	[NgayKetThuc] [varchar](20) NULL,
	[TrangThai] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThaiSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[MaHD] [varchar](20) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[LoaiHD] [nvarchar](150) NOT NULL,
	[NgayBD] [varchar](20) NOT NULL,
	[NgayKT] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[MaLuong] [int] IDENTITY(1,1) NOT NULL,
	[LuongCB] [float] NULL,
	[ChucVu] [nvarchar](200) NULL,
	[MaNV] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](20) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](20) NOT NULL,
	[NgaySinh] [varchar](20) NOT NULL,
	[QueQuan] [nvarchar](200) NOT NULL,
	[SDT] [int] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Cmnd] [int] NULL,
	[Email] [varchar](50) NULL,
	[TenTDHV] [nvarchar](100) NULL,
	[CNganh] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](200) NULL,
	[TinhTrang] [nvarchar](200) NULL,
	[NgayVaoLam] [varchar](20) NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[MaPhong] [varchar](20) NOT NULL,
	[MaBP] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhong] [varchar](20) NOT NULL,
	[MaBP] [varchar](20) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TongLuong]    Script Date: 30/11/2024 8:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TongLuong](
	[MaTongLuong] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[TuNgay] [varchar](20) NULL,
	[DenNgay] [varchar](20) NULL,
	[SoNgayCong] [int] NULL,
	[TongPhiBH] [float] NULL,
	[TongTienThuong] [float] NULL,
	[TongTienPhat] [float] NULL,
	[TongLuong] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTongLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [Password], [Type]) VALUES (N'admin', N'Người Quản Lý', N'1234', 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [Password], [Type]) VALUES (N'staff', N'Nhân Viên', N'nv1', 3)
INSERT [dbo].[Account] ([UserName], [DisplayName], [Password], [Type]) VALUES (N'tk1', N'nhân viên 1', N'234', 3)
GO
INSERT [dbo].[BoPhan] ([MaBP], [TenBP], [NgayTL], [GhiChu]) VALUES (N'BP001', N'Kỹ thuật', N'3/3/2021', N'')
INSERT [dbo].[BoPhan] ([MaBP], [TenBP], [NgayTL], [GhiChu]) VALUES (N'BP002', N'Công nghệ', N'3/2/2020', N'')
INSERT [dbo].[BoPhan] ([MaBP], [TenBP], [NgayTL], [GhiChu]) VALUES (N'BP003', N'Kiểm toán', N'3/2/2020', N'')
INSERT [dbo].[BoPhan] ([MaBP], [TenBP], [NgayTL], [GhiChu]) VALUES (N'BP004', N'Hành chính', N'3/2/2020', N'')
INSERT [dbo].[BoPhan] ([MaBP], [TenBP], [NgayTL], [GhiChu]) VALUES (N'BP005', N'Nhân sự', N'3/2/2020', N'')
INSERT [dbo].[BoPhan] ([MaBP], [TenBP], [NgayTL], [GhiChu]) VALUES (N'BP006', N'Chăm sóc Khách hàng', N'3/2/2020', N'')
GO
SET IDENTITY_INSERT [dbo].[ChamCong] ON 

INSERT [dbo].[ChamCong] ([MaCC], [MaNV], [NgayCham], [GioVao], [StatusIn], [GioRa], [StatusOut]) VALUES (8, N'NV003', N'2024-11-30', N'18:10', N'Đi trễ', N'18:10', N'Đúng giờ')
SET IDENTITY_INSERT [dbo].[ChamCong] OFF
GO
SET IDENTITY_INSERT [dbo].[DSBaoHiem] ON 

INSERT [dbo].[DSBaoHiem] ([MaBH], [MaNV], [LoaiBH], [MaTheBH], [NgayCap], [NgayHetHan], [NoiCap], [PhiBaoHiem]) VALUES (1, N'NV001', N'Bảo hiểm xã hội', N'BH001', N'2023-01-01', N'2025-01-01', N'Hà Nội', 500000)
INSERT [dbo].[DSBaoHiem] ([MaBH], [MaNV], [LoaiBH], [MaTheBH], [NgayCap], [NgayHetHan], [NoiCap], [PhiBaoHiem]) VALUES (2, N'NV002', N'BHXH', N'BH002', N'01/06/2023', N'01/06/2025', N'Hồ Chí Minh Hóc MÔn', 40000)
SET IDENTITY_INSERT [dbo].[DSBaoHiem] OFF
GO
SET IDENTITY_INSERT [dbo].[DSKhenThuong] ON 

INSERT [dbo].[DSKhenThuong] ([MaThuong], [MaNV], [NgayThuong], [LyDo], [HinhThuc], [TienThuong]) VALUES (1, N'NV001', N'2024-01-01', N'Hoàn thành tốt nhiệm vụ', N'Tiền mặt', 2000000)
INSERT [dbo].[DSKhenThuong] ([MaThuong], [MaNV], [NgayThuong], [LyDo], [HinhThuc], [TienThuong]) VALUES (2, N'NV002', N'2024-02-01', N'Nhân viên xuất sắc', N'Tiền mặt', 1500000)
SET IDENTITY_INSERT [dbo].[DSKhenThuong] OFF
GO
SET IDENTITY_INSERT [dbo].[DSKyLuat] ON 

INSERT [dbo].[DSKyLuat] ([MaKyLuat], [MaNV], [NgayKyLuat], [LyDo], [HinhThuc], [TienPhat]) VALUES (1, N'NV001', N'2024-03-01', N'Đi làm muộn', N'Cảnh cáo', 50000)
INSERT [dbo].[DSKyLuat] ([MaKyLuat], [MaNV], [NgayKyLuat], [LyDo], [HinhThuc], [TienPhat]) VALUES (2, N'NV002', N'2024-04-01', N'Không hoàn thành công việc', N'Phạt tiền', 100000)
SET IDENTITY_INSERT [dbo].[DSKyLuat] OFF
GO
SET IDENTITY_INSERT [dbo].[DSThaiSan] ON 

INSERT [dbo].[DSThaiSan] ([MaThaiSan], [MaNV], [NgayBatDau], [NgayKetThuc], [TrangThai]) VALUES (1, N'NV002', N'2024-05-01', N'2024-08-01', N'Đã hoàn thành')
SET IDENTITY_INSERT [dbo].[DSThaiSan] OFF
GO
INSERT [dbo].[HopDong] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD001', N'NV001', N'Hợp đồng lao động', N'2023-01-01', N'2026-01-01')
INSERT [dbo].[HopDong] ([MaHD], [MaNV], [LoaiHD], [NgayBD], [NgayKT]) VALUES (N'HD002', N'NV002', N'Hợp đồng học việc', N'2023-06-01', N'2024-06-01')
GO
SET IDENTITY_INSERT [dbo].[Luong] ON 

INSERT [dbo].[Luong] ([MaLuong], [LuongCB], [ChucVu], [MaNV]) VALUES (1, 15000000, N'Lập trình viên', N'NV001')
INSERT [dbo].[Luong] ([MaLuong], [LuongCB], [ChucVu], [MaNV]) VALUES (2, 12000324, N'Nhân viên', N'NV002')
INSERT [dbo].[Luong] ([MaLuong], [LuongCB], [ChucVu], [MaNV]) VALUES (3, 1000000, N'Nhân viên', N'NV003')
SET IDENTITY_INSERT [dbo].[Luong] OFF
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [DiaChi], [Cmnd], [Email], [TenTDHV], [CNganh], [ChucVu], [TinhTrang], [NgayVaoLam], [UserName], [MaPhong], [MaBP]) VALUES (N'NV001', N'Nguyễn Văn A', N'Nam', N'1990-01-01', N'Hà Nội', 123456789, N'Số 1, Quận 1', 123456, N'a@gmail.com', N'Cử nhân', N'Công nghệ', N'Lập trình viên', N'Đang làm việc', N'2021-01-01', N'admin', N'PB01', N'BP001')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [DiaChi], [Cmnd], [Email], [TenTDHV], [CNganh], [ChucVu], [TinhTrang], [NgayVaoLam], [UserName], [MaPhong], [MaBP]) VALUES (N'NV002', N'Lê Thị B', N'Nữ', N'1992-05-15', N'Hồ Chí Minh', 987654321, N'Số 2, Quận 2', 654321, N'b@gmail.com', N'Cao đẳng', N'Sinh học', N'Nhân viên', N'Đang làm việc', N'2022-05-01', N'staff', N'PB02', N'BP002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [DiaChi], [Cmnd], [Email], [TenTDHV], [CNganh], [ChucVu], [TinhTrang], [NgayVaoLam], [UserName], [MaPhong], [MaBP]) VALUES (N'NV003', N'Phong đẹp trai', N'Nam', N'15/05/1992', N'Hồ Chí Minh', 987654321, N'Số 2, Quận 2', 654321, N'b@gmail.com', N'Đại học', N'IT', N'Nhân viên', N'Đang Làm Việc', N'01/05/2022', N'tk1', N'PB06', N'BP006')
GO
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB01', N'BP001', N'Phần Mềm', N'Hóc Môn')
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB02', N'BP002', N'Sinh Học', N'Bà Điểm')
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB03', N'BP003', N'Kiểm toán', N'Quận 12')
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB04', N'BP004', N'Hành chính', N'Hóc Môn')
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB05', N'BP005', N'Nhân sự', N'Bà điểm')
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB06', N'BP006', N'Chăm sóc Khách hàng', N'Bà điểm')
INSERT [dbo].[PhongBan] ([MaPhong], [MaBP], [TenPhong], [DiaChi]) VALUES (N'PB07', N'BP005', N'Phòng của Phong', N'Bà Điểm zzzzzz')
GO
SET IDENTITY_INSERT [dbo].[TongLuong] ON 

INSERT [dbo].[TongLuong] ([MaTongLuong], [MaNV], [TuNgay], [DenNgay], [SoNgayCong], [TongPhiBH], [TongTienThuong], [TongTienPhat], [TongLuong]) VALUES (1, N'NV001', N'2024-01-01', N'2024-01-31', 26, 500000, 2000000, 50000, 16545000)
INSERT [dbo].[TongLuong] ([MaTongLuong], [MaNV], [TuNgay], [DenNgay], [SoNgayCong], [TongPhiBH], [TongTienThuong], [TongTienPhat], [TongLuong]) VALUES (2, N'NV002', N'2024-01-01', N'2024-01-31', 24, 300000, 1500000, 100000, 13250000)
INSERT [dbo].[TongLuong] ([MaTongLuong], [MaNV], [TuNgay], [DenNgay], [SoNgayCong], [TongPhiBH], [TongTienThuong], [TongTienPhat], [TongLuong]) VALUES (3, N'NV003', N'2024-11-30', N'2024-11-30', 1, 0, 0, 0, 45454.545454545456)
SET IDENTITY_INSERT [dbo].[TongLuong] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__C9F2845669FBF715]    Script Date: 30/11/2024 8:34:20 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Si') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DSBaoHiem]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DSKhenThuong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DSKyLuat]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DSThaiSan]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Luong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaBP])
REFERENCES [dbo].[BoPhan] ([MaBP])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongBan] ([MaPhong])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
GO
ALTER TABLE [dbo].[PhongBan]  WITH CHECK ADD FOREIGN KEY([MaBP])
REFERENCES [dbo].[BoPhan] ([MaBP])
GO
ALTER TABLE [dbo].[TongLuong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
USE [master]
GO
ALTER DATABASE [QLNhansu4] SET  READ_WRITE 
GO
