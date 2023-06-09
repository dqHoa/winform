CREATE DATABASE [QLThuVien]
GO
USE [QLThuVien]
GO
ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [FK__Sach__MaCD__5CD6CB2B]
GO
ALTER TABLE [dbo].[PhieuPhat] DROP CONSTRAINT [FK__PhieuPhat__MaThe__693CA210]
GO
ALTER TABLE [dbo].[PhieuPhat] DROP CONSTRAINT [FK__PhieuPhat__Masac__68487DD7]
GO
ALTER TABLE [dbo].[PhieuPhat] DROP CONSTRAINT [FK__PhieuPhat__MaPhi__6B24EA82]
GO
ALTER TABLE [dbo].[PhieuPhat] DROP CONSTRAINT [FK__PhieuPhat__MaNV__6A30C649]
GO
ALTER TABLE [dbo].[PhieuMuonSach] DROP CONSTRAINT [FK__PhieuMuonS__MaNV__6477ECF3]
GO
ALTER TABLE [dbo].[PhieuMuonSach] DROP CONSTRAINT [FK__PhieuMuon__MaThe__6383C8BA]
GO
ALTER TABLE [dbo].[PhieuMuonSach] DROP CONSTRAINT [FK__PhieuMuon__Masac__656C112C]
GO
/****** Object:  Table [dbo].[TheDocGia]    Script Date: 11/3/2021 3:04:23 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TheDocGia]') AND type in (N'U'))
DROP TABLE [dbo].[TheDocGia]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 11/3/2021 3:04:23 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sach]') AND type in (N'U'))
DROP TABLE [dbo].[Sach]
GO
/****** Object:  Table [dbo].[PhieuPhat]    Script Date: 11/3/2021 3:04:23 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuPhat]') AND type in (N'U'))
DROP TABLE [dbo].[PhieuPhat]
GO
/****** Object:  Table [dbo].[PhieuMuonSach]    Script Date: 11/3/2021 3:04:23 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuMuonSach]') AND type in (N'U'))
DROP TABLE [dbo].[PhieuMuonSach]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/3/2021 3:04:23 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhanVien]') AND type in (N'U'))
DROP TABLE [dbo].[NhanVien]
GO
/****** Object:  Table [dbo].[Chude]    Script Date: 11/3/2021 3:04:23 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Chude]') AND type in (N'U'))
DROP TABLE [dbo].[Chude]
GO
/****** Object:  Table [dbo].[Chude]    Script Date: 11/3/2021 3:04:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chude](
	[MaCD] [char](2) NOT NULL,
	[TenCD] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/3/2021 3:04:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](6) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[NgayVaoLam] [datetime] NULL,
	[GioiTinh] [nvarchar](4) NULL,
	[Diachi] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](30) NULL,
	[SDT] [varchar](15) NULL,
	[MatKhau] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuonSach]    Script Date: 11/3/2021 3:04:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuonSach](
	[MaPhieu] [char](6) NOT NULL,
	[MaThe] [char](6) NULL,
	[MaNV] [char](6) NULL,
	[Masach] [char](6) NULL,
	[Ngaymuon] [datetime] NULL,
	[NgayTra] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuPhat]    Script Date: 11/3/2021 3:04:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuPhat](
	[MaPhieuPhat] [char](6) NOT NULL,
	[MaPhieu] [char](6) NULL,
	[MaNV] [char](6) NULL,
	[MaThe] [char](6) NULL,
	[Masach] [char](6) NULL,
	[PhiPhat] [decimal](9, 3) NULL,
	[NoiDung] [nvarchar](100) NULL,
	[Ngay] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 11/3/2021 3:04:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[Masach] [char](6) NOT NULL,
	[Tensach] [nvarchar](30) NULL,
	[Tacgia] [nvarchar](20) NULL,
	[Ngaynhap] [datetime] NULL,
	[MaCD] [char](2) NULL,
	[TenNXB] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheDocGia]    Script Date: 11/3/2021 3:04:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheDocGia](
	[MaThe] [char](6) NOT NULL,
	[TenDocGia] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[NgayCapThe] [datetime] NULL,
	[NgayHetHan] [datetime] NULL,
	[GioiTinh] [nvarchar](4) NULL,
	[Diachi] [nvarchar](100) NULL,
	[SDT] [char](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Chude] ([MaCD], [TenCD]) VALUES (N'1 ', N'Công Nghệ')
INSERT [dbo].[Chude] ([MaCD], [TenCD]) VALUES (N'2 ', N'Khoa Học')
INSERT [dbo].[Chude] ([MaCD], [TenCD]) VALUES (N'3 ', N'Tâm Lý')
INSERT [dbo].[Chude] ([MaCD], [TenCD]) VALUES (N'4 ', N'Kế toán')
INSERT [dbo].[Chude] ([MaCD], [TenCD]) VALUES (N'5 ', N'Sách Giáo Khoa')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [NgayVaoLam], [GioiTinh], [Diachi], [ChucVu], [SDT], [MatKhau]) VALUES (N'NV0001', N'Dương Quốc Hoa', CAST(N'2001-11-16T00:00:00.000' AS DateTime), CAST(N'2021-10-27T00:00:00.000' AS DateTime), N'Nam', N'168 NCT, Q.1', N'Quản Lý', N'0123456789', N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [NgayVaoLam], [GioiTinh], [Diachi], [ChucVu], [SDT], [MatKhau]) VALUES (N'NV0002', N'Nguyễn Nhật Thương', CAST(N'2001-12-12T00:00:00.000' AS DateTime), CAST(N'2021-10-25T00:00:00.000' AS DateTime), N'Nữ', N'123 NVC, Q.2', N'Thủ Thư', N'0987654321', N'250cf8b51c773f3f8dc8b4be867a9a02')
GO
INSERT [dbo].[PhieuMuonSach] ([MaPhieu], [MaThe], [MaNV], [Masach], [Ngaymuon], [NgayTra]) VALUES (N'PM1   ', N'001   ', N'NV0001', N'S00002', CAST(N'2021-10-10T00:00:00.000' AS DateTime), CAST(N'2021-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuMuonSach] ([MaPhieu], [MaThe], [MaNV], [Masach], [Ngaymuon], [NgayTra]) VALUES (N'PM2   ', N'002   ', N'NV0002', N'S00001', CAST(N'2021-10-25T00:00:00.000' AS DateTime), CAST(N'2021-11-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PhieuPhat] ([MaPhieuPhat], [MaPhieu], [MaNV], [MaThe], [Masach], [PhiPhat], [NoiDung], [Ngay]) VALUES (N'1     ', N'PM1   ', N'NV0001', N'001   ', N'S00002', CAST(200000.000 AS Decimal(9, 3)), N'Hư Sách', CAST(N'2021-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuPhat] ([MaPhieuPhat], [MaPhieu], [MaNV], [MaThe], [Masach], [PhiPhat], [NoiDung], [Ngay]) VALUES (N'2     ', N'PM2   ', N'NV0001', N'002   ', N'S00001', CAST(10000.000 AS Decimal(9, 3)), N'Trả muộn', CAST(N'2021-10-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Sach] ([Masach], [Tensach], [Tacgia], [Ngaynhap], [MaCD], [TenNXB]) VALUES (N'S00001', N'Công nghệ thông tin', N'Nguyên Kim', CAST(N'2009-12-12T00:00:00.000' AS DateTime), N'1 ', N'Nguyễn Biểu')
INSERT [dbo].[Sach] ([Masach], [Tensach], [Tacgia], [Ngaynhap], [MaCD], [TenNXB]) VALUES (N'S00002', N'Toán 12', N'Kim Su', CAST(N'2021-02-02T00:00:00.000' AS DateTime), N'5 ', N'Bộ Giáo Dục')
INSERT [dbo].[Sach] ([Masach], [Tensach], [Tacgia], [Ngaynhap], [MaCD], [TenNXB]) VALUES (N'S00003', N'Công nghệ phần mềm', N'Nguyên Kim Lân', CAST(N'2009-02-12T00:00:00.000' AS DateTime), N'1 ', N'Kim Đồng')
INSERT [dbo].[Sach] ([Masach], [Tensach], [Tacgia], [Ngaynhap], [MaCD], [TenNXB]) VALUES (N'S00004', N'Lập Trình C#', N'Nguyên Hồng', CAST(N'2009-02-12T00:00:00.000' AS DateTime), N'1 ', N'Kim Đồng')
INSERT [dbo].[Sach] ([Masach], [Tensach], [Tacgia], [Ngaynhap], [MaCD], [TenNXB]) VALUES (N'S00005', N'Anh Văn', N'Kim Tuyên', CAST(N'2021-02-02T00:00:00.000' AS DateTime), N'5 ', N'Bộ Giáo Dục')
GO
INSERT [dbo].[TheDocGia] ([MaThe], [TenDocGia], [NgaySinh], [NgayCapThe], [NgayHetHan], [GioiTinh], [Diachi], [SDT]) VALUES (N'001   ', N'Quốc Hoa', CAST(N'2001-11-16T00:00:00.000' AS DateTime), CAST(N'2021-02-10T00:00:00.000' AS DateTime), CAST(N'2022-02-10T00:00:00.000' AS DateTime), N'Nam', N'123 QDG,Q4', N'0854985462     ')
INSERT [dbo].[TheDocGia] ([MaThe], [TenDocGia], [NgaySinh], [NgayCapThe], [NgayHetHan], [GioiTinh], [Diachi], [SDT]) VALUES (N'002   ', N'Nhật Thương', CAST(N'2001-11-18T00:00:00.000' AS DateTime), CAST(N'2021-02-10T00:00:00.000' AS DateTime), CAST(N'2022-02-10T00:00:00.000' AS DateTime), N'Nữ', N'1 NTMK, Q1', N'0484616874     ')
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD FOREIGN KEY([Masach])
REFERENCES [dbo].[Sach] ([Masach])
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD FOREIGN KEY([MaThe])
REFERENCES [dbo].[TheDocGia] ([MaThe])
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuPhat]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuPhat]  WITH CHECK ADD FOREIGN KEY([MaPhieu])
REFERENCES [dbo].[PhieuMuonSach] ([MaPhieu])
GO
ALTER TABLE [dbo].[PhieuPhat]  WITH CHECK ADD FOREIGN KEY([Masach])
REFERENCES [dbo].[Sach] ([Masach])
GO
ALTER TABLE [dbo].[PhieuPhat]  WITH CHECK ADD FOREIGN KEY([MaThe])
REFERENCES [dbo].[TheDocGia] ([MaThe])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaCD])
REFERENCES [dbo].[Chude] ([MaCD])
GO
