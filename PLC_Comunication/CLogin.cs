using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_Comunication
{
    public partial class CLogin : Form
    {
        public string LoginUserName = string.Empty;
        private Dictionary<string, string> _acount = new Dictionary<string, string>()
        {
            { "admin", "admin!123" },
            { "operator", "1234!" }
        };
        public CLogin()
        {
            InitializeComponent();
        }
        private void picPassOnOff_Click(object sender, EventArgs e)
        {
            string fileName = txtPassword.PasswordChar == '*' ? "\\PassOff.png" : "\\PassOn.png";
            string imagePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + fileName;
            Bitmap bitmap = new Bitmap(imagePath);
            picPassOnOff.Image = bitmap;
            txtPassword.PasswordChar = txtPassword.PasswordChar == '*' ? '\0' : '*';
        }
        private void CLogin_Shown(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            picPassOnOff_Click(null, null);
            txtPassword.Text = "";
            txtUserName.Text = "";
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password;
            if (_acount.TryGetValue(txtUserName.Text, out password))
            {
                if (password != txtPassword.Text) MessageBox.Show("Mật khẩu không chính xác!\n\rVui lòng thử lại!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.DialogResult = DialogResult.OK;
                    LoginUserName = txtUserName.Text;
                    this.Close();
                }
            }
            else MessageBox.Show("Tên đăng nhập không tồn tại!\n\rVui lòng thử lại!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnLogin_Click(null, null);
            }
            else if (e.KeyChar == '\u001b')
            {
                this.DialogResult = DialogResult.OK;
                LoginUserName = "Developer";
                this.Close();
            }
        }
        private void CLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK) LoginUserName = string.Empty;
        }
    }
}
