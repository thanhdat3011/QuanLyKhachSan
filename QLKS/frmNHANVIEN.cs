using BUS;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmNHANVIEN : DevExpress.XtraEditors.XtraForm
    {
        public frmNHANVIEN()
        {
            InitializeComponent();
        }

        NHANVIEN _nhanvien;
        string _idnv;
        bool _them;
        frmDatPhongDon objDPDon = (frmDatPhongDon)Application.OpenForms["frmDatPhongDon"];

        private void frmNHANVIEN_Load(object sender, EventArgs e)
        {
            _nhanvien = new NHANVIEN();
            loadData();
            showHideControl(true);
            _enabled(false); // không hiển thị txtb
            txtBIDnv.Enabled = false;
        }

        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoqua.Visible = !t;
        }

        // ==============   HÀM ĐỂ HIỆN THỊ TXTB   ========
        void _enabled(bool t)
        { 
            txtBTennv.Enabled = t;
            txtBsdt.Enabled = t;
            txtBcv.Enabled = t;

        }
        void _reset(bool t)
        { 
            txtBIDnv.Text = "";
            txtBTennv.Text = "";
            txtBsdt.Text = "";
            txtBcv.Text = "";
        }
        // ============================================

        void loadData()
        {
            gcDS.DataSource = _nhanvien.getAll();
            gvDS.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtBIDnv.Enabled = true;
            showHideControl(false);
            _enabled(true);
            _reset(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true); // hiển thị txtb
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhanvien.delete(_idnv);
            }
            loadData();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtBIDnv.Enabled = false;
            _enabled(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DAL.NHANVIEN nv = new DAL.NHANVIEN();
                nv.IDNV = txtBIDnv.Text;
                nv.TENNV = txtBTennv.Text;
                nv.SDT = txtBsdt.Text;
                nv.CHUCVU = txtBcv.Text;

                _nhanvien.add(nv);
            }
            else
            {
                DAL.NHANVIEN nv = _nhanvien.getItem(_idnv);
                nv.TENNV = txtBTennv.Text;
                nv.SDT = txtBsdt.Text;
                nv.CHUCVU = txtBcv.Text;
                _nhanvien.update(nv);
            }

            _them = false;
            loadData();
            showHideControl(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void gcDS_Click_1(object sender, EventArgs e)
        {
            if (gvDS.RowCount > 0)
            {
                _idnv = gvDS.GetFocusedRowCellValue("IDNV").ToString();
                txtBIDnv.Text = gvDS.GetFocusedRowCellValue("IDNV").ToString();
                txtBTennv.Text = gvDS.GetFocusedRowCellValue("TENNV").ToString();
                txtBsdt.Text = gvDS.GetFocusedRowCellValue("SDT").ToString();
                txtBcv.Text = gvDS.GetFocusedRowCellValue("CHUCVU").ToString();
            }
        }

        private void gcDS_DoubleClick(object sender, EventArgs e)
        {
            objDPDon.loadNV();
            objDPDon.setNV(gvDS.GetFocusedRowCellValue("IDNV").ToString());
            this.Close();
        }
    }
}