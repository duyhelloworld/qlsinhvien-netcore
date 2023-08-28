-- Active: 1692198311467@@127.0.0.1@1433@qlsinhvien
INSERT INTO [Khoa] ([TenKhoa])
VALUES
  (N'Khoa Công Nghệ Thông Tin'),
  (N'Khoa Kinh Tế'),
  (N'Khoa Khoa Học Xã Hội'),
  (N'Khoa Khoa Học Tự Nhiên'),
  (N'Khoa Ngoại Ngữ');

INSERT INTO [BoMon] ([TenBoMon])
VALUES
  (N'Công nghệ phần mềm'),
  (N'Ngoại ngữ'),
  (N'Hệ thống thông tin'),
  (N'Kĩ thuật máy tính'),
  (N'Công nghệ sinh học'), 
  (N'Khoa học dữ liệu'),
  (N'Công nghệ thực phẩm'),
  (N'Vi sinh - Hoá sinh - SH phân tử'),
  (N'Khoa học chính trị'),
  (N'Tâm lí xã hội'),
  (N'Kinh tế - Tài chính'), 
  (N'Kinh tế học'),
  (N'Kinh tế thủy sản'),
  (N'Kinh doanh thương mại'), 
  (N'Quản trị kinh doanh'), 
  (N'Marketing'),
  (N'Dịch thuật, Văn hoá và Lí thuyết tiếng');

INSERT INTO [BoMonKhoa] ([KhoaMaKhoa], [BoMonsMaBoMon])
VALUES   
  (1, 1),
  (1, 3),
  (1, 4),
  (1, 6),
  (2, 11),
  (2, 12),
  (2, 13),
  (2, 14),
  (2, 15), 
  (2, 16),
  (3, 9),
  (3, 10), 
  (3, 12),
  (4, 5),
  (4, 7), 
  (4, 8),
  (5, 2),
  (5, 17);

INSERT INTO [GiangVien] ([HoTen], [GioiTinh], [NgaySinh], [DiaChiThuongTru], [QueQuan], [Email], [SoDienThoai], [MaBoMon])
VALUES
  ('Nguyễn Trung Hoà', 1, '1980-05-21', 'Đà Nẵng', 'Huế', 'hoanguyen@example.com', '0123456789', 2),
  ('Đặng Trường Nam', 1, '1975-12-03', 'Hồ Chí Minh', 'Quảng Nam', 'namdang@example.com', '0987654321', 3),
  ('Phạm Thị Thu Trang', 0, '1995-08-12', 'Hà Nội', 'Hải Phòng', 'trangpham@example.com', '0369874521', 3),
  ('Trần Văn Anh', 1, '1965-02-28', 'Cần Thơ', 'Sóc Trăng', 'anhtran@example.com', '0562314789', 2),
  ('Vũ Thị Hồng', 0, '1988-09-17', 'Hải Dương', 'Bắc Ninh', 'hongvu@example.com', '0963142578', 1),
  ('Lê Quang Minh', 1, '1973-06-11', 'Ninh Bình', 'Thái Bình', 'minhle@example.com', '0987123456', 1),
  ('Mai Thế Dũng', 1, '1968-11-30', 'Hà Giang', 'Cao Bằng', 'dungmai@example.com', '0912345678', 3),
  ('Nguyễn Thị Tâm', 0, '1990-03-25', 'Đồng Nai', 'Bình Dương', 'tamnguyen@example.com', '0332581476', 3),
  ('Trương Hữu Thành', 1, '1970-10-09', 'Bà Rịa - Vũng Tàu', 'Cần Giờ', 'thanht[email protected]', '0965324871', 2),
  ('Lý Văn Tú', 1, '1985-07-14', 'Đắk Lắk', 'Khánh Hòa', 'tuly@example.com', '0987412365', 1);

INSERT INTO [MonHoc] ([TenMonHoc], [SoTinChi], [BatBuoc], [MoTa], [MaMonTienQuyet], [MaBoMon])
VALUES
  (N'Sinh học tế bào và phân tử', 3, 1, NULL, NULL, 5),
  (N'Vi sinh học', 3, 1, NULL, NULL, 8),
  (N'Hóa sinh', 3, 1, NULL, NULL, 8),
  (N'Kỹ thuật di truyền', 3, 1, NULL, NULL, 5),
  (N'Kiến trúc dữ liệu và cơ sở dữ liệu', 3, 1, NULL, NULL, 6),
  (N'Thu thập và xử lý dữ liệu lớn', 3, 1, NULL, NULL, 6),
  (N'Phân tích dữ liệu thống kê', 3, 1, NULL, NULL, 6),
  (N'Học máy', 3, 1, NULL, NULL, 6),
  (N'Thị giác máy tính', 3, 1, NULL, NULL, 6),
  (N'Khoa học ngôn ngữ tự nhiên', 3, 1, NULL, NULL, 6),
  (N'Xử lý ngôn ngữ tự nhiên', 3, 1, NULL, NULL, 6),
  (N'Hóa học thực phẩm', 3, 1, NULL, NULL, 7),
  (N'Sinh học thực phẩm', 3, 1, NULL, NULL, 7),
  (N'Vật lý thực phẩm', 3, 1, NULL, NULL, 7),
  (N'An toàn thực phẩm', 3, 1, NULL, NULL, 7),
  (N'Kỹ thuật chế biến thực phẩm', 3, 1, NULL, NULL, 7),
  (N'Quản lý chất lượng thực phẩm', 3, 1, NULL, NULL, 7),
  (N'Tâm lý học xã hội', 3, 1, NULL, NULL, 10),
  (N'Tâm lý học nhận thức', 3, 1, NULL, NULL, 10),
  (N'Tâm lý học phát triển', 3, 1, NULL, NULL, 10),
  (N'Tâm lý học nhân cách', 3, 1, NULL, NULL, 10),
  (N'Tâm lý học giáo dục', 3, 1, NULL, NULL, 10),
  (N'Tâm lý học kinh doanh', 3, 1, NULL, NULL, 10),
  (N'Tâm lý học quản lý', 3, 1, NULL, NULL, 10),
  (N'Kinh tế vi mô', 3, 1, NULL, NULL, 11),
  (N'Kinh tế vĩ mô', 3, 1, NULL, NULL, 11),
  (N'Nguyên lý kế toán', 3, 1, NULL, NULL, 11),
  (N'Tài chính doanh nghiệp', 3, 1, NULL, NULL, 11),
  (N'Quản trị tài chính', 3, 1, NULL, NULL, 11),
  (N'Phân tích đầu tư', 3, 1, NULL, NULL, 11),
  (N'Kinh tế quốc tế', 3, 1, NULL, NULL, 11),
  (N'Kinh tế phát triển', 3, 1, NULL, NULL, 11),
  (N'Kinh tế môi trường', 3, 1, NULL, NULL, 11),
  (N'Marketing căn bản', 3, 1, NULL, NULL, 16),
  (N'Nghiên cứu thị trường', 3, 1, NULL, NULL, 16),
  (N'Chiến lược marketing', 3, 1, NULL, NULL, 16),
  (N'Bán hàng và quản lý kênh phân phối', 3, 1, NULL, NULL, 16),
  (N'Truyền thông marketing', 3, 1, NULL, NULL, 16),
  (N'Marketing quốc tế', 3, 1, NULL, NULL, 16),
  (N'Marketing dịch vụ', 3, 1, NULL, NULL, 16),
  (N'Marketing thương hiệu', 3, 1, NULL, NULL, 16),
  (N'Marketing trực tuyến', 3, 1, NULL, NULL, 16),
  (N'Marketing xã hội', 3, 1, NULL, NULL, 16),
  (N'Tiếng Anh 1', 3, 1, N'Học tiếng Anh cơ bản cấp độ 1', NULL, 2),
  (N'Tiếng Anh 2', 3, 1, N'Tiếp tục học tiếng Anh cấp độ 2', 1, 2),
  (N'Tin học đại cương', 2, 1, N'Học tin học căn bản', NULL, 1),
  (N'Lập trình căn bản', 3, 1, N'Học lập trình cơ bản', NULL, 1),
  (N'Cơ sở dữ liệu', 3, 1, N'Học về cơ sở dữ liệu', NULL, 1),
  (N'Lập trình nâng cao', 3, 1, N'Học lập trình nâng cao', 4, 1),
  (N'Xây dựng website', 2, 1, N'Học xây dựng website cơ bản', 4, 1),
  (N'Hệ điều hành', 3, 1, N'Học về hệ điều hành', NULL, 1),
  (N'Thực tập công nghệ phần mềm', 3, 0, N'Thực tập công nghệ phần mềm tại công ty ABC', NULL, 1),
  (N'Triết học Mác-Lênin', 3, 1, N'Học về triết', NULL, 9),
  (N'Kinh tế chính trị Mác-Lênin', 2, 1, NULL, NULL, 9),
  (N'Chủ nghĩa xã hội khoa học', 2, 1, NULL, NULL, 9),
  (N'Lịch sử Đảng Cộng sản Việt Nam', 2, 1, NULL, NULL, 9),
  (N'Tư tưởng Hồ Chí Minh', 2, 1, NULL, NULL, 9);

INSERT INTO [LopQuanLi] ([TenLopQuanLi], [MaGiangVien], [MaKhoa])
VALUES
  (N'66IT5', 1, 1),
  (N'68KT1', 3, 2),
  (N'66IT3', 2, 1),
  (N'68XH2', 4, 3),
  (N'67TN1', 5, 4),
  (N'67XH1', 7, 3),
  (N'69TN1', 6, 4),
  (N'69NN1', 8, 5),
  (N'66KT1', 9, 2),
  (N'69IT2', 10, 1);

-- Khi lỗi mất 1 số dòng
-- SET IDENTITY_INSERT [LopQuanLi] ON;
-- INSERT INTO [LopQuanLi] ([MaLopQuanLi], [TenLopQuanLi], [MaGiangVien], [MaKhoa] )
-- VALUES (1, N'66IT4', 2, 2);
-- DBCC CHECKIDENT ('LopQuanLi', RESEED, 1);

INSERT INTO [LopMonHoc] ([TenLopMonHoc], [MaMonHoc], [MaGiangVien])
VALUES
  (N'68IT3', 3, 1),
  (N'64IT1', 7, 2),
  (N'66NV1', 3, 3),
  (N'68TH5', 4, 4),
  (N'67IT1', 5, 5),
  (N'65CS2', 6, 6),
  (N'64IT2', 7, 7),
  (N'68IT5', 8, 8),
  (N'64IT1', 9, 9),
  (N'63IT2', 10, 10);

INSERT INTO [SinhVien] ([NgayVaoTruong], [MaLopQuanLi], [HoTen], [GioiTinh], [NgaySinh], [DiaChiThuongTru], [QueQuan], [Email], [SoDienThoai])
VALUES
  ('2008-09-01', 11, N'Nguyễn Văn An', 1, '1995-03-15', N'Hà Nội', N'Hưng Yên', N'nguyenvanan@gmail.com', '0987654321'),
  ('2009-08-15', 2, N'Phạm Thị Bình', 0, '1996-07-10', N'Thái Bình', N'Thái Bình', N'phamthibinh@gmail.com', '0976543210'),
  ('2010-09-01', 3, N'Lê Thành Công', 1, '1997-05-20', N'Hồ Chí Minh', N'Hà Nội', N'lethanhcong@gmail.com', '0965432109'),
  ('2007-08-20', 4, N'Trần Thị Diễm', 0, '1998-12-25', N'Hà Nội', N'Hưng Yên', N'tranthidiem@gmail.com', '0954321098'),
  ('2008-09-01', 5, N'Đỗ Thị Ðào', 0, '1999-09-05', N'Hải Phòng', N'Thái Bình', N'dothidao@gmail.com', '0943210987'),
  ('2011-08-15', 6, N'Vũ Văn Ðức', 1, '1995-08-30', N'Hưng Yên', N'Hưng Yên', N'vuvanduc@gmail.com', '0932109876'),
  ('2009-09-01', 7, N'Nguyễn Thị Hạnh', 0, '1996-03-05', N'Hồ Chí Minh', N'Thái Bình', N'nguyenthihanh@gmail.com', '0921098765'),
  ('2008-08-20', 8, N'Phạm Văn Hiếu', 1, '1997-07-20', N'Hà Nội', N'Hưng Yên', N'phamvanhieu@gmail.com', '0910987654'),
  ('2010-09-01', 9, N'Lê Thị Huệ', 0, '1998-05-15', N'Hồ Chí Minh', N'Hà Nội', N'lethihue@gmail.com', '0909876543'),
  ('2011-08-15', 10, N'Trần Văn Khánh', 1, '1999-04-10', N'Hưng Yên', N'Thái Bình', N'tranvankhanh@gmail.com', '0898765432'),
  ('2008-09-01', 11, N'Lê Thị Lý', 0, '1995-03-25', N'Hồ Chí Minh', N'Hưng Yên', N'lethily@gmail.com', '0887654321'),
  ('2009-08-15', 2, N'Vũ Thành Minh', 1, '1996-06-20', N'Hà Nội', N'Thái Bình', N'vuthanhminh@gmail.com', '0876543210'),
  ('2010-09-01', 3, N'Trương Hoàng Nam', 1, '1997-05-05', N'Hồ Chí Minh', N'Hà Nội', N'truonghoangnam@gmail.com', '0865432109'),
  ('2007-08-20', 4, N'Nguyễn Thị Ngọc', 0, '1998-12-10', N'Hưng Yên', N'Hưng Yên', N'nguyenthingoc@gmail.com', '0854321098'),
  ('2008-09-01', 5, N'Đỗ Văn Ðức', 1, '1999-10-20', N'Thái Bình', N'Hà Nội', N'dovanduc@gmail.com', '0843210987'),
  ('2011-08-15', 6, N'Trần Thị Oanh', 0, '1995-09-15', N'Hồ Chí Minh', N'Thái Bình', N'tranthioanh@gmail.com', '0832109876'),
  ('2009-09-01', 7, N'Nguyễn Văn Phong', 1, '1996-04-05', N'Hưng Yên', N'Hưng Yên', N'nguyenvanphong@gmail.com', '0821098765'),
  ('2008-08-20', 8, N'Phạm Thị Quỳnh', 0, '1997-08-10', N'Hồ Chí Minh', N'Hà Nội', N'phamthiquynh@gmail.com', '0810987654'),
  ('2010-09-01', 9, N'Lê Thị Quyên', 1, '1998-07-20', N'Hưng Yên', N'Thái Bình', N'lethiquyen@gmail.com', '0809876543'),
  ('2011-08-15', 10, N'Trần Văn Rạng', 1, '1999-06-25', N'Hà Nội', N'Thái Bình', N'tranvanrang@gmail.com', '0798765432'),
  ('2008-09-01', 11, N'Vũ Thị Sáng', 0, '1995-02-10', N'Hồ Chí Minh', N'Hưng Yên', N'vuthisang@gmail.com', '0787654321'),
  ('2009-08-15', 2, N'Trần Hoàng Sơn', 1, '1996-09-05', N'Hưng Yên', N'Hưng Yên', N'tranhoangson@gmail.com', '0776543210'),
  ('2010-09-01', 3, N'Trương Văn Tùng', 1, '1997-08-15', N'Hồ Chí Minh', N'Hưng Yên', N'truongvantung@gmail.com', '0765432109'),
  ('2007-08-20', 4, N'Nguyễn Thị Út', 0, '1998-1-20', N'Thái Bình', N'Thái Bình', N'nguyenthaut@gmail.com', '0754321098'),
  ('2008-09-01', 5, N'Đỗ Văn Ðức', 1, '1999-07-05', N'Hà Nội', N'Hà Nội', N'dovanduc2@gmail.com', '0743210987'),
  ('2011-08-15', 6, N'Trần Thị Út', 0, '1995-06-10', N'Hưng Yên', N'Thái Bình', N'tranthiut@gmail.com', '0732109876'),
  ('2009-09-01', 7, N'Nguyễn Thị Vân', 0, '1996-05-15', N'Hồ Chí Minh', N'Thái Bình', N'nguyenthivan@gmail.com', '0721098765'),
  ('2008-08-20', 8, N'Phạm Thị Xuân', 1, '1997-10-30', N'Hưng Yên', N'Hà Nội', N'phamthixuan@gmail.com', '0710987654'),
  ('2010-09-01', 9, N'Lê Thị Xuân', 0, '1998-06-25', N'Hồ Chí Minh', N'Thái Bình', N'lethixuan@gmail.com', '0709876543'),
  ('2011-08-15', 10, N'Trần Thị Yến', 0, '1999-05-15', N'Hà Nội', N'Thái Bình', N'tranthiyen@gmail.com', '0798765433');

INSERT INTO [DiemSinhVien] ([MaLopMonHoc], [MaSinhVien], [DiemChuyenCan], [DiemGiuaKi], [DiemCuoiKi], [HocKi], [GhiChu])
VALUES
  (1, 10, 9.5, 9.0, 9.5, 2, N'Giỏi'),
  (2, 2, 8.5, 7.0, 9.0, 1, N'Tốt'),
  (3, 2, 6.0, 7.5, 8.0, 2, N'Khá'),
  (4, 3, 7.5, 8.0, 9.5, 1, N'Giỏi'),
  (5, 4, 9.0, 8.5, 9.0, 2, N'Tốt'),
  (6, 5, 6.5, 6.0, 7.0, 1, N'Khá'),
  (7, 6, 8.0, 9.0, 9.5, 2, N'Giỏi'),
  (8, 7, 7.0, 7.5, 8.0, 1, N'Tốt'),
  (9, 8, 8.5, 9.0, 9.0, 2, N'Khá'),
  (10, 9, 5.5, 6.0, 6.5, 1, N'Yếu'),
  (1, 20, 8.0, 8.5, 9.0, 2, N'Giỏi'),
  (2, 11, 6.0, 7.0, 7.5, 1, N'Khá'),
  (3, 12, 8.0, 8.5, 8.0, 2, N'Tốt'),
  (4, 13, 7.5, 8.0, 8.5, 1, N'Giỏi'),
  (5, 14, 6.5, 7.0, 7.0, 2, N'Khá'),
  (6, 15, 9.0, 8.5, 8.0, 1, N'Tốt'),
  (7, 16, 7.0, 7.5, 7.5, 2, N'Khá'),
  (8, 17, 8.5, 9.0, 9.0, 1, N'Giỏi'),
  (9, 18, 6.5, 7.0, 7.5, 2, N'Tốt'),
  (10, 19, 7.0, 7.5, 8.0, 1, N'Khá'),
  (1, 21, 8.5, 9.0, 9.5, 1, N'Tốt'),
  (2, 30, 9.5, 9.0, 9.5, 2, N'Giỏi'),
  (3, 22, 7.0, 7.5, 8.0, 2, N'Khá'),
  (4, 23, 8.0, 8.0, 8.5, 1, N'Giỏi'),
  (5, 24, 6.5, 7.0, 7.0, 2, N'Khá'),
  (6, 25, 9.0, 9.5, 9.0, 1, N'Tốt'),
  (7, 26, 7.5, 8.0, 8.0, 2, N'Khá'),
  (8, 27, 8.5, 9.0, 9.5, 1, N'Giỏi'),
  (9, 28, 6.0, 6.5, 7.0, 2, N'Tốt'),
  (10, 29, 7.0, 7.5, 8.0, 1, N'Khá');

INSERT INTO [NguoiDung] (TenNguoiDung, MatKhau)
VALUES  ("nguyentrunghoa", "gv1"),
        ("dangtruongnam", "gv2"), 
        ("nguyenvanan", "sv1"), 
        ("phamthibinh", "sv2"), 
        ("lethanhcong", "sv3");

