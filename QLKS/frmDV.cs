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
    public partial class frmDV : DevExpress.XtraEditors.XtraForm
    {
        public frmDV()
        {
            InitializeComponent();
        }

        BUS.DICHVU dvu;
        public int _iddv;
        bool _them;

        private void frmDV_Load(object sender, EventArgs e)
        {
            dvu = new BUS.DICHVU();
            loadData();
            showHideControl(true);
            _enabled(false); // không hiển thị txtb

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

        // ==============   HÀM ĐỂ HIỆN THỊ btn   ========
        void _enabled(bool t)
        {
            txtBTenDV.Enabled = t;
            txtBdvt.Enabled = t;
            txtBdongia.Enabled = t;
        }
        void _reset(bool t)
        {
            txtBTenDV.Text = "";
            txtBdvt.Text = "";
            txtBdongia.Text = "";
        }
        // ============================================

        void loadData()
        {
            gcDS.DataSource = dvu.getAll();
            gvDS.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
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
                dvu.delete(_iddv);
            }
            loadData();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DAL.DICHVU dv = new DAL.DICHVU();
                dv.TENDV = txtBTenDV.Text;
                dv.DONGIA = int.Parse(txtBdongia.Text);
                dv.DONVITINH = txtBdvt.Text;
                dvu.add(dv);
            }
            else
            {
                DAL.DICHVU dv = dvu.getItem(_iddv);
                dv.TENDV = txtBTenDV.Text;
                dv.DONGIA = int.Parse(txtBdongia.Text);
                dv.DONVITINH = txtBdvt.Text;
                dvu.update(dv);
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
                _iddv = int.Parse(gvDS.GetFocusedRowCellValue("IDDV").ToString());
                txtBTenDV.Text = gvDS.GetFocusedRowCellValue("TENDV").ToString();
                txtBdongia.Text = gvDS.GetFocusedRowCellValue("DONGIA").ToString();
                txtBdvt.Text = gvDS.GetFocusedRowCellValue("DONVITINH").ToString();
            }
        }
    }
}