using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmLOGIN : DevExpress.XtraEditors.XtraForm
    {
        public frmLOGIN()
        {
            InitializeComponent();
            InitCustomUI();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 350);
            this.Text = "Đăng nhập";
            this.BackColor = Color.White;

            UserLookAndFeel.Default.SetSkinStyle("WXI"); // hoặc "Office 2019 Colorful"

        }
        private SimpleButton btnLogin;

        private TextEdit txtUser;
        private TextEdit txtPass;



        private void frmLOGIN_Load(object sender, EventArgs e)
        {

        }


        private void InitCustomUI()
        {
            LabelControl lblTitle = new LabelControl()
            {
                Text = "ĐĂNG NHẬP HỆ THỐNG",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                Location = new Point(80, 20),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(250, 30),
                Appearance = { TextOptions = { HAlignment = HorzAlignment.Center } }
            };
            this.Controls.Add(lblTitle);

            // Label - Tên đăng nhập
            LabelControl lblUser = new LabelControl()
            {
                Text = "Tên đăng nhập",
                Font = new Font("Segoe UI", 10),
                Location = new Point(50, 70)
            };
            this.Controls.Add(lblUser);

            // TextEdit - Username
            txtUser = new TextEdit()
            {
                Name = "txtUser",
                Location = new Point(50, 95),
                Size = new Size(280, 28),
                Font = new Font("Segoe UI", 10),
            };
            this.Controls.Add(txtUser);

            // Label - Mật khẩu
            LabelControl lblPass = new LabelControl()
            {
                Text = "Mật khẩu",
                Font = new Font("Segoe UI", 10),
                Location = new Point(50, 135)
            };
            this.Controls.Add(lblPass);

            // TextEdit - Password
            txtPass = new TextEdit()
            {
                Name = "txtPass",
                Location = new Point(50, 160),
                Size = new Size(280, 28),
                Font = new Font("Segoe UI", 10),

            };
            this.Controls.Add(txtPass);
            txtPass.Properties.UseSystemPasswordChar = true;


            // Button Đăng nhập
            btnLogin = new SimpleButton()
            {
                Text = "ĐĂNG NHẬP",
                Location = new Point(50, 240),
                Size = new Size(120, 35),
                Appearance = {
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            },
                LookAndFeel = { UseDefaultLookAndFeel = false }
            };
            this.Controls.Add(btnLogin);

            // Button Thoát
            SimpleButton btnExit = new SimpleButton()
            {
                Text = "THOÁT",
                Location = new Point(210, 240),
                Size = new Size(120, 35),
                Appearance = {
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            },
                LookAndFeel = { UseDefaultLookAndFeel = false }
            };
            this.Controls.Add(btnExit);

            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;

            txtUser.Properties.Appearance.BackColor = Color.White;
            txtUser.Properties.Appearance.ForeColor = Color.Black;
            txtUser.Properties.AppearanceFocused.BackColor = Color.White;
            txtUser.Properties.AppearanceFocused.BorderColor = Color.FromArgb(33, 150, 243); // xanh dương
            txtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtUser.Properties.UseSystemPasswordChar = false;

            txtPass.Properties.Appearance.BackColor = Color.White;
            txtPass.Properties.Appearance.ForeColor = Color.Black;
            txtPass.Properties.AppearanceFocused.BackColor = Color.White;
            txtPass.Properties.AppearanceFocused.BorderColor = Color.FromArgb(33, 150, 243); // xanh dương
            txtPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // =====================================================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string conectionString = "Data Source=QUANVU\\QUANZU;Initial Catalog=HOTELS;Integrated Security=True"; // Đổi tên CSDL phù hợp
            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM USER_LOGIN WHERE IDLG = @id AND PSW = @psw";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtUser.Text);
                    cmd.Parameters.AddWithValue("@psw", int.Parse(txtPass.Text)); // Nếu PSW là int thì cần ép kiểu

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();
                        frmMain mainForm = new frmMain(); // Giao diện chính
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai ID hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi chưa nhập thông tin đăng nhập");
                }
            }
        }

    }
}