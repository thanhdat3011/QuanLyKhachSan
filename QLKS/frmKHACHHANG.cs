using BUS;
using DAL;
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
    public partial class frmKHACHHANG : DevExpress.XtraEditors.XtraForm
    {
        public frmKHACHHANG()
        {
            InitializeComponent();
        }

        BUS.KHACHHANG _kh;
        string _idkh;
        bool _them;
        frmDatPhongDon objDPDon = (frmDatPhongDon)Application.OpenForms["frmDatPhongDon"];

        private void frmKHACHHANG_Load(object sender, EventArgs e)
        {
            _kh = new BUS.KHACHHANG();
            loadData();
            showHideControl(true);
            _enabled(false); // không hiển thị txtb
            txtBIDkh.Enabled = false;

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
            txtBTenkh.Enabled = t;
            txtBsdt.Enabled = t;
            txtBcccd.Enabled = t;
            txtBdc.Enabled = t;
        }
        void _reset(bool t)
        {
            txtBIDkh.Text = "";
            txtBTenkh.Text = "";
            txtBsdt.Text = "";
            txtBcccd.Text = "";
            txtBdc.Text = "";
        }
        // ============================================


        void loadData()
        {
            gcDS.DataSource = _kh.getAll();
            gvDS.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtBIDkh.Enabled = true;
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
                _kh.delete(_idkh);
            }
            loadData();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtBIDkh.Enabled = false;
            _enabled(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DAL.KHACHHANG kh = new DAL.KHACHHANG();
                kh.IDKH = txtBIDkh.Text;
                kh.TENKH = txtBTenkh.Text;
                kh.SDT = txtBsdt.Text;
                kh.CCCD = txtBcccd.Text;
                kh.DIACHI = txtBdc.Text;

                _kh.add(kh);
            }
            else
            {
                DAL.KHACHHANG kh = _kh.getItem(_idkh);
                kh.TENKH = txtBTenkh.Text;
                kh.SDT = txtBsdt.Text;
                kh.CCCD = txtBcccd.Text;
                kh.DIACHI = txtBdc.Text;
                _kh.update(kh);
            }

            _them = false;
            loadData();
            showHideControl(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcDS_Click(object sender, EventArgs e)
        {
            if (gvDS.RowCount > 0)
            {
                _idkh = gvDS.GetFocusedRowCellValue("IDKH").ToString();
                txtBIDkh.Text = gvDS.GetFocusedRowCellValue("IDKH").ToString();
                txtBTenkh.Text = gvDS.GetFocusedRowCellValue("TENKH").ToString();
                txtBsdt.Text = gvDS.GetFocusedRowCellValue("SDT").ToString();
                txtBcccd.Text = gvDS.GetFocusedRowCellValue("CCCD").ToString();
                txtBdc.Text = gvDS.GetFocusedRowCellValue("DIACHI").ToString();
            }
        }

        private void gcDS_DoubleClick(object sender, EventArgs e)
        {
            objDPDon.loadKH();
            objDPDon.setKH(gvDS.GetFocusedRowCellValue("IDKH").ToString());
            this.Close();
        }
    }
}