use master
go
create database qlnv
go
use qlnv
go
--Dia diem
create table DiaDiem
(
    Id        int identity primary key,
    DiaDiem   nvarchar(100),
    IsDeleted bit default 0
)

go
create proc GetDiaDiem
as
begin
    select * from DiaDiem where IsDeleted = 0
end
go
create proc AddDiaDiem @DiaDiem nvarchar(100)
as
begin
    insert into DiaDiem(DiaDiem) values (@DiaDiem)
end
go
create proc UpdateDiadiem @Id int, @DiaDiem nvarchar(100)
as
begin
    update DiaDiem set DiaDiem= @DiaDiem where Id = @Id
end
go
create proc DeleteDiaDiem @Id int
as
begin
    update DiaDiem set IsDeleted= 1 where Id = @Id
end
go
--Phong Ban
create table PhongBan
(
    Id          int identity primary key,
    TenPhong    nvarchar(100),
    TruongPhong nvarchar(100),
    IdDiaDiem   int not null
        constraint fk_diadiem foreign key (IdDiaDiem) references DiaDiem (Id),
    IsDeleted   bit default 0
)
go

create proc GetPhongBan
as
begin
    select PhongBan.Id, TenPhong, TruongPhong, DiaDiem.DiaDiem, IdDiaDiem
    from PhongBan,
         DiaDiem
    where PhongBan.IdDiaDiem = DiaDiem.Id
      and PhongBan.IsDeleted = 0
end
go
create proc AddPhongBan @TenPhong nvarchar(100), @TruongPhong nvarchar(100), @IdDiaDiem int
as
begin
    insert into PhongBan(TenPhong, TruongPhong, IdDiaDiem) values (@TenPhong, @TruongPhong, @IdDiaDiem)
end
go
create proc UpdatePhongBan @Id int, @TenPhong nvarchar(100), @TruongPhong nvarchar(100), @IdDiaDiem int
as
begin
    update PhongBan set TenPhong= @TenPhong, TruongPhong= @TruongPhong, IdDiaDiem= @IdDiaDiem where Id = @Id
end
go
create proc DeletePhongBan @Id int
as
begin
    update PhongBan set IsDeleted= 1 where Id = @Id
end
go

--nhan vien
create table NhanVien
(
    Id        int identity primary key,
    HoTen     nvarchar(100),
    NgaySinh  nvarchar(50),
    DiaChi    nvarchar(100),
    GioiTinh  nvarchar(10),
    Luong     int,
    IdPhong   int not null
        constraint fk_phong foreign key (IdPhong) references PhongBan (Id),
    IsDeleted bit default 0
)
go
create proc GetNhanVien
as
begin
    select NhanVien.Id,
           HoTen,
           NgaySinh,
           DiaChi,
           GioiTinh,
           Luong,
           IdPhong,
           TenPhong
    from NhanVien,
         PhongBan
    where NhanVien.IsDeleted = 0
      and NhanVien.IdPhong = PhongBan.Id
end
go
create proc AddNhanVien @HoTen nvarchar(100), @NgaySinh nvarchar(50), @DiaChi nvarchar(100), @GioiTinh nvarchar(10),
                        @Luong int, @IdPhong int
as
begin
    insert into NhanVien(HoTen, NgaySinh, DiaChi, GioiTinh, Luong, IdPhong)
    values (@HoTen, @NgaySinh, @DiaChi, @GioiTinh, @Luong, @IdPhong)
end
go

create proc UpdateNhanVien @Id int, @HoTen nvarchar(100), @NgaySinh nvarchar(50), @DiaChi nvarchar(100),
                           @GioiTinh nvarchar(10), @Luong int, @IdPhong int
as
begin
    update NhanVien
    set HoTen= @HoTen,
        NgaySinh = @NgaySinh,
        DiaChi= @DiaChi,
        GioiTinh= @GioiTinh,
        Luong=@Luong,
        IdPhong= @IdPhong
    where Id = @Id
end
go
create proc DeleteNhanVien @Id int
as
begin
    update NhanVien set IsDeleted= 1 where Id = @Id
end
go

create table DeAn
(
    Id        int identity primary key,
    TenDA     nvarchar(100),
    DiaDiem   nvarchar(100),
    IdPhong   int not null
        constraint fk_phong_da foreign key (IdPhong) references PhongBan (Id),
    IsDeleted bit default 0
)
go
create proc GetDeAn
as
begin
    select DeAn.Id, DeAn.TenDA, DeAn.DiaDiem, DeAn.IdPhong, PhongBan.TenPhong
    from DeAn,
         PhongBan
    where DeAn.IdPhong = PhongBan.Id
      and DeAn.IsDeleted = 0
end
go
create proc AddDeAn @TenDA nvarchar(100), @DiaDiem nvarchar(100), @IdPhong int
as
begin
    insert into DeAn(TENDA, DIADIEM, IDPHONG) values (@TenDA, @DiaDiem, @IdPhong)
end
go
create proc UpdateDeAn @Id int, @TenDA nvarchar(100), @DiaDiem nvarchar(100), @IdPhong int
as
begin
    update DeAn set TenDA= @TenDA, DiaDiem= @DiaDiem, IdPhong= @IdPhong where Id = @Id
end
go
create proc DeleteDeAn @Id int
as
begin
    update DeAn set IsDeleted= 1 where Id = @Id
end
go
create table PhanCong
(
    Id         int identity primary key,
    IdNhanVien int not null
        constraint fk_nv_pc foreign key (IdNhanVien) references NhanVien (Id),
    SoDA       int,
    ThoiGian   nvarchar(100),
    IsDeleted  bit default 0
)
go
create proc GetPhanCong
as
begin
    select PhanCong.Id, IdNhanVien, SoDA, HoTen, ThoiGian
    from PhanCong,
         NhanVien
    where PhanCong.IdNhanVien = NhanVien.Id
      and PhanCong.IsDeleted = 0
end
go
create proc AddPhanCong @IdNhanVien int, @SoDA int, @ThoiGian nvarchar(100)
as
begin
    insert into PhanCong(IdNhanVien, SoDA, ThoiGian) values (@IdNhanVien, @SoDA, @ThoiGian)
end
go
create proc UpdatePhanCong @Id int, @IdNhanVien int, @SoDA int, @ThoiGian nvarchar(100)
as
begin
    update PhanCong set IdNhanVien= @IdNhanVien, SoDA= @SoDA, ThoiGian= @ThoiGian where Id = @Id
end
go
create proc DeletePhanCong @Id int
as
begin
    update PhanCong set IsDeleted= 1 where Id = @Id
end


