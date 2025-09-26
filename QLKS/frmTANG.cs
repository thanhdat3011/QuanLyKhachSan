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
    public partial class frmTANG : DevExpress.XtraEditors.XtraForm
    {
        public frmTANG()
        {
            InitializeComponent();
        }

        BUS.TANG _tang;
        string idT;
        bool _them;
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];

        private void frmTANG_Load(object sender, EventArgs e)
        {
            _tang = new BUS.TANG();
            loadData();
            showHideControl(true);
            _enabled(false); // không hiển thị txtb
            txtBid.Enabled = false;
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

        void _enabled(bool t)
        {
            txtBid.Enabled = t;
            txtBtTang.Enabled = t;
        }
        void _reset(bool t)
        {
            txtBid.Text = "";
            txtBtTang.Text = "";
        }

        void loadData()
        {
            gcDS.DataSource = _tang.getAll();
            gvDS.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtBid.Enabled = true;
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
                _tang.delete(idT);
            }
            loadData();
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtBid.Enabled = false;
            _enabled(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                DAL.TANG t = new DAL.TANG();
                t.IDTANG = txtBid.Text;
                t.TENTANG = txtBtTang.Text;
                _tang.add(t);
            }
            else
            {
                DAL.TANG t = new DAL.TANG();
                t.IDTANG = txtBid.Text;
                t.TENTANG = txtBtTang.Text;
                _tang.update(t);
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
                idT = gvDS.GetFocusedRowCellValue("IDTANG").ToString();
                txtBid.Text = gvDS.GetFocusedRowCellValue("IDTANG").ToString();
                txtBtTang.Text = gvDS.GetFocusedRowCellValue("TENTANG").ToString();
            }
        }
    }
}