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
using DAL;

namespace QLKS
{
    public partial class frmLOAIPHONG : DevExpress.XtraEditors.XtraForm
    {
        public frmLOAIPHONG()
        {
            InitializeComponent();
        }

        BUS.LOAIPHONG _lphong;
        string _idlp;
        bool _them;

        private void frmLOAIPHONG_Load(object sender, EventArgs e)
        {
            _lphong = new BUS.LOAIPHONG();
            loadData();
            showHideControl(true);
            _enabled(false); // không hiển thị txtb
            txtBIDLoai.Enabled = false;
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
            txtBTenloai.Enabled = t;
            txtBGiatien.Enabled = t;
            txtBMota.Enabled = t;
        }
        void _reset(bool t)
        {
            txtBIDLoai.Text = "";
            txtBTenloai.Text = "";
            txtBGiatien.Text = "";
            txtBMota.Text = "";
        }
// ============================================

        void loadData()
        {
            gcDS.DataSource = _lphong.getAll();
            gvDS.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtBIDLoai.Enabled = true;
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
            if(MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _lphong.delete(_idlp);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DAL.LOAIPHONG lp = new DAL.LOAIPHONG();
                lp.IDLOAIPHONG = txtBIDLoai.Text;
                lp.TENLOAI = txtBTenloai.Text;
                lp.GIATIEN = int.Parse(txtBGiatien.Text);
                lp.MOTA = txtBMota.Text;
                _lphong.add(lp);
            }
            else
            {
                DAL.LOAIPHONG lp = _lphong.getItem(_idlp);
                lp.TENLOAI = txtBTenloai.Text;
                lp.GIATIEN = int.Parse(txtBGiatien.Text);
                lp.MOTA = txtBMota.Text;
                _lphong.update(lp);
            }

            _them = false;
            loadData();    
            showHideControl(true);
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtBIDLoai.Enabled = false;
            _enabled(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcDS_Click(object sender, EventArgs e)
        {
            if(gvDS.RowCount > 0)
            {
                _idlp = gvDS.GetFocusedRowCellValue("IDLOAIPHONG").ToString();
                txtBIDLoai.Text = gvDS.GetFocusedRowCellValue("IDLOAIPHONG").ToString();
                txtBTenloai.Text = gvDS.GetFocusedRowCellValue("TENLOAI").ToString();
                txtBGiatien.Text = gvDS.GetFocusedRowCellValue("GIATIEN").ToString();
                txtBMota.Text = gvDS.GetFocusedRowCellValue("MOTA").ToString();
            }
        }
    }
}