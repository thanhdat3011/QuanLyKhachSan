namespace QLKS
{
    partial class frmDSDATPHONG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSDATPHONG));
            this.tabCctdp = new System.Windows.Forms.TabControl();
            this.tPdsdp = new System.Windows.Forms.TabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcDSDP = new DevExpress.XtraGrid.GridControl();
            this.gvDSDP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDDATPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYDAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYTRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRANGTHAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.GHICHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONGUOIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONGAYO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tPctdp = new System.Windows.Forms.TabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcDPCT = new DevExpress.XtraGrid.GridControl();
            this.gvDPCT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDCTDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDDP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dv_IDDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THANHTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabCctdp.SuspendLayout();
            this.tPdsdp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.tPctdp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDPCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDPCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCctdp
            // 
            this.tabCctdp.Controls.Add(this.tPdsdp);
            this.tabCctdp.Controls.Add(this.tPctdp);
            this.tabCctdp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCctdp.Location = new System.Drawing.Point(0, 0);
            this.tabCctdp.Name = "tabCctdp";
            this.tabCctdp.SelectedIndex = 0;
            this.tabCctdp.Size = new System.Drawing.Size(1228, 597);
            this.tabCctdp.TabIndex = 3;
            this.tabCctdp.Tag = "DANH SÁCH ĐẶT PHÒNG";
            // 
            // tPdsdp
            // 
            this.tPdsdp.Controls.Add(this.groupControl1);
            this.tPdsdp.Location = new System.Drawing.Point(4, 22);
            this.tPdsdp.Name = "tPdsdp";
            this.tPdsdp.Padding = new System.Windows.Forms.Padding(3);
            this.tPdsdp.Size = new System.Drawing.Size(1220, 571);
            this.tPdsdp.TabIndex = 0;
            this.tPdsdp.Text = "DANH SÁCH ĐẶT PHÒNG";
            this.tPdsdp.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.gcDSDP);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1214, 565);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "DANH SÁCH ĐẶT PHÒNG";
            // 
            // gcDSDP
            // 
            this.gcDSDP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDSDP.Location = new System.Drawing.Point(2, 23);
            this.gcDSDP.MainView = this.gvDSDP;
            this.gcDSDP.Name = "gcDSDP";
            this.gcDSDP.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemSearchLookUpEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.gcDSDP.Size = new System.Drawing.Size(1210, 540);
            this.gcDSDP.TabIndex = 1;
            this.gcDSDP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDSDP});
            this.gcDSDP.Click += new System.EventHandler(this.gcDSDP_Click);
            // 
            // gvDSDP
            // 
            this.gvDSDP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDDATPHONG,
            this.NGAYDAT,
            this.NGAYTRA,
            this.TRANGTHAI,
            this.GHICHU,
            this.SONGUOIO,
            this.IDKH,
            this.TENKH,
            this.IDNV,
            this.TENNV,
            this.IDPHONG,
            this.SONGAYO,
            this.TENPHONG,
            this.SOTIEN});
            this.gvDSDP.GridControl = this.gcDSDP;
            this.gvDSDP.Name = "gvDSDP";
            // 
            // IDDATPHONG
            // 
            this.IDDATPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDDATPHONG.AppearanceHeader.Options.UseFont = true;
            this.IDDATPHONG.Caption = "ID Đặt phòng";
            this.IDDATPHONG.FieldName = "IDDATPHONG";
            this.IDDATPHONG.Name = "IDDATPHONG";
            this.IDDATPHONG.Visible = true;
            this.IDDATPHONG.VisibleIndex = 0;
            this.IDDATPHONG.Width = 72;
            // 
            // NGAYDAT
            // 
            this.NGAYDAT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.NGAYDAT.AppearanceHeader.Options.UseFont = true;
            this.NGAYDAT.Caption = "Ngày Đặt";
            this.NGAYDAT.FieldName = "NGAYDAT";
            this.NGAYDAT.Name = "NGAYDAT";
            this.NGAYDAT.Visible = true;
            this.NGAYDAT.VisibleIndex = 1;
            this.NGAYDAT.Width = 69;
            // 
            // NGAYTRA
            // 
            this.NGAYTRA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.NGAYTRA.AppearanceHeader.Options.UseFont = true;
            this.NGAYTRA.Caption = "Ngày Trả";
            this.NGAYTRA.FieldName = "NGAYTRA";
            this.NGAYTRA.Name = "NGAYTRA";
            this.NGAYTRA.Visible = true;
            this.NGAYTRA.VisibleIndex = 2;
            this.NGAYTRA.Width = 69;
            // 
            // TRANGTHAI
            // 
            this.TRANGTHAI.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TRANGTHAI.AppearanceCell.Options.UseFont = true;
            this.TRANGTHAI.Caption = "TRẠNG THÁI";
            this.TRANGTHAI.ColumnEdit = this.repositoryItemCheckEdit1;
            this.TRANGTHAI.FieldName = "TRANGTHAI";
            this.TRANGTHAI.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.TRANGTHAI.Name = "TRANGTHAI";
            this.TRANGTHAI.Visible = true;
            this.TRANGTHAI.VisibleIndex = 3;
            this.TRANGTHAI.Width = 83;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // GHICHU
            // 
            this.GHICHU.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GHICHU.AppearanceHeader.Options.UseFont = true;
            this.GHICHU.Caption = "Ghi Chú";
            this.GHICHU.FieldName = "GHICHU";
            this.GHICHU.Name = "GHICHU";
            this.GHICHU.Visible = true;
            this.GHICHU.VisibleIndex = 4;
            this.GHICHU.Width = 141;
            // 
            // SONGUOIO
            // 
            this.SONGUOIO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.SONGUOIO.AppearanceHeader.Options.UseFont = true;
            this.SONGUOIO.Caption = "Số người ở";
            this.SONGUOIO.FieldName = "SONGUOIO";
            this.SONGUOIO.Name = "SONGUOIO";
            this.SONGUOIO.Visible = true;
            this.SONGUOIO.VisibleIndex = 5;
            this.SONGUOIO.Width = 76;
            // 
            // IDKH
            // 
            this.IDKH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IDKH.AppearanceHeader.Options.UseFont = true;
            this.IDKH.Caption = "ID KH";
            this.IDKH.FieldName = "IDKH";
            this.IDKH.Name = "IDKH";
            // 
            // TENKH
            // 
            this.TENKH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENKH.AppearanceHeader.Options.UseFont = true;
            this.TENKH.Caption = "Họ Tên KH";
            this.TENKH.FieldName = "TENKH";
            this.TENKH.Name = "TENKH";
            this.TENKH.Visible = true;
            this.TENKH.VisibleIndex = 6;
            this.TENKH.Width = 145;
            // 
            // IDNV
            // 
            this.IDNV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IDNV.AppearanceHeader.Options.UseFont = true;
            this.IDNV.Caption = "ID Nhân Viên";
            this.IDNV.FieldName = "IDNV";
            this.IDNV.Name = "IDNV";
            // 
            // TENNV
            // 
            this.TENNV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENNV.AppearanceHeader.Options.UseFont = true;
            this.TENNV.Caption = "Tên NV";
            this.TENNV.FieldName = "TENNV";
            this.TENNV.Name = "TENNV";
            this.TENNV.Visible = true;
            this.TENNV.VisibleIndex = 7;
            this.TENNV.Width = 128;
            // 
            // IDPHONG
            // 
            this.IDPHONG.Caption = "ID Phòng";
            this.IDPHONG.FieldName = "IDPHONG";
            this.IDPHONG.Name = "IDPHONG";
            // 
            // SONGAYO
            // 
            this.SONGAYO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.SONGAYO.AppearanceHeader.Options.UseFont = true;
            this.SONGAYO.Caption = "Số ngày ở";
            this.SONGAYO.FieldName = "SONGAYO";
            this.SONGAYO.Name = "SONGAYO";
            this.SONGAYO.Visible = true;
            this.SONGAYO.VisibleIndex = 8;
            this.SONGAYO.Width = 67;
            // 
            // TENPHONG
            // 
            this.TENPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENPHONG.AppearanceHeader.Options.UseFont = true;
            this.TENPHONG.Caption = "Tên Phòng";
            this.TENPHONG.FieldName = "TENPHONG";
            this.TENPHONG.Name = "TENPHONG";
            this.TENPHONG.Visible = true;
            this.TENPHONG.VisibleIndex = 9;
            this.TENPHONG.Width = 102;
            // 
            // SOTIEN
            // 
            this.SOTIEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.SOTIEN.AppearanceHeader.Options.UseFont = true;
            this.SOTIEN.Caption = "Số tiền";
            this.SOTIEN.FieldName = "SOTIEN";
            this.SOTIEN.Name = "SOTIEN";
            this.SOTIEN.Visible = true;
            this.SOTIEN.VisibleIndex = 10;
            this.SOTIEN.Width = 91;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.PopupView = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // tPctdp
            // 
            this.tPctdp.Controls.Add(this.groupControl2);
            this.tPctdp.Location = new System.Drawing.Point(4, 22);
            this.tPctdp.Name = "tPctdp";
            this.tPctdp.Padding = new System.Windows.Forms.Padding(3);
            this.tPctdp.Size = new System.Drawing.Size(1220, 571);
            this.tPctdp.TabIndex = 1;
            this.tPctdp.Text = "CHI TIẾT ĐẶT PHÒNG DỊCH VỤ";
            this.tPctdp.UseVisualStyleBackColor = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcDPCT);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1214, 565);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "CHI TIẾT ĐẶT PHÒNG DỊCH VỤ";
            // 
            // gcDPCT
            // 
            this.gcDPCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDPCT.Location = new System.Drawing.Point(2, 23);
            this.gcDPCT.MainView = this.gvDPCT;
            this.gcDPCT.Name = "gcDPCT";
            this.gcDPCT.Size = new System.Drawing.Size(1210, 540);
            this.gcDPCT.TabIndex = 0;
            this.gcDPCT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDPCT});
            this.gcDPCT.Click += new System.EventHandler(this.gcDPCT_Click);
            // 
            // gvDPCT
            // 
            this.gvDPCT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDCTDV,
            this.IDDP,
            this.IDP,
            this.TPHONG,
            this.dv_IDDV,
            this.TENDV,
            this.NGAY,
            this.SOLUONG,
            this.DONGIA,
            this.THANHTIEN});
            this.gvDPCT.GridControl = this.gcDPCT;
            this.gvDPCT.GroupCount = 1;
            this.gvDPCT.Name = "gvDPCT";
            this.gvDPCT.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.IDDP, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // IDCTDV
            // 
            this.IDCTDV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IDCTDV.AppearanceHeader.Options.UseFont = true;
            this.IDCTDV.Caption = "ID Chi tiết dịch vụ";
            this.IDCTDV.FieldName = "IDCTDV";
            this.IDCTDV.Name = "IDCTDV";
            this.IDCTDV.Visible = true;
            this.IDCTDV.VisibleIndex = 0;
            // 
            // IDDP
            // 
            this.IDDP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IDDP.AppearanceHeader.Options.UseFont = true;
            this.IDDP.Caption = "ID Đặt Phòng";
            this.IDDP.FieldName = "IDDATPHONG";
            this.IDDP.Name = "IDDP";
            this.IDDP.Visible = true;
            this.IDDP.VisibleIndex = 1;
            // 
            // IDP
            // 
            this.IDP.Caption = "idphong";
            this.IDP.FieldName = "IDPHONG";
            this.IDP.Name = "IDP";
            // 
            // TPHONG
            // 
            this.TPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TPHONG.AppearanceHeader.Options.UseFont = true;
            this.TPHONG.Caption = "Tên Phòng";
            this.TPHONG.FieldName = "TENPHONG";
            this.TPHONG.Name = "TPHONG";
            this.TPHONG.Visible = true;
            this.TPHONG.VisibleIndex = 1;
            // 
            // dv_IDDV
            // 
            this.dv_IDDV.Caption = "ID DV";
            this.dv_IDDV.FieldName = "IDDV";
            this.dv_IDDV.Name = "dv_IDDV";
            // 
            // TENDV
            // 
            this.TENDV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENDV.AppearanceHeader.Options.UseFont = true;
            this.TENDV.Caption = "Tên DV";
            this.TENDV.FieldName = "TENDV";
            this.TENDV.Name = "TENDV";
            this.TENDV.Visible = true;
            this.TENDV.VisibleIndex = 2;
            // 
            // NGAY
            // 
            this.NGAY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.NGAY.AppearanceHeader.Options.UseFont = true;
            this.NGAY.Caption = "Ngày ";
            this.NGAY.FieldName = "NGAY";
            this.NGAY.Name = "NGAY";
            this.NGAY.Visible = true;
            this.NGAY.VisibleIndex = 3;
            // 
            // SOLUONG
            // 
            this.SOLUONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.SOLUONG.AppearanceHeader.Options.UseFont = true;
            this.SOLUONG.Caption = "Số lượng";
            this.SOLUONG.FieldName = "SOLUONG";
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.Visible = true;
            this.SOLUONG.VisibleIndex = 4;
            // 
            // DONGIA
            // 
            this.DONGIA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.DONGIA.AppearanceHeader.Options.UseFont = true;
            this.DONGIA.Caption = "Đơn giá";
            this.DONGIA.FieldName = "DONGIA";
            this.DONGIA.Name = "DONGIA";
            this.DONGIA.Visible = true;
            this.DONGIA.VisibleIndex = 5;
            // 
            // THANHTIEN
            // 
            this.THANHTIEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.THANHTIEN.AppearanceHeader.Options.UseFont = true;
            this.THANHTIEN.Caption = "Thành tiền";
            this.THANHTIEN.FieldName = "THANHTIEN";
            this.THANHTIEN.Name = "THANHTIEN";
            this.THANHTIEN.Visible = true;
            this.THANHTIEN.VisibleIndex = 6;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // frmDSDATPHONG
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 597);
            this.Controls.Add(this.tabCctdp);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmDSDATPHONG.IconOptions.Image")));
            this.Name = "frmDSDATPHONG";
            this.Text = "DANH SÁCH ĐẶT PHÒNG";
            this.Load += new System.EventHandler(this.frmDSDATPHONG_Load);
            this.tabCctdp.ResumeLayout(false);
            this.tPdsdp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.tPctdp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDPCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDPCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCctdp;
        private System.Windows.Forms.TabPage tPdsdp;
        private System.Windows.Forms.TabPage tPctdp;
        private DevExpress.XtraGrid.GridControl gcDSDP;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDSDP;
        private DevExpress.XtraGrid.Columns.GridColumn IDDATPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYDAT;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYTRA;
        private DevExpress.XtraGrid.Columns.GridColumn GHICHU;
        private DevExpress.XtraGrid.Columns.GridColumn SONGUOIO;
        private DevExpress.XtraGrid.Columns.GridColumn IDKH;
        private DevExpress.XtraGrid.Columns.GridColumn TENKH;
        private DevExpress.XtraGrid.Columns.GridColumn IDNV;
        private DevExpress.XtraGrid.Columns.GridColumn TENNV;
        private DevExpress.XtraGrid.Columns.GridColumn IDPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn TENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn SOTIEN;
        private DevExpress.XtraGrid.GridControl gcDPCT;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDPCT;
        private DevExpress.XtraGrid.Columns.GridColumn SONGAYO;
        private DevExpress.XtraGrid.Columns.GridColumn IDCTDV;
        private DevExpress.XtraGrid.Columns.GridColumn IDDP;
        private DevExpress.XtraGrid.Columns.GridColumn IDP;
        private DevExpress.XtraGrid.Columns.GridColumn TPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn dv_IDDV;
        private DevExpress.XtraGrid.Columns.GridColumn TENDV;
        private DevExpress.XtraGrid.Columns.GridColumn NGAY;
        private DevExpress.XtraGrid.Columns.GridColumn SOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn DONGIA;
        private DevExpress.XtraGrid.Columns.GridColumn THANHTIEN;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TRANGTHAI;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}