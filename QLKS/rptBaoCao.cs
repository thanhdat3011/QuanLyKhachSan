using BUS;
using DevExpress.Office.Utils;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLKS
{
    public partial class rptBaoCao : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBaoCao(DoanhThuDTO baocao)
        {
            InitializeComponent();
        }

        int tong = 0;
        List<DoanhThuDTO> _lstDT;
        public rptBaoCao(List<DoanhThuDTO> lstDT)
        {
            InitializeComponent();
            this._lstDT = lstDT;
            this.DataSource = lstDT;
            loadData();
            
        }

        void loadData()
        {
            lblTenPh.DataBindings.Add("Text", _lstDT, "TENPHONG");
            lblSNO.DataBindings.Add("Text", _lstDT, "SONGAYO");
            lblSOTIEN.DataBindings.Add("Text", _lstDT, "DOANHTHU");
            lblSOTIEN.TextFormatString = "{0:n0}";
            lbltuNgay.DataBindings.Add("Text", _lstDT, "TUNGAY");
            lbldenNgay.DataBindings.Add("Text", _lstDT, "DENNGAY");



            lblDateTime.Text = $"Ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} Năm {DateTime.Now.Year}";

        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {

        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            var value = GetCurrentColumnValue<int>("DOANHTHU");
            tong += value;
        }

        private void ReportFooter_BeforePrint(object sender, CancelEventArgs e)
        {
            lblTT.Text = tong.ToString("N0");
        }
    }
}
