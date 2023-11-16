use master
go
if exists (select name from sysdatabases where name='quanlyst1')
drop Database quanlyst1
go
CREATE DATABASE quanlyst1;
GO

USE quanlyst1;
GO

CREATE TABLE chitietdonhang (
    maphieuxuat int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    sanphamban nvarchar(500) NULL,
    ngayban datetime NULL,
    thanhtien int NULL,
    nguoiban nvarchar(50) NULL
);

CREATE TABLE nhacungcap (
    mancc int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    tenncc nvarchar(50) NULL,
    diachi nvarchar(50) NULL,
    sdt nvarchar(50) NULL,
    congno int NULL
);

CREATE TABLE sanpham (
    masp int IDENTITY(1000,1) NOT NULL PRIMARY KEY,
    tensp nvarchar(50) NULL,
    mancc int NULL,
    gianhap int NULL,
    giaban int NULL,
    solg int NULL,
    hsd date NULL,
    noisx nvarchar(50) NOT NULL,
    donvitinh nvarchar(50) NULL,
    nguoinhap nvarchar(50) NULL
);

CREATE TABLE taikhoan (
    username nvarchar(50) NOT NULL PRIMARY KEY,
    password nvarchar(50) NULL,
    fullname nvarchar(50) NULL,
    datecreate nvarchar(25) NULL,
	isAdmin int NULL

);

INSERT INTO chitietdonhang (sanphamban, ngayban, thanhtien, nguoiban) VALUES (N'Tuong ot : 1, Dau an : 2, Bot ngot : 2', '2022-08-24 22:44:05', 175000, N'Nguyen Van Teo (Quản trị)');
-- Thêm các dòng dữ liệu khác cho bảng chitietdonhang
-- Vui lòng sửa lại ngày tháng và dữ liệu phù hợp

INSERT INTO nhacungcap (tenncc, diachi, sdt, congno) VALUES (N'VinFast', N'Hà Nội', N'01655888622', 0);
-- Thêm các dòng dữ liệu khác cho bảng nhacungcap

INSERT INTO sanpham (tensp, mancc, gianhap, giaban, solg, hsd, noisx, donvitinh, nguoinhap) VALUES (N'Quat Máy', 1, 300000, 400000, 6, '2025-01-01', N'Hải Phòng', N'Chiếc', N'Nguyen Van Dung (Quản trị)');
-- Thêm các dòng dữ liệu khác cho bảng sanpham
-- Vui lòng sửa lại ngày tháng và dữ liệu phù hợp

INSERT INTO taikhoan (username, password, fullname,datecreate,isAdmin) VALUES (N'admin', N'123', N'Nguyen Van a',N'2022-55-30 10:55:52 PM',0);
-- Thêm các dòng dữ liệu khác cho bảng taikhoan

SET IDENTITY_INSERT chitietdonhang OFF;
SET IDENTITY_INSERT nhacungcap OFF;
SET IDENTITY_INSERT sanpham OFF;

--DROP TABLE taikhoan;
--DROP TABLE sanpham;
--DROP TABLE chitietdonhang;
--DROP TABLE nhacungcap;
select * from taikhoan