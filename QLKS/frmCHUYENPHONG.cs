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
    public partial class frmCHUYENPHONG : DevExpress.XtraEditors.XtraForm
    {
        public frmCHUYENPHONG()
        {
            InitializeComponent();
        }

        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        public int _idPhong;
        BUS.PHONG _phong;
        BUS.DATPHONG dphong;
        BUS.CTDP dpct;
        private void frmCHUYENPHONG_Load(object sender, EventArgs e)
        {
            _phong = new BUS.PHONG();
            dphong = new BUS.DATPHONG();
            dpct = new BUS.CTDP();  
            var p = _phong.getItemFull(_idPhong);
            lblPhong.Text = p.TENPHONG + " - Đơn giá: " + p.GIATIEN.ToString("N0");
            loadPhongTrong();

        }

        void loadPhongTrong()
        {
            searchPhong.Properties.DataSource = _phong.getPhongTrongFull();
            searchPhong.Properties.ValueMember = "IDPHONG";
            searchPhong.Properties.DisplayMember = "TENPHONG";

            searchPhong.Properties.View.Columns["GIATIEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            searchPhong.Properties.View.Columns["GIATIEN"].DisplayFormat.FormatString = "n0";
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (searchPhong.EditValue == null || searchPhong.EditValue.ToString() == "")
            {
                MessageBox.Show("Phòng chưa được chọn nên không thể chuyển phòng, vui lòng chọn phòng đã được đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int tongtien1 = 0;

            var phongHT = dpct.getIDDPbyPhong(_idPhong);
            var phongCD = _phong.getItemFull(int.Parse(searchPhong.EditValue.ToString()));

            List<DPCT> lstDPCT = dpct.getAllByPhong((int)phongHT.IDDATPHONG);
            foreach (var item in lstDPCT)
            {
                item.IDPHONG = int.Parse(searchPhong.EditValue.ToString());
                tongtien1 = (int)(tongtien1 + double.Parse(item.DONGIA.ToString()) * int.Parse(item.SOLUONG.ToString()));
                dpct.update(item);
            }


            var _dp = dphong.getItem((int)phongHT.IDDATPHONG);
            _dp.IDPHONG = phongCD.IDPHONG;
            _dp.SOTIEN = (_dp.SONGAYO * phongCD.GIATIEN) + tongtien1;
            
            dphong.update(_dp);

            _phong.updateStatus(_idPhong, false);
            _phong.updateStatus(phongCD.IDPHONG, true);

            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
        }

       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchPhong_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}