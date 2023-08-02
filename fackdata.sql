-- Active: 1690861638105@@127.0.0.1@1433@qlsinhvien
INSERT INTO [GiangVien] ([HoTen], [GioiTinh], [NgaySinh], [DiaChiThuongTru], [QueQuan], [Email], [PhoneNumber])
VALUES
  ('Nguyễn Trung Hoà', 1, '1980-05-21', 'Đà Nẵng', 'Huế', 'hoanguyen@example.com', '0123456789'),
  ('Đặng Trường Nam', 1, '1975-12-03', 'Hồ Chí Minh', 'Quảng Nam', 'namdang@example.com', '0987654321'),
  ('Phạm Thị Thu Trang', 0, '1995-08-12', 'Hà Nội', 'Hải Phòng', 'trangpham@example.com', '0369874521'),
  ('Trần Văn Anh', 1, '1965-02-28', 'Cần Thơ', 'Sóc Trăng', 'anhtran@example.com', '0562314789'),
  ('Vũ Thị Hồng', 0, '1988-09-17', 'Hải Dương', 'Bắc Ninh', 'hongvu@example.com', '0963142578'),
  ('Lê Quang Minh', 1, '1973-06-11', 'Ninh Bình', 'Thái Bình', 'minhle@example.com', '0987123456'),
  ('Mai Thế Dũng', 1, '1968-11-30', 'Hà Giang', 'Cao Bằng', 'dungmai@example.com', '0912345678'),
  ('Nguyễn Thị Tâm', 0, '1990-03-25', 'Đồng Nai', 'Bình Dương', 'tamnguyen@example.com', '0332581476'),
  ('Trương Hữu Thành', 1, '1970-10-09', 'Bà Rịa - Vũng Tàu', 'Cần Giờ', 'thanht[email protected]', '0965324871'),
  ('Lý Văn Tú', 1, '1985-07-14', 'Đắk Lắk', 'Khánh Hòa', 'tuly@example.com', '0987412365');

INSERT INTO [Khoa] ([TenKhoa])
VALUES
  (N'Khoa Kỹ Thuật Công Nghệ Thông Tin'),
  (N'Khoa Kinh Tế'),
  (N'Khoa Khoa Học Xã Hội'),
  (N'Khoa Khoa Học Tự Nhiên'),
  (N'Khoa Ngoại Ngữ');

INSERT INTO [MonHoc] ([TenMonHoc], [SoTinChi], [BatBuoc], [MoTa], [MaMonTienQuyet])
VALUES
  (N'Tiếng Anh 1', 3, 1, N'Học tiếng Anh cơ bản cấp độ 1', NULL),
  (N'Tiếng Anh 2', 3, 1, N'Tiếp tục học tiếng Anh cấp độ 2', NULL),
  (N'Tin học đại cương', 2, 1, N'Học tin học căn bản', NULL),
  (N'Lập trình căn bản', 3, 1, N'Học lập trình cơ bản', NULL),
  (N'Cơ sở dữ liệu', 3, 1, N'Học về cơ sở dữ liệu', NULL),
  (N'Lập trình nâng cao', 3, 1, N'Học lập trình nâng cao', 4),
  (N'Xây dựng website', 2, 1, N'Học xây dựng website cơ bản', 4),
  (N'Hệ điều hành', 3, 1, N'Học về hệ điều hành', NULL),
  (N'Thực tập công nghệ phần mềm', 3, 0, N'Thực tập công nghệ phần mềm tại công ty ABC', NULL),
  (N'Thực tập tốt nghiệp', 2, 0, N'Thực tập tốt nghiệp tại công ty XYZ', NULL);

INSERT INTO [LopQuanLi] ([TenLopQuanLi], [MaGiangVien], [MaKhoa])
VALUES
  (N'66IT5', 1, 2),
  (N'68KT1', 2, 3),
  (N'66IT3', 3, 1),
  (N'68KT2', 1, 3),
  (N'67KT1', 2, 3),
  (N'67IT1', 4, 1),
  (N'69IT1', 3, 1),
  (N'69KT1', 5, 3),
  (N'66KT1', 1, 3),
  (N'69KT2', 2, 3);

INSERT INTO [KhoaMonHoc] ([MaKhoa], [MaMonHoc])
VALUES
  (1, 3),
  (2, 3),
  (3, 3),
  (1, 5),
  (2, 5),
  (3, 6),
  (1, 7),
  (2, 8),
  (3, 8),
  (3, 9);

INSERT INTO [LopMonHoc] ([TenLopMonHoc], [MaMonHoc], [MaGiangVien])
VALUES
  (N'Lop 1A', 3, 1),
  (N'Lop 1B', 7, 2),
  (N'Lop 2A', 3, 3),
  (N'Lop 2B', 4, 1),
  (N'Lop 3A', 5, 2),
  (N'Lop 3B', 6, 3),
  (N'Lop 4A', 7, 4),
  (N'Lop 4B', 8, 5),
  (N'Lop 5A', 9, 1),
  (N'Lop 5B', 10, 2);

INSERT INTO [SinhVien] ([NgayVaoTruong], [MaLopQuanLi], [HoTen], [GioiTinh], [NgaySinh], [DiaChiThuongTru], [QueQuan], [Email], [PhoneNumber])
VALUES
  ('2008-09-01', 1, N'Nguyễn Văn An', 1, '1995-03-15', N'Hà Nội', N'Hưng Yên', N'nguyenvanan@gmail.com', '0987654321'),
  ('2009-08-15', 2, N'Phạm Thị Bình', 0, '1996-07-10', N'Thái Bình', N'Thái Bình', N'phamthibinh@gmail.com', '0976543210'),
  ('2010-09-01', 3, N'Lê Thành Công', 1, '1997-05-20', N'Hồ Chí Minh', N'Hà Nội', N'lethanhcong@gmail.com', '0965432109'),
  ('2007-08-20', 4, N'Trần Thị Diễm', 0, '1998-12-25', N'Hà Nội', N'Hưng Yên', N'tranthidiem@gmail.com', '0954321098'),
  ('2008-09-01', 5, N'Đỗ Thị Ðào', 0, '1999-09-05', N'Hải Phòng', N'Thái Bình', N'dothidao@gmail.com', '0943210987'),
  ('2011-08-15', 6, N'Vũ Văn Ðức', 1, '1995-08-30', N'Hưng Yên', N'Hưng Yên', N'vuvanduc@gmail.com', '0932109876'),
  ('2009-09-01', 7, N'Nguyễn Thị Hạnh', 0, '1996-03-05', N'Hồ Chí Minh', N'Thái Bình', N'nguyenthihanh@gmail.com', '0921098765'),
  ('2008-08-20', 8, N'Phạm Văn Hiếu', 1, '1997-07-20', N'Hà Nội', N'Hưng Yên', N'phamvanhieu@gmail.com', '0910987654'),
  ('2010-09-01', 9, N'Lê Thị Huệ', 0, '1998-05-15', N'Hồ Chí Minh', N'Hà Nội', N'lethihue@gmail.com', '0909876543'),
  ('2011-08-15', 10, N'Trần Văn Khánh', 1, '1999-04-10', N'Hưng Yên', N'Thái Bình', N'tranvankhanh@gmail.com', '0898765432'),
  ('2008-09-01', 1, N'Lê Thị Lý', 0, '1995-03-25', N'Hồ Chí Minh', N'Hưng Yên', N'lethily@gmail.com', '0887654321'),
  ('2009-08-15', 2, N'Vũ Thành Minh', 1, '1996-06-20', N'Hà Nội', N'Thái Bình', N'vuthanhminh@gmail.com', '0876543210'),
  ('2010-09-01', 3, N'Trương Hoàng Nam', 1, '1997-05-05', N'Hồ Chí Minh', N'Hà Nội', N'truonghoangnam@gmail.com', '0865432109'),
  ('2007-08-20', 4, N'Nguyễn Thị Ngọc', 0, '1998-12-10', N'Hưng Yên', N'Hưng Yên', N'nguyenthingoc@gmail.com', '0854321098'),
  ('2008-09-01', 5, N'Đỗ Văn Ðức', 1, '1999-10-20', N'Thái Bình', N'Hà Nội', N'dovanduc@gmail.com', '0843210987'),
  ('2011-08-15', 6, N'Trần Thị Oanh', 0, '1995-09-15', N'Hồ Chí Minh', N'Thái Bình', N'tranthioanh@gmail.com', '0832109876'),
  ('2009-09-01', 7, N'Nguyễn Văn Phong', 1, '1996-04-05', N'Hưng Yên', N'Hưng Yên', N'nguyenvanphong@gmail.com', '0821098765'),
  ('2008-08-20', 8, N'Phạm Thị Quỳnh', 0, '1997-08-10', N'Hồ Chí Minh', N'Hà Nội', N'phamthiquynh@gmail.com', '0810987654'),
  ('2010-09-01', 9, N'Lê Thị Quyên', 1, '1998-07-20', N'Hưng Yên', N'Thái Bình', N'lethiquyen@gmail.com', '0809876543'),
  ('2011-08-15', 10, N'Trần Văn Rạng', 1, '1999-06-25', N'Hà Nội', N'Thái Bình', N'tranvanrang@gmail.com', '0798765432'),
  ('2008-09-01', 1, N'Vũ Thị Sáng', 0, '1995-02-10', N'Hồ Chí Minh', N'Hưng Yên', N'vuthisang@gmail.com', '0787654321'),
  ('2009-08-15', 2, N'Trần Hoàng Sơn', 1, '1996-09-05', N'Hưng Yên', N'Hưng Yên', N'tranhoangson@gmail.com', '0776543210'),
  ('2010-09-01', 3, N'Trương Văn Tùng', 1, '1997-08-15', N'Hồ Chí Minh', N'Hưng Yên', N'truongvantung@gmail.com', '0765432109'),
  ('2007-08-20', 4, N'Nguyễn Thị Út', 0, '1998-11-20', N'Thái Bình', N'Thái Bình', N'nguyenthaut@gmail.com', '0754321098'),
  ('2008-09-01', 5, N'Đỗ Văn Ðức', 1, '1999-07-05', N'Hà Nội', N'Hà Nội', N'dovanduc@gmail.com', '0743210987'),
  ('2011-08-15', 6, N'Trần Thị Út', 0, '1995-06-10', N'Hưng Yên', N'Thái Bình', N'tranthiut@gmail.com', '0732109876'),
  ('2009-09-01', 7, N'Nguyễn Thị Vân', 0, '1996-05-15', N'Hồ Chí Minh', N'Thái Bình', N'nguyenthivan@gmail.com', '0721098765'),
  ('2008-08-20', 8, N'Phạm Thị Xuân', 1, '1997-10-30', N'Hưng Yên', N'Hà Nội', N'phamthixuan@gmail.com', '0710987654'),
  ('2010-09-01', 9, N'Lê Thị Xuân', 0, '1998-06-25', N'Hồ Chí Minh', N'Thái Bình', N'lethixuan@gmail.com', '0709876543'),
  ('2011-08-15', 10, N'Trần Thị Yến', 0, '1999-05-15', N'Hà Nội', N'Thái Bình', N'tranthiyen@gmail.com', '0798765432');

INSERT INTO [DiemSinhVien] ([MaLopMonHoc], [MaSinhVien], [DiemChuyenCan], [DiemGiuaKi], [DiemCuoiKi], [HocKi], [GhiChu])
VALUES
  (2, 1, 8.5, 7.0, 9.0, 1, N'Tốt'),
  (3, 2, 6.0, 7.5, 8.0, 2, N'Khá'),
  (4, 3, 7.5, 8.0, 9.5, 1, N'Giỏi'),
  (5, 4, 9.0, 8.5, 9.0, 2, N'Tốt'),
  (6, 5, 6.5, 6.0, 7.0, 1, N'Khá'),
  (7, 6, 8.0, 9.0, 9.5, 2, N'Giỏi'),
  (8, 7, 7.0, 7.5, 8.0, 1, N'Tốt'),
  (9, 8, 8.5, 9.0, 9.0, 2, N'Khá'),
  (10, 9, 5.5, 6.0, 6.5, 1, N'Yếu'),
  (11, 10, 9.5, 9.0, 9.5, 2, N'Giỏi'),
  (2, 11, 6.0, 7.0, 7.5, 1, N'Khá'),
  (3, 12, 8.0, 8.5, 8.0, 2, N'Tốt'),
  (4, 13, 7.5, 8.0, 8.5, 1, N'Giỏi'),
  (5, 14, 6.5, 7.0, 7.0, 2, N'Khá'),
  (6, 15, 9.0, 8.5, 8.0, 1, N'Tốt'),
  (7, 16, 7.0, 7.5, 7.5, 2, N'Khá'),
  (8, 17, 8.5, 9.0, 9.0, 1, N'Giỏi'),
  (9, 18, 6.5, 7.0, 7.5, 2, N'Tốt'),
  (10, 19, 7.0, 7.5, 8.0, 1, N'Khá'),
  (11, 20, 8.0, 8.5, 9.0, 2, N'Giỏi'),
  (2, 21, 8.5, 9.0, 9.5, 1, N'Tốt'),
  (3, 22, 7.0, 7.5, 8.0, 2, N'Khá'),
  (4, 23, 8.0, 8.0, 8.5, 1, N'Giỏi'),
  (5, 24, 6.5, 7.0, 7.0, 2, N'Khá'),
  (6, 25, 9.0, 9.5, 9.0, 1, N'Tốt'),
  (7, 26, 7.5, 8.0, 8.0, 2, N'Khá'),
  (8, 27, 8.5, 9.0, 9.5, 1, N'Giỏi'),
  (9, 28, 6.0, 6.5, 7.0, 2, N'Tốt'),
  (10, 29, 7.0, 7.5, 8.0, 1, N'Khá'),
  (11, 30, 9.5, 9.0, 9.5, 2, N'Giỏi');
