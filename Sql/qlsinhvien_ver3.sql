IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BoMon] (
    [MaBoMon] int NOT NULL IDENTITY,
    [TenBoMon] nvarchar(80) NOT NULL,
    CONSTRAINT [PK_BoMon] PRIMARY KEY ([MaBoMon])
);
GO

CREATE TABLE [Khoa] (
    [MaKhoa] int NOT NULL IDENTITY,
    [TenKhoa] nvarchar(80) NOT NULL,
    CONSTRAINT [PK_Khoa] PRIMARY KEY ([MaKhoa])
);
GO

CREATE TABLE [NguoiDung] (
    [TenNguoiDung] nvarchar(50) NOT NULL,
    [MatKhau] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_NguoiDung] PRIMARY KEY ([TenNguoiDung])
);
GO

CREATE TABLE [VaiTro] (
    [TenVaiTro] nvarchar(50) NOT NULL,
    [TenVaiTroCuThe] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_VaiTro] PRIMARY KEY ([TenVaiTro])
);
GO

CREATE TABLE [GiangVien] (
    [MaGiangVien] int NOT NULL IDENTITY,
    [MaBoMon] int NOT NULL,
    [HoTen] nvarchar(40) NOT NULL,
    [GioiTinh] bit NOT NULL,
    [NgaySinh] date NULL,
    [DiaChiThuongTru] nvarchar(80) NULL,
    [QueQuan] nvarchar(80) NULL,
    [Email] nvarchar(150) NOT NULL,
    [SoDienThoai] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_GiangVien] PRIMARY KEY ([MaGiangVien]),
    CONSTRAINT [FK_GiangVien_BoMon_MaBoMon] FOREIGN KEY ([MaBoMon]) REFERENCES [BoMon] ([MaBoMon]) ON DELETE CASCADE
);
GO

CREATE TABLE [MonHoc] (
    [MaMonHoc] int NOT NULL IDENTITY,
    [TenMonHoc] nvarchar(60) NOT NULL,
    [SoTinChi] tinyint NOT NULL,
    [BatBuoc] bit NOT NULL,
    [MoTa] nvarchar(max) NULL,
    [MaMonTienQuyet] int NULL,
    [MaBoMon] int NOT NULL,
    CONSTRAINT [PK_MonHoc] PRIMARY KEY ([MaMonHoc]),
    CONSTRAINT [FK_MonHoc_BoMon_MaBoMon] FOREIGN KEY ([MaBoMon]) REFERENCES [BoMon] ([MaBoMon]) ON DELETE CASCADE,
    CONSTRAINT [FK_MonHoc_MonHoc_MaMonTienQuyet] FOREIGN KEY ([MaMonTienQuyet]) REFERENCES [MonHoc] ([MaMonHoc])
);
GO

CREATE TABLE [BoMonKhoa] (
    [BoMonsMaBoMon] int NOT NULL,
    [KhoaMaKhoa] int NOT NULL,
    CONSTRAINT [PK_BoMonKhoa] PRIMARY KEY ([BoMonsMaBoMon], [KhoaMaKhoa]),
    CONSTRAINT [FK_BoMonKhoa_BoMon_BoMonsMaBoMon] FOREIGN KEY ([BoMonsMaBoMon]) REFERENCES [BoMon] ([MaBoMon]) ON DELETE CASCADE,
    CONSTRAINT [FK_BoMonKhoa_Khoa_KhoaMaKhoa] FOREIGN KEY ([KhoaMaKhoa]) REFERENCES [Khoa] ([MaKhoa]) ON DELETE CASCADE
);
GO

CREATE TABLE [NguoiDung_VaiTro] (
    [TenNguoiDung] nvarchar(50) NOT NULL,
    [TenVaiTro] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_NguoiDung_VaiTro] PRIMARY KEY ([TenNguoiDung], [TenVaiTro]),
    CONSTRAINT [FK_NguoiDung_VaiTro_NguoiDung_TenNguoiDung] FOREIGN KEY ([TenNguoiDung]) REFERENCES [NguoiDung] ([TenNguoiDung]) ON DELETE CASCADE,
    CONSTRAINT [FK_NguoiDung_VaiTro_VaiTro_TenVaiTro] FOREIGN KEY ([TenVaiTro]) REFERENCES [VaiTro] ([TenVaiTro]) ON DELETE CASCADE
);
GO

CREATE TABLE [LopQuanLi] (
    [MaLopQuanLi] int NOT NULL IDENTITY,
    [TenLopQuanLi] nvarchar(20) NOT NULL,
    [MaGiangVien] int NULL,
    [MaKhoa] int NOT NULL,
    CONSTRAINT [PK_LopQuanLi] PRIMARY KEY ([MaLopQuanLi]),
    CONSTRAINT [FK_LopQuanLi_GiangVien_MaGiangVien] FOREIGN KEY ([MaGiangVien]) REFERENCES [GiangVien] ([MaGiangVien]),
    CONSTRAINT [FK_LopQuanLi_Khoa_MaKhoa] FOREIGN KEY ([MaKhoa]) REFERENCES [Khoa] ([MaKhoa]) ON DELETE CASCADE
);
GO

CREATE TABLE [LopMonHoc] (
    [MaLopMonHoc] int NOT NULL IDENTITY,
    [TenLopMonHoc] nvarchar(10) NOT NULL,
    [MaMonHoc] int NOT NULL,
    [MaGiangVien] int NOT NULL,
    CONSTRAINT [PK_LopMonHoc] PRIMARY KEY ([MaLopMonHoc]),
    CONSTRAINT [FK_LopMonHoc_GiangVien_MaGiangVien] FOREIGN KEY ([MaGiangVien]) REFERENCES [GiangVien] ([MaGiangVien]),
    CONSTRAINT [FK_LopMonHoc_MonHoc_MaMonHoc] FOREIGN KEY ([MaMonHoc]) REFERENCES [MonHoc] ([MaMonHoc])
);
GO

CREATE TABLE [SinhVien] (
    [MaSinhVien] int NOT NULL IDENTITY,
    [NgayVaoTruong] date NOT NULL,
    [LopQuanLiMaLopQuanLi] int NOT NULL,
    [MaLopQuanLi] int NOT NULL,
    [HoTen] nvarchar(40) NOT NULL,
    [GioiTinh] bit NOT NULL,
    [NgaySinh] date NULL,
    [DiaChiThuongTru] nvarchar(80) NULL,
    [QueQuan] nvarchar(80) NULL,
    [Email] nvarchar(150) NOT NULL,
    [SoDienThoai] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_SinhVien] PRIMARY KEY ([MaSinhVien]),
    CONSTRAINT [FK_SinhVien_LopQuanLi_LopQuanLiMaLopQuanLi] FOREIGN KEY ([LopQuanLiMaLopQuanLi]) REFERENCES [LopQuanLi] ([MaLopQuanLi]) ON DELETE CASCADE
);
GO

CREATE TABLE [DiemSinhVien] (
    [MaLopMonHoc] int NOT NULL,
    [MaSinhVien] int NOT NULL,
    [DiemChuyenCan] real NOT NULL,
    [DiemGiuaKi] real NOT NULL,
    [DiemCuoiKi] real NOT NULL,
    [HocKi] tinyint NOT NULL,
    [GhiChu] text NULL,
    CONSTRAINT [PK_DiemSinhVien] PRIMARY KEY ([MaLopMonHoc], [MaSinhVien]),
    CONSTRAINT [FK_DiemSinhVien_LopMonHoc_MaLopMonHoc] FOREIGN KEY ([MaLopMonHoc]) REFERENCES [LopMonHoc] ([MaLopMonHoc]),
    CONSTRAINT [FK_DiemSinhVien_SinhVien_MaSinhVien] FOREIGN KEY ([MaSinhVien]) REFERENCES [SinhVien] ([MaSinhVien])
);
GO

CREATE INDEX [IX_BoMonKhoa_KhoaMaKhoa] ON [BoMonKhoa] ([KhoaMaKhoa]);
GO

CREATE INDEX [IX_DiemSinhVien_MaSinhVien] ON [DiemSinhVien] ([MaSinhVien]);
GO

CREATE UNIQUE INDEX [IX_GiangVien_Email] ON [GiangVien] ([Email]);
GO

CREATE INDEX [IX_GiangVien_MaBoMon] ON [GiangVien] ([MaBoMon]);
GO

CREATE UNIQUE INDEX [IX_GiangVien_SoDienThoai] ON [GiangVien] ([SoDienThoai]);
GO

CREATE UNIQUE INDEX [IX_Khoa_TenKhoa] ON [Khoa] ([TenKhoa]);
GO

CREATE INDEX [IX_LopMonHoc_MaGiangVien] ON [LopMonHoc] ([MaGiangVien]);
GO

CREATE INDEX [IX_LopMonHoc_MaMonHoc] ON [LopMonHoc] ([MaMonHoc]);
GO

CREATE UNIQUE INDEX [IX_LopQuanLi_MaGiangVien] ON [LopQuanLi] ([MaGiangVien]) WHERE [MaGiangVien] IS NOT NULL;
GO

CREATE INDEX [IX_LopQuanLi_MaKhoa] ON [LopQuanLi] ([MaKhoa]);
GO

CREATE INDEX [IX_MonHoc_MaBoMon] ON [MonHoc] ([MaBoMon]);
GO

CREATE INDEX [IX_MonHoc_MaMonTienQuyet] ON [MonHoc] ([MaMonTienQuyet]);
GO

CREATE INDEX [IX_NguoiDung_VaiTro_TenVaiTro] ON [NguoiDung_VaiTro] ([TenVaiTro]);
GO

CREATE UNIQUE INDEX [IX_SinhVien_Email] ON [SinhVien] ([Email]);
GO

CREATE INDEX [IX_SinhVien_LopQuanLiMaLopQuanLi] ON [SinhVien] ([LopQuanLiMaLopQuanLi]);
GO

CREATE UNIQUE INDEX [IX_SinhVien_SoDienThoai] ON [SinhVien] ([SoDienThoai]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230828031854_RemoveBangTenTiengAnh', N'7.0.10');
GO

COMMIT;
GO

