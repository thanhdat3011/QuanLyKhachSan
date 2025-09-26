using BUS;
using DAL;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        BUS.TANG _tang;
        BUS.FUNC _func;
        BUS.PHONG _phong;
        GalleryItem item = null;


        private void frmMain_Load(object sender, EventArgs e)
        {
            _tang = new BUS.TANG();
            _func = new BUS.FUNC();
            _phong = new BUS.PHONG();
            leftMenu();
            showRoom();

            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            UserLookAndFeel.Default.SkinName = "The Bezier";



        }

        public void showRoom()
        {
            _tang = new BUS.TANG();
            _phong = new BUS.PHONG();
            var _lsTang = _tang.getAll();
            gControl.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64, 64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;


            foreach ( var t in _lsTang )
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = t.TENTANG;
                galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;


                var _lsPhong = _phong.getByTang(t.IDTANG);
                foreach(var p in _lsPhong)
                {
                    var gc_item = new GalleryItem();
                    gc_item.Caption = p.TENPHONG;
                    gc_item.Value = p.IDPHONG;
                    if(p.TINHTRANG == true)
                    {
                        gc_item.ImageOptions.Image = imageList3.Images[1];
                    }
                    else
                    {
                        gc_item.ImageOptions.Image = imageList3.Images[0];
                    }
                        galleryItem.Items.Add(gc_item);
                }
                gControl.Gallery.Groups.Add(galleryItem);
            }
        }

        void leftMenu()
        {
            var _lsParent = _func.getParent();

            foreach (var _pr in _lsParent)
            {
                NavBarGroup navGroup = new NavBarGroup(_pr.TENDM);
                navGroup.Tag = _pr.FUNC_CODE;
                navGroup.Name = _pr.FUNC_CODE;
                navGroup.ImageOptions.LargeImageIndex = 0;
                navBarControl1.LinkInterval = 5;
                navBarControl1.Appearance.ItemHotTracked.BackColor = Color.FromArgb(230, 230, 230); // xám nhẹ
                navBarControl1.Appearance.ItemHotTracked.ForeColor = Color.Black; // giữ chữ đen
                navBarControl1.Appearance.ItemHotTracked.Options.UseBackColor = true;
                navBarControl1.Appearance.ItemHotTracked.Options.UseForeColor = true;


                navGroup.Appearance.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Cỡ 11, in đậm
                navGroup.Appearance.ForeColor = Color.Black;
                navGroup.Appearance.Options.UseForeColor = true;
                navGroup.Appearance.Options.UseFont = true;

                navBarControl1.Groups.Add(navGroup);

                var _lsChild = _func.getChild(_pr.FUNC_CODE); // hàm item
                for (int i = 0; i < _lsChild.Count; i++)
                {
                    var _ch = _lsChild[i];
                    NavBarItem navItem = new NavBarItem(_ch.TENDM);
                    navItem.Tag = _ch.FUNC_CODE;
                    navItem.Name = _ch.FUNC_CODE;
                    navItem.ImageOptions.SmallImageIndex = i;
                    navGroup.ItemLinks.Add(navItem);
                    navItem.Appearance.Font = new Font("Segoe UI", 11, FontStyle.Bold); // Cỡ 11, in đậm
                    navItem.Appearance.ForeColor = Color.Black; // Tùy chọn: đổi màu chữ
                    navItem.Appearance.Options.UseFont = true;

                    

                    navItem.AppearancePressed.Font = new Font("Segoe UI", 11, FontStyle.Bold); // Cỡ 11, in đậm
                    navItem.AppearancePressed.ForeColor = Color.Gray;
                    navItem.AppearanceHotTracked.Font = new Font("Segoe UI", 11, FontStyle.Bold); // Cỡ 11, in đậm
                }
                navBarControl1.Groups[navGroup.Name].Expanded = true;
            }
        }

      
        private void toolStripBtnHT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripBtnBC_Click(object sender, EventArgs e)
        {
            frmBAOCAO frmBC = new frmBAOCAO();
            frmBC.ShowDialog();
        }

        private void toolStripBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            Point point = gControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = gControl.CalcHitInfo(point);
            if(hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
            {
                item = hitInfo.GalleryItem;
            }
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng đã được đặt, vui lòng chọn phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmDatPhongDon frmDP = new frmDatPhongDon();
            frmDP._idPhong = int.Parse(item.Value.ToString());
            frmDP._them = true;
            frmDP.ShowDialog();         
        }

        private void btnDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt nên không thể cập nhật dịch vụ, vui lòng chọn phòng đã được đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmDatPhongDon frmDP = new frmDatPhongDon();
            frmDP._idPhong = int.Parse(item.Value.ToString());
            frmDP._them = false;
            frmDP.ShowDialog();
        }

        private void btnChuyenPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (! _phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt nên không thể chuyển phòng, vui lòng chọn phòng đã được đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmCHUYENPHONG frm = new frmCHUYENPHONG();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm.ShowDialog();
        }

        private void btnTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt nên không thể thanh toán, vui lòng chọn phòng đã được đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon frmDP = new frmDatPhongDon();
            frmDP._idPhong = int.Parse(item.Value.ToString());
            frmDP._them = false;
            frmDP.ShowDialog();
        }

        private void galleryControlClient1_Click(object sender, EventArgs e)
        {

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarControl1_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Name.ToString();

            switch (func_code)
            {
                case "LOAIPHONG":
                    {
                        frmLOAIPHONG frm = new frmLOAIPHONG();
                        frm.ShowDialog();
                        break;
                    }
                case "TANG":
                    {
                        frmTANG frm = new frmTANG();
                        frm.ShowDialog();
                        break;
                    }
                case "PHONG":
                    {
                        frmPHONG frm = new frmPHONG();
                        frm.ShowDialog();
                        break;
                    }
                case "KHACHHANG":
                    {
                        frmKHACHHANG frm = new frmKHACHHANG();
                        frm.ShowDialog();
                        break;
                    }
                case "NHANVIEN":
                    {
                        frmNHANVIEN frm = new frmNHANVIEN();
                        frm.ShowDialog();
                        break;
                    }
                case "DATPHONG":
                    {
                        frmDSDATPHONG frm = new frmDSDATPHONG();
                        frm.ShowDialog();
                        break;
                    }
                case "DICHVU":
                    {
                        frmDV frm = new frmDV();
                        frm.ShowDialog();
                        break;
                    }
            }
        }
    }
}
