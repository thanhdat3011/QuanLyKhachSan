using BUS;
using DAL;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace QLKS
{
    public partial class frmDatPhongDon : DevExpress.XtraEditors.XtraForm
    {
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        public int _idPhong;
        BUS.DATPHONG _dphong;
        OBJ_DATPHONG _phongHT;
        BUS.CTDP dpct;
        BUS.PHONG _phong;
        BUS.DICHVU _dichvu;
        BUS.CTDP _dphongct;
        public bool _them;
        int idDP;
        TRANGTHAI _trangthai;

        List<OBJ_DSDV> lstDSDV;
        List<DATPHONG_DTO> _lstDPDTO;
        

        public frmDatPhongDon()
        {
            InitializeComponent();
        }

        private void frmDatPhongDon_Load(object sender, EventArgs e)
        {
            _dphong = new BUS.DATPHONG();
            _dichvu = new BUS.DICHVU();
            lstDSDV = new List<OBJ_DSDV>();
            dpct = new BUS.CTDP();
            _dphongct = new BUS.CTDP();
            _trangthai = new TRANGTHAI();

            cbTrangThai.DataSource = TRANGTHAI.getList();
            cbTrangThai.ValueMember = "_value";
            cbTrangThai.DisplayMember = "_display";

            _phong = new BUS.PHONG();
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);

            loadKH();
            loadNV();
            loadSP();

            var _dpct = _dphongct.getIDDPbyPhong(_idPhong);
            if(!_them &&  _dpct != null)
            {
                this.Text = "CẬP NHẬT DỊCH VỤ - SẢN PHẨM";
                idDP = int.Parse(_dpct.IDDATPHONG.ToString());
                var dp = _dphong.getItem(idDP);
                searchKH.EditValue = dp.IDKH;
                searchNV.EditValue = dp.IDNV;
                dtNgayDat.Value = dp.NGAYDAT;
                dtNgayTra.Value = dp.NGAYTRA;
                spSNO.Text = dp.SONGUOIO.ToString();
                txtBghichu.Text = dp.GHICHU.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString();
                loadSPDV();
            }


            _phongHT = _phong.getItemFull(_idPhong);
            lblPhong.Text = _phongHT.TENPHONG + " - Đơn giá: " + _phongHT.GIATIEN.ToString("N0") + "VNĐ";
        }

        void loadSPDV()
        {
            gcDSDV.DataSource = _dphongct.getAllByDatPhong(idDP);
            lstDSDV = _dphongct.getAllByDatPhong(idDP);
            _lstDPDTO = dpct.getListFull(idDP);
        }

        public void loadKH()
        {
            BUS.KHACHHANG _kh = new BUS.KHACHHANG();
            searchKH.Properties.DataSource = _kh.getAll();
            searchKH.Properties.DisplayMember = "TENKH";
            searchKH.Properties.ValueMember = "IDKH";
        }

        public void loadNV()
        {
            BUS.NHANVIEN _nv = new BUS.NHANVIEN();
            searchNV.Properties.DataSource = _nv.getAll();
            searchNV.Properties.ValueMember = "IDNV";
            searchNV.Properties.DisplayMember = "TENNV";
        }

        void loadSP()
        {
            gcDV.DataSource =  _dichvu.getAll();
            gvDV.OptionsBehavior.Editable = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            saveData();
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
        }

        void saveData()
        {

            if (searchKH.EditValue == null || searchNV.EditValue == null || txtBghichu.Text == null || spSNO.Text == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                return;
            }


            if (_them)
            {
                DAL.DATPHONG dp = new DAL.DATPHONG();
                DPCT dpct = new DPCT();
                dp.IDDV = int.Parse(gvDV.GetFocusedRowCellValue("IDDV").ToString());
                dp.NGAYDAT = dtNgayDat.Value;
                dp.NGAYTRA = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSNO.EditValue.ToString());
                dp.IDKH = searchKH.EditValue.ToString();
                dp.SOTIEN = int.Parse(txtThanhTien.Text);
                dp.GHICHU = txtBghichu.Text;
                dp.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                dp.IDNV = searchNV.EditValue.ToString();
                dp.IDPHONG = _phongHT.IDPHONG;
                var _dp = _dphong.add(dp);

                dpct.IDDATPHONG = _dp.IDDATPHONG;
                dpct.IDPHONG = _dp.IDPHONG;

                dpct.NGAY = DateTime.Now;

                var _dpct = _dphongct.add(dpct);
                _phong.updateStatus(int.Parse(dpct.IDPHONG.ToString()), true);

                if (gvDSSP.RowCount > 0)
                {
                    for (int j = 0; j < gvDSSP.RowCount; j++)
                    {
                        if (dpct.IDPHONG == int.Parse(gvDSSP.GetRowCellValue(j, "IDPHONG").ToString()))
                        {
                            //dpct = new BUS.CTDP();
                            dpct.IDDATPHONG = _dp.IDDATPHONG;
                            dpct.IDCTDV = _dpct.IDCTDV;
                            dpct.IDPHONG = int.Parse(gvDSSP.GetRowCellValue(j, "IDPHONG").ToString());
                            dpct.IDDV = int.Parse(gvDSSP.GetRowCellValue(j, "IDDV").ToString());
                            dpct.DONGIA = int.Parse(gvDSSP.GetRowCellValue(j, "DONGIA").ToString());
                            dpct.SOLUONG = int.Parse(gvDSSP.GetRowCellValue(j, "SOLUONG").ToString());
                            dpct.THANHTIEN = dpct.DONGIA * dpct.SOLUONG;
                            _dphongct.add(dpct);

                        }
                    }
                }
                MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DAL.DATPHONG dp = _dphong.getItem(idDP);
                _dphongct.deleteByIdDatPhong(dp.IDDATPHONG); // của chatGPT
                dp.NGAYDAT = dtNgayDat.Value;
                dp.NGAYTRA = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSNO.EditValue.ToString());
                dp.IDKH = searchKH.EditValue.ToString();
                dp.SOTIEN = int.Parse(txtThanhTien.Text);
                dp.GHICHU = txtBghichu.Text;
                dp.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                dp.IDPHONG = _phongHT.IDPHONG;
                dp.IDNV = searchNV.EditValue.ToString();
                var _dp = _dphong.update(dp);

                DPCT dpct = new DPCT();
                dpct.IDDATPHONG = _dp.IDDATPHONG;
                dpct.IDPHONG = _dp.IDPHONG;

                dpct.DONGIA = dpct.DONGIA;
                dpct.NGAY = DateTime.Now;

                _phong.updateStatus(int.Parse(dpct.IDPHONG.ToString()), true);
                if (gvDSSP.RowCount > 0)
                {
                    for (int j = 0; j < gvDSSP.RowCount; j++)
                    {
                        if (dpct.IDPHONG == int.Parse(gvDSSP.GetRowCellValue(j, "IDPHONG").ToString()))
                        {
                            DPCT dpctN = new DPCT();
                            //dpct = new BUS.CTDP();
                            dpctN.IDDATPHONG = _dp.IDDATPHONG;
                            dpctN.IDPHONG = int.Parse(gvDSSP.GetRowCellValue(j, "IDPHONG").ToString());
                            dpctN.IDDV = int.Parse(gvDSSP.GetRowCellValue(j, "IDDV").ToString());
                            dpctN.DONGIA = int.Parse(gvDSSP.GetRowCellValue(j, "DONGIA").ToString());
                            dpctN.SOLUONG = int.Parse(gvDSSP.GetRowCellValue(j, "SOLUONG").ToString());
                            dpctN.THANHTIEN = dpctN.DONGIA * dpctN.SOLUONG;
                            _dphongct.add(dpctN);

                        }
                    }
                }
                MessageBox.Show("Bạn đã cập nhật dịch vụ hoặc thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                rptHOADON rpt = new rptHOADON(_lstDPDTO);
                rpt.ShowPreview();
            }
            if (!_them)
            {
                rptHOADON rpt = new rptHOADON(_lstDPDTO);
                rpt.ShowPreview();
                saveData();
                _dphong.updateStatus(idDP);
                _phong.updateStatus(_idPhong, false);
                cbTrangThai.SelectedValue = true;
                objMain.gControl.Gallery.Groups.Clear();
                objMain.showRoom();
            }

        }

        public void getKH(string idKH)
        {
            BUS.KHACHHANG _kh = new BUS.KHACHHANG();
            var kh = _kh.getItem(idKH);
            searchKH.EditValue = kh.IDKH;
            searchKH.Text = kh.TENKH;
        }

        public void setKH(string idKH)
        {
            searchKH.EditValue = idKH;
        }

        public void setNV(string idNV)
        {
            searchNV.EditValue = idNV;
        }



        private void btnThemKH_Click(object sender, EventArgs e)
        {
             frmKHACHHANG frmKH = new frmKHACHHANG();
            frmKH.ShowDialog();
        }

        private void gcDV_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cboTTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvDV_DoubleClick(object sender, EventArgs e)
        {
            if(gvDV.GetFocusedRowCellValue("IDDV") != null)
            {
                OBJ_DSDV dv = new OBJ_DSDV();
                dv.IDDV = int.Parse(gvDV.GetFocusedRowCellValue("IDDV").ToString());
                dv.TENDV = gvDV.GetFocusedRowCellValue("TENDV").ToString();
                dv.IDPHONG = _idPhong;
                dv.TENPHONG = _phongHT.TENPHONG;
                dv.DONGIA = float.Parse(gvDV.GetFocusedRowCellValue("DONGIA").ToString());
                dv.SOLUONG = 1;
                dv.THANHTIEN = dv.DONGIA * dv.SOLUONG;
                foreach(var item in lstDSDV)
                {
                    if(item.IDDV == dv.IDDV && item.IDPHONG == dv.IDPHONG)
                    {
                        item.SOLUONG = item.SOLUONG + 1;
                        item.THANHTIEN = item.SOLUONG * item.DONGIA;
                        loadDSDV();
                        return;
                    }
                }
                lstDSDV.Add(dv);
            }
            loadDSDV();
            gvDSSP.Columns["THANHTIEN"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "THANHTIEN");

            DAL.DATPHONG dp = new DAL.DATPHONG();
            dp.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
            txtThanhTien.Text = (double.Parse(gvDSSP.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + (dp.SONGAYO * _phongHT.GIATIEN)).ToString();
        }

        void loadDSDV()
        {
            List<OBJ_DSDV> lsDV = new List<OBJ_DSDV>();
            foreach(var item in lstDSDV)
            {
                lsDV.Add(item);
            }
            gcDSDV.DataSource = lsDV;
        }

        private void gvDSSP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName == "SOLUONG")
            {
                int sl = int.Parse(e.Value.ToString());
                if(sl != 0)
                {
                    double gia = double.Parse(gvDSSP.GetRowCellValue(gvDSSP.FocusedRowHandle, "DONGIA").ToString());
                    gvDSSP.SetRowCellValue(gvDSSP.FocusedRowHandle, "THANHTIEN", sl * gia);
                }
                else
                {
                    gvDSSP.SetRowCellValue(gvDSSP.FocusedRowHandle, "THANHTIEN", 0);
                }
            }

            gvDSSP.UpdateTotalSummary();
            DAL.DATPHONG dp = new DAL.DATPHONG();
            dp.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
            gvDSSP.Columns["THANHTIEN"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "THANHTIEN");
            txtThanhTien.Text = (double.Parse(gvDSSP.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + (dp.SONGAYO * _phongHT.GIATIEN)).ToString();

        }

        private void gvDSSP_HiddenEditor(object sender, EventArgs e)
        {
            gvDSSP.UpdateCurrentRow();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frmNHANVIEN frm = new frmNHANVIEN();
            frm.ShowDialog();
        }

        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtNgayDat_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}