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
    public partial class frmDSDATPHONG : DevExpress.XtraEditors.XtraForm
    {
        public frmDSDATPHONG()
        {
            InitializeComponent();
        }

        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        DATPHONG _datphong;
        CTDP _dpct;
        KHACHHANG _kh;
        NHANVIEN _nv;

        private void frmDSDATPHONG_Load(object sender, EventArgs e)
        {
            _kh = new KHACHHANG();
            _nv = new NHANVIEN();
            _dpct = new CTDP();
            _datphong = new DATPHONG();
            loadDP();
            loadCTDP();
            gvDPCT.ExpandAllGroups();


        }

        void loadDP()
        { 
            gcDSDP.DataSource = _datphong.getAll();
            gvDSDP.OptionsBehavior.Editable = false;
        }

        void loadCTDP()
        {
            gcDPCT.DataSource = _dpct.getAllDPCT();
            gvDPCT.OptionsBehavior.Editable = false;
        }
        private void gcDSDP_Click(object sender, EventArgs e)
        {

        }

        private void gcDPCT_Click(object sender, EventArgs e)
        {

        }
    }
}