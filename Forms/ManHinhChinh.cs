using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien.Forms
{
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        DAL db;

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            db = new DAL();
            LoadData();
        }

        public void LoadData()
        {
            LoadDSDiaDiem();
            LoadDSPhongBan();
            LoadNhanVien();
            LoadDeAn();
            LoadPhanCong();
        }

        private void LoadDSDiaDiem()
        {
            string tuKhoa = txtTimKiemDiaDiem.Text.ToLower();
            if (String.IsNullOrEmpty(tuKhoa))
            {
                dgvDiaDiem.DataSource = db.DiaDiems.DiaDiems();
            }
            else
            {
                dgvDiaDiem.DataSource =
                    db.DiaDiems.DiaDiems().Where(x => x.DiaDiem1.ToLower().Contains(tuKhoa)).ToList();
            }

            dgvDiaDiem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDiaDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        DiaDiem diaDiem = new DiaDiem();

        private void button3_Click(object sender, EventArgs e)
        {
            diaDiem.DiaDiem1 = txtDiaDiemDiaDiem.Text;
            db.DiaDiems.Add(diaDiem);

            LoadData();
        }

        private void dgvDiaDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDiaDiem.SelectedRows)
            {
                diaDiem.Id = int.Parse(row.Cells[0].Value.ToString());
                txtDiaDiemDiaDiem.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db.DiaDiems.Update(diaDiem);
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db.DiaDiems.Delete(diaDiem.Id);
            LoadData();
        }


        //Quản lý phòng ban
        public void LoadDSPhongBan()
        {
            string tuKhoa = txtTimKiemPhongBan.Text.ToLower();
            if (String.IsNullOrEmpty(tuKhoa))
            {
                dgvPhongBan.DataSource = db.PhongBans.PhongBans();
            }
            else
            {
                dgvPhongBan.DataSource =
                    db.PhongBans.PhongBans().Where(x => x.TenPhong.ToLower().Contains(tuKhoa)).ToList();
            }

            dgvPhongBan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbDiaDiem.Items.Clear();
            foreach (var item in db.DiaDiems.DiaDiems())
            {
                cbDiaDiem.Items.Add(item.DiaDiem1);
            }
        }

        PhongBan phongBan = new PhongBan();

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDSPhongBan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbDiaDiem.SelectedIndex > -1)
            {
                int idDiaDiem = db.DiaDiems.DiaDiems()[cbDiaDiem.SelectedIndex].Id;
                phongBan.IdDiadiem = idDiaDiem;
                phongBan.TruongPhong = txtTruongPhong.Text;
                phongBan.TenPhong = txtTenPhongBan.Text;
                db.PhongBans.Add(phongBan);
                LoadData();
            }
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPhongBan.SelectedRows)
            {
                phongBan.Id = int.Parse(row.Cells[0].Value.ToString());
                txtTenPhongBan.Text = row.Cells[1].Value.ToString();
                txtTruongPhong.Text = row.Cells[2].Value.ToString();
                cbDiaDiem.Text = row.Cells[3].Value.ToString();

                phongBan.IdDiadiem = int.Parse(row.Cells[4].Value.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int idDiaDiem = db.DiaDiems.DiaDiems()[cbDiaDiem.SelectedIndex].Id;
            phongBan.IdDiadiem = idDiaDiem;
            phongBan.TruongPhong = txtTruongPhong.Text;
            phongBan.TenPhong = txtTenPhongBan.Text;
            db.PhongBans.Update(phongBan);
            LoadData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            db.PhongBans.Delete(phongBan.Id);
            LoadData();
        }

        //Quản lý nhân viên
        public void LoadNhanVien()
        {
            string tuKhoa = txtTimKiemNV.Text.ToLower();
            if (String.IsNullOrEmpty(tuKhoa))
            {
                dgvNhanVien.DataSource = db.NhanViens.NhanViens();
            }
            else
            {
                dgvNhanVien.DataSource = db.NhanViens.NhanViens().Where(x => x.HoTen.Contains(tuKhoa)).ToList();
            }

            dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbPhong.Items.Clear();
            foreach (var item in db.PhongBans.PhongBans())
            {
                cbPhong.Items.Add(item.TenPhong);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        NhanVien nhanVien = new NhanVien();

        private void button10_Click(object sender, EventArgs e)
        {
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.GioiTinh = bcGioiTinh.Text;
            nhanVien.DiaChi = txtDiachiNV.Text;
            nhanVien.NgaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            nhanVien.Luong = int.Parse(txtLuong.Text);
            if (cbPhong.SelectedIndex > -1)
            {
                nhanVien.IdPhong = db.PhongBans.PhongBans()[cbPhong.SelectedIndex].Id;
            }

            db.NhanViens.Add(nhanVien);
            LoadData();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPhongBan.SelectedRows)
            {
                nhanVien.Id = int.Parse(row.Cells[0].Value.ToString());
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                txtDiachiNV.Text = row.Cells[3].Value.ToString();
                bcGioiTinh.Text = row.Cells[4].Value.ToString();
                txtLuong.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nhanVien.HoTen = txtHoTen.Text;
            nhanVien.GioiTinh = bcGioiTinh.Text;
            nhanVien.DiaChi = txtDiachiNV.Text;
            nhanVien.NgaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            nhanVien.Luong = int.Parse(txtLuong.Text);
            if (cbPhong.SelectedIndex > -1)
            {
                nhanVien.IdPhong = db.PhongBans.PhongBans()[cbPhong.SelectedIndex].Id;
            }

            db.NhanViens.Update(nhanVien);
            LoadData();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            db.NhanViens.Delete(nhanVien.Id);
            LoadData();
        }

        //Quan ly de an
        private DeAn deAn = new DeAn();

        public void LoadDeAn()
        {
            string tuKhoa = txtTimKiemDeAn.Text.ToLower();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                dgvDean.DataSource = db.DeAns.DeAns();
            }
            else
            {
                dgvDean.DataSource = db.DeAns.DeAns().Where(x => x.TenDA.ToLower().Contains(tuKhoa));
            }

            cbTenPhong.Items.Clear();
            foreach (var phongBan in db.PhongBans.PhongBans())
            {
                cbTenPhong.Items.Add(phongBan.TenPhong);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            deAn.DiaDiem = txtDiaDiem.Text;
            deAn.TenDA = txtTenDA.Text;
            if (cbTenPhong.SelectedIndex > -1)
            {
                deAn.IdPhong = db.PhongBans.PhongBans()[cbTenPhong.SelectedIndex].Id;
                db.DeAns.Add(deAn);
                LoadData();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            deAn.DiaDiem = txtDiaDiem.Text;
            deAn.TenDA = txtTenDA.Text;
            if (cbTenPhong.SelectedIndex > -1)
            {
                deAn.IdPhong = db.PhongBans.PhongBans()[cbTenPhong.SelectedIndex].Id;
                db.DeAns.Update(deAn);
                LoadData();
            }
        }

        private void dgvDean_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDean.SelectedRows)
            {
                deAn.Id = int.Parse(row.Cells[0].Value.ToString());
                txtTenDA.Text = row.Cells[1].Value.ToString();
                txtDiaDiem.Text = row.Cells[2].Value.ToString();
                cbTenPhong.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            db.DeAns.Delete(deAn.Id);
            LoadData();
        }

// Phan cong
        private PhanCong phanCong = new PhanCong();

        public void LoadPhanCong()
        {
            string tuKhoa = txtTimKiemPhanCong.Text.ToLower();
            if (String.IsNullOrEmpty(tuKhoa))
            {
                dgvPhanCong.DataSource = db.PhanCongs.PhanCongs();
            }
            else
            {
                dgvPhanCong.DataSource = db.PhanCongs.PhanCongs().Where(x => x.HoTen.Contains(tuKhoa)).ToList();
            }

            dgvPhanCong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPhanCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbNhanVien.Items.Clear();
            cbDeAn.Items.Clear();
            foreach (var nv in db.NhanViens.NhanViens())
            {
                cbNhanVien.Items.Add(nv.HoTen);
            }

            foreach (var da in db.DeAns.DeAns())
            {
                cbDeAn.Items.Add(da.TenDA);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            phanCong.ThoiGian = dtpThoiGian.Value.ToString("dd/MM/yyyy");
            if (cbNhanVien.SelectedIndex > -1)
            {
                phanCong.IdNhanVien = db.NhanViens.NhanViens()[cbNhanVien.SelectedIndex].Id;
                if (cbDeAn.SelectedIndex > -1)
                {
                    phanCong.SoDA = db.DeAns.DeAns()[cbDeAn.SelectedIndex].Id;
                    db.PhanCongs.Add(phanCong);
                  LoadData();
                }
            }

        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPhanCong.SelectedRows)
            {
                phanCong.Id = int.Parse(row.Cells[0].Value.ToString());
                dtpThoiGian.Text = row.Cells[3].Value.ToString();
                cbNhanVien.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            phanCong.ThoiGian = dtpThoiGian.Value.ToString("dd/MM/yyyy");
            if (cbNhanVien.SelectedIndex > -1)
            {
                phanCong.IdNhanVien = db.NhanViens.NhanViens()[cbNhanVien.SelectedIndex].Id;
                if (cbDeAn.SelectedIndex > -1)
                {
                    phanCong.SoDA = db.DeAns.DeAns()[cbDeAn.SelectedIndex].Id;
                    db.PhanCongs.Update(phanCong);
                    LoadData();
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            db.PhanCongs.Delete(phanCong.Id);
            LoadData();
        }
    }
}