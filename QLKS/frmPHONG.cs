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
    public partial class frmPHONG : DevExpress.XtraEditors.XtraForm
    {
        public frmPHONG()
        {
            InitializeComponent();
        }

        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        BUS.PHONG _phong;
        BUS.LOAIPHONG _lphong;
        BUS.TANG _tang;
        int _idp;
        bool _them;

        private void frmPHONG_Load(object sender, EventArgs e)
        {
            _phong = new BUS.PHONG();
            _lphong = new BUS.LOAIPHONG();
            _tang = new BUS.TANG();
            txtBIDPhong.Enabled = false;
            _enabled(false); // không hiển thị txtb
            loadData();
            showHideControl(true);
            loadLP();
        }

        void loadLP()
        {
            cbotLP.DataSource = _lphong.getAll();
            cboTang.DataSource = _tang.getAll();

            cbotLP.DisplayMember = "TENLOAI";
            cbotLP.ValueMember = "IDLOAIPHONG";
            cboTang.DisplayMember = "TENTANG";
            cboTang.ValueMember = "IDTANG";
        }

        void showHideControl(bool t) // HÀM HIỂN THỊ DỮ LIỆU
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
            txtBTenphong.Enabled = t;
            chkBTtrang.Enabled = t;
            cboTang.Enabled = t;
            cbotLP.Enabled = t;
        }
        void _reset(bool t)
        {
            txtBIDPhong.Text = "";
            txtBTenphong.Text = "";
            chkBTtrang.Enabled = true;
            cboTang.Text = "";
            cbotLP.Text = "";
        }
        // ============================================

        void loadData()
        {
            gcDS.DataSource = _phong.getAll();
            gvDS.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtBIDPhong.Enabled = true;
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
                _phong.delete(_idp);
            }
            loadData();
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtBIDPhong.Enabled = false;
            _enabled(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DAL.PHONG p = new DAL.PHONG();
                p.IDLOAIPHONG = cbotLP.SelectedValue.ToString();
                p.IDTANG = cboTang.SelectedValue.ToString();
                p.TENPHONG = txtBTenphong.Text;
                p.TINHTRANG = chkBTtrang.Checked;
                _phong.add(p);
            }
            else
            {
                DAL.PHONG p = _phong.getItem(_idp);
                p.IDLOAIPHONG = cbotLP.SelectedValue.ToString();
                p.IDTANG = cboTang.SelectedValue.ToString();
                p.TENPHONG = txtBTenphong.Text;
                p.TINHTRANG = chkBTtrang.Checked;
                _phong.update(p);
            }

            _them = false;
            loadData();
            showHideControl(true);
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcDS_Click(object sender, EventArgs e)
        {
            if (gvDS.RowCount > 0)
            {
                _idp = int.Parse(gvDS.GetFocusedRowCellValue("IDPHONG").ToString());
                txtBIDPhong.Text = gvDS.GetFocusedRowCellValue("IDPHONG").ToString();
                txtBTenphong.Text = gvDS.GetFocusedRowCellValue("TENPHONG").ToString();
                chkBTtrang.Checked = bool.Parse(gvDS.GetFocusedRowCellValue("TINHTRANG").ToString());
            }
        }
    }
}