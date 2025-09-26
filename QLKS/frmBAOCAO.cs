using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class frmBAOCAO : DevExpress.XtraEditors.XtraForm
    {
        public frmBAOCAO()
        {
            InitializeComponent();
        }

        DATPHONG dphong;
        List<DoanhThuDTO> lstDT;

        private void frmBAOCAO_Load(object sender, EventArgs e)
        {
            dphong = new DATPHONG();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtTuNgay.Value.Date;
            DateTime denNgay = dtDenNgay.Value.Date;
            var lst = dphong.getDTTheoNgay(tuNgay, denNgay);

            rptBaoCao rpt = new rptBaoCao(lstDT);
            rpt.DataSource = lst;

            rpt.ShowPreview();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}