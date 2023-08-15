-- Active: 1690861638105@@127.0.0.1@1433@qlsinhvien
CREATE DATABASE QLSinhVien
USE QLSinhVien
GO

CREATE TABLE
    Khoa (
        ma_khoa INT PRIMARY KEY AUTO_INCREMENT,
        ten_khoa VARCHAR(120) UNIQUE
    );

CREATE TABLE
    MonHoc (
        ma_mon_hoc INT PRIMARY KEY AUTO_INCREMENT,
        ten_mon_hoc VARCHAR(60),
        so_tin_chi TINYINT,
        bat_buoc BIT,
        mon_tien_quyet INT,
        mo_ta TEXT,
        CONSTRAINT FK_mon_tienquyet Foreign Key (mon_tien_quyet) REFERENCES MonHoc(ma_mon_hoc),
        CONSTRAINT UK_monhoc UNIQUE (ma_mon_hoc, ten_mon_hoc)
    );

CREATE TABLE
    Khoa_MonHoc (
        ma_mon_hoc INT,
        ma_khoa INT,
        PRIMARY KEY(ma_mon_hoc, ma_khoa),
        Foreign Key (ma_mon_hoc) REFERENCES MonHoc(ma_mon_hoc),
        Foreign Key (ma_khoa) REFERENCES Khoa(ma_khoa)
    );

CREATE TABLE
    GiangVien (
        ma_gv INT PRIMARY KEY AUTO_INCREMENT,
        ho_ten VARCHAR(100),
        gioi_tinh BIT,
        ngay_sinh DATE,
        dia_chi_hien_tai VARCHAR(200),
        que_quan VARCHAR(200),
        email VARCHAR(40) UNIQUE,
        so_dien_thoai VARCHAR(10) UNIQUE,
        ma_khoa INT NOT NULL,
        Foreign Key (ma_khoa) REFERENCES Khoa(ma_khoa)
    );

CREATE TABLE
    LopMonHoc (
        ma_lop_mon_hoc INT PRIMARY KEY AUTO_INCREMENT,
        ten_lop_mon_hoc VARCHAR(10) NOT NULL,
        ma_mon_hoc INT,
        ma_gv INT,
        Foreign Key (ma_mon_hoc) REFERENCES MonHoc(ma_mon_hoc),
        Foreign Key (ma_gv) REFERENCES GiangVien(ma_gv)
    );

CREATE TABLE
    LopQuanLi (
        ma_lop_quan_li INT PRIMARY KEY AUTO_INCREMENT,
        ma_gv INT,
        ma_khoa INT,
        ten_lop_quan_li VARCHAR(20) UNIQUE,
        Foreign Key (ma_khoa) REFERENCES khoa(ma_khoa),
        Foreign Key (ma_gv) REFERENCES giangvien(ma_gv)
    );

CREATE TABLE
    SinhVien (
        mssv INT PRIMARY KEY AUTO_INCREMENT,
        ho_ten VARCHAR(100),
        gioi_tinh BIT,
        ma_lop_quan_li INT,
        ngay_sinh DATE,
        dia_chi_thuong_tru VARCHAR(200),
        que_quan VARCHAR(200),
        email VARCHAR(30) UNIQUE,
        so_dien_thoai CHAR(10) UNIQUE,
        ngay_vao_truong DATE,
        Foreign Key (ma_lop_quan_li) REFERENCES LopQuanLi(ma_lop_quan_li)
    );

CREATE TABLE
    DiemSinhVien (
        ma_lop_mon_hoc INT,
        mssv INT,
        diem_chuyen_can FLOAT,
        diem_giua_ki FLOAT,
        diem_cuoi_ki FLOAT,
        hoc_ki INT,
        ghi_chu TEXT,
        PRIMARY KEY(ma_lop_mon_hoc, mssv),
        Foreign Key (ma_lop_mon_hoc) REFERENCES LopMonHoc(ma_lop_mon_hoc),
        Foreign Key (mssv) REFERENCES SinhVien(mssv)
    );