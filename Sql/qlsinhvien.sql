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

CREATE TABLE [GiangVien] (
    [MaGiangVien] int NOT NULL IDENTITY,
    [HoTen] nvarchar(40) NOT NULL,
    [GioiTinh] bit NOT NULL,
    [NgaySinh] datetime2 NOT NULL,
    [DiaChiThuongTru] nvarchar(80) NOT NULL,
    [QueQuan] nvarchar(80) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    [SoDienThoai] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_GiangVien] PRIMARY KEY ([MaGiangVien])
);
GO

CREATE TABLE [Khoa] (
    [MaKhoa] int NOT NULL IDENTITY,
    [TenKhoa] nvarchar(80) NOT NULL,
    CONSTRAINT [PK_Khoa] PRIMARY KEY ([MaKhoa])
);


CREATE TABLE [MonHoc] (
    [MaMonHoc] int NOT NULL IDENTITY,
    [TenMonHoc] nvarchar(60) NOT NULL,
    [SoTinChi] tinyint NOT NULL,
    [BatBuoc] bit NOT NULL,
    [MoTa] nvarchar(max) NULL,
    [MaMonTienQuyet] int NULL,
    CONSTRAINT [PK_MonHoc] PRIMARY KEY ([MaMonHoc]),
    CONSTRAINT [FK_MonHoc_MonHoc_MaMonTienQuyet] FOREIGN KEY ([MaMonTienQuyet]) REFERENCES [MonHoc] ([MaMonHoc])
);
GO

CREATE TABLE [LopQuanLi] (
    [MaLopQuanLi] int NOT NULL IDENTITY,
    [TenLopQuanLi] nvarchar(20) NOT NULL,
    [MaGiangVien] int NOT NULL,
    [MaKhoa] int NOT NULL,
    CONSTRAINT [PK_LopQuanLi] PRIMARY KEY ([MaLopQuanLi]),
    CONSTRAINT [FK_LopQuanLi_GiangVien_MaGiangVien] FOREIGN KEY ([MaGiangVien]) REFERENCES [GiangVien] ([MaGiangVien]) ON DELETE CASCADE,
    CONSTRAINT [FK_LopQuanLi_Khoa_MaKhoa] FOREIGN KEY ([MaKhoa]) REFERENCES [Khoa] ([MaKhoa]) ON DELETE CASCADE
);
GO

CREATE TABLE [Khoa-MonHoc] (
    [MaKhoa] int NOT NULL,
    [MaMonHoc] int NOT NULL,
    CONSTRAINT [PK_Khoa-MonHoc] PRIMARY KEY ([MaKhoa], [MaMonHoc]),
    CONSTRAINT [FK_Khoa-MonHoc_Khoa_MaKhoa] FOREIGN KEY ([MaKhoa]) REFERENCES [Khoa] ([MaKhoa]) ON DELETE CASCADE,
    CONSTRAINT [FK_Khoa-MonHoc_MonHoc_MaMonHoc] FOREIGN KEY ([MaMonHoc]) REFERENCES [MonHoc] ([MaMonHoc]) ON DELETE CASCADE
);
GO

CREATE TABLE [LopMonHoc] (
    [MaLopMonHoc] int NOT NULL IDENTITY,
    [TenLopMonHoc] nvarchar(10) NOT NULL,
    [MaMonHoc] int NOT NULL,
    [MaGiangVien] int NOT NULL,
    CONSTRAINT [PK_LopMonHoc] PRIMARY KEY ([MaLopMonHoc]),
    CONSTRAINT [FK_LopMonHoc_GiangVien_MaGiangVien] FOREIGN KEY ([MaGiangVien]) REFERENCES [GiangVien] ([MaGiangVien]) ON DELETE CASCADE,
    CONSTRAINT [FK_LopMonHoc_MonHoc_MaMonHoc] FOREIGN KEY ([MaMonHoc]) REFERENCES [MonHoc] ([MaMonHoc]) ON DELETE CASCADE
);
GO

CREATE TABLE [SinhVien] (
    [MaSinhVien] int NOT NULL IDENTITY,
    [NgayVaoTruong] datetime2 NOT NULL,
    [MaLopQuanLi] int NOT NULL,
    [HoTen] nvarchar(40) NOT NULL,
    [GioiTinh] bit NOT NULL,
    [NgaySinh] datetime2 NOT NULL,
    [DiaChiThuongTru] nvarchar(80) NOT NULL,
    [QueQuan] nvarchar(80) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    [SoDienThoai] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_SinhVien] PRIMARY KEY ([MaSinhVien]),
    CONSTRAINT [FK_SinhVien_LopQuanLi_MaLopQuanLi] FOREIGN KEY ([MaLopQuanLi]) REFERENCES [LopQuanLi] ([MaLopQuanLi]) ON DELETE CASCADE
);
GO

CREATE TABLE [DiemSinhVien] (
    [MaLopMonHoc] int NOT NULL,
    [MaSinhVien] int NOT NULL,
    [DiemChuyenCan] real NOT NULL,
    [DiemGiuaKi] real NOT NULL,
    [DiemCuoiKi] real NOT NULL,
    [HocKi] int NOT NULL,
    [GhiChu] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DiemSinhVien] PRIMARY KEY ([MaLopMonHoc], [MaSinhVien]),
    CONSTRAINT [FK_DiemSinhVien_LopMonHoc_MaLopMonHoc] FOREIGN KEY ([MaLopMonHoc]) REFERENCES [LopMonHoc] ([MaLopMonHoc]),
    CONSTRAINT [FK_DiemSinhVien_SinhVien_MaSinhVien] FOREIGN KEY ([MaSinhVien]) REFERENCES [SinhVien] ([MaSinhVien])
);
GO

CREATE INDEX [IX_DiemSinhVien_MaSinhVien] ON [DiemSinhVien] ([MaSinhVien]);
GO

CREATE INDEX [IX_Khoa-MonHoc_MaMonHoc] ON [Khoa-MonHoc] ([MaMonHoc]);
GO

CREATE INDEX [IX_LopMonHoc_MaGiangVien] ON [LopMonHoc] ([MaGiangVien]);
GO

CREATE INDEX [IX_LopMonHoc_MaMonHoc] ON [LopMonHoc] ([MaMonHoc]);
GO

CREATE UNIQUE INDEX [IX_LopQuanLi_MaGiangVien] ON [LopQuanLi] ([MaGiangVien]);
GO

CREATE INDEX [IX_LopQuanLi_MaKhoa] ON [LopQuanLi] ([MaKhoa]);
GO

CREATE INDEX [IX_MonHoc_MaMonTienQuyet] ON [MonHoc] ([MaMonTienQuyet]);
GO

CREATE INDEX [IX_SinhVien_MaLopQuanLi] ON [SinhVien] ([MaLopQuanLi]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230804034129_qlsinhvien', N'7.0.9');
GO

COMMIT;
GO

ALTER TABLE
    [giangvien] ADD [MaKhoa] INT,
    CONSTRAINT [FK_GiangVien_Khoa_MaKhoa] FOREIGN KEY ([MaKhoa]) REFERENCES [Khoa] ([MaKhoa]);
go
