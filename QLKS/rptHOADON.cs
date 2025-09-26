using BUS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace QLKS
{
    public partial class rptHOADON : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHOADON(DATPHONG_DTO hoadon)
        {
            InitializeComponent();

        }

        List<DATPHONG_DTO> _lstDP;


        public rptHOADON(List<DATPHONG_DTO> lstDP)
        {
            InitializeComponent();
            this._lstDP = lstDP;
            this.DataSource = lstDP;
            loadData();
        }

        void loadData()
        {
            lblKH.DataBindings.Add("Text", _lstDP, "TENKH");
            lblSDT.DataBindings.Add("Text", _lstDP, "SDT");
            lblNV.DataBindings.Add("Text", _lstDP, "TENNV");
            lblTDV.DataBindings.Add("Text", _lstDP, "TENDV");
            lblSL.DataBindings.Add("Text", _lstDP, "SOLUONG");
            lblTT.DataBindings.Add("Text", _lstDP, "THANHTIEN");
            lblTT.TextFormatString = "{0:n0}";
            lblDG.TextFormatString = "{0:n0}";
            lblDG.DataBindings.Add("Text", _lstDP, "DONGIA");
            lblP.DataBindings.Add("Text", _lstDP, "TENPHONG");
            lblSnguoiO.DataBindings.Add("Text", _lstDP, "SONGUOIO");
            lblSNO.DataBindings.Add("Text", _lstDP, "SONGAYO");
            lblGhiChu.DataBindings.Add("Text", _lstDP, "GHICHU");
            lblP.DataBindings.Add("Text", _lstDP, "TENPHONG");

            pTenPhong.DataBindings.Add("Text", _lstDP, "TENPHONG");
            pSNO.DataBindings.Add("Text", _lstDP, "SONGAYO");
            pDonGia.DataBindings.Add("Text", _lstDP, "GIATIEN");
            pDonGia.TextFormatString = "{0:n0}";
            pTT.ExpressionBindings.Add(new 
                ExpressionBinding("BeforePrint", "Text", "FormatString('{0:n0}', [GIATIEN] * [SONGAYO])"));
            lblTONGTIEN.DataBindings.Add("Text", _lstDP, "SOTIEN");
            lblTONGTIEN.TextFormatString = "{0:n0}";

            lblID.DataBindings.Add("Text", _lstDP, "IDDATPHONG");
            lblNL.DataBindings.Add("Text", _lstDP, "TENNV");

            lblNGAYDAT.DataBindings.Add("Text", _lstDP, "NGAYDAT");
            lblNGAYTRA.DataBindings.Add("Text", _lstDP, "NGAYTRA");

            lblDate.Text = $"Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} Năm {DateTime.Now.Year}";
        }

    }
}
